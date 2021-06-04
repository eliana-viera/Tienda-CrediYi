using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente
    {
        private int idCliente;
        private string tipoDocumento;
        private int numeroDocumento;
        private string nombre;
        private string email;
        private int telefono;
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }

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
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public Cliente(int pIdCliente, string pTipoDoc, int pNumDoc, string pNom, string pEmail, int pTelefono)
        {
            IdCliente = pIdCliente;
            TipoDocumento = pTipoDoc;
            NumeroDocumento = pNumDoc;
            Nombre = pNom;
            Email = pEmail;
            Telefono = pTelefono;
        }
    }
}
