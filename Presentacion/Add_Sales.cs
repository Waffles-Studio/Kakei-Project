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
    public partial class Add_Sales : Form
    {
        public Add_Sales()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(Common.Cache.UserLoginCache.conexion);
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                double control = double.Parse(txt_descuento.Text);
                if (radioButton_no.Checked == true)
                {
                    Sin_Descuento();
                    txt_descuento.Enabled = false;
                    //txt_descuento.Text="0";
                }
                if (radioButton_si.Checked == true)
                {
                    Con_descuento();
                }
                //else if (radioButton_si.Checked == true && control > 0)
                //{
                    //MessageBox.Show("Algun campo contiene un dato incorrecto\nPor favor inserte datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch(FormatException X)
            {
                MessageBox.Show("The record was not added correctly", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton_no.Checked==true)
            //{
            button8.Enabled = true;
            txt_descuento.Enabled = false;
            txt_descuento.Text = "0";
            //}
        }

        private void radioButton_si_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton_si.Checked == true)
            //{
            button8.Enabled = true;
            txt_descuento.Enabled = true;
            //}
        }
        private void Con_descuento()
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Venta (monto_venta,descuento,fecha_venta)Values(@monto_venta,@descuento,@fecha_venta)", conexion);
                comando.Parameters.Add("@monto_venta", SqlDbType.Float);
                comando.Parameters["@monto_venta"].Value = float.Parse(txt_monto.Text);
                
                comando.Parameters.Add("@descuento", SqlDbType.Float);
                comando.Parameters["@descuento"].Value = float.Parse(txt_descuento.Text);

                comando.Parameters.Add("@fecha_venta", SqlDbType.SmallDateTime);
                comando.Parameters["@fecha_venta"].Value = dateTimeFecha.Value;

                comando.ExecuteNonQuery();
                MessageBox.Show("The record was successfully modified", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
                txt_monto.Clear();
            }
            catch (FormatException X)
            {
                MessageBox.Show("The record was not added correctly", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                txt_monto.Clear();
            }
        }
        public void Sin_Descuento()
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Venta (monto_venta,descuento,fecha_venta)Values(@monto_venta,@descuento,@fecha_venta)", conexion);

                comando.Parameters.Add("@monto_venta", SqlDbType.Float);
                comando.Parameters["@monto_venta"].Value = float.Parse(txt_monto.Text);                    
                
                comando.Parameters.Add("@descuento", SqlDbType.Float);
                comando.Parameters["@descuento"].Value = 0;

                comando.Parameters.Add("@fecha_venta", SqlDbType.SmallDateTime);
                comando.Parameters["@fecha_venta"].Value = dateTimeFecha.Value;

                comando.ExecuteNonQuery();
                MessageBox.Show("The record was successfully modified", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
                txt_monto.Clear();
            }
            catch (FormatException X)
            {
                MessageBox.Show("The record was not added correctly", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
                txt_monto.Clear();
            }
        }

        private void Add_Sales_Load(object sender, EventArgs e)
        {
            button8.Enabled = false;
            txt_descuento.Enabled = false;
        }

        private void txt_monto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}