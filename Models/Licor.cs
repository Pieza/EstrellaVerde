using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estrella_Verde.Models
{
    public class Licor
    {
        private int Id;
        private string Nombre;
       

        public Licor() { }

        public int _Id { get { return Id; } set { Id = value; } }
        public string _Nombre { get { return Nombre; } set { Nombre = value; } }

        
   

        public static List<Licor> Todos_los_Licores()
        {
            List<Licor> listaadevolver = new List<Licor>();
           
            Conexion cnx = new Conexion();
            cnx.parametro();
            cnx.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Seleccionar_Licor ?";
            cnx.annadir_consulta(CONSULTA);
            cnx.annadir_parametro(0, 1);
            CONTENEDOR = cnx.busca();
            while (CONTENEDOR.Read())
            {
                Models.Licor nuevoLicor = new Models.Licor();
                nuevoLicor.Id = Convert.ToInt32(CONTENEDOR["Id"]);
                nuevoLicor.Nombre = CONTENEDOR["Nombre"].ToString();
                
                listaadevolver.Add(nuevoLicor);

            }
            cnx.conexion.Close();
            cnx.conexion.Dispose();
            CONTENEDOR.Close();
            return listaadevolver;

        }

        public static int Insert_Licor(int _Id, String _Nombre)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Insert_Licor ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id, 1);
            conx_detalles.annadir_parametro(_Nombre, 2);
            
            CONTENEDOR = conx_detalles.busca();
            while (CONTENEDOR.Read())
            {
                respuesta = Convert.ToInt32(CONTENEDOR[0].ToString());
            }
            conx_detalles.conexion.Close();
            conx_detalles.conexion.Dispose();
            CONTENEDOR.Close();
            return respuesta;
        }

       


        public static int Modificar_Licor(int _Id, String _Nombre)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Modificar_Licor ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id, 1);
            conx_detalles.annadir_parametro(_Nombre, 2);
            
            CONTENEDOR = conx_detalles.busca();
            while (CONTENEDOR.Read())
            {
                respuesta = Convert.ToInt32(CONTENEDOR[0].ToString());
            }
            conx_detalles.conexion.Close();
            conx_detalles.conexion.Dispose();
            CONTENEDOR.Close();
            return respuesta;
        }

        public static int Elimina_Licor(int _Id)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Elimina_Licor ?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id, 1);
            
            
            CONTENEDOR = conx_detalles.busca();
            while (CONTENEDOR.Read())
            {
                respuesta = Convert.ToInt32(CONTENEDOR[0].ToString());
            }
            conx_detalles.conexion.Close();
            conx_detalles.conexion.Dispose();
            CONTENEDOR.Close();
            return respuesta;
        }




    }
}