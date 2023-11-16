using Entity;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        private static ServicioHabitacion servicioHabitacion = new ServicioHabitacion();
        private static ServicioHuesped servicioHuesped = new ServicioHuesped();

        public Form1()
        {
            InitializeComponent();
            tablaHabitaion();
            tablaHuesped();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Habitacion habitacion = new Habitacion();
            habitacion.idhabitacion = txtCodigoH.Text;
            habitacion.estado = cmbEstadoH.Text;
            habitacion.precio = decimal.Parse(txtPrecioH.Text);
            servicioHabitacion.Crear(habitacion);
            tablaHabitaion();
            limpiarTexto();


        }

        public void limpiarTexto()
        {
            txtCodigoH.Text = string.Empty;
            txtPrecioH.Text = string.Empty; 
            cmbEstadoH.SelectedIndex = 0;
            
        }

        public void tablaHabitaion()
        {
            tblHabitaciones.Rows.Clear();
            foreach (Habitacion h in servicioHabitacion.listaHabitacioens())
            {
                tblHabitaciones.Rows.Add(h.idhabitacion, h.estado, h.precio);
            }
        }

        private void btnCrearHu_Click(object sender, EventArgs e)
        {
            Huesped h = new Huesped();

            h.tipoIdentificacion = cmbTipoIdentificacion.Text;
            h.identificacion = int.Parse(txtIdentificacion.Text);
            h.pais = cmbPais.Text;
            h.nombreHuesped1 = txtPNombre.Text;
            h.nombreHuesped2 = txtSNombre.Text;
            h.apellidoHuesped = txtPApellido.Text;
            h.apellidoHuesped2 = txtSApellido.Text;
            h.emial = txtEmail.Text;
            h.telefono = long.Parse(txtTelefono.Text);
            h.estado = cmbEstadoHu.Text;

            servicioHuesped.Crear(h);

            tablaHuesped();
        }

        public void tablaHuesped()
        {

            tblHuespedes.Rows.Clear();
            foreach (Huesped h in servicioHuesped.listaHuespedes())
            {
                tblHuespedes.Rows.Add(h.tipoIdentificacion,h.identificacion,h.pais,h.nombreHuesped1,h.nombreHuesped2,h.apellidoHuesped,
                  h.apellidoHuesped2,h.emial,h.telefono,h.estado,h.cuenta);
            }
        }

        private void tblHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = tblHabitaciones.CurrentCell.RowIndex;

            txtCodigoH.Text = tblHabitaciones[0, fila].Value.ToString();
            cmbEstadoH.Text = tblHabitaciones[1, fila].Value.ToString();
            txtPrecioH.Text = tblHabitaciones[2, fila].Value.ToString();
            
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Habitacion H = servicioHabitacion.buscarHabitacion(txtCodigoH.Text);
            
            
        //    H.idhabitacion = txtCodigoH.Text;
        //    H.estado = cmbEstadoH.Text;
        //    H.precio = decimal.Parse(txtPrecioH.Text);
        //    servicioHabitacion.Modificar(H);
        //    tablaHabitaion();
        //    limpiarTexto();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Habitacion H = servicioHabitacion.buscarHabitacion(txtCodigoH.Text);

            H.idhabitacion = txtCodigoH.Text;
            H.estado = cmbEstadoH.Text;
            H.precio = decimal.Parse(txtPrecioH.Text);
            servicioHabitacion.Modificar(H);
            tablaHabitaion();
            limpiarTexto();
            

            if (servicioHabitacion.Modificar(H))
            {
                MessageBox.Show("L Actualizada exitosamente");
                btnModificar.Visible = false;
            }
            else
            {
                MessageBox.Show("Error al actualizar la Habitacion");
            }

            limpiarTexto();
        }

        //botton eliminar
        private void button3_Click(object sender, EventArgs e)
        {
         
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
