-- TESTES DE OP��ES CRIADAS

	-- CLIENTE

	select * from Cliente;
	
	exec Create_Cliente 0,'Jo�o',123456789,'morada qq';
	exec Update_Cliente 0,'Ant�nio',123123123,'quinta da madragoa';
	exec Remove_Cliente 0;

	-- EQUIPAMENTO

	select * from Equipamento;
