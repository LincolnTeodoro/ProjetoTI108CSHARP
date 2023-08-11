-- Apagando banco de dados
DROP DATABASE dbPadariaCarmel;

-- Criando banco de dados;
CREATE DATABASE dbPadariaCarmel;

-- Acessando banco de dados
USE dbPadariaCarmel;

-- Criando as tableas
CREATE TABLE tbFuncionarios(
	codFunc INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(100),
	email VARCHAR(100),
	telCel CHAR(15),
	cpf CHAR(14) UNIQUE,
	endereco VARCHAR(100),
	numero VARCHAR(10),
	bairro VARCHAR(100),
	cidade VARCHAR(100),
	estado CHAR(2),
	cep CHAR(9),
	PRIMARY KEY (codFunc)
);
