using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class ServicioHabitacion
    {
        private readonly RepositorioHabitacion repositorioHabitacion;

        public ServicioHabitacion() { 
            
            repositorioHabitacion = new RepositorioHabitacion();
        }

        public bool Crear(Habitacion habitacion)
        {
            try
            {
                Habitacion HabitacionAnterior = repositorioHabitacion.buscarHabitacion(habitacion.idhabitacion);
                if (HabitacionAnterior != null)
                {
                    MessageBox.Show("No se puede crear esta habitacion, debido a que ya existe uno con esta identificacion");
                    return false;
                }

                repositorioHabitacion.Crear(habitacion);
                MessageBox.Show($"La habitacion {habitacion.idhabitacion} se ha creado correctamente");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la habitacion: {ex.Message}");
                return false;
            }
        }

        public Habitacion buscarHabitacion(string idhabitacion)
        {
            return repositorioHabitacion.buscarHabitacion(idhabitacion);
        }

        public bool Modificar(Habitacion habitacion)
        {
            return repositorioHabitacion.Modificar(habitacion);
        }

        /////////////////////////////////////////
        public bool Eliminar(Habitacion habitacion)
        {
            return repositorioHabitacion.Eliminar(habitacion);
        }

        /////////////////////////////////

        public List<Habitacion> listaHabitacioens ()
        {
            return repositorioHabitacion.listaHabitaciones();
;        }

    }
}
