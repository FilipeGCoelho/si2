use SI2;

--go
--create procedure insert_aluguer
--	@nSerie INT,
--	@dataInicio DATETIME NOT NULL,
--	@dataFim DATE,
--	@tipo INT NOT NULL,
--	@preco MONEY NOT NULL,
--	@nEmpregado INT,
--	@nCliente INT
	
--	as
--	exec Insert_Cliente
--	insert into Aluguer values (@nSerie, @dataInicio, @dataFim, @tipo, @preco, @nEmpregado, @nCliente);

------------------------------------------(h)


go
create procedure Remove_Aluguer
	@nSerie int
	as
	delete from Aluguer_Equipamento where @nSerie = nSerie;
	delete from Aluguer where nSerie = @nSerie;
go
	
go
create procedure Alter_Preco
	@validade int,
	@idEquipamento int,
	@valor money
	as
	update Preco
	set 
		valor = @valor
	where validade = @validade and idEquipamento = @idEquipamento
go