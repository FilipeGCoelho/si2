USE SI2

IF OBJECT_ID('Aluguer_Equipamento') IS NOT NULL DROP TABLE Aluguer_Equipamento
IF OBJECT_ID('Preco') IS NOT NULL DROP TABLE Preco
IF OBJECT_ID('Aluguer') IS NOT NULL DROP TABLE Aluguer
IF OBJECT_ID('Promocao') IS NOT NULL DROP TABLE Promocao
IF OBJECT_ID('Empregado') IS NOT NULL DROP TABLE Empregado
IF OBJECT_ID('Cliente') IS NOT NULL DROP TABLE Cliente
IF OBJECT_ID('Equipamento') IS NOT NULL DROP TABLE Equipamento
IF OBJECT_ID('Tipo_Equipamento') IS NOT NULL DROP TABLE Tipo_Equipamento

IF OBJECT_ID('Insert_Cliente') IS NOT NULL DROP PROC Insert_Cliente
IF OBJECT_ID('Update_Cliente') IS NOT NULL DROP PROC Update_Cliente
IF OBJECT_ID('Remove_Cliente') IS NOT NULL DROP PROC Remove_Cliente

IF OBJECT_ID('Insert_Equipamento') IS NOT NULL DROP PROC Insert_Equipamento
IF OBJECT_ID('Update_Equipamento') IS NOT NULL DROP PROC Update_Equipamento
IF OBJECT_ID('Remove_Equipamento') IS NOT NULL DROP PROC Remove_Equipamento

IF OBJECT_ID('Insert_Promocao') IS NOT NULL DROP PROC Insert_Promocao
IF OBJECT_ID('Update_Promocao') IS NOT NULL DROP PROC Update_Promocao
IF OBJECT_ID('Remove_Promocao') IS NOT NULL DROP PROC Remove_Promocao