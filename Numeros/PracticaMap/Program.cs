using System;

namespace Listas
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    /// <summary>
    /// Lista para guardar números enteros. Se han de implementar todos los métodos que aquí aparecen
    /// </summary>
    public class Lista
    {
      private class Nodo
        {
            public int dato;
            public Nodo sig; // enlace al siguiente nodo

            // constructoras
            public Nodo(int e) { dato = e; sig = null; }
            public Nodo(int e, Nodo n)
            {
                dato = e; sig = n;

            }

        }

        // atributos de la lista enlazada: referencia al primero y al último
        Nodo pri, ult;
        int nElems;


        /// <summary>
        /// Constructora de la lista. Construye una lista sin elementos
        /// </summary>
        public Lista()
        {
            pri = ult = null;
            nElems = 0;
        }
        public Lista(int lim, int rep)
        {
            for (int i = 1; i <= rep; i++)
            {
                for (int j = 1; j <= lim; j++)
                {
                    InsertaFin(j);
                }
            }
        }
        /// <summary>
        /// Devuelve el número de elementos contenidos en la lista
        /// </summary>
        /// <returns>El número de elementos (0, si está vacía)</returns>
        public int NumEltos()
        {
            return nElems;
        }
        // <summary>
            /// Devuelve el elemento que ocupa la n-ésima posición dentro de la lista
             /// </summary>
             /// <param name="n">Posición del elemento a recuperar dentro de la lista</param>
            /// <returns>El elemento en la posición n.</returns>
             /// <exception cref="System.Exception">Lanza una excepción en caso de que no exista la posición n</exception>
        public int N_esimo(int n)
        {
            if (n < 0 || n >= nElems) throw new Exception("error n-esimo");
            else
            {
                Nodo aux = pri;
                while (n > 0) { aux = aux.sig; n--; }
                return aux.dato;
            }
        }



         //<summary>
              /// Comprueba si un elemento está en la lista
              /// </summary>
              /// <param name="e">Elemento buscado</param>
              /// <returns>True, si el elemento e está en la lista. False, en otro caso</returns>
        public bool Esta(int e)
        {
            Nodo aux = buscaNodo(e);
            return (aux != null);

        }
        // auxiliar privada para buscar un nodo con un elto
        // devuelve referencia al nodo donde está el elto
        // devuelve null si no está ese elto
        private Nodo buscaNodo(int e)
        {
            Nodo aux = pri; // referencia al primero
            while (aux != null && aux.dato != e)
            {  // búsqueda de nodo con elto e
                aux = aux.sig;
            }
            // termina con aux==null (elto no encontrado)
            // o bien con aux apuntando al primer nodo con elto e
            return aux;
        }

        /// <summary>
        //      /// Inserta un elemento al final de la lista
        //      /// </summary>
        //      /// <param name="x">Elemento a insertar en la lista</param>
        public void InsertaFin(int x)
        {
            // si es vacia creamos nodo y apuntamos a el ppi y ult
            if (pri == null)
            {
                pri = new Nodo(x);
                pri.sig = null;
                ult = pri;
            }
            else
            {
                // si no, creamos nodo apuntado por ult.sig y enlazamos
                ult.sig = new Nodo(x);
                ult = ult.sig;
                ult.sig = null;
            }
            nElems++;
        }



        /// <summary>
        //      /// Borra la primera aparición de un elemento en la lista
        //      /// </summary>
        //      /// <param name="x">Elemento buscado</param>
        //      /// <returns>True, si se ha eliminado el elemento. False, en caso de que el elemento no aparezca en la lista</returns>
        public bool BorraElto(int x)
        {
            // lista vacia
            if (pri == null) return false;
            else
            {
                bool result = false;
                // eliminar el primero
                if (x == pri.dato)
                {
                    result = true;
                    nElems--;
                    // si solo tienen un elto
                    if (pri == ult)
                        pri = ult = null;
                    // si tiene más de uno
                    else
                        pri = pri.sig;
                }
                // eliminar otro distino al primero
                else
                {
                    // busqueda 
                    Nodo aux = pri;
                    // recorremos lista buscando el ANTERIOR al que hay que eliminar (para poder luego enlazar)
                    while (aux.sig != null && x != aux.sig.dato)
                        aux = aux.sig;
                    // si lo encontramos
                    if (aux.sig != null)
                    {
                        result = true;
                        nElems--;
                        // si es el ultimo cambiamos referencia al ultimo
                        if (aux.sig == ult)
                            ult = aux;
                        // puenteamos
                        aux.sig = aux.sig.sig;
                    }
                }
                return result;

            }
        }

    }
}

