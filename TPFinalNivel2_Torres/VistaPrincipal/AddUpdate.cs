using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaPrincipal
{
    public partial class frmAddUpdate : Form
    {
        public frmAddUpdate()
        {
            InitializeComponent();
        }
        //logica para agregar articulo
        private void frmAddUpdate_Load(object sender, EventArgs e)
        {
            //TODO
        }
        //cierra la ventana sin guardar nada
        private void btnAddCancelar_Click(object sender, EventArgs e)
        {
            
            Close();
        }
    }
}
