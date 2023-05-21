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
using System.Windows.Forms.DataVisualization.Charting;

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
            conexion = "mongodb+srv://GabrielRgz:GabrielRgz2@clusterfree.pzhwwnw.mongodb.net/?retryWrites=true&w=majority";
            try
            {
                // Crea el cliente de MongoDB
                cliente = new MongoClient(conexion);

                var database = cliente.GetDatabase("Super");

                // Obtiene la lista de colecciones
                List<string> collectionNames = database.ListCollectionNames().ToList();

                // Muestra las bases de datos en un ListBox (u otro control de tu elección)
                foreach (var c in collectionNames)
                {
                    lbxColecciones.Items.Add(c);
                }
            }
            catch (Exception ex) {
                MostrarERROR(ex);
            }
        }

        private void lbxBasesDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //Obtiene la base de datos
                var database = cliente.GetDatabase("Super");
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
