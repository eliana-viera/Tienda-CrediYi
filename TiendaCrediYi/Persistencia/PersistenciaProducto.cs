using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using EntidadesCompartidas;
using System.Data;

namespace Persistencia
{
   internal class PersistenciaProducto:IPersistenciaProducto
    {
        //patron singleton: 

        private static PersistenciaProducto _instancia = null;

        private PersistenciaProducto() { }

        public static PersistenciaProducto GetInstancia()

        {
            if (_instancia == null)
                _instancia = new PersistenciaProducto();
            return _instancia;
        }

        public Producto BuscarProducto(int pIdProducto)
        {
            string pDescripcion;
            decimal pImporte;

            Producto P = null;
            SqlConnection conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand comando = new SqlCommand("BUSCARPRODUCTO", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IDPRODUCTO", pIdProducto);

            SqlDataReader _Reader;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                _Reader = comando.ExecuteReader();

                if (_Reader.Read())
                {
                     pIdProducto = (int)_Reader["IDPRODUCTO"];
                     pDescripcion = (string)_Reader["DESCRIPCION"];
                     pImporte = (decimal)_Reader["IMPORTE"];

                    P = new Producto(pIdProducto, pDescripcion, pImporte);
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
            return P;
        }

        public List<Producto> ListarProducto()
        {
            int _codigo;
            string _descripcion;
            decimal _monto;

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand _Comando = new SqlCommand("LISTARPRODUCTO", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            List<Producto> _Lista = new List<Producto>();
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Reader = _Comando.ExecuteReader();
                if (_Reader.HasRows)
                {

                    while (_Reader.Read())
                    {
                        _codigo = (int)_Reader["IDPRODUCTO"];
                        _descripcion = (string)_Reader["DESCRIPCION"];
                        _monto = (decimal)_Reader["IMPORTE"];
                        Producto P = new Producto(_codigo, _descripcion, _monto);
                        _Lista.Add(P);
                    }
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
                _Conexion.Dispose();
            }
            return _Lista;
        }

    }
}
