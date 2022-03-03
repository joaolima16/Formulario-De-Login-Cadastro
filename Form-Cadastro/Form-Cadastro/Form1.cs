using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Cadastro
{
    public partial class Form1 : Form

    {
      private SqlConnection conexao;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnVerifica_Click(object sender, EventArgs e)
        {
          
            try
            {
              
                string str_conexao = "server=localhost;User Id=root;password='';database=cadastro_users";
                MySqlConnection conexao = new MySqlConnection(str_conexao);
                conexao.Open();
                string consulta = "SELECT * FROM cadastro_usuarios  WHERE usuario = @usuario AND senha=@senha";
                MySqlCommand comando = new MySqlCommand(consulta , conexao);
                comando.Parameters.AddWithValue("@usuario", txtUser.Text);
                comando.Parameters.AddWithValue("@senha", txtSenha.Text);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.Read()) {
                    MessageBox.Show("Usuario Cadastrado No Banco");
                     
                }
                else
                {
                    MessageBox.Show("Usuario Não Cadastrado No Banco");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                    
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cadastro cd = new Cadastro();
            cd.Show();
        }
    }
}
