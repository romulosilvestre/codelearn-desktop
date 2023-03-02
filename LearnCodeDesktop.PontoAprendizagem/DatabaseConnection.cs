using System.Data.SqlClient; //importando o namespace


namespace LearnCodeDesktop.PontoAprendizagem //definição de namespace
{
    public class DatabaseConnection  //criação da classe
    {
        //Variável de Referência (meu tipo é uma classe)
        private SqlConnection connection;

        //Construtor vazio no parâmetro
        public DatabaseConnection()
        {
            string connectionString = "Server=VAIAMANHECER\\SQLEXPRESS;Database=LearnCodeTest;Integrated Security=True;";
            this.connection = new SqlConnection(connectionString);//objeto (instância)
        }

        public void Open() //método (void) - retorno é vazio
        {
            this.connection.Open();
        }

        public void Close() //método (void) - retorno vazio
        {
            this.connection.Close();
        }

        public SqlConnection GetConnection() //método (SqlConnection) - retornar uma conexão SQL
        {
            return this.connection;
        }





    }
}
