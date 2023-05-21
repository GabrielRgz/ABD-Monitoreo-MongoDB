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

        private void MostrarERROR(Exception e) {
            MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cadena de conexión a tu instancia de MongoDB
            conexion = "cadena conexion";

            try
            {
                // Crea el cliente de MongoDB
                cliente = new MongoClient(conexion);

                var database = cliente.GetDatabase("nombre base de datos");

                // Obtiene la lista de colecciones
                List<string> collectionNames = database.ListCollectionNames().ToList();

                // Obtiene la lista de bases de datos
                //List<string> listaBD = cliente.ListDatabaseNames().ToList();

                // Muestra las bases de datos en un ListBox (u otro control de tu elección)
                foreach (var databaseName in collectionNames)
                {
                    lbxColecciones.Items.Add(databaseName);
                }
            }
            catch (Exception ex) {
                MostrarERROR(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                cliente = new MongoClient(conexion);
                var result = cliente.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Conectado correctamente a MongoDB");
            }
            catch (Exception ex)
            {
                MostrarERROR(ex);
            }*/
        }

        private void lbxBasesDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //Obtiene la base de datos
                var database = cliente.GetDatabase("nombre base de datos");
                //Obtiene la coleccion
                var collection = database.GetCollection<BsonDocument>(lbxColecciones.SelectedItem.ToString());

                //Agrega los elementos de la coleccion a una lista
                var documents = collection.Find(new BsonDocument()).ToList();

                var dataTable = new System.Data.DataTable();

                // Crea las columnas del DataTable
                foreach (var element in documents.First().Elements)
                {
                    dataTable.Columns.Add(element.Name);
                }

                // Agrega las filas al DataTable
                foreach (var document in documents)
                {
                    var row = dataTable.NewRow();

                    foreach (var element in document.Elements)
                    {
                        row[element.Name] = element.Value.ToString();
                    }

                    dataTable.Rows.Add(row);
                }

                // Asigna el DataTable como origen de datos para el DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MostrarERROR(ex);
            }
        }
    }
}
