-- TESTES DE OPÇÔES CRIADAS

	-- CLIENTE

	select * from Cliente;
	
	exec Insert_Cliente 0,'João',123456789,'morada qq';
	exec Update_Cliente 0,'António',123123123,'quinta da madragoa';
	exec Remove_Cliente 0;

	-- EQUIPAMENTO

	select * from Tipo;
	Insert into Tipo values ('Canoa','descricao');

	select * from Equipamento;

	exec Insert_Equipamento 0,'descrição','Canoa';
	exec Update_Equipamento 0,'descrição2','Canoa';
	exec Remove_Equipamento 0;


	-- Promoçoes

	select * from Promocao;
	
	exec Insert_Promocao '01-01-2016', '01-02-2016', 'descrição', 'tempo';
	exec Update_Promocao 1, '01-01-2015', '01-02-2015', 'descrição2', 'tempo';
	exec Remove_Promocao 1;