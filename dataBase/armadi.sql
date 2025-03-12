DROP DATABASE IF EXISTS armadieti;
CREATE DATABASE armadieti;
USE armadieti;


CREATE TABLE CategoriaArmadio (
    CategoriaArmadio VARCHAR(50) PRIMARY KEY
);
CREATE TABLE StatoArmadio (
    StatoArmadio VARCHAR(50) PRIMARY KEY
);
CREATE TABLE Location(
	IdLocation INT AUTO_INCREMENT PRIMARY KEY,
	Stabile VARCHAR(50) NOT NULL,
    Piano VARCHAR(50) NOT NULL,
    UNIQUE(Stabile,Piano)
);
CREATE TABLE Armadio (
    IdArmadio INT AUTO_INCREMENT PRIMARY KEY,
    Numero INT NOT NULL,
    IdLocation INT NOT NULL,
    CategoriaArmadio VARCHAR(50) NOT NULL,
    StatoArmadio VARCHAR(50) NOT NULL,
    FOREIGN KEY (CategoriaArmadio) REFERENCES CategoriaArmadio(CategoriaArmadio),
    FOREIGN KEY (IdLocation) REFERENCES Location(IdLocation),
    FOREIGN KEY (StatoArmadio) REFERENCES StatoArmadio(StatoArmadio),
    UNIQUE (IdLocation, Numero)
);

CREATE TABLE StatoChiave (
    StatoChiave VARCHAR(50) PRIMARY KEY
);


CREATE TABLE Chiave (
    IdChiave INT AUTO_INCREMENT PRIMARY KEY,
    IdArmadio INT NOT NULL,
    StatoChiave VARCHAR(50) NOT NULL,
    FOREIGN KEY (StatoChiave) REFERENCES StatoChiave(StatoChiave),
    UNIQUE (StatoChiave)
);


CREATE TABLE Dipartimento (
   NomeDipartimento VARCHAR(50) PRIMARY KEY
);

CREATE TABLE TipoUtente (
   TipoUtente VARCHAR(50) PRIMARY KEY
);


CREATE TABLE Utente (
    IdUtente INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Cognome VARCHAR(50) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    IdMonitor VARCHAR(50) UNIQUE NOT NULL,
    TipoUtente VARCHAR(50) NOT NULL,
    NomeDipartimento VARCHAR(50) NOT NULL,
    FOREIGN KEY (TipoUtente) REFERENCES TipoUtente(TipoUtente),
   	FOREIGN KEY (NomeDipartimento) REFERENCES Dipartimento(NomeDipartimento)
);


CREATE TABLE TipoPagamento (
	Pagamento VARCHAR(30) PRIMARY KEY
);

CREATE TABLE Noleggio (
    IdNoleggio INT AUTO_INCREMENT PRIMARY KEY,
    DataInizio DATETIME NOT NULL,
    DataFine DATETIME NOT NULL,
	Pagamento VARCHAR(30) NOT NULL,
    Cauzione DECIMAL(10,2) NOT NULL DEFAULT 0,
    IdArmadio INT NOT NULL,
    IdChiave INT NOT NULL,
    IdUtente INT NOT NULL,
    FOREIGN KEY (Pagamento) REFERENCES TipoPagamento(Pagamento),
    FOREIGN KEY (IdArmadio) REFERENCES Armadio(IdArmadio),
    FOREIGN KEY (IdChiave) REFERENCES Chiave(IdChiave),
    FOREIGN KEY (IdUtente) REFERENCES Utente(IdUtente),
    UNIQUE (IdArmadio, DataInizio, DataFine)
);
