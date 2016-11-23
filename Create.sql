USE SI2

GO
CREATE SCHEMA dbb;
GO

CREATE TABLE dbb.Tipo (
	nome VARCHAR(64) PRIMARY KEY,
	descricao VARCHAR(128) NOT NULL,
	hidden bit default 0 NOT NULL
)

CREATE TABLE dbb.Equipamento (
	id INT PRIMARY KEY,
	descricao VARCHAR(128) NOT NULL,
	tipo VARCHAR(64) FOREIGN KEY REFERENCES Tipo,
	hidden bit default 0 NOT NULL
)

CREATE TABLE dbb.Preco (
	validade INT NOT NULL,
	valor MONEY NOT NULL,
	idEquipamento INT FOREIGN KEY REFERENCES Equipamento,
	hidden bit default 0 NOT NULL,
	PRIMARY KEY (validade, idEquipamento)
	
)

CREATE TABLE dbb.Empregado (
	numero INT PRIMARY KEY,
	nome VARCHAR(32) NOT NULL,
	hidden bit default 0 NOT NULL
)

CREATE TABLE dbb.Cliente (
	numero INT PRIMARY KEY,
	nome VARCHAR(64),
	nif NUMERIC(9),
	morada VARCHAR(64),
	hidden bit default 0 NOT NULL
)

CREATE TABLE dbb.Aluguer (
	nSerie INT PRIMARY KEY,
	dataInicio DATETIME NOT NULL,
	dataFim DATE,
	tipo INT NOT NULL,
	preco MONEY NOT NULL,
	nEmpregado INT FOREIGN KEY REFERENCES Empregado,
	nCliente INT FOREIGN KEY REFERENCES Cliente,
	hidden bit default 0 NOT NULL
)

CREATE TABLE dbb.Promocao (
	id INT IDENTITY(1,1) PRIMARY KEY,
	dataInicio DATE NOT NULL,
	dataFim DATE NOT NULL,
	descricao VARCHAR(128) NOT NULL,
	tipo VARCHAR(8) NOT NULL,
	hidden bit default 0 NOT NULL,
	CONSTRAINT CheckTipo CHECK (tipo = 'tempo' OR tipo = 'desconto')
)

CREATE TABLE dbb.Aluguer_Equipamento (
	nSerie INT FOREIGN KEY REFERENCES Aluguer,
	codigo INT FOREIGN KEY REFERENCES Equipamento,
	idPromocao INT FOREIGN KEY REFERENCES Promocao,
	hidden bit default 0 NOT NULL,
	PRIMARY KEY (nSerie, Codigo)
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
	SELECT id, descricao, tipo
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
	SELECT numero, nome, nuf, morada
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
CREATE VIEW Aluguer_Equipamento
as
	SELECT nSerie, codigo, idPromocao
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