using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estrella_Verde.Models
{
    public class Usuario
    {
        private int Id;
        private string Nombre;
        private int Tipo;
        private string Correo;
        private string Password;
        public Usuario() { }

        public int _Id { get { return Id; } set { Id = value; } }
        public string _Nombre { get { return Nombre; } set { Nombre = value; } }
        public int _Tipo { get { return Tipo; } set { Tipo = value; } }
        public string _Correo { get { return Correo; } set { Correo = value; } }
        public string _Password { get { return Password; } set { Password = value; } }

        

       

        public static List<Usuario> Todos_los_Usuarios()
        {
            List<Usuario> listaadevolver = new List<Usuario>();
            

            Conexion cnx = new Conexion();
            cnx.parametro();
            cnx.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Seleccionar_Usuario ?";
            cnx.annadir_consulta(CONSULTA);
            cnx.annadir_parametro(0, 1);
            CONTENEDOR = cnx.busca();
            while (CONTENEDOR.Read())
            {
                Models.Usuario nuevoUsuario = new Models.Usuario();
                nuevoUsuario.Id = Convert.ToInt32(CONTENEDOR["Id"]);
                nuevoUsuario.Nombre = CONTENEDOR["Nombre"].ToString();
                nuevoUsuario.Tipo = Convert.ToInt32(CONTENEDOR["Tipo"]);
                nuevoUsuario.Correo = CONTENEDOR["Correo"].ToString();
                nuevoUsuario.Password = CONTENEDOR["Password"].ToString();
                


                listaadevolver.Add(nuevoUsuario);

            }
            cnx.conexion.Close();
            cnx.conexion.Dispose();
            CONTENEDOR.Close();
            return listaadevolver;

        }
        public static int Insert_Usuario(int _Id, String _Nombre, int _Tipo, String _Correo, String _Password)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Insert_Usuario ?,?,?,?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id, 1);
            conx_detalles.annadir_parametro(_Nombre, 2);
            conx_detalles.annadir_parametro(_Tipo, 1);
            conx_detalles.annadir_parametro(_Correo, 2);
            conx_detalles.annadir_parametro(_Password, 2);
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

       

        public static int Modificar_Usuario(int _Id, String _Nombre, int _Tipo, String _Correo, String _Password)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Modificar_Usuario ?,?,?,?,?";
            conx_detalles.annadir_consulta(CONSULTA);
            conx_detalles.annadir_parametro(_Id, 1);
            conx_detalles.annadir_parametro(_Nombre, 2);
            conx_detalles.annadir_parametro(_Tipo, 1);
            conx_detalles.annadir_parametro(_Correo, 2);
            conx_detalles.annadir_parametro(_Password, 2);
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

        public static int Elimina_Usuario(int _Id)
        {
            int respuesta = 0;

            Conexion conx_detalles = new Conexion();
            conx_detalles.parametro();
            conx_detalles.inicializa();
            string CONSULTA;
            System.Data.OleDb.OleDbDataReader CONTENEDOR;

            CONSULTA = "EXEC Elimina_Usuario ?";
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


        public static int Login(int _Id , string _Password){
        int resultado = 0;
        Conexion conx_detalles = new Conexion();
        conx_detalles.parametro();
        conx_detalles.inicializa();
        string CONSULTA;
        System.Data.OleDb.OleDbDataReader CONTENEDOR;

        CONSULTA = "EXEC Login ?,?";
        conx_detalles.annadir_consulta(CONSULTA);
        conx_detalles.annadir_parametro(_Id, 1);
        conx_detalles.annadir_parametro(_Password, 2);
        CONTENEDOR = conx_detalles.busca();
   

        while (CONTENEDOR.Read()){
            resultado = Convert.ToInt32(CONTENEDOR[0].ToString());
    }
        return resultado;
    }



    }

}