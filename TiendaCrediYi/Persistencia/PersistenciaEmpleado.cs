using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaEmpleado:IPersistenciaEmpleado
    {
        //patron singleton: 

        private static PersistenciaEmpleado _instancia = null;

        private PersistenciaEmpleado() { }

        public static PersistenciaEmpleado GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaEmpleado();
            return _instancia;
        }

        public Empleado Logueo(int pDocumento, string pContrasena)
        {
            SqlConnection sqlConnection = new SqlConnection(Conexion.Cnn());
            SqlConnection _cnn = sqlConnection;
            SqlCommand _comando = new SqlCommand("LOGUEO", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@DOCUMENTO", pDocumento);
            _comando.Parameters.AddWithValue("@CONTRASENA", pContrasena);
            Empleado E = null;
            SqlDataReader _Reader;

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                _Reader = _comando.ExecuteReader();
                if (_Reader.HasRows)
                {
                    _Reader.Read();
                    E = new Empleado((Convert.ToInt32(_Reader["DOCUMENTO"])),
                        (string)_Reader["CONTRASENA"].ToString(), 
                        (string)_Reader["NOMBRE"].ToString());
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                _cnn.Close();
                _cnn.Dispose();
            }

            return E;
        }
    }
}
