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
        IMongoDatabase database;

        public Form1()
        {
            InitializeComponent();
        }

        private void MostrarERROR(Exception e) {
            MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Conectar()
        {
            // Cadena de conexión a tu instancia de MongoDB
            string conexion = "mongodb+srv://GabrielRgz:GabrielRgz2@clusterfree.pzhwwnw.mongodb.net/?retryWrites=true&w=majority";
            try
            {
                // Crea el cliente de MongoDB
                MongoClient cliente = new MongoClient(conexion);

                database = cliente.GetDatabase("Super");

                // Obtiene la lista de colecciones
                List<string> collectionNames = database.ListCollectionNames().ToList();

                // Muestra las bases de datos en un ListBox (u otro control de tu elección)
                foreach (var c in collectionNames)
                {
                    lbxColecciones.Items.Add(c);
                }
            }
            catch (Exception ex)
            {
                MostrarERROR(ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Cargando ventanaCarga = new Cargando())
            {
                ventanaCarga.Show();
                Conectar();
            }
        }

        private void setPlaceHolders()
        {
            try
            {
                var collectionName = lbxColecciones.SelectedItem.ToString();

                //Obtiene la coleccion
                var collection = database.GetCollection<BsonDocument>(collectionName);

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

                // Actualiza los valores de los TextBox usando la primera fila del DataGridView
                if (dataGridView1.Rows.Count > 0)
                {
                    txbId.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    txb2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    txb3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    txb4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MostrarERROR(ex);
            }
        }

        private void lbxColecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPlaceHolders();

            try
            {
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

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            //Obtiene la coleccion
            var collection = database.GetCollection<BsonDocument>(lbxColecciones.SelectedItem.ToString());

            if (collection.CollectionNamespace.CollectionName == "Productos")
            {
                Producto p = new Producto(txb2.Text, Decimal128.Parse(txb3.Text), txb4.Text);
               await collection.InsertOneAsync(p.ToBsonDocument());
            }
            else
            {
                Cliente c = new Cliente(txb2.Text, txb3.Text, txb4.Text);
                await collection.InsertOneAsync(c.ToBsonDocument());
            }
            
            setPlaceHolders();
        }

        private async void btnUpdate_ClickAsync(object sender, EventArgs e)
        {
            var collectionName = lbxColecciones.SelectedItem.ToString();
            var collection = database.GetCollection<BsonDocument>(collectionName);

            ObjectId id = ObjectId.Parse(txbId.Text);

            if (collection.CollectionNamespace.CollectionName == "Productos")
            {
                // Obtiene los valores de los TextBox
                var nombre = txb2.Text;
                var precio = Decimal128.Parse(txb3.Text);
                var proveedor = txb4.Text;
                

                // Crea el filtro utilizando parámetros
                var filtro = Builders<BsonDocument>.Filter.Eq("_id", id);
                var actualizaciones = Builders<BsonDocument>.Update
                    .Set("nombre", nombre)
                    .Set("precio", precio)
                    .Set("Proveedor", proveedor);

                // Ejecuta la actualización en la base de datos
                await collection.UpdateOneAsync(filtro, actualizaciones);
            }
            else
            {
                // Obtiene los valores de los TextBox
                var nombre = txb2.Text;
                var telefono = txb3.Text;
                var correo = txb4.Text;

                // Crea el filtro utilizando parámetros
                var filtro = Builders<BsonDocument>.Filter.Eq("_id", id);
                var actualizaciones = Builders<BsonDocument>.Update
                    .Set("nombre", nombre)
                    .Set("Telefono", telefono)
                    .Set("Correo", correo);

                // Ejecuta la actualización en la base de datos
                await collection.UpdateOneAsync(filtro, actualizaciones);
            }

            setPlaceHolders();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var collectionName = lbxColecciones.SelectedItem.ToString();
            var collection = database.GetCollection<BsonDocument>(collectionName);

            ObjectId id = ObjectId.Parse(txbId.Text);

            // Crea el filtro utilizando parámetros
            var filtro = Builders<BsonDocument>.Filter.Eq("_id", id);

            // Ejecuta la eliminación en la base de datos
            await collection.DeleteOneAsync(filtro);
            setPlaceHolders();
        }

        private void lblTitulo_MouseClick(object sender, MouseEventArgs e)
        {
            Metricas m = new Metricas();
            m.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult cerrar = MessageBox.Show("Esta seguro que desea salir?","Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (cerrar == DialogResult.Yes)
            {
                this.Close();
            }
            
        }
    }
}
