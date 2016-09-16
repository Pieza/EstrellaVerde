using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estrella_Verde.Models
{
    public class Producto
    {

        private int Id;
        private string Nombre;
        private float Precio;
        private List<Licor> listadelicores;
        public Producto() { }

        public int _Id { get { return Id; } set { Id = value; } }
        public string _Nombre { get { return Nombre; } set { Nombre = value; } }
        public float _Precio { get { return Precio; } set { Precio = value; } }

        public List<Licor> _listadelicores { get { return listadelicores; } set { listadelicores = value; } }

        public static List<Producto> Todos_los_Productos()
        {
            List<Producto> listaadevolver = new List<Producto>();
           

            Conexion cnx = new Conexion();
            cnx.parametro();
            cnx.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Seleccionar_Producto ?";
            cnx.annadir_consulta(CONSULTA);
            cnx.annadir_parametro(0, 1);
            CONTENEDOR = cnx.busca();
            while (CONTENEDOR.Read())
            {
                Models.Producto nuevoProducto = new Models.Producto();
                nuevoProducto.Id = Convert.ToInt32(CONTENEDOR["Id"]);
                nuevoProducto.Nombre = CONTENEDOR["Nombre"].ToString();
                nuevoProducto.Precio = Convert.ToInt32(CONTENEDOR["Precio"]);
                listaadevolver.Add(nuevoProducto);

            }
            cnx.conexion.Close();
            cnx.conexion.Dispose();
            CONTENEDOR.Close();
            return listaadevolver;
            
        }

        public static int Insert_Producto(int _Id, String _Nombre, int _Precio)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Insert_Producto ?,?,?";
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


        public static int Modificar_Producto(int _Id, String _Nombre, int _Precio)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Modificar_Producto ?,?,?";
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

        public static int Elimina_Producto(int _Id)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Elimina_Producto ?";
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