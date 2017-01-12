use SI2;

--2c
-- CLIENTE PROCEDURES
go
create procedure Insert_Cliente
	@nome VARCHAR(64),
	@nif NUMERIC(9),
	@morada VARCHAR(64) 

	as
	insert into Cliente Values (@nome, @nif, @morada)
go



go
create procedure Update_Cliente
	@numero INT,
	@nome VARCHAR(64),
	@nif NUMERIC(9),
	@morada VARCHAR(64) 

	as
	if (@numero <> 1)
	begin
		Update Cliente 
		set nome = @nome, nif = @nif, morada = @morada
		where numero = @numero
	end
go


go
create procedure Remove_Cliente
	@numero INT

	as
	if (@numero <> 1)
	begin
		DELETE FROM Cliente WHERE numero = @numero;
	end
go

----------------****  Trigger
IF OBJECT_ID('Delete_Cliente_Trigger', 'TR') IS NOT NULL DROP TRIGGER Delete_Cliente_Trigger

go
create trigger Delete_Cliente_Trigger on Cliente 
instead of delete
as
	if (select COUNT(*) from deleted inner join Aluguer on numero = nCliente) = 0
		DELETE FROM Cliente WHERE (select numero from deleted) = numero;
	
	else UPDATE dbb.Cliente set hidden = 1 where numero = (select numero from deleted);
go
----------------****

--2d
-- EQUIPAMENTO PROCEDURES

go
create procedure Insert_Equipamento
	@Descricao VARCHAR(128),
	@tipo VARCHAR(64)

as
	
	insert into Equipamento Values (@Descricao, @tipo);
go


go
create procedure Update_Equipamento
	@codigo INT ,
	@Descricao VARCHAR(128),
	@tipo VARCHAR(64)  

as
	Update Equipamento
	set Descricao = @Descricao, tipo = @tipo
	where codigo = @codigo
go

go
create procedure Remove_Equipamento
	@codigo INT

as
	DELETE FROM Equipamento WHERE codigo = @codigo;
go
----------------****  Trigger
IF OBJECT_ID('Delete_Equipamento_Trigger', 'TR') IS NOT NULL DROP TRIGGER Delete_Equipamento_Trigger;

go
create trigger Delete_Equipamento_Trigger on Equipamento
instead of delete
as
	if (select count(*) from Aluguer_Equipamento inner join deleted on codigo = codigoEquipamento) = 0
		delete from Equipamento where codigo = (select codigo from deleted);

	else 
		UPDATE dbb.Equipamento set hidden = 1 where codigo = (select codigo from deleted);
go
----------------****

--2e
-- PROMO��ES PROCEDURES

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
	@dataInicio DATE = null,
	@dataFim DATE = null,
	@descricao VARCHAR(128) = null,
	@tipo VARCHAR(8) = null

as
	begin tran
		begin try
		IF @dataInicio is not null
		begin
			update Promocao
			set dataInicio = @dataInicio
			where id = @id
		end

		IF @dataFim is not null
		begin
			update Promocao
			set dataFim = @dataFim
			where id = @id
		end

		IF @descricao is not null
			begin
				update Promocao
				set descricao = @descricao
				where id = @id
			end
		IF @tipo is not null
			begin
				update Promocao
				set tipo = @tipo
				where id = @id
			end
		commit
		end try

		begin catch
			rollback
		end catch
	
go


go
create procedure Remove_Promocao
	@id INT

as
	DELETE FROM Promocao WHERE id = @id;
go

----------------****  Trigger
IF OBJECT_ID('Delete_Promocao_Trigger', 'TR') IS NOT NULL DROP TRIGGER Delete_Promocao_Trigger;

go
create trigger Delete_Promocao_Trigger on Promocao
instead of delete
as
	if (select count(*) from deleted inner join Aluguer_Promocao on id = idPromocao) = 0
		delete from promocao where id = (select id from deleted);

	else 
	update dbb.Promocao set hidden = 1 where id = (select id from deleted);
go
----------------****

-- 2g
-- Inserir aluguer

go
create procedure Insert_Aluguer_Com_Cliente
	--dados cliente
	@idCliente INT,

	--dados aluguer
	@dataInicio DATETIME,
	@dataFim DATE,
	@tipo INT,
	@preco MONEY,
	@nEmpregado INT
as

	insert into Aluguer values (@dataInicio, @dataFim, @tipo, @preco, @nEmpregado, @idCliente);
	

go

-- 2f
-- Inserir aluguer + Cliente

