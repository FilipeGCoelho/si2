use SI2

CREATE TABLE Tipo_Equipamento (
	nome VARCHAR(64) PRIMARY KEY,
	descricao VARCHAR(128) NOT NULL
)

CREATE TABLE Equipamento (
	id INT PRIMARY KEY,
	Descricao VARCHAR(128) NOT NULL,
	tipo VARCHAR(64) FOREIGN KEY REFERENCES Tipo_Equipamento
)

CREATE TABLE Preco (
	validade INT NOT NULL,
	valor MONEY NOT NULL,
	idEquipamento INT FOREIGN KEY REFERENCES Equipamento,
	PRIMARY KEY (validade,valor)
)

CREATE TABLE Aluguer (
	nSerie INT PRIMARY KEY,
	dataInicio DATETIME NOT NULL,
	dataFim DATE,
	tipo INT NOT NULL,
	preco MONEY NOT NULL
)

CREATE TABLE Promocao (
	id INT IDENTITY(1,1) PRIMARY KEY,
	dataInicio DATE NOT NULL,
	dataFIm DATE NOT NULL,
	descricao VARCHAR(128) NOT NULL,
	tipo VARCHAR(8) NOT NULL,
	CONSTRAINT CheckTipo CHECK (tipo = 'tempo' OR tipo = 'desconto')
)

CREATE TABLE Aluguer_Equipamento (
	nSerie INT FOREIGN KEY REFERENCES Aluguer,
	Codigo INT FOREIGN KEY REFERENCES Equipamento,
	idPromocao INT FOREIGN KEY REFERENCES Promocao,
	PRIMARY KEY (nSerie, Codigo)
)

CREATE TABLE Empregado (
	numero INT PRIMARY KEY,
	nome VARCHAR(32) NOT NULL
)

CREATE TABLE Cliente (
	numero INT PRIMARY KEY,
	nome VARCHAR(64),
	nif NUMERIC(9),
	morada VARCHAR(64)
)