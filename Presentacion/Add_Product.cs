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
    public partial class Add_Product : Form
    {
        public Add_Product()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(Common.Cache.UserLoginCache.conexion);
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Productos (nombre,precio,departamento)VALUES(@nombre,@precio,@departamento)", conexion);
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = txt_nbre.Text;

                comando.Parameters.Add("@precio", SqlDbType.Float);
                comando.Parameters["@precio"].Value = float.Parse(txt_precio.Text);

                comando.Parameters.Add("@departamento", SqlDbType.VarChar);
                comando.Parameters["@departamento"].Value = txt_dep.Text;

                comando.ExecuteNonQuery();
                MessageBox.Show("The record was successfully modified", "Successful operation", MessageBoxButtons.OK,MessageBoxIcon.Information);
                conexion.Close();
                txt_nbre.Clear();
                txt_precio.Clear();
                txt_dep.Clear();
            }
            catch(FormatException X)
            {
                MessageBox.Show("The record was not added correctly", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
            }
        }
    }
}
