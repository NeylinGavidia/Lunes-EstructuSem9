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
            if (raiz == null) { //esto es insertar

                Nodo nuevo = new Nodo();
                nuevo.dato = d;
                raiz = nuevo;
            }
            else
            {
                if (d<raiz.dato) //para guiarlo a la izquierda
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
            if (raiz != null){
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
            if (raiz !=null)
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
                        Console.WriteLine("Hoja eliminada");
                        return null;
                    }
                    else
                    {
                        Console.WriteLine("El nodo no es hoja");
                    }
                }
            }
            return raiz;
        }
    }
}
