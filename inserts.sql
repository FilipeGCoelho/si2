
use si2;

insert into Empregado values ('ze');
insert into Cliente values ('Manel', 123456789, 'Casa Do Manel');
insert into Promocao values (GETDATE(), GETDATE(), 'desc', 'tempo');
insert into Tipo values ('casa', 'desc');
insert into Tipo values ('barco', 'desc');
insert into Equipamento values ('desc','casa');
insert into Equipamento values ('desc2','barco');

insert into Aluguer values ('2018-01-01', '2019-01-01', 1, 1, 1, 2);
insert into Aluguer values ('2018-01-01', '2019-01-01', 1, 1, 1, 2);
insert into Aluguer values (GETDATE(), GETDATE() + 1000, 1, 1, 1, 2);
insert into Aluguer_Equipamento values (1, 1);
insert into Aluguer_Equipamento values (1, 2);
insert into Aluguer_Equipamento values (3, 1);
insert into Aluguer_Promocao values (1,1);
insert into Preco values (30, 1, 1);