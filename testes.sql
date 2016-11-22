-- TESTES DE OP��ES CRIADAS

	-- CLIENTE

	select * from Cliente;
	
	exec Insert_Cliente 0,'Jo�o',123456789,'morada qq';
	exec Update_Cliente 0,'Ant�nio',123123123,'quinta da madragoa';
	exec Remove_Cliente 0;

	-- EQUIPAMENTO

	select * from Tipo;
	Insert into Tipo values ('Canoa','descricao');

	select * from Equipamento;

	exec Insert_Equipamento 0,'descri��o','Canoa';
	exec Update_Equipamento 0,'descri��o2','Canoa';
	exec Remove_Equipamento 0;


	-- Promo�oes

	select * from Promocao;
	
	exec Insert_Promocao '01-01-2016', '01-02-2016', 'descri��o', 'tempo';
	exec Update_Promocao 1, '01-01-2015', '01-02-2015', 'descri��o2', 'tempo';
	exec Remove_Promocao 1;


	-- Inserts

	insert into Empregado values (1, 'ze');
	insert into Cliente values (1, null, null, null);
	insert into Promocao values (GETDATE(), GETDATE(), 'desc', 'tempo');
	insert into Tipo_Equipamento values ('nometipo', 'desc');
	insert into Equipamento values (1,'desc','nometipo');
	insert into Equipamento values (2,'desc2','nometipo');

	insert into Aluguer values (1, GETDATE() ,	GETDATE() ,	1 ,	1 , 1, 1);
	insert into Aluguer_Equipamento values (1, 1, 2);
	insert into Aluguer_Equipamento values (1, 2, 2);
	insert into Preco values (30, 1, 1);