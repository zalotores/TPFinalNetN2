
USE CATALOGO_DB;

SELECT * FROM ARTICULOS;

SELECT * FROM CATEGORIAS;

SELECT * FROM MARCAS;

--comando para listar--

SELECT A.Id, Codigo AS C�digo, C.Descripcion AS Categor�a, M.Descripcion AS Marca, Nombre, A.Descripcion as Descripci�n, Precio, ImagenUrl, 
IdMarca, IdCategoria FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id;

--comando para agregar--

INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio ) VALUES ('001', 'Prueba1', 'Otra prueba', 1, 1, '', 1.1);

