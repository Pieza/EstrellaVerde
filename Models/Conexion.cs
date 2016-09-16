using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;


namespace Estrella_Verde.Models
{
 public class Conexion
    {
        public OleDbConnection conexion;            //Hey muy buenas a todos aki guilirets komentando
        public OleDbCommand comando;                //Aqui creamos variables que no estoy muy seguro de que hacen xdxd
        String strcomando;
        String strconexion;
        OleDbTransaction transaccion;
        bool conecta;
        String xconecta;

        public void parametro()
        {
strconexion= "Provider=SQLOLEDB;Data Source=greenstar.database.windows.net;Initial Catalog='estrellaverde'; PersistSecurityInfo=True;User ID=pieza; Password=Chito258; Pooling=False;";//AQUI VA LA CADENA DE CONEXION DE SU SERVIDOR Y BASE DE DATOS
                     

        }


        public bool inicializa()
        {
            conexion = new OleDbConnection(strconexion);        //aqui prueba la conexion xdxd
            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public OleDbDataReader busca()                  //Aqui busca algo que no se que es
        {
            OleDbDataReader busca_int;
            comando.Prepare();
            busca_int = comando.ExecuteReader();
            comando.CommandTimeout = 0;
            return busca_int;
            conexion.Close();
            conexion.Dispose();

        }
        public bool annadir_consulta(String _Consulta)          //Añade consultas
        { 
         comando = new OleDbCommand(_Consulta, conexion);
         return false;
        }
        public bool annadir_parametro(Object _PARAMETRO, Int16 _TIPO)
        {
            OleDbParameter parametro;
            switch (_TIPO)                              //No se que hace aqui
            { 
                case 1:
                    parametro = comando.Parameters.Add("@InputParm", OleDbType.BigInt);
                    parametro.Value = _PARAMETRO;
                    break;
                case 2:
              
                    parametro = comando.Parameters.Add("@InputParm", OleDbType.VarChar,2500);
                    parametro.Value = _PARAMETRO;
                    break;
                case 3:
                   
                    parametro = comando.Parameters.Add("@InputParm", OleDbType.Decimal,10);
                    parametro.Value = _PARAMETRO;
                    parametro.Precision = 10;
                    parametro.Scale = 2;
                    break;
                case 4:

                    parametro = comando.Parameters.Add("@InputParm", OleDbType.Date);
                    parametro.Value = _PARAMETRO;
                    break;
                case 5:

                    parametro = comando.Parameters.Add("@InputParm", OleDbType.VarBinary,((byte[])_PARAMETRO).Length);
                    parametro.Value = _PARAMETRO;
                    break;

            }
            return false;
        }
        public bool ejecutasql(String sql)      //Ejecuta la base de datos
        {
            inicializa();
            transaccion = conexion.BeginTransaction();
            try
            {
                comando = new OleDbCommand(sql, conexion);
                comando.Transaction = transaccion;
                comando.ExecuteNonQuery();
                transaccion.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                return false;

            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }

        }
        public void cuadricula(string csql, System.Data.DataSet aux)
        {
            inicializa();
            OleDbDataAdapter da = new OleDbDataAdapter(csql, conexion);
            da.Fill(aux);


        }
        public Conexion()
        {

        }
    }

}