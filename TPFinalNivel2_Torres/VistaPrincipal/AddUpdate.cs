using Dominio;
using Negocio;
using System;
using System.Windows.Forms;

namespace VistaPrincipal
{
    public partial class frmAddUpdate : Form
    {
        //creo atributos privados null
        private Articulo articulo = null;

        //constructor para crear articulo nuevo
        public frmAddUpdate()
        {
            InitializeComponent();
        }
        //constructor para modificar articulo
        public frmAddUpdate(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        //carga de ventana Agregar/Atualizar articulo
        private void frmAddUpdate_Load(object sender, EventArgs e)
        {
            //cargo los desplegables de marca y categoria
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            cboAddMarca.DataSource = marcaNegocio.listar();
            cboAddMarca.ValueMember = "Id";
            cboAddMarca.DisplayMember = "Descripcion";
            cboAddMarca.ResetText();
            cboAddCategoria.DataSource = categoriaNegocio.listar();
            cboAddCategoria.ValueMember = "Id";
            cboAddCategoria.DisplayMember = "Descripcion";
            cboAddCategoria.ResetText();
        }
        //cierra la ventana sin guardar nada
        private void btnAddCancelar_Click(object sender, EventArgs e)
        {
            
            Close();
        }
        //logica para agregar articulo nuevo
        private void btnAddAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            //saco el null del articulo
            articulo = new Articulo();
            try
            {
                articulo.CodigoArticulo = txtAddCodigo.Text.ToUpper();
                articulo.Nombre = txtAddNombre.Text;
                articulo.Descripcion = txtAddDescripcion.Text;
                articulo.Marca = (Marca)cboAddMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboAddCategoria.SelectedItem;
                articulo.Precio = decimal.Parse(txtAddPrecio.Text);
                articulo.Imagen = txtAddImagen.Text;

                //agrego el articulo a la DDBB
                negocio.agregar(articulo);
                MessageBox.Show("Articulo agregado");
                Close();

            }
            catch
            {
                MessageBox.Show("Debe completar todos los campos");
            }
        }

        
        //cargar imagen al cambiar el campo
        private void txtAddImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtAddImagen.Text);
        }

        //cargar imagen en ventana
        private void cargarImagen(string imagen)
        {
            try
            {
                picboxAddImagen.Load(imagen);
            }
            catch
            {
                //imagen por defecto en caso de no encontrar url de la imagen
                picboxAddImagen.Load("https://demofree.sirv.com/nope-not-here.jpg");
            }
        }
    }
}
