SELECT * FROM ARTICULOS;

SELECT * FROM CATEGORIAS;

SELECT * FROM MARCAS;

SELECT A.Id, Codigo AS C�digo, C.Descripcion AS Categor�a, M.Descripcion AS Marca, Nombre, A.Descripcion as Descripci�n, Precio, ImagenUrl, 
IdMarca, IdCategoria FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id;