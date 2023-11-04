Drop DATABASE IF EXISTS gameDB;
CREATE DATABASE gameDB;

USE gameDB;

CREATE TABLE jugadores(
		id_jugador INT NOT NULL AUTO_INCREMENT,
		nombre VARCHAR(60) NOT NULL,
		password VARCHAR(60) NOT NULL,
		partidas_jugadas INT NOT NULL,
		partidas_ganadas INT NOT NULL,
		fecha_perfil varchar(60) NOT NULL,
		PRIMARY KEY (id_jugador)
)ENGINE=InnoDB;

CREATE TABLE escenario(
		id_escenario INT NOT NULL AUTO_INCREMENT,
		nombre_escenario VARCHAR(60) NOT NULL,
		Musica INT NOT NULL,
		diseño INT NOT NULL,
		PRIMARY KEY (id_escenario)
)ENGINE=InnoDB;

CREATE TABLE partidas(
		id_partida INT NOT NULL AUTO_INCREMENT,
		jugador1 INT NOT NULL,
		jugador2 INT NOT NULL,
		ganador  INT NOT NULL,
		fecha_partida INT NOT NULL,
		duracion INT NOT NULL,
		escenario_jugado INT NOT NULL,
		PRIMARY KEY (id_partida)
)ENGINE=InnoDB;







