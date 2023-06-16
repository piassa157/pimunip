CREATE TABLE Pessoa (
    ID INT NOT NULL AUTO_INCREMENT,
    NOME VARCHAR(256) NOT NULL,
    CPF BIGINT NOT NULL,
    ENDERECO_ID INT,
    PRIMARY KEY (ID),
    FOREIGN KEY (ENDERECO_ID) REFERENCES Endereco(ID)
);

CREATE TABLE Endereco (
    ID INT NOT NULL AUTO_INCREMENT,
    LOGRADOURO VARCHAR(256) NOT NULL,
    NUMERO INT NOT NULL,
    CEP INT NOT NULL,
    BAIRRO VARCHAR(50) NOT NULL,
    CIDADE VARCHAR(50) NOT NULL,
    ESTADO VARCHAR(50) NOT NULL,
    PRIMARY KEY (ID)
);

CREATE TABLE Pessoa_telefone (
    ID_PESSOA INT,
    ID_TELEFONE INT,
    PRIMARY KEY (ID_PESSOA, ID_TELEFONE),
    FOREIGN KEY (ID_PESSOA) REFERENCES Pessoa(ID),
    FOREIGN KEY (ID_TELEFONE) REFERENCES Telefone(ID)
);

CREATE TABLE Telefone (
    ID INT NOT NULL AUTO_INCREMENT,
    NUMERO INT NOT NULL,
    DDD INT NOT NULL,
    TIPO_TELEFONE_ID INT,
    PRIMARY KEY (ID),
    FOREIGN KEY (TIPO_TELEFONE_ID) REFERENCES Telefone_tipo(ID)
);

CREATE TABLE Telefone_tipo (
    ID INT NOT NULL AUTO_INCREMENT,
    TIPO VARCHAR(10) NOT NULL,
    PRIMARY KEY (ID)
);


INSERT INTO Endereco (LOGRADOURO, NUMERO, CEP, BAIRRO, CIDADE, ESTADO)
VALUES ('Rua Exemplo', 123, 12345, 'Bairro Exemplo', 'Cidade Exemplo', 'Estado Exemplo');


INSERT INTO Pessoa (NOME, CPF)
VALUES ('Test', 12345678900);

INSERT INTO Telefone_tipo (TIPO)
VALUES ('Celular');

INSERT INTO Telefone (NUMERO, DDD, TIPO_TELEFONE_ID)
VALUES (987654321, 11, 1);

INSERT INTO Pessoa_telefone (ID_PESSOA, ID_TELEFONE)
VALUES (1, 1);


