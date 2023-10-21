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
    public class RepositorioHuesped
    {

        private readonly string FileName = "Huesped.txt";

        public RepositorioHuesped()
        {

        }

        public bool Crear(Huesped h)
        {
            try
            {
                FileStream file = new FileStream(FileName, FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine($"{h.tipoIdentificacion};{h.identificacion};{h.pais};{h.nombreHuesped1};{h.nombreHuesped2};{h.apellidoHuesped};{h.apellidoHuesped2};{h.emial};{h.telefono};{h.estado};{h.cuenta}");
                writer.Close();
                file.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el huesped: {ex.Message}");
                return false;

            }
        }

        public Huesped buscarHuesped(int identificacion)
        {
            try
            {

                foreach (Huesped h in listaHuespedes())
                {
                    if (identificacion == h.identificacion)
                    {
                        return h;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar por identificaion: {ex.Message}");
                return null;
            }
        }

        public List<Huesped> listaHuespedes()
        {
            List<Huesped> lista = new List<Huesped> ();
            try
            {
                FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                string linea = string.Empty;
                while ((linea = reader.ReadLine()) != null)
                {
                    Huesped huesped = Map(linea);
                    lista.Add(huesped);
                }
                reader.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar los huespedes: {ex.Message}");
            }
            return lista;
        }

        private Huesped Map(String linea)
        {

            try
            {
                Huesped h = new Huesped();
                char delimiter = ';';
                string[] matrizHuesped = linea.Split(delimiter);
                h.tipoIdentificacion = matrizHuesped[0];
                h.identificacion = int.Parse(matrizHuesped[1]);
                h.pais = matrizHuesped[2];
                h.nombreHuesped1 = matrizHuesped[3];
                h.nombreHuesped2 = matrizHuesped[4];
                h.apellidoHuesped = matrizHuesped[5];
                h.apellidoHuesped2 = matrizHuesped[6];
                h.emial = matrizHuesped[7];
                h.telefono = long.Parse(matrizHuesped[8]);  
                h.estado = matrizHuesped[9];
                h.cuenta = decimal.Parse(matrizHuesped[10]);

                return h;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mapear: {ex.Message}");
                return null;
            }
        }
    }
}
