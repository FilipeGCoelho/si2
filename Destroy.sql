USE SI2

IF OBJECT_ID('dbb.Aluguer_Equipamento', 'U') IS NOT NULL DROP TABLE dbb.Aluguer_Equipamento;
IF OBJECT_ID('dbb.Aluguer_Promocao', 'U') IS NOT NULL DROP TABLE dbb.Aluguer_Promocao;
IF OBJECT_ID('dbb.Preco', 'U') IS NOT NULL DROP TABLE dbb.Preco;
IF OBJECT_ID('dbb.Aluguer', 'U') IS NOT NULL DROP TABLE dbb.Aluguer;
IF OBJECT_ID('dbb.Promocao', 'U') IS NOT NULL DROP TABLE dbb.Promocao;
IF OBJECT_ID('dbb.Empregado', 'U') IS NOT NULL DROP TABLE dbb.Empregado;
IF OBJECT_ID('dbb.Cliente', 'U') IS NOT NULL DROP TABLE dbb.Cliente;
IF OBJECT_ID('dbb.Equipamento', 'U') IS NOT NULL DROP TABLE dbb.Equipamento;
IF OBJECT_ID('dbb.Tipo', 'U') IS NOT NULL DROP TABLE dbb.Tipo;

IF OBJECT_ID('Aluguer_Equipamento', 'V') IS NOT NULL DROP VIEW Aluguer_Equipamento;
IF OBJECT_ID('Aluguer_Promocao', 'V') IS NOT NULL DROP VIEW Aluguer_Promocao;
IF OBJECT_ID('Preco', 'V') IS NOT NULL DROP VIEW Preco;
IF OBJECT_ID('Aluguer', 'V') IS NOT NULL DROP VIEW Aluguer;
IF OBJECT_ID('Promocao', 'V') IS NOT NULL DROP VIEW Promocao;
IF OBJECT_ID('Empregado', 'V') IS NOT NULL DROP VIEW Empregado;
IF OBJECT_ID('Cliente', 'V') IS NOT NULL DROP VIEW Cliente;
IF OBJECT_ID('Equipamento', 'V') IS NOT NULL DROP VIEW Equipamento;
IF OBJECT_ID('Tipo', 'V') IS NOT NULL DROP VIEW Tipo;

IF OBJECT_ID('Insert_Cliente', 'P') IS NOT NULL DROP PROC Insert_Cliente
IF OBJECT_ID('Update_Cliente', 'P') IS NOT NULL DROP PROC Update_Cliente
IF OBJECT_ID('Remove_Cliente', 'P') IS NOT NULL DROP PROC Remove_Cliente

IF OBJECT_ID('Insert_Equipamento', 'P') IS NOT NULL DROP PROC Insert_Equipamento
IF OBJECT_ID('Update_Equipamento', 'P') IS NOT NULL DROP PROC Update_Equipamento
IF OBJECT_ID('Remove_Equipamento', 'P') IS NOT NULL DROP PROC Remove_Equipamento

IF OBJECT_ID('Insert_Promocao', 'P') IS NOT NULL DROP PROC Insert_Promocao
IF OBJECT_ID('Update_Promocao', 'P') IS NOT NULL DROP PROC Update_Promocao
IF OBJECT_ID('Remove_Promocao', 'P') IS NOT NULL DROP PROC Remove_Promocao

IF OBJECT_ID('Insert_Aluguer_Sem_Cliente', 'P') IS NOT NULL DROP PROC Insert_Aluguer_Sem_Cliente;
IF OBJECT_ID('Insert_Aluguer_Com_Cliente', 'P') IS NOT NULL DROP PROC Insert_Aluguer_Com_Cliente;
IF OBJECT_ID('Remove_Aluguer', 'P') IS NOT NULL DROP PROC Remove_Aluguer;
IF OBJECT_ID('Add_Preco', 'P') IS NOT NULL DROP PROC Add_Preco;
IF OBJECT_ID('ListNaoUsadosSemana', 'P') IS NOT NULL DROP PROC ListNaoUsadosSemana
IF OBJECT_ID('ListEquipamentosLivres', 'P') IS NOT NULL DROP PROC ListEquipamentosLivres;
IF OBJECT_ID('ListAlugueresBetween', 'P') IS NOT NULL DROP PROC ListAlugueresBetween;

IF SCHEMA_ID('dbb') IS NOT NULL DROP SCHEMA dbb;

IF OBJECT_ID('Delete_Promocao_Trigger', 'TR') IS NOT NULL DROP TRIGGER Delete_Promocao_Trigger;
IF OBJECT_ID('Delete_Equipamento_Trigger', 'TR') IS NOT NULL DROP TRIGGER Delete_Equipamento_Trigger;
IF OBJECT_ID('Delete_Cliente_Trigger', 'TR') IS NOT NULL DROP TRIGGER Delete_Cliente_Trigger
