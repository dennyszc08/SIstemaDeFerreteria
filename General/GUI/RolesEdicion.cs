using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI
{
    public partial class RolesEdicion : Form
    {
        private void Procesar()
        {
            CLS.Roles oEntidad = new CLS.Roles();
            oEntidad.IR = txbIdRol.Text;
            oEntidad.R = TxbRol.Text;
            try
            {
                if (txbIdRol.TextLength > 0)
                {
                    //Actualizando
                   if (oEntidad.Editar())
                    {
                        MessageBox.Show("REGISTRO ACTUALIZADO CORRECTAMENTE","CONFIRMACION",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("OCURRIO UN ERROR AL ACTUALIZAR", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    //Guardando
                    if (oEntidad.Guardar())
                    {
                        MessageBox.Show("REGISTRO INGRESADO CORRECTAMENTE", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("OCURRIO UN ERROR AL GUARDAR", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {

            }
        }
        private Boolean Comprobar()
        {
            Boolean Resultado = true;
            Notificador.Clear();

            if (TxbRol.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(TxbRol, "ESTE CAMPO NO SE PERMITE ESTAR VACIO");
            }

            return Resultado;
        }

        public RolesEdicion()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Comprobar())
            {
                Procesar();
            }
        }

        private void RolesEdicion_Load(object sender, EventArgs e)
        {

        }
    }
}
