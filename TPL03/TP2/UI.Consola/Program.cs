using System;

namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        public static void menu()
        {
            Console.WriteLine("'---- Menu ----" );
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

            public static void ListadoGeneral()
            {

            }
        }
    }
}
