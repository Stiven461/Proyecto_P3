using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class RepositorioHabitacion
    {

        private readonly string FileName = "Habitaciones.txt";
      
        public RepositorioHabitacion()
        {
        
        }

        public bool Crear(Habitacion habitacion)
        {
            try
            {
                FileStream file = new FileStream(FileName, FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine($"{habitacion.idhabitacion};{habitacion.estado};{habitacion.precio}");
                writer.Close();
                file.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la venta: {ex.Message}");
                return false;

            }
        }

        public Habitacion buscarHabitacion(string codigo)
        {
            try
            {
               
                foreach (Habitacion h in listaHabitaciones())
                {
                    if (codigo == h.idhabitacion)
                    {
                        return h;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar por codigo: {ex.Message}");
                return null;
            }
        }

        public List<Habitacion> listaHabitaciones()
        {
            List<Habitacion> habitaciones = new List<Habitacion>();
            try
            {
                FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                string linea = string.Empty;
                while ((linea = reader.ReadLine()) != null)
                {
                    Habitacion habitacion = Map(linea);
                    habitaciones.Add(habitacion);
                }
                reader.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar las habitacioens: {ex.Message}");
            }
            return habitaciones;
        }

        private Habitacion Map(String linea)
        {
          
            try
            {
                Habitacion habitacion = new Habitacion();
                char delimiter = ';';
                string[] matrizHabitacion = linea.Split(delimiter);
                habitacion.idhabitacion = matrizHabitacion[0];
                habitacion.estado = matrizHabitacion[1];
                habitacion.precio = decimal.Parse(matrizHabitacion[2]);
               

                return habitacion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mapear: {ex.Message}");
                return null;
            }
        }
    }
}
