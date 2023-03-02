using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LearnCodeDesktop.PontoAprendizagem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            /*
             * Esse formulário tem como objetivo interagir com o usuário
             * para armazenar um documento de competências 
             * no formato .docx (Microsoft Word).
             * Depois nosso objetivo vai ser adicionar depois essa competência
             * no formato word em uma associação com a Aula. 
             */

            /*
             * Dentro do conceito de DDL vamos criar uma nova tabela
             * no nosso banco de dados:
             * Passo 1 - Criando o banco de dados
             *  USE LearnCodeTest;
                GO
                CREATE TABLE Documentos(
                  Id INT PRIMARY KEY IDENTITY,
                  NomeArquivo NVARCHAR(100),
                  TipoArquivo NVARCHAR(50),
                  DadosArquivo VARBINARY(MAX)
                );
             * 
             */

            //Passo 2: Criar um formulário com um botão para selecionar um arquivo
            //No evento de click vamos usar o OpenFileDialog para permitir selecionar o arquivo.


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Aqui vou programar o envio
            if(openFileDialog1.ShowDialog() == DialogResult.OK) { 
                 
                string nomeArquivo = openFileDialog1.SafeFileName;       
            
                string tipoArquivo = Path.GetExtension(openFileDialog1.FileName);
                byte[] dadosArquivo =File.ReadAllBytes(openFileDialog1.FileName);
                InserirDocumento(nomeArquivo, tipoArquivo, dadosArquivo);
            
            
            }
        }
        //Vamos gerar um método InserirDocumento.
        private void InserirDocumento(string nomeArquivo, string tipoArquivo, byte[] dadosArquivo)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            dbConnection.Open();//abrindo

            //Comandos SQL
            SqlCommand comando = dbConnection.GetConnection().CreateCommand();//peguei e criei um comando 

            //Recurso no banco do + básico até o + avançado
            //o que escolhemos é úm básico (comando de texto)
            comando.CommandType = System.Data.CommandType.Text;


            //Definindo a DML (Data Manipulation Language)
            comando.CommandText = "INSERT INTO Documentos(NomeArquivo,TipoArquivo,DadosArquivo)Values(@NomeArquivo,@TipoArquivo,@DadosArquivo)";

            //Passando valor para os parâmetros
            comando.Parameters.AddWithValue("@NomeArquivo",nomeArquivo);
            comando.Parameters.AddWithValue("@TipoArquivo", tipoArquivo);
            comando.Parameters.AddWithValue("@DadosArquivo", dadosArquivo);
            

            //executar o DML (INSERT INTO.....)
            comando.ExecuteNonQuery();

            MessageBox.Show("Documento Inserido com Sucesso!");
            dbConnection.Close();
        }
    }
}
