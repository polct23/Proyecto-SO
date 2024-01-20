#include <stdio.h>
#include <mysql.h>
#include <string.h>
#include <stdlib.h>
#include <sys/socket.h>
#include <unistd.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <fcntl.h>
#include <time.h>
#include <pthread.h>

//Variables globales del servidor
//******************************************************************************
//******************************************************************************

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int num; //cantidad de usuarios conectados
char nombres[512]; //lista de conectados, formato --> "nombre1/nombre2/nombre3/nombre4/..."
//la lista de conectados pero la que se enviara al cliente ya que tendra concatenada al principio la cantidad de conectados
char nombres_modi[512]; // formato --> "num/nombre1/nombre2/nombre3/nombre4/..."

int k=0; //para el vector de sockets
int sockets[100];

//Estructuras globales del servidor
//******************************************************************************

//estructuras necesarias para guardar los sockets
typedef struct{
	int numSocket;
	char nombreCliente[20];
}RelacionClienteSocket;

typedef struct{
	RelacionClienteSocket lista[512];
	int num;
}ListaSockets;

//estructura necesarias para guardar las salas
typedef struct{
	char nombreHost[20]; //nombre del creador
	char nombresClientes[512]; // --> nombre1/nombre2/nombre3/nombre4 --> hasta 4
	int numActual;
	int socketsJugadores[100];
	int ronda;
	int puntuacionMayorUltimaRonda;
	char ganadorUltimaRonda[20];
	int contadorGanador;
}TSala;

typedef struct{
	TSala salas[512];
	int num;
}TListaSala;

//Declaracion de las dos listas, de sockets y de salas
//******************************************************************************
//creamos la ListaSockets
ListaSockets listaSockets;
//creamos la TListaSala
TListaSala listaSalas;

//Funcion que genera una palabra aleatoria 
//******************************************************************************
int generarPalabraAleatoria(MYSQL *conn, char palabra[80]){
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[200];
	
	strcat (consulta, "SELECT * FROM palabras ORDER BY RAND() LIMIT 1");
	printf("consulta: %s\n", consulta);
	
	err = mysql_query(conn, consulta);
	if(err!=0){
		return -1;
		exit(1);
	}
	resultado = mysql_store_result (conn);
	
	row = mysql_fetch_row (resultado);
	char palabraAleatoria[80];
	
	
	strcpy(palabraAleatoria, row[0]);
	printf("Palabra: %s\n", palabraAleatoria);
	strcpy(palabra, palabraAleatoria);
	return 0;
}

//Funciones auxiliares
//******************************************************************************
//funcion que devuelve el socket del usuario pasado como parametro
int buscaSocketJugador(ListaSockets *lista, char nombre_jugador[20]){
	int i=0;
	int encontrado = 0;
	while((i < lista->num) && (encontrado == 0)){
		if(strcmp(lista->lista[i].nombreCliente, nombre_jugador) == 0){
			encontrado = 1;
		}else if(encontrado == 0)
		   i++;
	}
	if (encontrado == 1){
		int socket = lista->lista[i].numSocket;
		return socket;
	}else
		return -1;
}

//funcion que devuelve la posicion en la lista de salas
int posicionDeLaSala(TListaSala *lista, char nombre_jugador[20]){
	int encontrado = 0;
	int i = 0;
	char *p;
	strcpy(p, nombre_jugador);
	
	while((i<lista->num) && (encontrado == 0)){
		p = strtok(lista->salas[i].nombresClientes, "/");
		while((p != NULL) && (encontrado == 0)){
			if(strcmp(p,nombre_jugador) == 0){
				encontrado = 1;
			}else{
				p = strtok(NULL, "/");
			}
		}
		if(encontrado == 0){
			i++;
		}
	}
	if(encontrado == 1){
		return i; //posicion de la sala en la lista
	}
}

