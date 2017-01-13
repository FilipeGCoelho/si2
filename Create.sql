USE SI2

GO
CREATE SCHEMA dbb;
GO

CREATE TABLE dbb.Tipo (
	nome VARCHAR(64) PRIMARY KEY,
	descricao VARCHAR(128) NOT NULL,
	hidden BIT DEFAULT 0 NOT NULL
)

CREATE TABLE dbb.Equipamento (
	codigo INT IDENTITY(1,1) PRIMARY KEY,
	descricao VARCHAR(128) NOT NULL,
	tipo VARCHAR(64) FOREIGN KEY REFERENCES dbb.Tipo,
	hidden BIT DEFAULT 0 NOT NULL
)

CREATE TABLE dbb.Preco (
	validade INT NOT NULL,
	valor MONEY NOT NULL,
	idEquipamento INT FOREIGN KEY REFERENCES dbb.Equipamento,
	hidden BIT DEFAULT 0 NOT NULL,
	PRIMARY KEY (validade, idEquipamento)
)

CREATE TABLE dbb.Empregado (
	numero INT IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR(32) NOT NULL,
	hidden BIT DEFAULT 0 NOT NULL
)

CREATE TABLE dbb.Cliente (
	numero INT IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR(64),
	nif NUMERIC(9) UNIQUE,
	morada VARCHAR(64),
	hidden BIT DEFAULT 0 NOT NULL,
	CONSTRAINT nifSize CHECK (nif BETWEEN 100000000 AND 999999999)
)

CREATE TABLE dbb.Aluguer (
	nSerie INT IDENTITY(1,1) PRIMARY KEY,
	dataInicio DATETIME NOT NULL,
	dataFim DATETIME,
	tipo INT NOT NULL, --duracao
	preco MONEY NOT NULL,
	nEmpregado INT FOREIGN KEY REFERENCES dbb.Empregado,
	nCliente INT FOREIGN KEY REFERENCES dbb.Cliente,
	hidden BIT DEFAULT 0 NOT NULL
)

CREATE TABLE dbb.Promocao (
	id INT IDENTITY(1,1) PRIMARY KEY,
	dataInicio DATE NOT NULL,
	dataFim DATE NOT NULL,
	descricao VARCHAR(128) NOT NULL,
	tipo VARCHAR(8) NOT NULL,
	hidden BIT DEFAULT 0 NOT NULL,
	CONSTRAINT CheckTipo CHECK (tipo = 'tempo' OR tipo = 'desconto')
)

CREATE TABLE dbb.Aluguer_Promocao (
	nSerieAluguer INT FOREIGN KEY REFERENCES dbb.Aluguer,
	idPromocao INT FOREIGN KEY REFERENCES dbb.Promocao,
	hidden BIT DEFAULT 0 NOT NULL,
	PRIMARY KEY (nSerieAluguer, idPromocao)
)


CREATE TABLE dbb.Aluguer_Equipamento (
	nSerieAluguer INT FOREIGN KEY REFERENCES dbb.Aluguer,
	codigoEquipamento INT FOREIGN KEY REFERENCES dbb.Equipamento,
	hidden BIT DEFAULT 0 NOT NULL,
	PRIMARY KEY (nSerieAluguer, CodigoEquipamento)
)

--Views-----------------------------

go
CREATE VIEW Tipo
as
	SELECT nome, descricao
	FROM dbb.Tipo
	WHERE hidden = 0
go

go
CREATE VIEW Equipamento
as
	SELECT codigo, descricao, tipo
	FROM dbb.Equipamento
	WHERE hidden = 0
go

go
CREATE VIEW Preco
as
	SELECT validade, valor, idEquipamento
	FROM dbb.Preco
	WHERE hidden = 0
go

go
CREATE VIEW Empregado
as
	SELECT numero, nome
	FROM dbb.Empregado
	WHERE hidden = 0
go

go
CREATE VIEW Cliente
as
	SELECT numero, nome, nif, morada
	FROM dbb.Cliente
	WHERE hidden = 0
go

go
CREATE VIEW Promocao
as
	SELECT id, dataInicio, dataFim, descricao, tipo
	FROM dbb.Promocao
	WHERE hidden = 0
go

go
CREATE VIEW Aluguer_Promocao
as
	SELECT nSerieAluguer, idPromocao
	FROM dbb.Aluguer_Promocao
	WHERE hidden = 0
go

go
CREATE VIEW Aluguer_Equipamento
as
	SELECT nSerieAluguer, codigoEquipamento
	FROM dbb.Aluguer_Equipamento
	WHERE hidden = 0
go

go
CREATE VIEW Aluguer
as
	SELECT nSerie, dataInicio, dataFim, tipo, preco, nEmpregado, nCliente 
	FROM dbb.Aluguer
	WHERE hidden = 0
go

insert into Cliente values (null, null, null);