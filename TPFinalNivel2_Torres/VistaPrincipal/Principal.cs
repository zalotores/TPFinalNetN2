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
    public partial class frmPrincipal : Form
    {
        private List<Articulo> listaArticulos;
        public frmPrincipal()
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
                fomatearColumnas();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //formato de data grid
        private void fomatearColumnas()
        {
            //oculta columnas que trae de DDBB pero no quiero visualizar
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Imagen"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;

            //cambio el formato de precio para que muestre dos decimales
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "0.00";

        }

        private void dgvArticulos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Articulo seleccionado = (Articulo) dgvArticulos.CurrentRow.DataBoundItem;
            frmDetalle detalle = new frmDetalle(seleccionado);
            detalle.Show();
        }
    }
}
