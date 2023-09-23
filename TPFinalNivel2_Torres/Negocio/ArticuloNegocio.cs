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
                    articulo.Id = (int) con.Reader["Id"];
                    articulo.CodigoArticulo = con.Reader.GetString(1);
                    articulo.Nombre = con.Reader.GetString(4);
                    articulo.Descripcion = con.Reader.GetString(5);
                    articulo.Marca = new Marca { Descripcion = con.Reader.GetString(3) };
                    articulo.Categoria = new Categoria { Descripcion = con.Reader.GetString(2) };
                    if (!(con.Reader.GetString(7) is DBNull))
                        articulo.Imagen = con.Reader.GetString(7);
                    articulo.Precio = (decimal)con.Reader["Precio"];

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
