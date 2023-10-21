using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Runtime.dll;//n...
using System.Timers;  //



namespace Entity
{
    public class Reserva
    {
        private int idReserva;
        private DateTime fechaEntrada;
        private DateTime fechaSalida;
        private Huesped huesped;
        private Habitacion habitacion;

        private static int contId = 0;

        public Reserva()
        {
        }

        public Reserva(DateTime fechaEntrada, DateTime fechaSalida, Huesped huesped, Habitacion habitacion)
        {
            this.idReserva = ++contId;
            this.fechaEntrada = fechaEntrada;
            this.fechaSalida = fechaSalida;
            this.huesped = huesped;
            this.habitacion = habitacion;
        }

       

        public int Duracion()
        {
            TimeSpan duracion = fechaSalida - fechaEntrada;
            int dias = (int)duracion.TotalDays;
            return dias;
        }

        //public double CalcularTotal()
        //{
        //    return habitacion.Precio * Duracion();
        //}

        //public override string ToString()
        //{
        //    return "Id Reserva = " + idReserva + "\nHuesped = " + huesped.Identificacion + "\nHabitacion = " + habitacion.IdHabitacion + "\nFecha Entrada = " +
        //        fechaEntrada + "\nFecha Salida = " + fechaSalida;
        //}
    }
}

