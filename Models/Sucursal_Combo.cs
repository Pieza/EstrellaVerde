using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estrella_Verde.Models
{
    public class Sucursal_Combo
    {
         private int Id_Sucursal;
         private int Id_Combo;
        
        public Sucursal_Combo() { }

        public int _Id_Produco { get { return Id_Sucursal; } set { Id_Sucursal = value; } }
        public int _Id_Combo { get { return Id_Combo; } set { Id_Combo = value; } }

        public static List<Sucursal_Combo> Todos_los_Sucursal_Combo()
        {
            List<Sucursal_Combo> listaadevolver = new List<Sucursal_Combo>();
           

            Conexion cnx = new Conexion();
            cnx.parametro();
            cnx.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Seleccionar_Sucursal_Combo ?";
            cnx.annadir_consulta(CONSULTA);
            cnx.annadir_parametro(0, 1);
            CONTENEDOR = cnx.busca();
            while (CONTENEDOR.Read())
            {
                Models.Sucursal_Combo nuevoSucursal_Combo = new Models.Sucursal_Combo();
                nuevoSucursal_Combo.Id_Sucursal = Convert.ToInt32(CONTENEDOR["Id_Sucursal"]);
                nuevoSucursal_Combo.Id_Combo = Convert.ToInt32(CONTENEDOR["Id_Combo"]);
                
                listaadevolver.Add(nuevoSucursal_Combo);

            }
            cnx.conexion.Close();
            cnx.conexion.Dispose();
            CONTENEDOR.Close();
            return listaadevolver;
            
        }

        public static int Insert_Sucursal_Combo(int _Id_Sucursal, int _Id_Combo)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Insert_Sucursal_Combo ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id_Sucursal, 1);
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


        public static int Modificar_Sucursal_Combo(int _Id_Sucursal, int _Id_Combo)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Modificar_Sucursal_Combo ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id_Sucursal, 1);
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

        public static int Elimina_Sucursal_Combo(int _Id_Sucursal, int _Id_Combo)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Elimina_Sucursal ?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id_Sucursal, 1);
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