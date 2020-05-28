using System;
using Listas;

namespace Conqueror
{
    /// <summary>
    /// El jugador del juego se caracteriza por tener un determinado número
    /// de puntos de ataque y un número máximo de movimientos entre los mazos del juego.
    /// El jugador está sobre un mazo del tablero y puede moverse entre los mazos (hacia
    /// la izquierda o hacia la derecha) mientras le queden movimientos.
    /// El jugador puede intentar atacar una de las ciudades que están en el mazo
    /// en el que se encuentra actualmente. Si el ataque es exitoso, entonces conquista
    /// la ciudad.
    /// La puntuación final del jugador es el total de puntos de las ciudades conquistadas
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Número de movimientos que le quedan al jugador
        /// </summary>
        int remainingMovements;

        /// <summary>
        ///  Puntos de ataque del jugador
        /// </summary>
        int attackPoints;

        /// <summary>
        /// Mazo en el que se encuentra actualmente el jugador
        /// </summary>
        int currentPosition;

        /// <summary>
        /// Lista con las ciudades conquistadas por el jugador
        /// </summary>
        Lista conqueredCities;


        /// <summary>
        /// Constructora
        /// </summary>
        /// <param name="maxMovements">Número máximo de movimientos que puede realizar el jugador</param>
        /// <param name="AP">Puntos de ataque del jugador</param>
        /// <param name="initialDeckIndex">Posición inicial del jugador dentro de la secuencia de mazos</param>
        public Player(int maxMovements, int AP, int initialDeckIndex)
        {
            remainingMovements = maxMovements;
            attackPoints = AP;
            currentPosition = initialDeckIndex;
            conqueredCities = new Lista();
        }

        /// <summary>
        /// Intenta mover al jugador en una dirección un determinado número de pasos
        /// entre los mazos de un tablero. Si se mueve, devuelve si el jugador ha
        /// agotado sus movimientos
        /// </summary>
        /// <param name="theBoard">Tablero de juego</param>
        /// <param name="steps">Número de pasos que se va a mover</param>
        /// <param name="movementDir">Dirección de movimiento.</param>
        /// <returns>True si el jugador se ha movido y ha agotado todos sus movimientos;
        /// o false, si el jugador se ha movido pero aún le quedan movimientos.</returns>
        /// <exception cref="System.Exception">Lanza una excepción
        /// si el número de movimientos es un valor negativo,
        /// o si el número de movimientos que quiere hacer es mayor que
        /// el número de movimientos que le quedan al jugador</exception>
        /// 

        #region testPlayer


        #endregion

        public bool Move(Board theBoard, int steps, Direction movementDir)
        {
            if (steps < 0 || remainingMovements < steps)
            {
                throw new Exception("No se puede mover");
            }
            else
            {
                remainingMovements -= steps;
                currentPosition = theBoard.Move(currentPosition, steps, movementDir);
                return remainingMovements == 0;
            }

        }


        /// <summary>
        /// Devuelve el número total de puntos conseguidos por el jugador
        /// como la suma de los puntos de las ciudades conquistadas
        /// </summary>
        /// <param name="theBoard">El tablero de juego</param>
        /// <returns>El número total de puntos conseguidos (o 0, si el jugador
        /// no ha conquistado ninguna ciudad)</returns>
        public int ComputePlayerPoints(Board theBoard)
        {
            if (conqueredCities.NumEltos() != 0)
            {
                int suma = 0;
                for (int i = 0; i < conqueredCities.NumEltos(); i++)
                {
                    suma += theBoard.GetCityPoints(conqueredCities.N_esimo(i));
                }
                return suma;

            }
            else return 0;
        }


        /// <summary>
        /// Intenta atacar una ciudad. Devuelve el éxito del ataque.
        /// Si el ataque ha sido exitoso, entonces la ciudad será eliminada del
        /// mazo en el que está el jugador y será añadida a la lista de
        /// ciudades conquistadas por el jugador.
        /// </summary>
        /// <param name="theBoard">El tablero de juego</param>
        /// <param name="cityName">El nombre de la ciudad</param>
        /// <returns>True, si el jugador ha vencido en el ataque y ha conquistado
        /// la ciudad; o false, en otro caso</returns>
        /// <exception cref="System.Exception">Lanza una excepción
        /// si el nombre de la ciudad no existe,
        /// o si la ciudad no aparece en el mazo en el que está el jugador
        /// </exception>
        public bool AttackCity(Board theBoard, string cityName)
        {
            int cityindex = theBoard.FindCityByName(cityName);
            //excepcion         
            if (cityindex == -1 || !theBoard.FindCityInDeck(currentPosition, cityindex))
            { throw new Exception("Ciudad Erronea"); }
            else if (theBoard.AttackCity(cityindex, attackPoints))
            {
                conqueredCities.InsertaFin(cityindex);
                return theBoard.RemoveCityFromDeck(currentPosition, cityindex);
            }
            return false;
        }

        /// <summary>
        /// Devuelve el número de mazo en el que se encuentra actualmente el jugador
        /// </summary>
        /// <returns>Un númnero de mazo</returns>
        public int GetPosition()
        {
            return currentPosition;
        }

        /// <summary>
        /// Devuelve una cadena con información sobre el estado actual del jugador
        /// </summary>
        /// <returns>Una cadena con los puntos de ataque y el número de movimientos que le quedan</returns>
        public string GetPlayerStatus()
        {
            string status = "PLAYER STATUS" + Environment.NewLine;
            return status + "AP=" + attackPoints + " Movements=" + remainingMovements;
        }
    }
}
