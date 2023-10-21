using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Habitacion
    {
        public string idhabitacion { get; set; }
        public string estado { get; set; }
  
        public decimal precio { get; set; }

        public Habitacion()
        {
        }

        public Habitacion(string idhabitacion, string estado, decimal precio)
        {
            this.idhabitacion = idhabitacion;
            this.estado = estado;
            this.precio = precio;
        }

    }
}
