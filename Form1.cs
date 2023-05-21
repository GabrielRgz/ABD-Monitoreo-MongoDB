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

        private void setPlaceHolders() 
        {
            var database = cliente.GetDatabase("Super");
            //Obtiene la coleccion
            var collection = database.GetCollection<BsonDocument>(lbxColecciones.SelectedItem.ToString());

            //Agrega los elementos de la coleccion a una lista
            var documents = collection.Find(new BsonDocument()).ToList();

            var dataTable = new System.Data.DataTable();
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
            dataGridView1.DataSource = dataTable;

            if (lbxColecciones.SelectedItem.ToString() == "Productos")
            {
                lblDescripcion.Text = "Datos del Producto";
                txb2.Text = "Nombre";
                txb3.Text = "Precio";
                txb4.Text = "Proveedor";
            }
            else
            {
                lblDescripcion.Text = "Datos del cliente";
                txb2.Text = "Nombre";
                txb3.Text = "Telefono";
                txb4.Text = "Correo";
            }
            
        }

        private void lbxColecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPlaceHolders();

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txb2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txb3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txb4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void txb2_Enter(object sender, EventArgs e)
        {
            if (txb2.Text == "Nombre")
            {
                txb2.Text = "";
                txb2.ForeColor = Color.Black;
            }
        }

        private void txb3_Enter(object sender, EventArgs e)
        {
            if (txb3.Text == "Precio" || txb3.Text == "Telefono")
            {
                txb3.Text = "";
                txb3.ForeColor = Color.Black;
            }
        }

        private void txb4_Enter(object sender, EventArgs e)
        {
            if (txb4.Text == "Proveedor" || txb4.Text == "Correo")
            {
                txb4.Text = "";
                txb4.ForeColor = Color.Black;
            }
        }

        private void txb4_Leave(object sender, EventArgs e)
        {
            if (txb4.Text == "" && lbxColecciones.SelectedItem.ToString() == "Productos")
            {
                txb4.Text = "Proveedor";
                txb4.ForeColor = Color.Silver;
            }
            else if (txb4.Text == "" && lbxColecciones.SelectedItem.ToString() == "Clientes")
            {
                txb4.Text = "Correo";
                txb4.ForeColor = Color.Silver;
            }
        }

        private void txb3_Leave(object sender, EventArgs e)
        {
            if (txb3.Text == "" && lbxColecciones.SelectedItem.ToString() == "Productos")
            {
                txb3.Text = "Precio";
                txb3.ForeColor = Color.Silver;

            }
            else if (txb3.Text == "" && lbxColecciones.SelectedItem.ToString() == "Clientes")
            {
                txb3.Text = "Telefono";
                txb3.ForeColor = Color.Silver;
            }
        }

        private void txb2_Leave(object sender, EventArgs e)
        {
            if (txb2.Text == "")
            {
                txb2.Text = "Nombre";
                txb2.ForeColor = Color.Silver;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var database = cliente.GetDatabase("Super");
            //Obtiene la coleccion
            var collection = database.GetCollection<BsonDocument>(lbxColecciones.SelectedItem.ToString());

            if (lbxColecciones.SelectedItem.ToString() == "Productos")
            {
                Producto p = new Producto(txb2.Text, Decimal128.Parse(txb3.Text), txb4.Text);
                collection.InsertOneAsync(p.ToBsonDocument());
            }
            else
            {
                Cliente c = new Cliente(txb2.Text, txb3.Text, txb4.Text);
                collection.InsertOneAsync(c.ToBsonDocument());
            }
            
            setPlaceHolders();
        }
    }
}
