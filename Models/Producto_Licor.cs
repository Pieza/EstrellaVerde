using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estrella_Verde.Models
{
    public class Producto_Licor
    {
         private int Id_Producto;
         private int Id_Licor;
        
        public Producto_Licor() { }

        public int _Id_Produco { get { return Id_Producto; } set { Id_Producto = value; } }
        public int _Id_Licor { get { return Id_Licor; } set { Id_Licor = value; } }

        public static List<Producto_Licor> Todos_los_Producto_Licor()
        {
            List<Producto_Licor> listaadevolver = new List<Producto_Licor>();
           

            Conexion cnx = new Conexion();
            cnx.parametro();
            cnx.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Seleccionar_Producto_Licor ?";
            cnx.annadir_consulta(CONSULTA);
            cnx.annadir_parametro(0, 1);
            CONTENEDOR = cnx.busca();
            while (CONTENEDOR.Read())
            {
                Models.Producto_Licor nuevoProducto_Licor = new Models.Producto_Licor();
                nuevoProducto_Licor.Id_Producto = Convert.ToInt32(CONTENEDOR["Id_Producto"]);
                nuevoProducto_Licor.Id_Licor = Convert.ToInt32(CONTENEDOR["Id_Licor"]);
                
                listaadevolver.Add(nuevoProducto_Licor);

            }
            cnx.conexion.Close();
            cnx.conexion.Dispose();
            CONTENEDOR.Close();
            return listaadevolver;
            
        }

        public static int Insert_Producto_Licor(int _Id_Producto, int _Id_Licor)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Insert_Producto_Licor ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id_Producto, 1);
            conx_detalles.annadir_parametro(_Id_Licor, 1);
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


        public static int Modificar_Producto_Licor(int _Id_Producto, int _Id_Licor)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Modificar_Producto_Licor ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id_Producto, 1);
            conx_detalles.annadir_parametro(_Id_Licor, 1);
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

        public static int Elimina_Producto_Licor(int _Id_Producto, int _Id_Licor)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Elimina_Producto ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id_Producto, 1);
            conx_detalles.annadir_parametro(_Id_Licor, 1);
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