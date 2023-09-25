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
            catch 
            {
                MessageBox.Show("Error al conectar a la Base de Datos");
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
        //entrada a ventana detalle
        private void dgvArticulos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!(dgvArticulos.CurrentRow is null))
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmDetalle detalle = new frmDetalle(seleccionado);
                detalle.Show();
            }
            else
            {
                //si la lista esta vacia informa al usuario
                MessageBox.Show("Ningun artículo listado!");
            }
        }

        //entrada a ventana agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAddUpdate agregar = new frmAddUpdate();
            //creo instancia unica
            agregar.ShowDialog();
            cargar();
        }
        //entrada para modificar articulo
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!(dgvArticulos.CurrentRow is null))
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAddUpdate modificar = new frmAddUpdate(seleccionado);
                //creo instancia unica
                modificar.ShowDialog();
                cargar();
            }
            else
            {
                //si la lista esta vacia informa al usuario
                MessageBox.Show("Ningun artículo listado!");
            }
        }
        //entrada para eliminar articulo
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            try
            {
                //pido confirmacion
                DialogResult respuesta = MessageBox.Show("Eliminar el artículo " + 
                    seleccionado.Nombre + "?", "Eliminando...", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    //envio el id para eliminar al negocio
                    negocio.eliminar(seleccionado.Id);
                    cargar();
                }
            }
            catch
            {
                MessageBox.Show("Error al eliminar articulo.");
            }
        }
    }
}
