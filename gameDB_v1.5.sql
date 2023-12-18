Drop DATABASE IF EXISTS gameDB;
CREATE DATABASE gameDB;

USE gameDB;

CREATE TABLE jugadores(
		id_jugador INT NOT NULL AUTO_INCREMENT,
		nombre VARCHAR(60) NOT NULL,
		password VARCHAR(60) NOT NULL,
		partidas_jugadas INT NOT NULL,
		partidas_ganadas INT NOT NULL,
		puntuacion_partidas INT NOT NULL,
		PRIMARY KEY (id_jugador)
)ENGINE=InnoDB;

CREATE TABLE partidas(
		id_partida INT NOT NULL AUTO_INCREMENT,
		jugador1 INT NOT NULL,
		jugador2 INT NOT NULL,
		jugador3 INT NOT NULL,
		jugador4 INT NOT NULL,
		ganador  INT NOT NULL,
		PRIMARY KEY (id_partida)
)ENGINE=InnoDB;

CREATE TABLE listaPalabras(
		palabra VARCHAR(60) NOT NULL,
		acertaciones INT NOT NULL,
		PRIMARY KEY (palabra)
)ENGINE=InnoDB;

CREATE TABLE Relacion(
		IdPartida INT NOT NULL,
		IdJugador INT NOT NULL,
		IdPalabra INT NOT NULL,
		FOREIGN KEY (IdPartida) REFERENCES partidas(id_partida),
		FOREIGN KEY (IdJugador) REFERENCES partidas(id_jugador),
		FOREIGN KEY (IdPalabra) REFERENCES partidas(palabra),
)ENGINE=InnoDB;
		







