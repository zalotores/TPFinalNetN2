using DataBase;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos con = new AccesoDatos();
            string query = "SELECT A.Id, Codigo AS Código, C.Descripcion AS Categoría, " +
                "M.Descripcion AS Marca, Nombre, A.Descripcion as Descripción, Precio, " +
                "ImagenUrl, IdMarca, IdCategoria FROM ARTICULOS A, CATEGORIAS C, MARCAS M " +
                "WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id;";

            try
            {
                con.setConsulta(query);
                con.ejecutarQuery();

                while (con.Reader.Read())
                {
                    Articulo articulo = new Articulo();
                    //TODO corregir bug en codigoArticulo
                    articulo.Id = (int)con.Reader["Id"];
                    articulo.CodigoArticulo =  int.Parse((string)con.Reader["Codigo"]);
                    articulo.Nombre = (string)con.Reader["Nombre"];
                    articulo.Descripcion = (string)con.Reader["A.Descripcion"];
                    articulo.Marca = new Marca { Descripcion = (string)con.Reader["M.Descripcion"] };
                    articulo.Categoria = new Categoria { Descripcion = (string)con.Reader["C.Descripcion"] };
                    if (!(con.Reader["ImagenUrl"] is DBNull))
                        articulo.Imagen = (string)con.Reader["ImagenUrl"];

                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.cerrarConexion();
            }
        }

    }
}
