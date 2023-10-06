Drop DATABASE IF EXISTS gameDB;
CREATE DATABASE gameDB;

USE gameDB;

CREATE TABLE jugadores(
		id INT NOT NULL AUTO_INCREMENT,
		nombre VARCHAR(60) NOT NULL,
		partidas_jugadas INT NOT NULL,
		partidas_ganadas INT NOT NULL,
		fecha_perfil varchar(60) NOT NULL,
		PRIMARY KEY (id)
)	ENGINE = InnoDB;

CREATE TABLE partidas(
		id_partida INT NOT NULL AUTO_INCREMENT,
		jugador1 VARCHAR(60) NOT NULL,
		jugador2 VARCHAR(60) NOT NULL,
		Ganador  INT,
		fecha_partida INT,
		duracion INT,
		escenario_jugado INT NOT NULL,
		PRIMARY KEY (id_partida)
)	ENGINE = InnoDB;


CREATE TABLE datos_personales(
		id_jugador INT NOT NULL AUTO_INCREMENT,
		nombre VARCHAR(60) NOT NULL,
		contraseña VARCHAR(60) NOT NULL,
		PRIMARY KEY (id_jugador)
)	ENGINE = InnoDB;

CREATE TABLE escenario(
		id_escenario INT NOT NULL AUTO_INCREMENT,
		nombre_escenario VARCHAR(60) NOT NULL,
		Musica INT NOT NULL,
		diseño INT NOT NULL,
		PRIMARY KEY (id_escenario)
)	ENGINE = InnoDB;
