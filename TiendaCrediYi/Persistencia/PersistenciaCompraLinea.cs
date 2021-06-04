using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia
{
    internal class PersistenciaCompraLinea
    {
        //Patrón Singleton

        private static PersistenciaCompraLinea instancia = null;

        private PersistenciaCompraLinea() { }

        public static PersistenciaCompraLinea GetInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaCompraLinea();

            return instancia;
        }

        public void AgregarLinea(CompraLinea CL, int numComp, SqlTransaction _pTransaccion)
        {
            SqlCommand Comando = new SqlCommand("ALTACOMPRALINEA", _pTransaccion.Connection);
            Comando.CommandType = CommandType.StoredProcedure;

            Comando.Parameters.AddWithValue("@IDCABEZAL", numComp);
            Comando.Parameters.AddWithValue("@IDPROD", CL.Producto.IdProducto);
            Comando.Parameters.AddWithValue("@CANTIDAD", CL.Cantidad);

            SqlParameter _Retorno = new SqlParameter("@RETURN", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            Comando.Parameters.Add(_Retorno);
          
            int _afectados;

            try
            {
                Comando.Transaction = _pTransaccion;
                Comando.ExecuteNonQuery();
                _afectados = (int)Comando.Parameters["@RETURN"].Value;
                if (_afectados == -1)
                    throw new Exception("No existe el producto");
                if (_afectados == -2)
                    throw new Exception("Error en el numero de compra");
                if (_afectados == -3)
                    throw new Exception("Ocurrio un error al intentar agregar la línea de compra");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
        }

        public static List<CompraLinea> ListadoCL(int _numCabezal)
        {
            Producto _prod;
            int _cantidad;
            CompraLinea CL = null;

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand _Comando = new SqlCommand("LISTADOLINEAS", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("@IDCABEZAL", _numCabezal);

            List<CompraLinea> ListadoCL = new List<CompraLinea>();
            SqlDataReader _Reader;

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
                _Comando.CommandTimeout = 300;
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        _prod = PersistenciaProducto.GetInstancia().BuscarProducto((int)_Reader["IDPRODUCTO"]);
                        _cantidad = (int)_Reader["CANTIDAD"];

                        CL = new CompraLinea(_prod, _cantidad);
                        ListadoCL.Add(CL);
                    }
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
                _Conexion.Dispose();
            }
            return ListadoCL;
                
         }
    }
}
