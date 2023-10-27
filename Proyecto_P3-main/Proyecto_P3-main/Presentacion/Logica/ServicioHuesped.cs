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
    public class ServicioHuesped
    {
        private readonly RepositorioHuesped repositorioHuesped;
        public ServicioHuesped()
        {
            repositorioHuesped = new RepositorioHuesped();
        }

        public bool Crear(Huesped h)
        {
            try
            {
                Huesped huespedAnterior = repositorioHuesped.buscarHuesped(h.identificacion);
                if (huespedAnterior != null)
                {
                    MessageBox.Show("No se puede crear este huesped, debido a que ya existe uno con esta identificacion");
                    return false;
                }

                repositorioHuesped.Crear(h);
                MessageBox.Show($"El huesped {h.identificacion} se ha creado correctamente");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear al huesped: {ex.Message}");
                return false;
            }
        }

        public List<Huesped> listaHuespedes()
        {
            return repositorioHuesped.listaHuespedes();
            ;
        }
    }
}
