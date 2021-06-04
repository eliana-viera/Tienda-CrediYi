using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado
    {
        private int numeroDocumento;
        private string nombre;
        private string contrasena;

        public int NumeroDocumento
        {
            get { return numeroDocumento; }
            set { numeroDocumento = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public Empleado(int pNumDoc, string pNom, string pContrasena)
        {
            NumeroDocumento = pNumDoc;
            Nombre = pNom;
            Contrasena = pContrasena;
        }
    }
}