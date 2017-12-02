using System;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace consorciosimulacao
{

    public partial class Cadastro: System.Web.UI.Page
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Cadastro()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "consorcio";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        public void btnCadastrar_Click(object sender, EventArgs args)
        {
            if ((txtSenha.Text == "") || (txtLogin.Text == "") || (txtNome.Text == ""))
                lblMensagem.Text = "Preencha todos os campos!";
            else
            {
                if (txtSenha.Text != txtConfSenha.Text)
                {
                    lblMensagem.Text = "Senhas não são iguais!";
                }
                else
                {
                    if (this.OpenConnection() == true)
                    {

                        string queryFind = "SELECT `usu_id` FROM `Usuario` WHERE usu_login = '" + txtLogin.Text + "'; ";

                        MySqlCommand cmdFind = new MySqlCommand(queryFind, connection);
                        MySqlDataReader objDataReaderFind = cmdFind.ExecuteReader();
                        if (objDataReaderFind.HasRows)
                            lblMensagem.Text = "Usuário já existe";
                        else
                        {
                            this.CloseConnection();
                            this.OpenConnection();
                            string query = "INSERT INTO Usuario(usu_login, usu_senha, usu_nome) VALUES ( '" + txtLogin.Text + "', '" + txtSenha.Text + "', '" + txtNome.Text + "');";

                            MySqlCommand cmd = new MySqlCommand(query, connection);

                            cmd.ExecuteNonQuery();
                        }
                        this.CloseConnection();
                    }
                }
            }
        }

    }
}
