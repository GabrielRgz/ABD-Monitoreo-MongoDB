using MongoDB.Bson;
using MongoDB.Driver;
using System;
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
    public partial class Metricas : Form
    {
        string conexion;
        MongoClient cliente;
        IMongoDatabase database;

        public Metricas()
        {
            InitializeComponent();
        }

        private void Metricas_Load(object sender, EventArgs e)
        {
            conexion = "mongodb+srv://GabrielRgz:GabrielRgz2@clusterfree.pzhwwnw.mongodb.net/?retryWrites=true&w=majority";
            try
            {
                // Crea el cliente de MongoDB
                cliente = new MongoClient(conexion);

                database = cliente.GetDatabase("Super");
                var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument { { "dbStats", 1 } });
                var result = database.RunCommand(command);

                // Crea una serie para mostrar los datos
                var serie = new Series("Espacio usado por la BD");
                serie.ChartType = SeriesChartType.Bar;
                serie.Color = Color.DarkGreen;
                serie.Points.AddXY("Tamaño", result["storageSize"].AsInt64);
                chart1.Series.Add(serie);

                var serie2 = new Series("Colecciones");
                serie2.ChartType = SeriesChartType.Column;
                serie2.Points.AddXY("Numero de \n colecciones", result["collections"].AsInt32);
                chart2.Series.Add(serie2);

                var serie3 = new Series("Documentos");
                serie3.ChartType = SeriesChartType.Column;
                serie3.Color = Color.BlueViolet;
                serie3.Points.AddXY("Numero de \n documentos", result["objects"].AsInt64);
                chart3.Series.Add(serie3);

                var serie4 = new Series("Tamaño");
                serie4.ChartType = SeriesChartType.Column;
                serie4.LabelBackColor = Color.Transparent;
                serie4.Color = Color.BlueViolet;
                serie4.Points.AddXY("Espacio usado por \n indices", result["indexSize"].AsInt64);
                //chart4.Series.Add(serie4);

                lblIndexes.Text += result["indexes"].AsInt32.ToString();
                lblVistas.Text += result["views"].AsInt32.ToString();

                command = new BsonDocumentCommand<BsonDocument>(new BsonDocument { { "serverStatus", 1 } });
                result = database.RunCommand(command);

                var infoConecciones = result["connections"].AsBsonDocument.ToList();

                List<string> etiquetas = new List<string>();
                List<int> valores = new List<int>();

                foreach (var item in infoConecciones)
                {
                    var etiqueta = item.Name;
                    int valor;

                    if (item.Value.IsInt32)
                        valor = item.Value.AsInt32;
                    else if (item.Value.IsInt64)
                        valor = (int)item.Value.AsInt64;
                    else
                        continue;

                    etiquetas.Add(etiqueta);
                    valores.Add(valor);
                }

                Series serie5 = new Series("Conecciones");
                serie5.LabelForeColor = Color.White;
                chart4.Series.Add(serie5);
                chart4.Series[0].Points.DataBindXY(etiquetas, valores);
                chart4.Series[0].ChartType = SeriesChartType.Pie;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
