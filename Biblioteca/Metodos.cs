using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Metodos
    {
        public Nodo raiz_prin = null;

        public void Insertar(ref Nodo raiz, int d) // el ref hace que los datos se guarden en la principal y no en copias del nodo
        {
            if (raiz == null)
            { //esto es insertar

                Nodo nuevo = new Nodo();
                nuevo.dato = d;
                raiz = nuevo;
            }
            else
            {
                if (d < raiz.dato) //para guiarlo a la izquierda
                {
                    Insertar(ref raiz.iz, d); //envia el dato a la izquierda, eso sognifica
                }
                else if (d > raiz.dato) //para enviarlo a la derecha
                {
                    Insertar(ref raiz.de, d);
                }
                else //cuando son iguales
                {
                    Console.WriteLine("Dato duplicado");
                }
            }
        }
        public void Mostrar(Nodo raiz, int nivel)
        {
            if (raiz != null)
            {
                Mostrar(raiz.de, nivel + 1);//el arbol comienza a mostrarse desde la derecha y el nivel aumenta en 1
                for (int i = 0; i < nivel; i++)
                {
                    Console.Write("    ");
                }
                Console.WriteLine(raiz.dato); //muestra el elemtno root
                Mostrar(raiz.iz, nivel + 1); //sigue con la izquierda, menores
            }
        }
        public void Preorden(Nodo raiz)
        {
            if (raiz != null)
            {
                Console.WriteLine(raiz.dato);
                Preorden(raiz.iz);
                Preorden(raiz.de);
            }
            //sin recursividad no muere
        }
        public void Postorden(Nodo raiz)
        {
            if (raiz != null)
            {
                Postorden(raiz.iz);
                Postorden(raiz.de);
                Console.WriteLine(raiz.dato);
            }
        }
        public void Inorden(Nodo raiz)
        {
            if (raiz != null)
            {
                Inorden(raiz.iz);
                Console.WriteLine(raiz.dato);
                Inorden(raiz.de);

            }
        }
        public void Buscar(Nodo raiz, int d) //gual al insertar pero se quita la insercion y se modifica la recursividad
        {
            if (raiz == null)
            {
                Console.WriteLine("Valor no encontrado");
            }
            else //recorre
            {
                if (d < raiz.dato)
                {
                    Buscar(raiz.iz, d);
                }
                else if (d > raiz.dato)
                {
                    Buscar(raiz.de, d);
                }
                else //encuentra
                {
                    Console.WriteLine("Valor encontrado");
                }
            }
        }
        public Nodo EliminarNodito(ref Nodo raiz, int d) //gual al insertar pero se quita la insercion y se modifica la recursividad
        {
            if (raiz == null)
            {
                Console.WriteLine("Valor no encontrado");
            }
            else //recorre
            {
                if (d < raiz.dato)
                {
                    EliminarNodito(ref raiz.iz, d);
                }
                else if (d > raiz.dato)
                {
                    EliminarNodito(ref raiz.de, d);
                }
                else //encuentra
                {
                    if (raiz.iz == null && raiz.de == null) //condicional para ver que sea hoja
                    {
                        raiz = null;
                    }
                    else if (raiz.de == null) //condicional para ver que tenga un hijo a la izquierda
                    {
                        raiz = raiz.iz;
                        Console.WriteLine("Nota: Raiz de subarbol reemplazado a la izquierda");
                    }
                    else if (raiz.iz == null)//condicional para ver que tenga un hijo a la derecha
                    {
                        raiz = raiz.de;
                        Console.WriteLine("Nota: Raiz de subarbol reemplazado a la derecha");
                    }
                    else if (raiz.iz != null && raiz.de !=null) //por si tiene 2 hijos
                    {
                        Nodo rem = Reemplazo(raiz.iz);
                        raiz.dato = rem.dato; //se reemplaza el valor del nodo a eliminar por el reemplazo
                        EliminarNodito(ref raiz.iz, rem.dato); //se elimina el nodo que estaba como hoja y funciona de reemplazo
                        Console.WriteLine("Nota: Raiz de subarbol reemplazado por el mayor a la izquierda");
                    }
                    Console.WriteLine("Nodo eliminado");
                }
            }
            return raiz;
        }
        public Nodo Reemplazo(Nodo raiz) //necesario para los nodos con mas de un hijo, mayor de la izquierda esta vez
        {
            while (raiz.de != null) //mientras tenga un hijo a la derecha, se va moviendo a ese lado para encontrar el mayor
            {
                raiz = raiz.de;
            }

            return raiz;
        }
        //public void EliminarRama(ref Nodo raiz, int d) //borra toda la rama, es decir, el nodo y sus hijos
        //{
        //    if (raiz == null)
        //    {
        //        Console.WriteLine("Valor no encontrado");
        //    }
        //    else //recorre
        //    {
        //        if (d < raiz.dato)
        //        {
        //            EliminarRama(ref raiz.iz, d);
        //        }
        //        else if (d > raiz.dato)
        //        {
        //            EliminarRama(ref raiz.de, d);
        //        }
        //        else //encuentra
        //        {
        //            Console.WriteLine("Rama eliminada");
        //            raiz = null;
        //        }
        //    }
        //}
        //public void EliminarRaiz(ref Nodo raiz) //elimina toda la raiz
        //{
        //    if (raiz != null)
        //    {
        //        Console.WriteLine("Raiz eliminada");
        //        raiz = null;
        //    }
        //    else
        //    {
        //        Console.WriteLine("No hay raiz");
        //    }
        //}
    }
}
