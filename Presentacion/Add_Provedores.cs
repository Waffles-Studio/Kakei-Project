using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Presentacion
{
    public partial class Add_Provedores : Form
    {
        public Add_Provedores()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(Common.Cache.UserLoginCache.conexion);
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Provedores (nombre_Provedor, telefono, direccion, ciudad, e_mail)VALUES(@nombre_Provedor, @telefono, @direccion, @ciudad, @e_mail)",conexion);
                comando.Parameters.Add("@nombre_Provedor", SqlDbType.VarChar);
                comando.Parameters["@nombre_Provedor"].Value = txt_nmbre_provedor.Text;

                comando.Parameters.Add("@telefono", SqlDbType.Float);
                comando.Parameters["@telefono"].Value = txt_telefono.Text;

                comando.Parameters.Add("@direccion", SqlDbType.VarChar);
                comando.Parameters["@direccion"].Value = txt_direccion.Text;

                comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
                comando.Parameters["@ciudad"].Value = txt_ciudad.Text;

                comando.Parameters.Add("@e_mail", SqlDbType.VarChar);
                comando.Parameters["@e_mail"].Value = txt_email.Text;
                comando.ExecuteNonQuery();
                if (txt_nmbre_provedor.Text!=null && txt_telefono.Text!=null && txt_direccion.Text!=null && txt_ciudad.Text!=null && txt_email.Text!=null)
                {
                    MessageBox.Show("The record was successfully modified", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conexion.Close();
                    txt_nmbre_provedor.Clear();
                    txt_telefono.Clear();
                    txt_direccion.Clear();
                    txt_ciudad.Clear();
                    txt_email.Clear();
                }
            }
            catch (FormatException X)
            {
                MessageBox.Show("The record was not added correctly", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                conexion.Close();
                txt_nmbre_provedor.Clear();
                txt_telefono.Clear();
                txt_direccion.Clear();
                txt_ciudad.Clear();
                txt_email.Clear();
            }
        }
    }
}
