CREATE DATABASE Tarea3_Lenguajes

USE Tarea3_Lenguajes

CREATE TABLE Producto
(
	idProducto INT PRIMARY KEY
	, nombre NVARCHAR(MAX)
	, precio DECIMAL
)

CREATE TABLE ListaDeseados
(
	idListaDeseado INT PRIMARY KEY
	, idProducto INT
	, cantidad INT
	, CONSTRAINT FK_ListaDeseados_Producto FOREIGN KEY (idProducto) REFERENCES Producto(idProducto)
)

--INSERTS
INSERT INTO Producto (idProducto, nombre, precio) VALUES
(1, 'Camisa', 25.99),
(2, 'Pantalón', 39.99),
(3, 'Zapatos', 49.99),
(4, 'Sombrero', 14.99),
(5, 'Chaqueta', 69.99),
(6, 'Bufanda', 12.50),
(7, 'Guantes', 9.99);

INSERT INTO ListaDeseados (idListaDeseado, idProducto, cantidad) VALUES
(1, 1, 2),
(2, 3, 1),
(3, 2, 3),
(4, 4, 2),
(5, 5, 1),
(6, 7, 2);


--DROPS
DROP TABLE ListaDeseados
DROP TABLE Producto