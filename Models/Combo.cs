using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estrella_Verde.Models
{
    public class Combo
    {
        private int Id;
        private string Nombre;
        private float Precio;
        private List<Producto> listadeproductos;
        public Combo() { }

        public int _Id { get { return Id; } set { Id = value; } }
        public string _Nombre { get { return Nombre; } set { Nombre = value; } }
        public float _Precio { get { return Precio; } set { Precio = value; } }
        public List<Producto> _listadeproductos { get { return listadeproductos; } set { listadeproductos = value; } }
        
       

        public static List<Combo> Todos_los_Combos()
        {
            List<Combo> listaadevolver = new List<Combo>();
           

            Conexion cnx = new Conexion();
            cnx.parametro();
            cnx.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Seleccionar_Combo ?";
            cnx.annadir_consulta(CONSULTA);
            cnx.annadir_parametro(0, 1);
            CONTENEDOR = cnx.busca();
            while (CONTENEDOR.Read())
            {
                Models.Combo nuevoCombo = new Models.Combo();
                nuevoCombo.Id = Convert.ToInt32(CONTENEDOR["Id"]);
                nuevoCombo.Nombre = CONTENEDOR["Nombre"].ToString();
                nuevoCombo.Precio = Convert.ToInt32(CONTENEDOR["Precio"]);
                listaadevolver.Add(nuevoCombo);

            }
            cnx.conexion.Close();
            cnx.conexion.Dispose();
            CONTENEDOR.Close();
            return listaadevolver;

        }

        public static int Insert_Combo(int _Id, String _Nombre, int _Precio)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Insert_Combo ?,?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id, 1);
            conx_detalles.annadir_parametro(_Nombre, 2);
            conx_detalles.annadir_parametro(_Precio, 1);
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

      


        public static int Modificar_Combo(int _Id, String _Nombre, int _Precio)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Modificar_Combo  ?,?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id, 1);
            conx_detalles.annadir_parametro(_Nombre, 2);
            conx_detalles.annadir_parametro(_Precio, 1);
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

        public static int Elimina_Combo(int _Id)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Elimina_Combo ?";
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