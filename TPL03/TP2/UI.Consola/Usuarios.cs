using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios

    {
        Usuarios()
        {
            UsuarioLogic nuevoUsuario = UsuarioNegocio;
        }

        private UsuarioLogic _UsuarioNegocio;
 
        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value;  }
        }

        public static void menu()
        {
            Console.WriteLine("'---- Menu ----");
            Console.WriteLine("1 - Listado General");
            Console.WriteLine("2 - Consulta");
            Console.WriteLine("3 - Agregar");
            Console.WriteLine("4 - Modificiar");
            Console.WriteLine("5 - Eliminar");
            Console.WriteLine("6 - Salir");
            int op = 0;

            while (op == 0)
            {
                Console.WriteLine("Seleccionar una opcion");
                op = int.Parse(Console.ReadLine());
            }

            switch (op)
            {
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: break;
                case 6: break;
            }


        }
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();

        }
        public void Consultar()
        {

        }
        public void Agregar()
        {

        }
        public void Modificar()
        {

        }
        public void Eliminar()
        {

        }

    }
}
