/*
	ALTERAR O CAMINHO ABAIXO PARA UMA PASTA EM OUTRA MÁQUINA!
*/

USE [master]
GO

CREATE DATABASE [DB_BNPP]
 ON  PRIMARY 
( NAME = N'DB_BNPP', FILENAME = N'C:\Users\Leandro\Desktop\TESTE BNPP\DB_BNPP\DB_BNPP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_TESTE_log', FILENAME = N'C:\Users\Leandro\Desktop\TESTE BNPP\DB_BNPP\DB_TESTE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

USE [DB_BNPP]
GO

CREATE TABLE [dbo].[PRODUTO](
	[COD_PRODUTO] [char](4) NOT NULL PRIMARY KEY,
	[DES_PRODUTO] [varchar](300) NULL,
	[STA_STATUS] [char](1) NULL
 );

CREATE TABLE [dbo].[PRODUTO_COSIF](
	[COD_PRODUTO] [char](4) NOT NULL,
	[COD_COSIF] [char](11) NOT NULL,
	[COD_CLASSIFICACAO] [char](6) NULL,
	[STA_STATUS] [char](1) NULL,
	PRIMARY KEY (COD_COSIF),
	FOREIGN KEY (COD_PRODUTO) REFERENCES PRODUTO(COD_PRODUTO)
	);

 CREATE TABLE [dbo].[MOVIMENTO_MANUAL](
	[DAT_MES] [numeric] NOT NULL,
	[DAT_ANO] [numeric] NOT NULL,
	[NUM_LANCAMENTO] [numeric] (18) NOT NULL,
	[COD_PRODUTO] [char] (4) NOT NULL,
	[COD_COSIF] [char] (11) NOT NULL,
	[VAL_VALOR] [numeric](18,2) NOT NULL,
	[DES_DESCRICAO] [varchar] (50) NOT NULL,
	[DAT_MOVIMENTO] [smalldatetime] NOT NULL,
	[COD_USUARIOS] [varchar](15) NOT NULL,
	PRIMARY KEY (DAT_MES, DAT_ANO, NUM_LANCAMENTO, COD_COSIF),
	FOREIGN KEY (COD_COSIF) REFERENCES PRODUTO_COSIF(COD_COSIF)
	);