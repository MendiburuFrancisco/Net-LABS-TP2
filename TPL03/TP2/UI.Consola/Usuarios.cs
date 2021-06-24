using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios

    {
        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();

        }

        private UsuarioLogic _UsuarioNegocio;
 
        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value;  }
        }

        public void Menu()
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
                case 1: ListadoGeneral();  break;
                case 2: Consultar();  break;
                case 3:    break;
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
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presiona una tecla para continuar");
                Console.ReadKey();
            }
            
        }
        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();
    
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();

            Console.Write("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();

            Console.Write("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();

            Console.Write("Ingrese Email: ");
            usuario.Email = Console.ReadLine();

            Console.Write("Ingrese Habilitacion (1-Si/otro-No):  ");
            usuario.Habilitado = (Console.ReadLine() == "1");

            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}",usuario.ID);
        }
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();

                Console.Write("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                
                Console.Write("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();

                Console.Write("Ingrese Email: ");
                usuario.Email = Console.ReadLine();

                Console.Write("Ingrese Habilitacion (1-Si/otro-No):  ");
                usuario.Habilitado = (Console.ReadLine() == "1");

                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);



            }  catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresa debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
            }
            finally
            {
                Console.WriteLine("Presiona una tecla para continuar");
                Console.ReadKey();
            }
        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);

            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presiona una tecla para continuar");
                Console.ReadKey();
            }
        }

    }
}
