using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace VistaPrincipal
{
    public partial class Principal : Form
    {
        private List<Articulo> listaArticulos;
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            cargar();
            //TODO
        }

        //carga de tabla
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                listaArticulos = negocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                ocultarColumnas();
                cargarImagen(listaArticulos[0].Imagen);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //oculta columnas que trae de DDBB pero no quiero visualizar
        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["IdMarca"].Visible = false;
            dgvArticulos.Columns["IdCategoria"].Visible = false;
        }

        //carga imagen en picturebox
        private void cargarImagen(string imagen)
        {
            try
            {
                picbxArticulo.Load(imagen);
            }
            catch
            {
                //imagen por defecto en caso de no encontrar url de la imagen
                picbxArticulo.Load("https://demofree.sirv.com/nope-not-here.jpg");
            }
        }
        
    }
}
