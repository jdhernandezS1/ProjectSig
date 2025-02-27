DROP DATABASE IF EXISTS armadieti;
CREATE DATABASE armadieti;
USE armadieti;


CREATE TABLE CategoriaArmadio (
    id_categoria INT AUTO_INCREMENT PRIMARY KEY,
    nome ENUM('casella', 'armadietto') UNIQUE NOT NULL
);


CREATE TABLE Armadio (
    id_armadio INT AUTO_INCREMENT PRIMARY KEY,
    piano VARCHAR(50) NOT NULL,
    numero INT NOT NULL,
    id_categoria INT NOT NULL,
    stato ENUM('Disponibile', 'Occupato', 'Manutenzione', 'Fuori uso') UNIQUE NOT NULL,
    FOREIGN KEY (id_categoria) REFERENCES CategoriaArmadio(id_categoria),
    UNIQUE (piano, numero)
);

CREATE TABLE StatoChiave (
    id_stato INT AUTO_INCREMENT PRIMARY KEY,
    nome ENUM('Disponibile', 'Consegnata', 'Persa', 'Danneggiata') UNIQUE NOT NULL
);


CREATE TABLE Chiave (
    id_chiave INT AUTO_INCREMENT PRIMARY KEY,
    id_armadio INT NOT NULL,
    id_stato INT NOT NULL,
    FOREIGN KEY (id_armadio) REFERENCES Armadio(id_armadio),
    FOREIGN KEY (id_stato) REFERENCES StatoChiave(id_stato),
    UNIQUE (id_armadio, id_stato)
);


CREATE TABLE Dipartimento (
    id_dipartimento INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) UNIQUE NOT NULL
);


CREATE TABLE Utente (
    id_utente INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    cognome VARCHAR(50) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    id_monitor VARCHAR(50) UNIQUE NOT NULL,
    tipo ENUM('Studente', 'Docente', 'Amministrativo') NOT NULL,
    id_dipartimento INT NOT NULL,
    FOREIGN KEY (id_dipartimento) REFERENCES Dipartimento(id_dipartimento)
);


CREATE TABLE TipoPagamento (
	pagamento VARCHAR(30) PRIMARY KEY
);

CREATE TABLE Noleggio (
    id_noleggio INT AUTO_INCREMENT PRIMARY KEY,
    data_inizio DATETIME NOT NULL,
    data_fine DATETIME NOT NULL,
	pagamento VARCHAR(30) NOT NULL,
    cauzione DECIMAL(10,2) NOT NULL DEFAULT 0,
    id_armadio INT NOT NULL,
    id_chiave INT NOT NULL,
    id_utente INT NOT NULL,
    FOREIGN KEY (pagamento) REFERENCES TipoPagamento(pagamento),
    FOREIGN KEY (id_armadio) REFERENCES Armadio(id_armadio),
    FOREIGN KEY (id_chiave) REFERENCES Chiave(id_chiave),
    FOREIGN KEY (id_utente) REFERENCES Utente(id_utente),
    UNIQUE (id_armadio, data_inizio, data_fine)
);
