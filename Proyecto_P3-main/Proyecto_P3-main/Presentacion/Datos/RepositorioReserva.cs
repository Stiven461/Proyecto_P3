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
    public class RepositorioReserva
    {
        private readonly string FileName = "Reserva.txt";
        private readonly RepositorioHuesped repositorioHuesped;
        private readonly RepositorioHabitacion repositorioHabitacion;

        public RepositorioReserva()
        {
            repositorioHuesped = new RepositorioHuesped();
            repositorioHabitacion = new RepositorioHabitacion();
        }

        public bool Crear(Reserva r)
        {
            try
            {
                FileStream file = new FileStream(FileName, FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine($"{r.idReserva};{r.fechaEntrada.ToString("d")};{r.fechaSalida.ToString("d")};{r.huesped.identificacion};{r.habitacion.idhabitacion}");
                writer.Close();
                file.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la Reserva: {ex.Message}");
                return false;

            }
        }

        public Reserva busarReserva(int idReserva)
        {
            try
            {

                foreach (Reserva r in listaReserva())
                {
                    if (idReserva == r.idReserva)
                    {
                        return r;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar por IdReserva: {ex.Message}");
                return null;
            }
        }

        //----------
        public List<Reserva> listaReserva()
        {
            List<Reserva> lista = new List<Reserva>();
            try
            {
                FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                string linea = string.Empty;
                while ((linea = reader.ReadLine()) != null)
                {
                    Reserva reserva = Map(linea);
                    lista.Add(reserva);
                }
                reader.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar las Reservas: {ex.Message}");
            }
            return lista;
        }

        private Reserva Map(String linea)
        {
            int identificacion;
            string id;

            try
            {
                Reserva r = new Reserva();
                char delimiter = ';';
                string[] matrizHuesped = linea.Split(delimiter);
                r.idReserva = int.Parse(matrizHuesped[0]);
                r.fechaEntrada = DateTime.Parse(matrizHuesped[1]);
                r.fechaSalida = DateTime.Parse(matrizHuesped[2]);
                identificacion = int.Parse(matrizHuesped[3]);
                r.huesped = repositorioHuesped.buscarHuesped(identificacion);
                id = matrizHuesped[4];
                r.habitacion = repositorioHabitacion.buscarHabitacion(id);
            
                

                return r;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mapear: {ex.Message}");
                return null;
            }
        }

    }
}
