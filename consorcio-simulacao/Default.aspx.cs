using System;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace consorciosimulacao
{

    public partial class Default : System.Web.UI.Page
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Default()
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

        public void btnEntrar_Click(object sender, EventArgs args)
        {
            if (this.OpenConnection() == true)
            {
                string queryFind = "SELECT usu_nome, usu_login FROM Usuario WHERE usu_login = '" + txtLogin.Text + "' and usu_senha = '"+ txtSenha.Text +"'; ";

                MySqlCommand cmdFind = new MySqlCommand(queryFind, connection);
                MySqlDataReader objDataReaderFind = cmdFind.ExecuteReader();
                if (!objDataReaderFind.HasRows)
                    lblMensagem.Text = "Usuário ou senha incorretos!";
                else
                {
                    while (objDataReaderFind.Read()) 
                    { 
                        //listBox1.Items.Add(leitor["Nome"].ToString());
                        Session["nomeUsuario"] = objDataReaderFind["usu_nome"].ToString();
                        Session["loginUsuario"] = objDataReaderFind["usu_login"].ToString();
                    }
                    this.CloseConnection();
                    Response.Redirect("~/Views/Simulacao.aspx");
                }
                this.CloseConnection();
            }

        }
    }
}
