using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaCompraCabezal: IPersistenciaCompraCabezal
    {
        //Patrón Singleton

        private static PersistenciaCompraCabezal instancia = null;
        private PersistenciaCompraCabezal() { }
        public static PersistenciaCompraCabezal GetInstancia()
        {
            if (instancia == null)
                instancia = new PersistenciaCompraCabezal();

            return instancia;
        }

        public void AgregarCompraCabezal(CompraCabezal pComp)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand Comando = new SqlCommand("ALTACOMPRACABEZAL", _Conexion);
            Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _Retorno = new SqlParameter("@Cabezal", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            Comando.Parameters.Add(_Retorno);

            Comando.Parameters.AddWithValue("@SERIE", pComp.Serie);
            Comando.Parameters.AddWithValue("@NUMERO", pComp.Numero);
            Comando.Parameters.AddWithValue("@FECHA",pComp.Fecha);
            Comando.Parameters.AddWithValue("@IDCLIENTE", pComp.Cliente.IdCliente);
            Comando.Parameters.AddWithValue("@TOTAL", pComp.TotalCompra);

            SqlTransaction _transaccion = null;

            int _afectados;

            try
            {
                _Conexion.Open();
                _transaccion = _Conexion.BeginTransaction();
                Comando.Transaction = _transaccion;
                Comando.ExecuteNonQuery();

                _afectados = (int)Comando.Parameters["@Cabezal"].Value;

                if (_afectados == -1)
                    throw new Exception("Error al ingresar la compra");

                foreach (CompraLinea unaLinea in pComp.Lineas)
                {
                    PersistenciaCompraLinea.GetInstancia().AgregarLinea(unaLinea, _afectados, _transaccion);
                }

                 _transaccion.Commit();
            }
            catch (Exception ex)
            {
                _transaccion.Rollback();
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
        }

        public CompraCabezal BuscarCabezal(int pIdCabezal)
        {
            string pSerie;
            int pNumero;
            Cliente pCliente;
            DateTime pFecha;

            List<CompraLinea> pListaLinea;

            CompraCabezal CC = null;
            SqlConnection conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand comando = new SqlCommand("BUSCARCABEZAL", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IDCABEZAL", pIdCabezal);

            SqlDataReader _Reader;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                _Reader = comando.ExecuteReader();

                if (_Reader.Read())
                {
                    pSerie = (string)_Reader["SERIE"];
                    pNumero = (int)_Reader["NUMERO"];
                    pCliente = PersistenciaCliente.GetInstancia().BuscarCliente((int)_Reader["IDCLIENTE"]);
                    pFecha = (DateTime)_Reader["FECHA"];
                    pListaLinea = PersistenciaCompraLinea.ListadoCL(pIdCabezal);

                    CC = new CompraCabezal(pIdCabezal, pSerie, pNumero, pCliente, pFecha, pListaLinea);
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
            return CC;
        }

        public List<CompraCabezal> ListarCompraCabezal()
         {
            int pIdCabezal;
            string pSerie;
            int pNum;
            Cliente pCliente;
            DateTime pFecha;

            List<CompraLinea> pListaCL;

             CompraCabezal CC = null;

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand _comando = new SqlCommand("LISTADOCOMPRAS", _Conexion);
            _comando.CommandType = CommandType.StoredProcedure;
 
            List<CompraCabezal> _listaC = new List<CompraCabezal>();
             SqlDataReader _Reader;

             try
             {
                 _Conexion.Open();
                 _comando.ExecuteNonQuery();
                 _comando.CommandTimeout = 300;
                _Reader = _comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        pIdCabezal = (int)_Reader["IDCABEZAL"];
                        pSerie = (string)_Reader["SERIE"];
                        pNum = (int)_Reader["NUMERO"];
                        pCliente = PersistenciaCliente.GetInstancia().BuscarCliente((int)_Reader["IDCLIENTE"]);
                        pFecha = (DateTime)_Reader["FECHA"];
                        pListaCL = PersistenciaCompraLinea.ListadoCL(pIdCabezal).ToList();

                        CC = new CompraCabezal(pIdCabezal, pSerie, pNum, pCliente, pFecha, pListaCL);

                        _listaC.Add(CC);
                    }
                }
                 _Reader.Close();
             }
             catch (Exception ex)
             {
                 throw new ApplicationException(ex.Message);
             }
             finally
             {
                 _Conexion.Close();
                 _Conexion.Dispose();
             }
             return _listaC;
         }

        public List<CompraCabezal> ListarCompraCliente(int pdoc)
        {
            int pIdCabezal;
            string pSerie;
            int pNum;
            Cliente pCliente;
            DateTime pFecha;

            List<CompraLinea> pListaCL;

            CompraCabezal CC = null;

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand comando = new SqlCommand("LISTADOCOMPRASCLIENTE", _Conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@DOCUMENTOCLI", pdoc);

            List<CompraCabezal> _listaC = new List<CompraCabezal>();
            SqlDataReader _Reader;

            try
            {
                _Conexion.Open();
                comando.ExecuteNonQuery();
                _Reader = comando.ExecuteReader();
                comando.CommandTimeout = 300;

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        pIdCabezal = (int)_Reader["IDCABEZAL"];
                        pSerie = (string)_Reader["SERIE"];
                        pNum = (int)_Reader["NUMERO"];
                        pCliente = PersistenciaCliente.GetInstancia().BuscarClienteXCedula(pdoc);
                        pFecha = (DateTime)_Reader["FECHA"];
                        pListaCL = PersistenciaCompraLinea.ListadoCL(pIdCabezal).ToList();

                        CC = new CompraCabezal(pIdCabezal, pSerie, pNum, pCliente, pFecha, pListaCL);
                        _listaC.Add(CC);
                    }
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                _Conexion.Close();
                _Conexion.Dispose();
            }

            return _listaC;
        }
    }
}
