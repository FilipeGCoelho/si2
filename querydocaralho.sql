USE SI2

--Cliente----------------------------------

--Inserir
SET TRAN ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	INSERT INTO Cliente VALUES (0, null, null, null)
COMMIT
SELECT * FROM Cliente

--Actualizar
SET TRAN ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	UPDATE Cliente 
		SET 
			nome = 'Ze',
			nif = 123456789,
			morada = 'Rua das Couves'
		WHERE numero = 0;
COMMIT
SELECT * FROM Cliente

--Remover
SET TRAN ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	IF OBJECT_ID('Cliente') IS NOT NULL DELETE FROM Cliente WHERE numero = 0;
COMMIT
SELECT * FROM Cliente


--Equipamento----------------------------------

--Inserir
SET TRAN ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	INSERT INTO Tipo_Equipamento VALUES ('bananas gigantes', 'daquelas bem maduras');
	INSERT INTO Equipamento VALUES (0, 'sao mesmo grandes', 'bananas gigantes');
COMMIT
SELECT * FROM Equipamento

--Actualizar
SET TRAN ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	UPDATE Equipamento 
		SET descricao = 'afinal ate sao pequenas'
		WHERE id = 0;
COMMIT
SELECT * FROM Equipamento

--Remover
SET TRAN ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	IF OBJECT_ID('Equipamento') IS NOT NULL DELETE FROM Equipamento WHERE id = 0;
COMMIT
SELECT * FROM Equipamento

--Promocao----------------------------------

--Inserir
SET TRAN ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	INSERT INTO Promocao VALUES (GETDATE(), GETDATE(), 'E TUDO A BORLA', 'tempo');
COMMIT
SELECT * FROM Promocao

--Actualizar
SET TRAN ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	UPDATE Promocao 
		SET tipo = 'desconto'
		WHERE tipo = 'tempo';
COMMIT
SELECT * FROM Promocao

--Remover
SET TRAN ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	IF OBJECT_ID('Promocao') IS NOT NULL DELETE FROM Promocao;
COMMIT
SELECT * FROM Promocao