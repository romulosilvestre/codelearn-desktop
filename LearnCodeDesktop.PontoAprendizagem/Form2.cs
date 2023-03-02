using LearnCodeDesktop.VO;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //realizei essa modificação, veja com o ficou um código limpo.
            dataGridView1.DataSource = ObterDados();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //vou fazer um filtro aplicando lambda
            /*
             * Para isso, e para a organização do nosso código irei criar 
             * uma camada de biblioteca, que chamamos de DLL.
             */
            //Pronto! Já criei a DLL, chamei de VO (Value Object) pois só vai ter propriedades automáticas (get e set)

            //Agora vou criar uma Lista usando Generics
            //Usar o LINQ e Lambda
            //Primeiro acessar uma fonte de dados (List, DataTable, XLS, .SQL)
            List<Aula> aulas = ListarDados();
            //crie um filtro
            string fitroTipo = cmbTipoPesquisa.SelectedItem.ToString();
            //Criando a expressão lambda
            //Func<Aula,bool> expressaoLambda = x=>x.Tipo.Equals(fitroTipo);
            //Vamos filtrar os dados usando a expressão
            var dadosFiltrados = aulas.Where(a => a.Tipo.Equals(fitroTipo));
            //agora vamos atribuir ao DataSource
            dataGridView1.DataSource = dadosFiltrados.ToList();
            //atualize
            dataGridView1.Update();
        }

        private List<Aula> ListarDados()
        {
            List<Aula> aulas = new List<Aula>();
            
            //vamos percorrer nosso DataTable pegar os dados e jogar na lista
            foreach (DataRow row in ObterDados().Rows)
            {
                Aula aula = new Aula();
                aula.Id = Convert.ToInt32(row["Id"]);
                aula.Descricao = row["Descricao"].ToString();
                aula.Esboco = row["Esboco"].ToString();
                aula.Tipo = row["Tipo"].ToString();
                aula.DataAgendamento = Convert.ToDateTime(row["DataAgendamento"]);
                aulas.Add(aula);
            }
            return aulas;
        }

        //vou criar um método ObterDados, trazendo o algoritmo que já fiz.
        public DataTable ObterDados()
        {
            //1º- Crie um objeto da classe DatabaseConnection
            DatabaseConnection dbConnection = new DatabaseConnection();
            //2º - Abra a Conexão
            dbConnection.Open();//abrir a conexão

            //3º - Pegue a conexão e crie um comando
            SqlCommand comando = dbConnection.GetConnection().CreateCommand();//peguei e criei um comando 

            //4º - Defina o tipo comando
            comando.CommandType = System.Data.CommandType.Text;
            //5º - Pesquise todos (*) os campos da tabela Aulas
            comando.CommandText = "SELECT * FROM Aula";

            //6º - Crie uma tabela na memória (DataTable)
            DataTable dataTable = new DataTable();

            //7º - Ler os dados
            SqlDataReader reader = comando.ExecuteReader();

            //8º - Carregar a tabela da memória (DataTable) com os dados da tabela Aula (SQL Server)
            dataTable.Load(reader);

            //9º - Atribuir o dataTable no componente DataGridView
            //dataGridView1.DataSource = dataTable;
            return dataTable;
        }
    }
}