go
create procedure Insert_Aluguer_Sem_Cliente
	--dados cliente
	@nomeCliente VARCHAR(64),
	@nifCliente NUMERIC(9),
	@moradaCliente VARCHAR(64),

	--dados aluguer
	@dataInicio DATETIME,
	@dataFim DATE,
	@tipo INT, --duracao
	@preco MONEY,
	@nEmpregado INT
as
	set transaction isolation level REPEATABLE READ
	begin tran

		begin try
			exec Insert_Cliente @nomeCliente, @nifCliente, @moradaCliente;

			declare @idCliente INT = @@IDENTITY;

			exec Insert_Aluguer_Com_Cliente @idCliente, @dataInicio, @dataFim, @tipo, @preco, @nEmpregado;

			commit
		end try

	begin catch
		rollback
	end catch

	return
	
go

-- 2h
-- Remover Aluguer
go
create procedure Remove_Aluguer
	@nSerie int
	as
	delete from Aluguer where nSerie = @nSerie;
go

if OBJECT_ID('Delete_Aluguer_Trigger', 'TR') IS NOT NULL DROP TRIGGER Delete_Aluguer_Trigger;
go
create trigger Delete_Aluguer_Trigger on Aluguer
instead of delete
as
	set transaction isolation level REPEATABLE READ
	begin tran
		
		begin try
			select distinct deleted.nSerie into #okToDelete
				from deleted inner join Aluguer
				on deleted.nSerie = Aluguer.nSerie
				where Aluguer.dataInicio > GETDATE();

			if (select count(*) from #okToDelete) <> 0 AND
			(select COUNT(*) from #okToDelete inner join Aluguer_Equipamento on nSerie = nSerieAluguer) = 0 AND 
			(select COUNT(*) from #okToDelete inner join Aluguer_Promocao on nSerie = nSerieAluguer) = 0
				delete t1 from Aluguer t1 inner join #okToDelete t2 on t1.nSerie = t2.nSerie;

			else 
				begin
					update dbb.Aluguer_Equipamento set hidden = 1
						from dbb.Aluguer_Equipamento inner join deleted
						on nSerieAluguer = nSerie where nSerieAluguer = nSerie;

					update dbb.Aluguer_Promocao set hidden = 1
						from dbb.Aluguer_Promocao inner join deleted
						on nSerieAluguer = nSerie where nSerieAluguer = deleted.nSerie;

					update dbb.Aluguer set hidden = 1 
						from dbb.Aluguer inner join deleted
						on dbb.Aluguer.nSerie = deleted.nSerie where dbb.Aluguer.nSerie = deleted.nSerie;
				end
			commit
		end try

		begin catch
			rollback
		end catch
			
go

-- 2i
-- Alterar pre�ario

go
create procedure Add_Preco
	@idEquipamento INT,
	@validade INT,
	@valor MONEY
as

	if (select COUNT(*) from Preco where idEquipamento = @idEquipamento AND validade = @validade) = 0
		insert into Preco values (@validade, @valor, @idEquipamento);

	else 
		update Preco set valor = @valor where idEquipamento = @idEquipamento AND validade = @validade
		
go

-- 2j
-- Listar todos os equipamentos livres, para um determinado tempo e tipo

go
create procedure ListEquipamentosLivres
	@tipo varchar(128),
	@tempo int
as
	select codigo, descricao
	from Equipamento
	where tipo = @tipo
	EXCEPT
	select codigo, descricao
	from (select * 
		from (select * 
			from Equipamento 
			where tipo = @tipo) as t1 inner join Aluguer_Equipamento
		on codigo = codigoEquipamento) as t2 inner join Aluguer
	on nSerie = nSerieAluguer AND Aluguer.tipo = @tempo
	where GETDATE() between dataInicio AND dataFim
go



-- 2k
-- Listar os equipamentos sem alugueres na �ltima semana;
go
create procedure ListNaoUsadosSemana
as
	select codigo, descricao, tipo
	from Equipamento inner join (
		select codigoEquipamento
		from (select *
			from Aluguer
			where dataInicio > GETDATE() - 7 AND dataInicio < GETDATE()) as t1 inner join Aluguer_Equipamento
		on nSerie = nSerieAluguer) as t2
	on codigo <> codigoEquipamento
go

--extra
--Listar os alugueres entre datas



go
create procedure ListAlugueresBetween
	@dataInicio DATE,
	@dataFim DATE
as
	select nSerie, tipoEquipamento, nCliente, codigo, dataInicio, dataFim
	from Aluguer inner join (
		(select nSerieAluguer, codigo, tipo as tipoEquipamento
		from Aluguer_Equipamento inner join Equipamento on codigo = codigoEquipamento)) as t1
	on nSerie = nSerieAluguer
	where (dataInicio between @dataInicio AND @dataFim) AND (dataFim between @dataInicio AND @dataFim)
go
