using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.GUI
{
    public partial class Login : Form
    {

        Boolean _Validacion = false;

        public bool Validacion
        {
            get
            {
                return _Validacion;
            }
        }

        private void Validar()
        {
            try
            {
                    SesionManager.CLS.Sesion SesionInicial = SesionManager.CLS.Sesion.Instancia;                    
                    _Validacion = SesionInicial.IniciarSesion(txbUsuario.Text, txbClave.Text);

                if (_Validacion)
                {
                    Close();
                }

                else
                {
                    lblMensaje.Text = "CREDENCIALES INCORRECTAS, VUELVA A INTENTARLO";
                }
            }
            catch
            {
                _Validacion = false;
            }
        }
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSingIn_Click(object sender, EventArgs e)
        {
            Validar();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txbClave.Focus();
                txbClave.SelectAll();
            }
        }

        private void txbClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSingIn.PerformClick();
            }
        }

        private void txbUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