//Funciones relacionadas con las salas
//******************************************************************************
//funcion que permite crear una sala
int crearSala(TListaSala *lista, char nombre_origen[20], int idSocket){
	int encontrado = 0;
	int i = 0;
	char *p;
	//comprobamos que el usuario no este en otra sala
	while((i<lista->num) && (encontrado == 0)){
		p = strtok(lista->salas[i].nombresClientes, "/");
		while((p != NULL) && (encontrado == 0)){
			if(strcmp(p,nombre_origen) == 0){
				encontrado = 1;
			}else{
				p = strtok(NULL, "/");
			}
		}
		if(encontrado == 0){
			i++;
		}
	}
	//dos ocpiones o que no esta en ninguna sala (encontrado = 0), o que si esta en alguna sala (encontrado = 1)
	if(encontrado == 0){
		//aqui crearemos la sala
		strcpy(lista->salas[lista->num].nombreHost,nombre_origen);
		sprintf(lista->salas[lista->num].nombresClientes, "%s",nombre_origen);
		lista->salas[i].socketsJugadores[0] = idSocket;
		lista->salas[lista->num].numActual = 1; //el host
		lista->num++;
		
		return lista->num - 1; //si se a creado la sala
	}else{
		return -1; //no se ha creado la sala
	}
}

//funciones que envia una invitacion al usurio invitado
//formato --> 7/nombre_destinatario/nombre_origen
int invitarUsuarioSala(TListaSala *lista, ListaSockets *lista2,char nombre_destinatario[20], char idSala[20], int idSocket){
	//en la lista estara como minimo el jugador que haya invitado al nuevo jugador, por tanto solo habra que hacer una busqueda en la lista para encontrar el idCliente origen
	//la forma mas sencilla es utilzando el id de la sala
	int encontrado = 0;
	int i = 0;
	
	//buscar num socket
	while((i<lista2->num) && (encontrado == 0)){
		if(strcmp(lista2->lista[i].nombreCliente, nombre_destinatario) == 0){
			encontrado = 1;
		}else{
			i++;
		}
	}
	if (encontrado == 1){
		int socketID = lista2->lista[i].numSocket;
		if(socketID == idSocket)
			return -2; //no se puede auto-invitar
		return socketID;
	}else{
		//el usuario no esta conectado
		return -1;
	}
}

//funciones que agrega al usuario invitado a la sala
int agregarUsuarioSala(TListaSala *lista,ListaSockets *lista2, char nombre_jugador[20], int socketAnfitrion, int socketInvitado){
	int i=0;
	int encontrado = 0;
	//buscamos la sala para a￱adirle
	while((i < lista2->num) && (encontrado == 0)){
		if(lista2->lista[i].numSocket == socketAnfitrion){
			encontrado = 1;
		}else if(encontrado == 0)
		   i++;
	}
	int j = 0;
	encontrado = 0;
	while((j<lista->num) && (encontrado == 0)){
		if(strcmp(lista->salas[j].nombreHost, lista2->lista[i].nombreCliente) == 0){
			encontrado = 1;
		}else if(encontrado == 0)
		   j++;
	}
	if(encontrado == 1){
		sprintf(lista->salas[j].nombresClientes, "%s/%s", lista->salas[j].nombresClientes, nombre_jugador);
		//sprintf(lista->salas[j].socketsId, "%s/%d", lista->salas[j].socketsId, socketInvitado);
		lista->salas[j].socketsJugadores[lista->salas[j].numActual] = socketInvitado;
		lista->salas[j].numActual = lista->salas[j].numActual + 1;
		lista->num = lista->num + 1;
		return 0;
	}else
	   return -1;
}

//funciones que elimina al usuario de la sala en la que este
int abandonarSala(TListaSala *lista, char nombre_jugador[20]){
	int i=0;
	int encontrado = 0;
	char *p;
	
	while((i<lista->num) && (encontrado == 0)){
		p = strtok(lista->salas[i].nombresClientes, "/");
		while((p != NULL) && (encontrado == 0)){
			if(strcmp(p,nombre_jugador) == 0){
				encontrado = 1;
			}else{
				p = strtok(NULL, "/");
			}
		}
		if(encontrado == 0){
			i++;
		}
	}
	
	if(encontrado == 1){
		char lista_nombres[512];
		int j = 0;
		p = strtok(lista->salas[i].nombresClientes, "/");
		while(p != NULL){
			if(strcmp(p,nombre_jugador) != 0){
				sprintf(lista_nombres, "%s/", p);
			}
			p = strtok(NULL, "/");
		}
		lista->salas[i].numActual = lista->salas[i].numActual - 1;
		
		return 0;
	}else{
		return -1;
	}
}


