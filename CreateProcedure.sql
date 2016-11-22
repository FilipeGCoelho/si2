-- CLIENTE PROCEDURES

go
create procedure Insert_Cliente
	@numero INT,
	@nome VARCHAR(64),
	@nif NUMERIC(9),
	@morada VARCHAR(64) 

	as
	insert into Cliente Values (@numero,@nome, @nif, @morada)

go


go
create procedure Update_Cliente
	@numero INT,
	@nome VARCHAR(64),
	@nif NUMERIC(9),
	@morada VARCHAR(64) 

	as
	Update Cliente 
	set nome = @nome, nif = @nif, morada = @morada
	where numero = @numero
go


go
create procedure Remove_Cliente
	@numero INT

	as
	DELETE FROM Cliente WHERE numero = @numero;
go


-- EQUIPAMENTO PROCEDURES

go
create procedure Insert_Equipamento
	@id INT ,
	@Descricao VARCHAR(128),
	@tipo VARCHAR(64) 

	as
	insert into Equipamento Values (@id, @Descricao, @tipo);

go


go
create procedure Update_Equipamento
	@id INT ,
	@Descricao VARCHAR(128),
	@tipo VARCHAR(64)  

	as
	Update Equipamento
	set Descricao = @Descricao, tipo = @tipo
	where id = @id
go


go
create procedure Remove_Equipamento
	@id INT

	as
	DELETE FROM Equipamento WHERE id = @id;
go


-- PROMOÇÔES PROCEDURES

go
create procedure Insert_Promocao
	@dataInicio DATE,
	@dataFim DATE,
	@descricao VARCHAR(128),
	@tipo VARCHAR(8)

	as
	insert into Promocao Values (@dataInicio, @dataFim, @descricao, @tipo);

go


go
create procedure Update_Promocao
	@id INT,
	@dataInicio DATE,
	@dataFim DATE,
	@descricao VARCHAR(128),
	@tipo VARCHAR(8)

	as
	Update Promocao
	set datainicio = @datainicio,  dataFim = @dataFim, descricao = @Descricao, tipo = @tipo
	where id = @id

go


go
create procedure Remove_Promocao
	@id INT

	as
	DELETE FROM Promocao WHERE id = @id;
go