-- TESTES DE OPÇÔES CRIADAS

	-- CLIENTE

	select * from Cliente;
	select * from dbb.Cliente;
	select * from aluguer;
	
	exec Insert_Cliente 0,'João',123456789,'morada qq';
	exec Update_Cliente 1,'António',123123123,'quinta da madragoa';
	exec Remove_Cliente 0;

	-- EQUIPAMENTO

	select * from Tipo;
	Insert into Tipo values ('Canoa','descricao');

	select * from Equipamento;
	select * from Aluguer_Equipamento;

	exec Insert_Equipamento 3,'descrição','Canoa';
	exec Update_Equipamento 0,'descrição2','Canoa';
	exec Remove_Equipamento 3;
	
	select * from Equipamento;
	select * from dbb.Equipamento;
	select * from Aluguer_Equipamento;


	-- Promoçoes

	select * from Promocao;
	select * from Aluguer_Equipamento
	
	exec Insert_Promocao '01-01-2016', '01-02-2016', 'descrição', 'tempo';
	exec Update_Promocao 1, '01-01-2015', '01-02-2015', 'descrição2', 'tempo';
	exec Remove_Promocao 3;
	
	select * from Promocao;
	select * from dbb.Promocao;
	select * from Aluguer_Equipamento


	-- Inserts
	use si2;

	insert into Empregado values ('ze');
	insert into Cliente values (null, null, null);
	insert into Promocao values (GETDATE(), GETDATE(), 'desc', 'tempo');
	insert into Tipo values ('nometipo', 'desc');
	insert into Equipamento values ('desc','nometipo');
	insert into Equipamento values ('desc2','nometipo');

	insert into Aluguer values ('2018-01-01', '2019-01-01', 1, 1, 1, 1);
	insert into Aluguer values ('2018-01-01', '2019-01-01', 1, 1, 1, 1);
	insert into Aluguer values (GETDATE(), GETDATE() + 1000, 1, 1, 1, 1);
	insert into Aluguer_Equipamento values (1, 1);
	insert into Aluguer_Equipamento values (1, 2);
	insert into Aluguer_Equipamento values (3, 1);
	insert into Aluguer_Promocao values (1,1);
	insert into Preco values (30, 1, 1);