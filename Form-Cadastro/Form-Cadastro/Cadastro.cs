using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Cadastro
{
    public partial class Cadastro : Form
    {
        MySqlConnection conn;
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                string comando = "INSERT INTO cadastro_usuarios (usuario,senha) values(@usuario,@senha)";
                string str_conexao = "server=localhost;User Id=root;database=cadastro_users;password=''";
                MySqlConnection conn = new MySqlConnection(str_conexao);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(comando, conn);
                cmd.Parameters.AddWithValue("@usuario", txtUser.Text);
                cmd.Parameters.AddWithValue("@senha", txtPassword.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                var result = true;

                if (result == true)
                {
                    MessageBox.Show("usuario cadastrado");
                }
                else
                {
                    MessageBox.Show("erro");
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }

        } 
    }
}
