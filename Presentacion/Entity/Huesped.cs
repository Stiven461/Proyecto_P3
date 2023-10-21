using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
        public class Huesped
        {
            public string tipoIdentificacion { get; set; }
            public int identificacion { get; set; }
            public string pais { get; set; }
        public string nombreHuesped1 { get; set; }
        public string nombreHuesped2 { get; set; }
            public string apellidoHuesped { get; set; }
            public string apellidoHuesped2 { get; set; }
            public string emial { get; set; }
            public long telefono { get; set; }
            public string estado { get; set; }
            public decimal cuenta { get; set; }

        public Huesped()
            {
                this.cuenta = 0;
            }

            public Huesped(string tipoIdentificacion, int identificacion, string pais, string nombreHuesped, string apellidoHuesped, string emial, long telefono,
                string nombreHuesped2, string apellidoHuesped2)
            {
                this.tipoIdentificacion = tipoIdentificacion;
                this.identificacion = identificacion;
                this.pais = pais;
                this.nombreHuesped1 = nombreHuesped;
                this.apellidoHuesped = apellidoHuesped;
                this.emial = emial;
                this.telefono = telefono;
                this.nombreHuesped2 = nombreHuesped2;
                this.apellidoHuesped2 = apellidoHuesped2;
                this.estado = "NO hospedado";
                this.cuenta = 0;
            }

        }
}

