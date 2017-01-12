use SI2;

----------2C

-- insert

select * from Cliente
exec Insert_Cliente 'toze das quintas', 111111111, 'quinta do toze'
select * from Cliente

-- update

select * from Cliente
exec Update_CLiente 1, 'novo nome', 777777777, 'nova morada'
exec Update_CLiente 3, 'novo nome', 777777777, 'nova morada'
select * from Cliente

-- remove

select * from Cliente
exec Remove_Cliente 2
select * from Cliente
select * from dbb.Cliente

----------2D

-- insert

select * from Equipamento
exec Insert_Equipamento 'desc teste', 'nometipo'
select * from Equipamento

-- update

select * from Equipamento
exec Update_Equipamento 1, 'toma', 'nometipo'
select * from Equipamento

-- remove

select * from Equipamento
exec Remove_Equipamento 1
select * from Equipamento
select * from dbb.Equipamento

----------2E

-- insert

select * from Promocao
exec Insert_Promocao '2016-01-01' , '2018-01-01', 'descPromo teste', 'desconto'
select * from Promocao

-- update

select * from Promocao
exec Update_Promocao 1, '2016-01-01' , '2018-01-01', 'descPromo teste', 'desconto'
select * from Promocao

-- remove

select * from Promocao
exec Remove_Promocao 1
select * from Promocao
select * from dbb.Promocao

----------2F e G
-- um procedimento usa o outro

select * from Cliente
select * from Aluguer
exec Insert_Aluguer_Sem_Cliente 
	'nome', 123123123, 'morada',
	'2016-01-01', '2018-01-01', 30, 10, 1
select * from Cliente
select * from Aluguer
select * from Empregado


----------2H

select * from Aluguer
exec Remove_Aluguer 1
exec Remove_Aluguer 2
select * from dbb.Aluguer
select * from dbb.Aluguer_Equipamento
select * from dbb.Aluguer_Promocao
-- nota que para o remove 1 escondeu tudo o que estava em aluguer,
-- aluguer_promocao e aluguer_equipamento

-- para o remove 2 ja apagou pois a data de inicio ainda nao tinha
-- acontecido e nao tinha nenhuma dependencia noutra tabela

----------2J

exec ListEquipamentosLivres 'nometipo', 1

----------2K

exec ListNaoUsadosSemana