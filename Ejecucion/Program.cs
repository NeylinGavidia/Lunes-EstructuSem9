using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;

namespace Ejecucion
{
    public class Program
    {
        static void Main(string[] args)
        {
            Metodos mt = new Metodos();

            Console.WriteLine("********MENU*********");

            int op = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Insertar");
                Console.WriteLine("2. Mostrar todo");
                Console.WriteLine("3. Inorden");
                Console.WriteLine("4. Preorden");
                Console.WriteLine("5. Postorden");
                Console.WriteLine("6. Buscar");
                Console.WriteLine("7. Eliminar hoja");
                Console.WriteLine("0. Salir");
                Console.Write("Ingrese una opcion: ");
                try
                {
                    op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 0:
                            Console.WriteLine("Goodbye ¬^^¬");
                            break;
                        case 1:

                            Console.Write("Ingrese numero: ");
                            int p = int.Parse(Console.ReadLine());
                            mt.Insertar(ref mt.raiz_prin, p);
                            Console.WriteLine();
                            Console.Write("Registrado correctamente ^^");
                            break;
                        case 2:
                            mt.Mostrar(mt.raiz_prin, 0); //aqui se indica que el nivel inicia en cero
                            break;
                        case 3:
                            mt.Inorden(mt.raiz_prin);
                            break;
                        case 4:
                            mt.Preorden(mt.raiz_prin);
                            break;
                        case 5:
                            mt.Postorden(mt.raiz_prin);
                            break;
                        case 6:
                            Console.Write("Ingrese valor buscar: ");
                            int re = int.Parse(Console.ReadLine());
                            mt.Buscar(mt.raiz_prin, re);
                            break;
                        case 7:
                            Console.Write("Ingrese elemento a eliminar: ");
                            int ri = int.Parse(Console.ReadLine());
                            mt.EliminarNodito(ref mt.raiz_prin, ri);
                            break;
                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                    Console.ReadKey();


                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e);
                    op = 1;
                }

            }
            while (op != 0);
        }
    }
}
