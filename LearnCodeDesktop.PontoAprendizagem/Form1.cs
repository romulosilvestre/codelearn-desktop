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

namespace LearnCodeDesktop.PontoAprendizagem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.Open();//abrindo

            //Comandos SQL
            SqlCommand comando = dbConnection.GetConnection().CreateCommand();//peguei e criei um comando 

            //Recurso no banco do + básico até o + avançado
            //o que escolhemos é úm básico (comando de texto)
            comando.CommandType = System.Data.CommandType.Text;
            
          
            //Definindo a DML (Data Manipulation Language)
            comando.CommandText = "INSERT INTO Aula(Descricao,Esboco,Tipo,DataAgendamento)Values(@Descricao,@Esboco,@Tipo,@DataAgendamento)";

            //Passando valor para os parâmetros
            comando.Parameters.Add(new SqlParameter("@Descricao",textBox1.Text));
            comando.Parameters.Add(new SqlParameter("@Esboco", textBox2.Text));
            comando.Parameters.Add(new SqlParameter("@Tipo",cmbTipo.SelectedItem.ToString()));
            comando.Parameters.Add(new SqlParameter("@DataAgendamento",dtpDataAgendamento.Value));

            //executar o DML (INSERT INTO.....)
            comando.ExecuteNonQuery();

            textBox1.Clear();
            textBox2.Clear();
                
            dbConnection.Close();

            MessageBox.Show("Dados Gravados com Sucesso!");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }
    }
}
