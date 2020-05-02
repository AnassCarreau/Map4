using System;

namespace Listas
{
	/// <summary>
	/// Lista para guardar números enteros. Se han de implementar todos los métodos que aquí aparecen
	/// </summary>
	public class Lista{

		/// <summary>
        /// Constructora de la lista. Construye una lista sin elementos
        /// </summary>
		public Lista(){
		}

        /// <summary>
        /// Devuelve el número de elementos contenidos en la lista
        /// </summary>
        /// <returns>El número de elementos (0, si está vacía)</returns>
		public int NumEltos(){
            return 0;
		}

		/// <summary>
		/// Devuelve el elemento que ocupa la n-ésima posición dentro de la lista
		/// </summary>
		/// <param name="n">Posición del elemento a recuperar dentro de la lista</param>
		/// <returns>El elemento en la posición n.</returns>
		/// <exception cref="System.Exception">Lanza una excepción en caso de que no exista la posición n</exception>
		public int N_esimo(int n){
            return 0;
		}

        /// <summary>
        /// Comprueba si un elemento está en la lista
        /// </summary>
        /// <param name="e">Elemento buscado</param>
        /// <returns>True, si el elemento e está en la lista. False, en otro caso</returns>
		public bool Esta(int e){
            return false;
		}

		/// <summary>
		/// Inserta un elemento al final de la lista
		/// </summary>
		/// <param name="x">Elemento a insertar en la lista</param>
		public void InsertaFin(int x){
		}

		/// <summary>
        /// Borra la primera aparición de un elemento en la lista
        /// </summary>
        /// <param name="x">Elemento buscado</param>
        /// <returns>True, si se ha eliminado el elemento. False, en caso de que el elemento no aparezca en la lista</returns>
		public bool BorraElto(int x){
            return false;
		}
	}
}

