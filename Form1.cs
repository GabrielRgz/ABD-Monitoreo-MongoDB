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
        string conexion = "cadena de conexion";
        MongoClient cliente;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
