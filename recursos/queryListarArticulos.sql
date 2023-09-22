SELECT * FROM ARTICULOS;

SELECT * FROM CATEGORIAS;

SELECT * FROM MARCAS;

SELECT A.Id, Codigo AS Código, C.Descripcion AS Categoría, M.Descripcion AS Marca, Nombre, A.Descripcion as Descripción, Precio, ImagenUrl, 
IdMarca, IdCategoria FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id;