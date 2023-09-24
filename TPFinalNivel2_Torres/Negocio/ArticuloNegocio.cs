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
        //habilito la conexion con DDBB para todo el negocio
        AccesoDatos con = new AccesoDatos();
        //variable para ejecutar las query
        string query = string.Empty;
        
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            query = "SELECT A.Id, Codigo AS Código, C.Descripcion AS Categoría, " +
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
                    articulo.Marca = new Marca((int)con.Reader["IdMarca"], con.Reader.GetString(3));
                    articulo.Categoria = new Categoria((int)con.Reader["IdCategoria"], con.Reader.GetString(2));
                    //no reviso imagen null ya que voy a hacer el control al agregar de forma
                    //que no haya campos null
                    //if (!(con.Reader.GetString(7) is DBNull))
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

        public void agregar(Articulo articulo)
        {
            try
            {
                //query para agregar datos con proteccion de injeccion de codigo
                query = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria" +
                    ", ImagenUrl, Precio ) VALUES (@codigo, @nombre, @descripcion, @idMarca, " +
                    "@idCategoria, @imagen, @precio);";
                //setear consulta
                con.setConsulta(query);
                //setear parametros
                con.setParametro("@codigo", articulo.CodigoArticulo);
                con.setParametro("@nombre", articulo.Nombre);
                con.setParametro("@descripcion", articulo.Descripcion);
                con.setParametro("@idMarca", articulo.Marca.Id);
                con.setParametro("@idCategoria", articulo.Categoria.Id);
                con.setParametro("@imagen", articulo.Imagen);
                con.setParametro("@precio", articulo.Precio);
                //ejecutar consulta
                con.ejecutarQuery();
            }
            catch(Exception ex)
            {
                throw(ex);
            }
            finally
            {
                con.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo)    //TODO ver por que no actualiza, no toma el parametro
        {
            //query para hacer update en DDBB
            query = "UPDATE ARTICULOS SET Codigo = '@codigo', Nombre = '@nombre', " +
                "Descripcion = '@descripcion', IdMarca = @idMarca, IdCategoria = @idCategoria" +
                ", ImagenUrl = '@imagen', Precio = @precio WHERE Id = @id; ";
            try
            {
                //setear consulta
                con.setConsulta(query);
                //setear parametros
                con.setParametro("@codigo", articulo.CodigoArticulo);
                con.setParametro("@nombre", articulo.Nombre);
                con.setParametro("@descripcion", articulo.Descripcion);
                con.setParametro("@idMarca", articulo.Marca.Id);
                con.setParametro("@idCategoria", articulo.Categoria.Id);
                con.setParametro("@imagen", articulo.Imagen);
                con.setParametro("@precio", articulo.Precio);
                con.setParametro("@id", articulo.Id);
                //ejecutar consulta
                con.ejecutarQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                con.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            //TODO
        }

    }
}
