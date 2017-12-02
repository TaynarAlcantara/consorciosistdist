using System;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace consorciosimulacao
{

    public partial class Simulacao : System.Web.UI.Page
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Simulacao()
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

        private void CarregarDropDownListEstado()
        {
            string query = "SELECT id, nome FROM estados";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader objDataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                ddlEstado.DataSource = objDataReader;
                ddlEstado.DataTextField = "nome";
                ddlEstado.DataValueField = "id";
                ddlEstado.DataBind();
                objDataReader.Close();

                //close Connection
                this.CloseConnection();
            }
        }

        private void CarregarDropDownListCidade(int IdEstado)
        {
            string query = "SELECT id, nome FROM cidades where estado_id = " + IdEstado + "";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);


                //Create a data reader and Execute the command
                MySqlDataReader objDataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                ddlCidade.DataSource = objDataReader;
                ddlCidade.DataTextField = "nome";
                ddlCidade.DataValueField = "id";
                ddlCidade.DataBind();
                objDataReader.Close();

                //close Connection
                this.CloseConnection();

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarDropDownListEstado();
                optValor.Visible = false;
                optRenda.Visible = false;
                lblUsuario.Text = "Bem Vindo/a " + Session["nomeUsuario"] + " !";
            }
        }

        protected void tipoOpcaoSelectedIndexChanged(object sender, EventArgs e){
            if (tipoOpcao.SelectedValue == "renda")
            {
                optValor.Visible = false;
                optRenda.Visible = true;
            }
            else{
                optValor.Visible = true;
                optRenda.Visible = false;
            }
        }

        public void button1Clicked(object sender, EventArgs args)
        {
            button1.Text = "You clicked me";

        }

        protected void ddlEstadoSelectedIndexChanged(object sender, EventArgs e)
        {
            int idCidade = int.Parse(ddlEstado.SelectedValue);
            if (!String.IsNullOrEmpty(ddlEstado.SelectedValue))
            {
                CarregarDropDownListCidade(idCidade);
            }
        }
    }
}
