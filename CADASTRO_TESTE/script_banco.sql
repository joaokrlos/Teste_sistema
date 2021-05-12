CREATE DATABASE CadastroDB
--Criando tabela

--determina o uso do banco de dados correto
USE CadastroDB

--CRIAÇÃO DE TABELA
CREATE TABLE Funcionario (
	FuncionarioId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nome nvarchar (50) NOT NULL ,
	Idade int NOT NULL,
	Genero nvarchar (10) NOT NULL,
	); 
-- VERIFICANDO COLUNAS
	SELECT * 

	FROM Funcionario

