DROP DATABASE IF EXISTS armadieti;
CREATE DATABASE armadieti;
USE armadieti;

CREATE TABLE TipoMobilio (
    TipoMobilio VARCHAR(50) PRIMARY KEY
);
CREATE TABLE StatoMobilio (
    StatoMobilio VARCHAR(50) PRIMARY KEY
);
CREATE TABLE Location(
	IdLocation INT AUTO_INCREMENT PRIMARY KEY,
	Stabile VARCHAR(50) NOT NULL,
    Piano VARCHAR(50) NOT NULL,
    UNIQUE(Stabile,Piano)
);


CREATE TABLE Chiave (
   NumeroChiave INT PRIMARY KEY 
);

CREATE TABLE Mobilio (
    IdMobilio INT AUTO_INCREMENT PRIMARY KEY,
    Numero INT NOT NULL,
    IdLocation INT NOT NULL,
    TipoMobilio VARCHAR(50) NOT NULL,
    NumeroChiave INT NOT NULL, 
    StatoMobilio VARCHAR(50) NOT NULL,
	FOREIGN KEY (NumeroChiave) REFERENCES Chiave(NumeroChiave),
    FOREIGN KEY (TipoMobilio) REFERENCES TipoMobilio(TipoMobilio),
    FOREIGN KEY (IdLocation) REFERENCES Location(IdLocation),
    FOREIGN KEY (StatoMobilio) REFERENCES StatoMobilio(StatoMobilio),
    UNIQUE (IdLocation, Numero)
);



CREATE TABLE Dipartimento (
   NomeDipartimento VARCHAR(50) PRIMARY KEY
);

CREATE TABLE TipoPersona (
   TipoPersona VARCHAR(50) PRIMARY KEY
);


CREATE TABLE Persona (
    IdPersona INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Cognome VARCHAR(50) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    IdMonitor VARCHAR(50) UNIQUE NOT NULL,
    TipoPersona VARCHAR(50) NOT NULL,
    NomeDipartimento VARCHAR(50) NOT NULL,
    FOREIGN KEY (TipoPersona) REFERENCES TipoPersona(TipoPersona),
   	FOREIGN KEY (NomeDipartimento) REFERENCES Dipartimento(NomeDipartimento)
);


CREATE TABLE TipoPagamento (
	Pagamento VARCHAR(30) PRIMARY KEY
);

CREATE TABLE Noleggio (
    IdNoleggio INT AUTO_INCREMENT PRIMARY KEY,
    DataInizio DATE NOT NULL,
    DataFine DATE NOT NULL,
    IdMobilio INT NOT NULL,    
    IdPersona INT NOT NULL,    
    Attivo BOOL default True,
    FOREIGN KEY (IdMobilio) REFERENCES Mobilio(IdMobilio),
    FOREIGN KEY (IdPersona) REFERENCES Persona(IdPersona),
    UNIQUE (IdMobilio, DataInizio, DataFine)
);

CREATE TABLE Movimento (
    IdMovimento INT AUTO_INCREMENT PRIMARY KEY,
    IdNoleggio INT NOT NULL,
    Cauzione DECIMAL(10,2) NOT NULL DEFAULT 0,
    Data DATE NOT NULL,
	Pagamento VARCHAR(30) NOT NULL,
	FOREIGN KEY (Pagamento) REFERENCES TipoPagamento(Pagamento),
    FOREIGN KEY (IdNoleggio) REFERENCES Noleggio(IdNoleggio)
);
