using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
    public class Usuario
    {
        public string userName {  get; set; }
        public string password {  get; set; }
        public string estado {  get; set; }
        public int cedula {  get; set; }
        public string user {  get; set; }
        public string roll {  get; set; }
        public string apellido { get; set; }

        public Usuario()
        {
        }
        public Usuario(string userName, string password, int cedula, string user, string roll, string apellido)
        {
            this.userName = userName;
            this.password = password;
            this.estado = "activo";
            this.cedula = cedula;
            this.user = user;
            this.roll = roll;
            this.apellido = apellido;
        }

        

        
        public override string ToString()
        {
            return "Nombre = " + userName + "\nApellido = " + apellido + "\nCedula = " + cedula + "\nUsuario = " + user + "\nTipo usuario = " + roll;
        }
    }
}

