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