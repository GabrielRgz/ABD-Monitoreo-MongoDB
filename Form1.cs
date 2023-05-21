using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABD_Monitoreo_MongoDB
{
    public partial class Form1 : Form
    {
        //Variables 
        string conexion;
        MongoClient cliente;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cadena de conexión a tu instancia de MongoDB
            conexion = "cadena de conexion";

            try
            {
                // Crea el cliente de MongoDB
                var client = new MongoClient(conexion);

                // Obtiene la lista de bases de datos
                List<string> listaBD = client.ListDatabaseNames().ToList();

                // Muestra las bases de datos en un ListBox (u otro control de tu elección)
                foreach (var databaseName in listaBD)
                {
                    lbxBasesDatos.Items.Add(databaseName);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                cliente = new MongoClient(conexion);
                var result = cliente.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                //var bd = cliente.GetDatabase("Super").GetCollection<BsonDocument>("Productos");
                Console.WriteLine("Conectado correctamente a MongoDB");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
