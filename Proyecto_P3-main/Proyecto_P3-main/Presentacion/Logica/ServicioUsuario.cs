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
    public class ServicioUsuario
    {

        private readonly RepositorioUsuario repositorioUsuario;
        public ServicioUsuario()
        {
            repositorioUsuario = new RepositorioUsuario();
        }

        public bool Crear(Usuario u)
        {
            try
            {
                Usuario usuarioAnterior = repositorioUsuario.buscarUsuario(u.cedula);
                if (usuarioAnterior != null)
                {
                    MessageBox.Show("No se puede crear este huesped, debido a que ya existe uno con esta identificacion");
                    return false;
                }

                repositorioUsuario.Crear(u);
                MessageBox.Show($"El usuario {u.cedula} se ha creado correctamente");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear al usuario: {ex.Message}");
                return false;
            }
        }

        public List<Usuario> listaUsuario()
        {
            return repositorioUsuario.listaUsuario();
            ;
        }

        public Usuario buscarUsuario(int cedula)
        {
            return repositorioUsuario.buscarUsuario(cedula);
            
        }

        public bool login(Usuario usuario)
        {
            foreach (Usuario u in repositorioUsuario.listaUsuario())
            {
                if(usuario.userName == u.userName && usuario.password == u.password)
                {
                    return true;
                }
                else
                    return false;

            }
            return false;

        }
    }
}
