#include <stdio.h>
#include <mysql.h>  //libreria para hacer las operaciones con mysql
#include <string.h>
#include <stdlib.h>
#include <sys/socket.h>
#include <unistd.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <fcntl.h>
#include <time.h>
#include <pthread.h>

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;


int num; //cantidad de usuarios conectados
char nombres[512]; //lista de conectados, formato --> "nombre1/nombre2/nombre3/nombre4/..."
//la lista de conectados pero la que se enviara al cliente ya que tendra concatenada al principio la cantidad de conectados
char nombres_modi[512]; // formato --> "num/nombre1/nombre2/nombre3/nombre4/..."

int i=0;
int sockets[100];

void *AtenderCliente (void *socket){
	MYSQL *conn;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	char buff[512];
	char respuesta[512];
	
	int err;
	//conexion a la base de datos 
	//aqui se esta creando una conexion al servidor, es decir que si el servidor existe este nos dara un conector "conn" para luego inicializar la conexion.
	conn = mysql_init(NULL);
	
	if(conn == NULL){
		printf("Error al crear la conexion con la base de datos:%u%s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	//mientras que aqui la estamos inicializando pasandole los parametros necesarios(usuario y contrase￯﾿ﾱa) para que se pueda conectar
	conn = mysql_real_connect (conn, "localhost", "root", "mysql", "gameDB", 0, NULL, 0);
	if(conn == NULL)
	{
		printf("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	int login(char name[60], char password[60]) {
		//SELECT id_jugador FROM datos_personales WHERE nombre = name;
		char consulta[200];
		strcpy(consulta,"\0");
		printf("consulta: %s\n", consulta);
		
		char nombre[60];
		strcpy(nombre,"\0");
		
		strcpy(nombre,name);
		char contra[60];
		strcpy(contra,"\0");
		strcpy(contra,password);
		
		strcat (consulta, "SELECT * FROM jugadores WHERE nombre ='");
		strcat (consulta, name);
		strcat (consulta, "'");
		printf("consulta: %s\n", consulta);
		
		err = mysql_query(conn, consulta);
		if(err!=0){
			return -1;
			exit(1);
		}
		resultado = mysql_store_result (conn);
		
		row = mysql_fetch_row (resultado);
		//printf("Contrasela: %s\n", contra);
		if(row == NULL)
			return -2; //no existe el usuario al que se intenta iniciar sesion
		else{
			int respuesta;
			//en caso de que haya mas de un usuario con el mismo nombre, entonces comparamos cada uno sus nombres con la contrase￯﾿ﾱa enviada
			while (row!=NULL){
				//en este caso el id sera row[0], el nombre sera row[1], y la contrase￯﾿ﾱa sera row[2]
				if(strcmp(row[2], contra) == 0){
					respuesta =0; //el usuario existe y la contrase￯﾿ﾱa coincide
				}else{
					respuesta =  -1; //contrase￯﾿ﾱa incorrecta
				}
				row = mysql_fetch_row (resultado);
			}
			return respuesta; //retornamos la respuesta, entre un -1 o un 0
		}
	}
	//metodos de la base de datos
	int registro(char name[60], char password[60]) {
		time_t seconds;
		seconds = time(NULL); // Seconds since January 1, 1970
		
		//pasamos 'seconds' a un string para insertarlo a la base de datos
		char time[50];
		sprintf(time, "%d", (int)seconds);
		printf("%s", time);
		
		char consulta[500];
		memset(consulta,'\0',500);
		printf("consulta: %s\n", consulta);
		//consultamos si ya existe el usuario
		strcat (consulta, "SELECT * FROM jugadores WHERE nombre ='");
		strcat (consulta, name);
		strcat (consulta, "'");
		printf("consulta: %s\n", consulta);
		err = mysql_query(conn, consulta);
		if(err!=0){
			return -1;
			exit(1);
		}else{
			resultado = mysql_store_result (conn);
			
			row = mysql_fetch_row (resultado);
			if(row[0] != NULL){
				return -2;
			}
		}
		//INSERT INTO datos_personales(nombre, contrase￯﾿ﾱa) VALUES ('name', 'password');
		strcpy (consulta,"INSERT INTO jugadores (nombre, password ,partidas_jugadas,partidas_ganadas,fecha_perfil) VALUES ('");
		strcat (consulta, name);
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
	}
	//en esta funcion retornamos el escenario donde jugo el jugado
	int mejorEscenario(){
		char consulta[200];
		strcpy(consulta,"\0");
		printf("consulta: %s\n", consulta);
		
		strcat (consulta, "SELECT MAX(partidas_ganadas) FROM jugadores");
		printf("consulta: %s\n", consulta);
		
		err = mysql_query(conn, consulta);
		if(err!=0){
			return -1;
			exit(1);
		}
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		
		strcpy(consulta,"\0");
		printf("consulta: %s\n", consulta);
		
		strcat (consulta, "SELECT nombre FROM jugadores WHERE partidas_ganadas = ");
		strcat (consulta, row[0]);
		printf("consulta: %s\n", consulta);
		
		err = mysql_query(conn, consulta);
		if(err!=0){
			return -1;
			exit(1);
		}
		resultado = mysql_store_result (conn);
		
		row = mysql_fetch_row (resultado);
		
		strcpy(consulta,"\0");
		printf("consulta: %s\n", consulta);
		
		strcat (consulta, "SELECT escenario_jugado FROM partidas WHERE jugador1 = '");
		strcat (consulta, row[0]);
		strcat (consulta, "' OR jugador2 = '");
		strcat (consulta, row[0]);
		strcat ( consulta, "'");
		printf("consulta: %s\n", consulta);
		
		err = mysql_query(conn, consulta);
		if(err!=0){
			printf("Error en la consulta\n");
			exit(1);
		}
		resultado = mysql_store_result (conn);
		
		row = mysql_fetch_row (resultado);
		
		printf("Valor %s\n",row[0]);
		strcpy(respuesta, row[0]);
	}
	int partidaMasLarga(){
		char consulta[200];
		strcpy(consulta,"\0");
		printf("consulta: %s\n", consulta);
		
		strcat (consulta, "SELECT MAX(duracion) FROM jugadores");
		printf("consulta: %s\n", consulta);
		
		err = mysql_query(conn, consulta);
		if(err!=0){
			return -1;
			exit(1);
		}
		resultado = mysql_store_result (conn);
		
		row = mysql_fetch_row (resultado);
		
		strcpy(consulta,"\0");
		printf("consulta: %s\n", consulta);
		
		strcat (consulta, "SELECT jugador1, jugador2 FROM partidas WHERE duracion = ");
		strcat (consulta, row[0]);
		printf("consulta: %s\n", consulta);
		err = mysql_query(conn, consulta);
		if(err!=0){
			printf("Error al ejecutar la consulta\n");
			exit(1);
		}
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		
		printf("Valor %s\n",row[0]);
		strcpy(respuesta, row[0]);
	}
	int coincidenciaPartidas(){
		char consulta[200];
		strcpy(consulta,"\0");
		printf("consulta: %s\n", consulta);
		
		strcpy(consulta, "SELECT * FROM partidas WHERE jugador1 = jugador2");
		printf("consulta: %s\n", consulta);
		err = mysql_query(conn, consulta);
		if(err!=0){
			return -1;
			exit(1);
		}
		resultado = mysql_store_result (conn);
		
		row = mysql_fetch_row (resultado);
		
		printf("Valor: %s\n",row[0]);
		//strcpy(respuesta, "error");
		return 0;
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
		
		buff[ret] ='\0';
		
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
					sprintf(nombres, "");
				}else{
					printf("%d\n", i);
					if(i==0){
						sprintf(nombres, "%s/" , p);
					}else if(i != 0){
						sprintf(nombres, "%s%s/",nombres, p);
					}
				}
				p = strtok(NULL, "/");
				i=i+1;
			}
			num = num - 1;
			pthread_mutex_unlock(&mutex); //ya se puede interrumpir
			printf("El usuario %s ha cerrado sesi￳n\n", nombre);
			terminar = 1;
		}
		
		else if(codigo == 1){ //el mensaje llega de la forma 1/'nombre'/'contrase￱a'
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
			}
			else{
				int res;
				res = login(nombre, contrasena);
				if(res == -1){
					printf("Password incorrecto\n");
					strcpy(respuesta, "1/incorrectPass");
				}
				else if(res == -2){
					printf("No existe el usuario\n");
					strcpy(respuesta, "1/noUser");
				}
				//la contrase￱a y usuario son correctos, por tanto lo a￱adira a la lista de conectados
				else{
					pthread_mutex_lock( &mutex); //no interrumpas
					num=num+1;
					printf("%s\n", nombres);
					sprintf(nombres, "%s%s/",nombres, nombre);
					pthread_mutex_unlock(&mutex); //ya se puede interrumpir
					printf("Password correcto\n");
					strcpy(respuesta, "1/SI");
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
			res = registro(nombre, contrasena);
			if(res == -1){
				printf("Ha ocurrido un problema con el registro\n");
				strcpy(respuesta, "2/NO");
			}else if(res == -2){
				printf("El usuario ya existe\n");
				strcpy(respuesta, "2/EXISTE");
			}
			else{
				printf("Te has registrado correctamente\n");
				strcpy(respuesta, "2/SI");
			}
		}
		else if(codigo == 3){
			mejorEscenario();
		}
		else if(codigo == 4){
			partidaMasLarga();
		}
		else if (codigo ==5){
			coincidenciaPartidas();
			//strcpy(respuesta, "error");
		}else {
			printf("Codigo incorrecto\n");
		}
		if(codigo != 0){
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
		}
		if ((codigo == 1) || (codigo == 0)) {
			sprintf(nombres_modi, "%d/%s", num, nombres);
			char notificacion[512];
			sprintf(notificacion, "6/%s", nombres_modi);
			printf("%s\n", notificacion);
			int j;
			//i es el indice de cuantos clientes hay conectados
			for(j=0; j<i; j++){
				write(sockets[j], notificacion, strlen(notificacion));
			}
		}
	}
	close(sock_conn);
}

int main(int argc, char *argv[]) {
	//iniciar socket
	//les tres crides, tenim en comte que si la crida retorna un numero negatiu es que hi ha hagut un erro, i si surt 0 o m￯﾿ﾩs gran es que esta tot correcte
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	if((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket\n");
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(9050);
	if(bind(sock_listen, (struct sockaddr*) &serv_adr, sizeof(serv_adr))<0)
		printf("%s","Error al bind\n");
	
	if(listen(sock_listen, 3)<0) 
		printf("Error al listen\n");
	
	//uso de las funciones del servidor
	pthread_t thread;
	for(;;){
		printf("Escuchando!\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("Conexion establecida!\n");
		
		sockets[i] = sock_conn;
		
		pthread_create(&thread, NULL, AtenderCliente, &sockets[i]);
		i=i+1;
		
	}
}
