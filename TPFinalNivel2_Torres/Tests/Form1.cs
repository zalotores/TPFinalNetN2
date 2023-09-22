using DataBase;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class formTest : Form
    {
        public formTest()
        {
            InitializeComponent();
        }
        //Test de acceso a datos
        private void btnTestDDBB_Click(object sender, EventArgs e)
        {
            AccesoDatos con = new AccesoDatos();
            try
            {
                lblConectadoResultado.Text = "NO";
                lblDesconectadoResultado.Text = "NO";
                con.setConsulta("SELECT * FROM CATEGORIAS;");
                con.ejecutarQuery();
                lblConectadoResultado.Text = "SI";
                con.cerrarConexion();
                lblDesconectadoResultado.Text = "SI";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Test de conexion a Categoria negocio
        private void btnTestTablaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio catNegocio = new CategoriaNegocio();
                dgvTestTablasAux.DataSource = catNegocio.listar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Test de conexion a Marca negocio
        private void btnTestTablaMarcas_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                dgvTestTablasAux.DataSource = marcaNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
