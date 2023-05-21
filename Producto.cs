using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading.Tasks;

namespace ABD_Monitoreo_MongoDB
{
    internal class Cliente
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("Telefono")]
        public string Telefono { get; set; }
        [BsonElement("Correo")]
        public string Correo { get; set; }

        public Cliente(string nombre, string telefono, string correo)
        {
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
        }
    }

    internal class Producto
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("precio")]
        public Decimal128 Precio { get; set; }
        [BsonElement("Proveedor")]
        public string Proveedor { get; set; }

        public Producto(string nombre, Decimal128 precio, string proveedor)
        {
            Nombre = nombre;
            Precio = precio;
            Proveedor = proveedor;
        }
    }
}
