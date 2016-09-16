using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estrella_Verde.Models
{
    public class Producto_Combo
    {
         private int Id_Producto;
         private int Id_Combo;
        
        public Producto_Combo() { }

        public int _Id_Produco { get { return Id_Producto; } set { Id_Producto = value; } }
        public int _Id_Combo { get { return Id_Combo; } set { Id_Combo = value; } }

        public static List<Producto_Combo> Todos_los_Producto_Combo()
        {
            List<Producto_Combo> listaadevolver = new List<Producto_Combo>();
           

            Conexion cnx = new Conexion();
            cnx.parametro();
            cnx.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Seleccionar_Producto_Combo ?";
            cnx.annadir_consulta(CONSULTA);
            cnx.annadir_parametro(0, 1);
            CONTENEDOR = cnx.busca();
            while (CONTENEDOR.Read())
            {
                Models.Producto_Combo nuevoProducto_Combo = new Models.Producto_Combo();
                nuevoProducto_Combo.Id_Producto = Convert.ToInt32(CONTENEDOR["Id_Producto"]);
                nuevoProducto_Combo.Id_Combo = Convert.ToInt32(CONTENEDOR["Id_Combo"]);
                
                listaadevolver.Add(nuevoProducto_Combo);

            }
            cnx.conexion.Close();
            cnx.conexion.Dispose();
            CONTENEDOR.Close();
            return listaadevolver;
            
        }

        public static int Insert_Producto_Combo(int _Id_Producto, int _Id_Combo)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Insert_Producto_Combo ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id_Producto, 1);
            conx_detalles.annadir_parametro(_Id_Combo, 1);
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


        public static int Modificar_Producto_Combo(int _Id_Producto, int _Id_Combo)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Modificar_Producto_Combo ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id_Producto, 1);
            conx_detalles.annadir_parametro(_Id_Combo, 1);
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

        public static int Elimina_Producto_Combo(int _Id_Producto, int _Id_Combo)
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
            conx_detalles.annadir_parametro(_Id_Combo, 1);
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