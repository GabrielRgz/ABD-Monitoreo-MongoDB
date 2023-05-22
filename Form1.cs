﻿using System;
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
        IMongoDatabase database;

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

               database = cliente.GetDatabase("Super");

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

            txbId.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            txb2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            txb3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            txb4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Obtiene la coleccion
            var collection = database.GetCollection<BsonDocument>(lbxColecciones.SelectedItem.ToString());

            if (lbxColecciones.SelectedItem.ToString() == "Productos")
            {
                var filtro = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(txbId.Text));
                var actualizaciones = Builders<BsonDocument>.Update.Set("nombre", txb2.Text).Set("precio", Decimal128.Parse(txb3.Text)).Set("Proveedor", txb4.Text);
                collection.UpdateOne(filtro, actualizaciones);
            }
            else
            {
                var filtro = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(txbId.Text));
                var actualizaciones = Builders<BsonDocument>.Update.Set("nombre", txb2.Text).Set("Telefono", txb3.Text).Set("Correo", txb4.Text);
                collection.UpdateOne(filtro, actualizaciones);
            }
            setPlaceHolders();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Obtiene la coleccion
            var collection = database.GetCollection<BsonDocument>(lbxColecciones.SelectedItem.ToString());
            var filtro = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(txbId.Text));
            collection.DeleteOne(filtro);
            setPlaceHolders();
        }
    }
}
