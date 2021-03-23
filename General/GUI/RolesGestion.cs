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
    public partial class RolesGestion : Form
    {

        BindingSource _D = new BindingSource();
        
        private void Cargar()
        {
            _D.DataSource = CacheManager.CLS.Cache.TodosLR();
            FiltrarLocalmente();
        }

        private void FiltrarLocalmente()
        {
            if (txbFiltrar.TextLength > 0)
            {
                _D.Filter="ROL LIKE '%" + txbFiltrar.Text + "%'";
            }
            else
            {
                _D.RemoveFilter();
            }
            dtgRoles.AutoGenerateColumns = false;
            dtgRoles.DataSource = _D;
            lblRegistros.Text = dtgRoles.Rows.Count.ToString() + "REGISTROS ENCONTRADOS";
        }

        public RolesGestion()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                RolesEdicion f = new RolesEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch
            {

            }
        }

        private void RolesGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txbFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("REALMENTE DESEA EDITAR EL REGISTRO SELECIONADO?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RolesEdicion f = new RolesEdicion();
                    f.txbIdRol.Text = dtgRoles.CurrentRow.Cells["IDRol"].Value.ToString();
                    f.TxbRol.Text = dtgRoles.CurrentRow.Cells["Rol"].Value.ToString();
                    f.ShowDialog();
                    Cargar();
                }
            }
            catch
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("REALMENTE DESEA ELIMINAR EL REGISTRO SELECIONADO?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLS.Roles oEntidad = new CLS.Roles();
                    oEntidad.IR= dtgRoles.CurrentRow.Cells["IDRol"].Value.ToString();
                    if (oEntidad.Eliminar())
                    {
                        MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("REGISTRO NO ELIMINADO CORRECTAMENTE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch
            {

            }
        }
    }
}
