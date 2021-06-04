using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using EntidadesCompartidas;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaCliente:IPersistenciaCliente
    {
        //Patrón Singleton

        private static PersistenciaCliente instancia = null;
        private PersistenciaCliente() { }
        public static PersistenciaCliente GetInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaCliente();

            return instancia;
        }

        public Cliente BuscarCliente(int pIdCliente)
        {
            string pTipoDoc;
            int pDoc;
            string pNombre;
            string pEmail;
            int pTel; 

            Cliente C = null;
            SqlConnection conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand comando = new SqlCommand("BUSCARCLIENTE", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IDCLIENTE", pIdCliente);

            SqlDataReader _Reader;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                _Reader = comando.ExecuteReader();

                if (_Reader.Read())
                {
                    pTipoDoc = (string)_Reader["TIPODOCUMENTO"];
                    pDoc = (int)_Reader["DOCUMENTO"];
                    pNombre = (string)_Reader["NOMBRE"];
                    pEmail = (string)_Reader["EMAIL"];
                    pTel = (int)_Reader["TELEFONO"];

                    C = new Cliente(pIdCliente, pTipoDoc, pDoc, pNombre, pEmail, pTel);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
            return C;
        }

        public Cliente BuscarClienteXCedula(int pDoc)
        {
            string pTipoDoc;
            int pIdCliente;
            string pNombre;
            string pEmail;
            int pTel;

            Cliente C = null;
            SqlConnection conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand comando = new SqlCommand("BUSCARCLIENTEXDOC", conexion);
            comando.CommandType = CommandType.StoredProcedure;
           
            comando.Parameters.AddWithValue("@DOCUMENTO", pDoc);

            SqlDataReader _Reader;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                _Reader = comando.ExecuteReader();

                if (_Reader.Read())
                {
                    pIdCliente = (int)_Reader["IDCLIENTE"];
                    pTipoDoc = (string)_Reader["TIPODOCUMENTO"];
                    pNombre = (string)_Reader["NOMBRE"];
                    pEmail = (string)_Reader["EMAIL"];
                    pTel = (int)_Reader["TELEFONO"];

                    C = new Cliente(pIdCliente, pTipoDoc, pDoc, pNombre, pEmail, pTel);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }

            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
            return C;
        }
    }
}
