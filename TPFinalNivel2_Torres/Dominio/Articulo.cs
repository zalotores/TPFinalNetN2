using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        [DisplayName("Código")]
        public int CodigoArticulo {  get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public int Marca {  get; set; }
        [DisplayName("Categoría")]
        public int Categoria {  get; set; }
        public string Imagen {  get; set; }
        public float Precio {  get; set; }
    }
}