//Output logic routine 
//******************************************************************************
int login(char nombre[60], char password[60], MYSQL *conn) {
	//SELECT id_jugador FROM datos_personales WHERE nombre = name;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[200];
		
	strcpy(consulta, "\0");
	
	strcat (consulta, "SELECT * FROM jugadores WHERE nombre ='");
	strcat (consulta, nombre);
	strcat (consulta, "'");
	printf("consulta: %s\n", consulta);
	
	err = mysql_query(conn, consulta);
	if(err!=0){
		return -1;
		exit(1);
	}
	resultado = mysql_store_result (conn);
	
	row = mysql_fetch_row (resultado);
	if(row == NULL)
		return -2; //no existe el usuario al que se intenta iniciar sesion
	else{
		int respuesta;
		//en caso de que haya mas de un usuario con el mismo nombre, entonces comparamos cada uno sus nombres con la contrasena enviada
		while (row!=NULL){
			//en este caso el id sera row[0], el nombre sera row[1], y la contrasena sera row[2]
			if(strcmp(row[2], password) == 0){
				respuesta =0; //el usuario existe y la contrasena coincide
			}else{
				respuesta =  -1; //contrasena incorrecta
			}
			row = mysql_fetch_row (resultado);
		}
		return respuesta; //retornamos la respuesta, entre un -1 o un 0
	}
}

int registro(char nombre[60], char password[60], MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	char consulta[512];
	char nRow[20];
	time_t seconds;
	seconds = time(NULL); // Seconds since January 1, 1970
	
	//pasamos 'seconds' a un string para insertarlo a la base de datos
	char time[50];
	// si existe usuario
	int encontrado = 0;
	sprintf(time, "%d", (int)seconds);
	printf("Hora de logeo %s\n", time);
	
	memset(consulta,'\0',500);
	//consultamos si ya existe el usuario
	char comillas[4];
	strcpy(comillas, "");
	sprintf (consulta, "SELECT * FROM jugadores WHERE nombre ='%s';%s", nombre, comillas);
	printf("consulta: %s\n", consulta);
	
	//aqui error
	err = mysql_query(conn, consulta);
	if(err!=0){	
		return -1;
		exit(1);
	}
	else
	{			
		resultado = mysql_store_result(conn);
		
		row = mysql_fetch_row(resultado);
		if(row == NULL)
		{
			//INSERT INTO datos_personales(nombre, contrase￯﾿ﾯ￯ﾾ﾿￯ﾾﾱa) VALUES ('name', 'password');
			strcpy (consulta,"INSERT INTO jugadores (nombre, password ,partidas_jugadas,partidas_ganadas,fecha_perfil) VALUES ('");
			strcat (consulta, nombre);
			strcat (consulta, "','");
			strcat (consulta, password);
			strcat (consulta, "',");
			strcat (consulta,"0,0,");
			//sprintf (consulta,",%s,%d",consulta,(int)seconds);
			strcat ( consulta, time);
			strcat (consulta,");");
			printf("%s\n", consulta);
			err = mysql_query(conn, consulta);
			if(err!=0){
				return -1;
				exit(1);
			}else
			   return 0;
			//retorna (-1) si ha habido un problema y (0) si la consulta ha salido bien
		}else{
			return -2;
		}
	}
}	

