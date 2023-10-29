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



int main(int argc, char *argv[]) {

	
	MYSQL *conn;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	int err;
    //conexion a la base de datos 
    //aqui se esta creando una conexion al servidor, es decir que si el servidor existe este nos dara un conector "conn" para luego inicializar la conexion.
    conn = mysql_init(NULL);
            
    if(conn == NULL){
        printf("Error al crear la conexion con la base de datos:%u%s\n", mysql_errno(conn), mysql_error(conn));
        exit(1);
    }
    //mientras que aqui la estamos inicializando pasandole los parametros necesarios(usuario y contrase￱a) para que se pueda conectar
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
		
		if(row == NULL)
			return -2; //no existe el usuario al que se intenta iniciar sesion
		else{
			int respuesta;
			//en caso de que haya mas de un usuario con el mismo nombre, entonces comparamos cada uno sus nombres con la contrase￱a enviada
			while (row!=NULL){
				//en este caso el id sera row[0], el nombre sera row[1], y la contrase￱a sera row[2]
				if(row[2] == password){
					respuesta =0; //el usuario existe y la contrase￱a coincide
				}else{
					respuesta =  -1; //contrase￱a incorrecta
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
		
		char consulta[500];
		memset(consulta,'\0',500);
		printf("consulta: %s\n", consulta);
		
		//INSERT INTO datos_personales(nombre, contrase￱a) VALUES ('name', 'password');
		strcat (consulta,"INSERT INTO jugadores (nombre, password,partidas_jugadas,partidas_ganadas,fecha_perfil) VALUES ('");
		strcat (consulta, name);
		strcat (consulta, "','");
		strcat (consulta, password);
		strcat (consulta, "',");
		strcat (consulta,"0,0");
		sprintf (consulta,",%s,%d",consulta,(int)seconds);
		strcat (consulta,");");
		printf("consulta: %s\n", consulta);
		
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
	}
	
	int coincidenciaPartidas(){
		char consulta[200];
		strcpy(consulta,"\0");
		printf("consulta: %s\n", consulta);
		
		strcat (consulta, "SELECT * FROM partidas WHERE jugador1 = jugador2");
		err = mysql_query(conn, consulta);
		if(err!=0){
			return -1;
			exit(1);
		}
		resultado = mysql_store_result (conn);
		
		row = mysql_fetch_row (resultado);

		printf("Valor %s\n",row[0]);
	}
	
	//iniciar socket
	//les tres crides, tenim en comte que si la crida retorna un numero negatiu es que hi ha hagut un erro, i si surt 0 o m￩s gran es que esta tot correcte
	int sock_conn, sock_listen, ret; 
	struct sockaddr_in serv_adr;
	char buff[512]; //variable per emmagatzemar els missatges que ens envia el client
	
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
	int i = 0;
	for(i=0;i<5;i++){
		printf("Escuchando!\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("Conexion establecida!\n");
		
		ret = read(sock_conn, buff, sizeof(buff));
		
		buff[ret] ='\0';
		
		char *p = strtok(buff, "/");
		int codigo = atoi(p);
		if(codigo == 0){
			printf("Cerrando conexion con el servidor\n");
			
		}
		else if(codigo == 1){ //el mensaje llega de la forma 1/'nombre'/'contrase￱a'
			char nombre[60];
			char contrasena[60];
			strcpy(nombre,"\0");
			strcpy(contrasena,"\0");
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			p = strtok(NULL, "/");
			strcpy(contrasena, p);
			int res;
			res = login(nombre, contrasena);
			if(res == -1){
				printf("Password incorrecto\n");
				
			}
			else{
				printf("Password correcto\n");
				
			}
		}
		else if(codigo == 2){
			char nombre[60];
			char contrasena[60];
			strcpy(nombre,"\0");
			strcpy(contrasena,"\0");
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			p = strtok(NULL, "/");
			strcpy(contrasena, p);
			int res;
			res = registro(nombre, contrasena);
			if(res == -1){
				printf("Ha ocurrido un problema con el registro\n");
				
			}
			else{
				printf("Te has registrado correctamente\n");
				
			}
		}
		else if(codigo == 3){
			mejorEscenario();
		
		}
		else if(codigo == 4){
			partidaMasLarga();
           
		}
		else if (codigo == 5){
			coincidenciaPartidas();
            
		}else {
			printf("Codigo incorrecto\n");
			
		}
	
		close(sock_conn);
	}
}
