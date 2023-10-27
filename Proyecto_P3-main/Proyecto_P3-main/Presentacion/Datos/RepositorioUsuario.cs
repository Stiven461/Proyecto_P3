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
    public class RepositorioUsuario
    {

        private readonly string FileName = "Usuario.txt";

        public RepositorioUsuario()
        {

        }

        public bool Crear(Usuario u)
        {
            try
            {
                FileStream file = new FileStream(FileName, FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine($"{u.userName};{u.password};{u.estado};{u.cedula};{u.user};{u.roll};{u.apellido}");
                writer.Close();
                file.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el Usuario: {ex.Message}");
                return false;

            }
        }

        public Usuario buscarUsuario(int cedula)
        {
            try
            {

                foreach (Usuario u in listaUsuario())
                {
                    if (cedula == u.cedula)
                    {
                        return u;
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

        public List<Usuario> listaUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                string linea = string.Empty;
                while ((linea = reader.ReadLine()) != null)
                {
                    Usuario usuario = Map(linea);
                    lista.Add(usuario);
                }
                reader.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar los Usuarios: {ex.Message}");
            }
            return lista;
        }

        private Usuario Map(String linea)
        {

            try
            {
                Usuario u = new Usuario();
                char delimiter = ';';
                string[] matrizHuesped = linea.Split(delimiter);
                u.userName = matrizHuesped[0];
                u.password = matrizHuesped[1];
                u.estado = matrizHuesped[2];
                u.cedula = int.Parse(matrizHuesped[3]);
                u.user = matrizHuesped[4];
                u.roll = matrizHuesped[5];
                u.apellido = matrizHuesped[6];
                

                return u;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mapear: {ex.Message}");
                return null;
            }
        }



    }
}
