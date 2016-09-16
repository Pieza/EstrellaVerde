using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estrella_Verde.Models
{
    public class Sucursal
    {
        private int Id;
        private string Provincia;
        private string Canton;
        private string Distrito;
        private string Nombre;
        private List<Sucursal> listadesucursales;
       

        public Sucursal() { }

        public int _Id { get { return Id; } set { Id = value; } }
        public string _Provincia { get { return Provincia; } set { Provincia = value; } }
        public string _Canton { get { return Canton; } set { Canton = value; } }
        public string _Distrito { get { return Distrito; } set { Distrito = value; } }
        public string _Nombre { get { return Nombre; } set { Nombre = value; } }

        public List<Sucursal> _listadecombos { get { return listadesucursales; } set { listadesucursales = value; } }

        


       

        public static List<Sucursal> Todos_los_Sucursales()
        {
            List<Sucursal> listaadevolver = new List<Sucursal>();
            

            Conexion cnx = new Conexion();
            cnx.parametro();
            cnx.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Seleccionar_Sucursal ?";
            cnx.annadir_consulta(CONSULTA);
            cnx.annadir_parametro(0, 1);
            CONTENEDOR = cnx.busca();
            while (CONTENEDOR.Read())
            {
                Models.Sucursal nuevoSucursal = new Models.Sucursal();
                nuevoSucursal.Id = Convert.ToInt32(CONTENEDOR["Id"]);
                nuevoSucursal.Provincia = CONTENEDOR["Provincia"].ToString();
                nuevoSucursal.Distrito = CONTENEDOR["Distrito"].ToString();
                nuevoSucursal.Canton = CONTENEDOR["Canton"].ToString();
                nuevoSucursal.Nombre = CONTENEDOR["Nombre"].ToString();

                listaadevolver.Add(nuevoSucursal);

            }
            cnx.conexion.Close();
            cnx.conexion.Dispose();
            CONTENEDOR.Close();
            return listaadevolver;

        }

        public static int Insert_Sucursal(int _Id, String _Provincia, String _Canton, String _Distrito, String _Nombre)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Insert_Sucursal ?,?,?,?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id, 1);
            conx_detalles.annadir_parametro(_Provincia, 2);
            conx_detalles.annadir_parametro(_Canton, 2);
            conx_detalles.annadir_parametro(_Distrito, 2);
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

        public static int Modificar_Sucursal(int _Id, String _Provincia, String _Canton, String _Distrito, String _Nombre)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Modificar_Sucursal ?,?,?,?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id, 1);
            conx_detalles.annadir_parametro(_Provincia, 2);
            conx_detalles.annadir_parametro(_Canton, 2);
            conx_detalles.annadir_parametro(_Distrito, 2);
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

       

        public static int Elimina_Sucursal(int _Id )
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Elimina_Sucursal ?";
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