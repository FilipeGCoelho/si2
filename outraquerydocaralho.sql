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


--insert into Empregado values (1, 'ze');
--insert into Cliente values (1, null, null, null);
--insert into Promocao values (GETDATE(), GETDATE(), 'desc', 'tempo');
--insert into Tipo_Equipamento values ('nometipo', 'desc');
--insert into Equipamento values (1,'desc','nometipo');
--insert into Equipamento values (2,'desc2','nometipo');

--insert into Aluguer values (1, GETDATE() ,	GETDATE() ,	1 ,	1 , 1, 1);
--insert into Aluguer_Equipamento values (1, 1, 2);
--insert into Aluguer_Equipamento values (1, 2, 2);
--insert into Preco values (30, 1, 1);

--select * from Aluguer;
--select * from Aluguer_Equipamento;
--exec Remove_Aluguer 1;
--select * from Aluguer;
--select * from Aluguer_Equipamento;
	