void *AtenderCliente (void *socket){
	char buff[2048];
	strcpy(buff, "");
	char respuesta[16392];
	strcpy(respuesta, "");
	char respuesta2[1024];
	strcpy(respuesta2, "");
	
	char buff_auxiliar[2048];
	
	MYSQL *conn;
	//conexion a la base de datos 
	//aqui se esta creando una conexion al servidor, es decir que si el servidor existe este nos dara un conector "conn" para luego inicializar la conexion.
	conn = mysql_init(NULL);
	
	if(conn == NULL){
		printf("Error al crear la conexion con la base de datos:%u%s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	//mientras que aqui la estamos inicializando pasandole los parametros necesarios(usuario y contrase￯﾿ﾯ￯ﾾ﾿￯ﾾﾱa) para que se pueda conectar
	conn = mysql_real_connect (conn, "localhost", "root", "mysql", "TGDingo_gameDB", 0, NULL, 0);
	if(conn == NULL)
	{
		printf("Error al inicializar la conexion con la base de datos: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
	int sock_conn;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	int ret;
	
	
	int terminar = 0;
	while(terminar == 0){
		ret = read(sock_conn, buff, sizeof(buff));
		printf("Recibido\n");
		
		//printf("Jugadores en la sala: %s\n", listaSalas.salas[0].nombresClientes);
		//printf("SOckets en la sala: %s\n", listaSalas.salas[0].socketsId);
		
		buff[ret] ='\0';
		
		strcpy(buff_auxiliar, buff);
		
		printf("Peticion: %s\n", buff);
		
		char nombre[60];
		char *p = strtok(buff, "/");
		int codigo = atoi(p);
		
		if(codigo == 0){
			printf("Cerrando conexion con el servidor\n");
			pthread_mutex_lock( &mutex); //no interrumpas
			int i = 0;
			p = strtok(nombres, "/");
			while(p != NULL){
				if((strcmp(p, nombre) == 0) && (i==0)){
					strcpy(nombres, "");
				}else{
					if(i==0){
						sprintf(nombres, "%s/" , p);
					}else if(i != 0){
						sprintf(nombres, "%s%s/",nombres, p);
					}
				}
				p = strtok(NULL, "/");
				i=i+1;
			}
			if(num > 0)
				  num = num - 1;
			pthread_mutex_unlock(&mutex); //ya se puede interrumpir
			printf("El usuario %s ha cerrado sesion\n", nombre);
			terminar = 1;
		}
		
		else if(codigo == 1){ //el mensaje llega de la forma 1/'nombre'/'contrase￯﾿ﾱa'
			char contrasena[60];
			strcpy(nombre,"\0");
			strcpy(contrasena,"\0");
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			p = strtok(NULL, "/");
			strcpy(contrasena, p);
			
			int encontrado = 0;
			char nombres_auxiliar[512];
			strcpy(nombres_auxiliar, nombres);		
			p = strtok(nombres_auxiliar, "/");
			while ((p != NULL) && (encontrado == 0)){
				if(strcmp(p, nombre) == 0){
					encontrado = 1;
				}
				else{
					p = strtok(NULL, "/");
				}
			}
			if(encontrado == 1){
				strcpy(respuesta, "1/yaConectado");
				write(sock_conn, respuesta, strlen(respuesta));
			}
			else{
				int res;
				res = login(nombre, contrasena,conn);
				if(res == -1){
					printf("Password incorrecto\n");
					strcpy(respuesta, "1/incorrectPass");
					write(sock_conn, respuesta, strlen(respuesta));
				}
				else if(res == -2){
					printf("No existe el usuario\n");
					strcpy(respuesta, "1/noUser");
					write(sock_conn, respuesta, strlen(respuesta));
				}
				//la contrase￯﾿ﾱa y usuario son correctos, por tanto lo a￯﾿ﾱadira a la lista de conectados
				else{
					pthread_mutex_lock( &mutex); //no interrumpas
					listaSockets.lista[listaSockets.num].numSocket = sock_conn;
					sprintf(listaSockets.lista[listaSockets.num].nombreCliente, "%s", nombre);
					listaSockets.num++;
					printf("Numero de Socket del usuario %s:%d\n", nombre, listaSockets.lista[listaSockets.num -1].numSocket);
					printf("Numero de scocket actual: %d\n", sock_conn);
					num=num+1;
					sprintf(nombres, "%s%s/",nombres, nombre);
					pthread_mutex_unlock(&mutex); //ya se puede interrumpir
					printf("Password correcto\n");
					strcpy(respuesta, "1/SI");
					write(sock_conn, respuesta, strlen(respuesta));
					printf("Lista nombres: %s\n", nombres);
				}
			}
		}
		else if(codigo == 2){
			char contrasena[60];
			//strcpy(nombre,"\0");
			//strcpy(contrasena,"\0");
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			p = strtok(NULL, "/");
			strcpy(contrasena, p);
			
			int res;
			pthread_mutex_lock( &mutex );
			res = registro(nombre, contrasena, conn);
			pthread_mutex_unlock( &mutex );
			if(res == -1){
				printf("Ha ocurrido un problema con el registro\n");
				strcpy(respuesta, "2/NO");
				write(sock_conn, respuesta, strlen(respuesta));
			}else if(res == -2){
				printf("El usuario ya existe\n");
				strcpy(respuesta, "2/EXISTE");
				write(sock_conn, respuesta, strlen(respuesta));
			}
			else if(res == 0){
				printf("Te has registrado correctamente\n");
				strcpy(respuesta, "2/SI");
				write(sock_conn, respuesta, strlen(respuesta));
			}else{
				strcpy(respuesta, "2/error");
				write(sock_conn, respuesta, strlen(respuesta));
			}
		}
		else if(codigo == 6){
			int res;
			p = strtok(NULL, "/");
			//mensaje que me llegara --> 6/nombre_origen
			pthread_mutex_lock( &mutex );
			res = crearSala(&listaSalas, p, sock_conn);
			pthread_mutex_unlock( &mutex );
			if(res != -1){
				printf("Sala creada\n");
				sprintf(respuesta, "7/Creada/%d", res);
				write(sock_conn, respuesta, strlen(respuesta));
			}
			else{
			   printf("Sala NO creada\n");
			   strcpy(respuesta, "7/NoCreada");
			   write(sock_conn, respuesta, strlen(respuesta));
			}
			
		}else if (codigo==7){
			int res;
			char nombre_destino[20];
			char nombre_orige[20];
			int num_sala;
			
			p = strtok(NULL, "/");
			strcpy(nombre_orige, p);
			p = strtok(NULL, "/");
			strcpy(nombre_destino, p);
			p = strtok(NULL, "/");
			num_sala = atoi(p);
			
			int sock = buscaSocketJugador(&listaSockets, nombre_destino);
			
			pthread_mutex_lock( &mutex );
			res = invitarUsuarioSala(&listaSalas, &listaSockets, nombre_destino, nombre_orige, sock_conn);
			pthread_mutex_unlock( &mutex );
			
			if((res != -1) && (res != -2)){
				sprintf(respuesta, "8/Enviada/%d/%d", sock_conn, num_sala);
				write(res, respuesta, strlen(respuesta));
				strcpy(respuesta, "");
			}else if(res == -2){
				strcpy(respuesta, "8/Error");
				write(sock_conn, respuesta, strlen(respuesta));
			}
			else{
				strcpy(respuesta, "8/NoConectado");
				write(sock_conn, respuesta, strlen(respuesta));
			}
		}
		
		else if(codigo == 9){
			char nombre_jugador[20];
			int sokcetJugador;
			p = strtok(NULL, "/");
			strcpy(nombre_jugador, p);
			p = strtok(NULL, "/");
			sokcetJugador = atoi(p);
			
			pthread_mutex_lock( &mutex );
			int res = agregarUsuarioSala(&listaSalas, &listaSockets, nombre_jugador, sokcetJugador, sock_conn);
			pthread_mutex_unlock( &mutex );
			
			sprintf(respuesta, "10/");
			write(sock_conn, respuesta, strlen(respuesta));
			
		}
		
		else if(codigo == 11){
			char nombre_jugador[20];
			int sala_num;
			
			p = strtok(NULL, "/");
			strcpy(nombre_jugador, p);
			p = strtok(NULL, "/");
			sala_num = atoi(p);
			
			pthread_mutex_lock( &mutex );
			int res = abandonarSala(&listaSalas, nombre_jugador);
			pthread_mutex_unlock( &mutex );
			
		}
		
		else if(codigo == 12){
			char nombre_jugador[20];
			int sala_num;
			
			p = strtok(NULL, "/");
			strcpy(nombre_jugador, p);
			p = strtok(NULL, "/");
			sala_num = atoi(p);

			//miramos en que sala esta a partir de su nombre
			//int i = posicionDeLaSala(&listaSalas, nombre_jugador);
			printf("Posicion: %d\n", 0);
			pthread_mutex_lock( &mutex );
			listaSalas.salas[sala_num].ronda = listaSalas.salas[sala_num].numActual - 1;
			pthread_mutex_unlock( &mutex );
			
			
		}

		//aqui reenviamos el dibujo a todos los jugadores de la sala
		else if(codigo == 13){
			char nombre_jugador[20];
			int num_sala;
			char color[4098];
			char a[4098];
			int pos_puntos_color;

			
			//aqui guardamos el nombre del que esta dibujando actualmente, para luego saber en que sala se ecuentra
			p = strtok(NULL, "/");
			strcpy(nombre_jugador, p);
			
			p = strtok(NULL, "/");
			num_sala = atoi(p);
			
			
			//int i = 0;
			
/*			sprintf(respuesta, "13/%s/%s/%s/%s/%s", nombre_jugador, num_sala, color, a, pos_puntos_color);*/
/*			while(i < pos_puntos_color){*/
/*				char string[20];*/
/*				p = strtok(NULL, "/");*/
/*				sprintf(string, "/%s", p); */
/*				strcat(respuesta, string);*/
				
/*				i++;*/
/*			}*/
			
			strcpy(respuesta, buff_auxiliar);
			printf("---%s\n", respuesta);
			//escribimos el mensaje
			//sprintf(respuesta,"13/%s/%s/%s/%s/%s/%s/%s", nombre_jugador, p1_x, p1_y, p2_x, p2_y, color, a);
			//printf("Respuesta: %s\n", respuesta);
			//aqui hay un problema con los sockets, en cambio con la peticion 18 funciona correctamente
			int j = 0;

			//write(5, respuesta, strlen(respuesta));
			
			while(j<listaSalas.salas[num_sala].numActual){
				//printf("Socket: %d\n",listaSalas.salas[num_sala].socketsJugadores[j]);
				write(listaSalas.salas[num_sala].socketsJugadores[j], respuesta, strlen(respuesta));
				//printf("Respuesta: %s\n", respuesta);
				j = j+1;
			}
		}
		
		//aqui el servidor cuando recibe esta peticion generara una palabra aleatoria y la reenviara, el usuario al que reenvia lo recibe como parametro
		else if(codigo == 18){
			char nombre_jugador[20];
			p = strtok(NULL, "/");
			strcpy(nombre_jugador, p);
			char palabra[80];
			
			int num_sala;
			p = strtok(NULL, "/");
			num_sala = atoi(p);
			
			//miramos en que sala esta a partir de su nombre
			//int i = posicionDeLaSala(&listaSalas, nombre_jugador);
			
			if( listaSalas.salas[num_sala].ronda >= 0){
				
				
				int socketElegido = listaSalas.salas[num_sala].socketsJugadores[listaSalas.salas[num_sala].ronda];
				printf("Socket elegido: %d\n", socketElegido);
				sprintf(respuesta2, "16/");
				
				write(socketElegido, respuesta2, strlen(respuesta2));
				
				char palabra[100];
				//procesamos la palabra
				generarPalabraAleatoria(conn, palabra);
				sprintf(respuesta, "18/%s", palabra);

				int j = 0;
				while(j<listaSalas.salas[num_sala].numActual){
					printf("Socket: %d\n",listaSalas.salas[num_sala].socketsJugadores[j]);
					write(listaSalas.salas[num_sala].socketsJugadores[j], respuesta, strlen(respuesta));
					
					j = j+1;
				}
			}
			pthread_mutex_lock( &mutex );
			listaSalas.salas[num_sala].ronda = listaSalas.salas[num_sala].ronda - 1;
			pthread_mutex_unlock( &mutex);
			
			if( listaSalas.salas[num_sala].ronda == -1){
				sprintf(respuesta, "20/");
				int j = 0;
				while(j<listaSalas.salas[num_sala].numActual){
					printf("Socket: %d\n",listaSalas.salas[num_sala].socketsJugadores[j]);
					write(listaSalas.salas[num_sala].socketsJugadores[j], respuesta, strlen(respuesta));
					
					j = j+1;
				}
				listaSalas.salas[num_sala].ronda = listaSalas.salas[num_sala].ronda - 1;
			}
		}
		
		else if(codigo == 20){
			char nombreJugador[20];
			int puntuacion;
			
			p = strtok(NULL, "/");
			strcpy(nombreJugador, p);
			p = strtok(NULL, "/");
			puntuacion = atoi(p);
			
			int i = posicionDeLaSala(&listaSalas, nombreJugador);
			
			pthread_mutex_lock( &mutex);
			listaSalas.salas[i].contadorGanador = listaSalas.salas[i].contadorGanador + 1;
			pthread_mutex_unlock( &mutex);
			
			if(puntuacion > listaSalas.salas[i].puntuacionMayorUltimaRonda){
				pthread_mutex_lock( &mutex);	
				listaSalas.salas[i].puntuacionMayorUltimaRonda = puntuacion;
				pthread_mutex_unlock( &mutex);
				strcpy(listaSalas.salas[i].ganadorUltimaRonda, nombreJugador);
			}
			
			if(listaSalas.salas[i].contadorGanador == listaSalas.salas[i].numActual){
				pthread_mutex_lock( &mutex);
				listaSalas.salas[i].contadorGanador = 0; //reseteamos contador para la proxima partida de la sala
				listaSalas.salas[i].puntuacionMayorUltimaRonda = 0;
				pthread_mutex_unlock( &mutex);
				
				sprintf(respuesta, "15/%s", listaSalas.salas[i].ganadorUltimaRonda);
				
				int j = 0;
				while(j<listaSalas.salas[i].numActual){
					printf("Socket: %d\n",listaSalas.salas[i].socketsJugadores[j]);
					write(listaSalas.salas[i].socketsJugadores[j], respuesta, strlen(respuesta));
					
					j = j+1;
				}
			}
		}
		
		//codigo del chat en proceso de acabar de implementarse
		
/*		else if(codigo == 30){*/
/*			char nombreAutor[20];*/
/*			char mensajeChat[512];*/
/*			char chatMessaege[512]; *///mensaje a enviar por el chat

/*			p = strtok(NULL, "/");*/
/*			strcpy(nombreAutor, p);*/
/*			p = strtok(NULL, "/");*/
/*			strcpy(mensajeChat, p);*/
		
/*			sprintf(chatMessaege, "%s: %s", nombreAutor, mensajeChat);*/
			
/*			sprintf(respuesta, "20/%s", chatMessaege);*/
			
			//miramos en que sala esta a partir de su nombre
/*			int i = posicionDeLaSala(&listaSalas, nombreAutor);*/
/*			printf("%d\n", i);*/
			
/*			int j;*/
/*			for(j=0; j<listaSalas.salas[j].numActual; i++){*/
/*				write(listaSalas.salas[i].socketsJugadores[j], respuesta, strlen(respuesta));*/
/*			}*/
/*		}*/
		
		else {
			printf("Codigo incorrecto\n");
		}
		if ((codigo == 1) || (codigo == 0)) {
			sprintf(nombres_modi, "%d/%s", num, nombres);
			char notificacion[512];
			sprintf(notificacion, "6/%s", nombres_modi);
			printf("%s\n", notificacion);
			int j;
			//i es el indice de cuantos clientes hay conectados
			for(j=0; j<k; j++){
				write(sockets[j], notificacion, strlen(notificacion));
			}
		}
	}
	close(sock_conn);
}

int main(int argc, char *argv[]) {
	//iniciar socket
	//les tres crides, tenim en comte que si la crida retorna un numero negatiu es que hi ha hagut un erro, i si surt 0 o m￯﾿ﾯ￯ﾾ﾿￯ﾾﾩs gran es que esta tot correcte
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	if((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket\n");
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(9100);
	if(bind(sock_listen, (struct sockaddr*) &serv_adr, sizeof(serv_adr))<0)
		printf("%s","Error al bind\n");
	
	if(listen(sock_listen, 3)<0) 
		printf("Error al listen\n");
	
	//uso de las funciones del servidor
	pthread_t thread;

	
	for(;;){
		printf("Escuchando!\n");
		
		//sock_con, el id del socket actual
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("Conexion establecida!\n");
		
		sockets[k] = sock_conn;
		
		pthread_create(&thread, NULL, AtenderCliente, &sockets[k]);
		k=k+1;
	}
}
