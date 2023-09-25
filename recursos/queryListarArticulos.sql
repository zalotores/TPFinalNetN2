
USE CATALOGO_DB;

SELECT * FROM ARTICULOS;

SELECT * FROM CATEGORIAS;

SELECT * FROM MARCAS;

--comando para listar--

SELECT A.Id, Codigo AS Código, C.Descripcion AS Categoría, M.Descripcion AS Marca, Nombre, A.Descripcion as Descripción, Precio, ImagenUrl, 
IdMarca, IdCategoria FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id;

--comando para agregar--

INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio ) VALUES ('001', 'Prueba1', 'Otra prueba', 1, 1, '', 1.1);

--comando para update--

UPDATE ARTICULOS SET Codigo = '@', Nombre = '@', Descripcion = '@', IdMarca = 1, IdCategoria = 1, ImagenUrl = '@', Precio = 0 WHERE Id = 14; 

--comando para delete--

DELETE FROM ARTICULOS WHERE Id = 12;

