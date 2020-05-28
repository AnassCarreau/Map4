using System;
using System.IO;
using Listas;
namespace Conqueror
{
    public enum Direction { Left, Right, None };

    /// <summary>
    /// El tablero o Board se compone de una secuencia de mazos (Deck)
    /// de ciudades (City). Cada mazo puede tener 0 o varias ciudades. Cada
    /// ciudad puede aparecer en uno o varios mazos.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Cada ciudad se caracteriza por su nombre (name); los puntos de defensa
        /// (defense), que son los puntos de ataque necesarios para poder conquistar
        /// la ciudad; y los puntos (points) que el jugador ganará si consigue
        /// conquistar la ciudad.
        /// </summary>
        public struct City
        {
            public string name;
            public int defense;
            public int points;
        }

        /// <summary>
        /// El array de ciudades diferentes que hay en el juego
        /// </summary>
        City[] cities;

        /// <summary>
        /// Número total de ciudades diferentes que hay en el juego
        /// </summary>
        int nCities;

        /// <summary>
        /// array que representa la secuencia de mazos (decks) que hay
        /// en el juego. Casa mazo se compone de una lista de enteros que
        /// apuntan a las ciudades guardadas en cities
        /// </summary>
        Lista[] decks;

        /// <summary>
        /// Número total de mazos que hay en la secuencia de mazos
        /// </summary>
        int nDecks;


        /// <summary>
        /// Constructora.
        /// </summary>
        /// <param name="maxCities">Número máximo de ciudades del tablero</param>
        /// <param name="numDecks">Número de mazos del tablero</param>
        public Board(int maxCities, int numDecks)
        {
            nDecks = numDecks;
            decks = new Lista[nDecks];
            for (int i = 0; i < nDecks; i++) { decks[i] = new Lista(); }
            nCities = maxCities;
            cities = new City[nCities];
        }

        #region Tests Board

        public Board CrearBoardTest(Board boardTest)
        {
            boardTest.AddCity("Alejandretta", 4, 5);
            boardTest.AddCity("Babilonia", 6, 10);
            boardTest.AddCity("Troya", 2, 2);

            boardTest.AddCityToDeck("Alejandretta", 0);
            boardTest.AddCityToDeck("Troya", 0);
            boardTest.AddCityToDeck("Troya", 1);
            boardTest.AddCityToDeck("Alejandretta", 3);
            boardTest.AddCityToDeck("Babilonia", 3);
            return boardTest;
        }

        #endregion

        /// <summary>
        /// Intenta crear una carta de ciudad en el tablero
        /// </summary>
        /// <param name="cityName">Nombre de la ciudad</param>
        /// <param name="cityDefense">Puntos de defensa</param>
        /// <param name="cityPoints">Puntos para el jugador en caso de conquista</param>
        /// <returns>True, si la ciudad ha podido ser creada.
        /// False, si no hay espacio para crear una nueva ciudad
        /// </returns>
        public bool AddCity(string cityName, int cityDefense, int cityPoints)
        {
            if (cities[cities.Length - 1].name == null)
            {
                int i = 0;
                while (i < cities.Length)
                {
                    if (cities[i].name == null)
                    {
                        cities[i].name = cityName;
                        cities[i].defense = cityDefense;
                        cities[i].points = cityPoints;
                        return true;
                    }
                    i++;
                }
            }
            return false;
        }

        /// <summary>
        /// Intenta añadir una ciudad a uno de los mazos del tablero
        /// </summary>
        /// <param name="cityName">Nombre de la ciudad</param>
        /// <param name="deckIndex">Posición del mazo en el que se quiere añadir</param>
        /// <returns>True, si la ciudad ha podido ser añadida al mazo.
        /// False, si la ciudad o el mazo no existen
        /// </returns>
        public bool AddCityToDeck(string cityName, int deckIndex)
        {
            if (deckIndex < nDecks)
            {
                int i = 0;
                while (i < cities.Length)
                {
                    if (cities[i].name == cityName)
                    {

                        decks[deckIndex].InsertaFin(i);
                        return true;
                    }
                    i++;
                }
            }
            return false;

        }

        /// <summary>
        /// Calcula el total de puntos de defensa de las ciudades que componen un mazo
        /// </summary>
        /// <param name="deckIndex">Posición del mazo dentro de la secuencia de mazos</param>
        /// <returns>La suma de los puntos de defensa de todas las ciudades que componen un mazo
        /// (o 0, si no hay ciudades en ese mazo).</returns>
        public int ComputeDefensePointsInDeck(int deckIndex)
        {
            int suma = 0;
            int cityIndex;
            for (int i = 0; i < decks[deckIndex].NumEltos(); i++)
            {
                cityIndex = decks[deckIndex].N_esimo(i);
                suma += cities[cityIndex].defense;
            }
            return suma;

        }

        /// <summary>
        /// Devuelve cuál es el mazo en el que termina el jugador, después de moverse
        /// un determinado de posiciones en una dirección. Hay que tener en cuenta que el movimiento
        /// es cíclico, de modo que:
        /// - Si nos movemos hacia la derecha, al llegar al último mazo de la derecha seguiremos contando
        ///   por el primer mazo de la izquierda.
        /// - Si nos movemos hacia la izquierda, al llegar al primer mazo de la izquierda seguiremos contando
        ///   por el último mazo de la derecha.
        /// </summary>
        /// <param name="playerPosition">Posición inicial del jugador dentro de la secuencia de mazos</param>
        /// <param name="steps">Número de pasos que se va a mover (siempre es un número positivo)</param>
        /// <param name="movementDir">Dirección de movimiento</param>
        /// <returns>La posición en la que termina el jugador dentro de la secuencia de mazos</returns>
        public int Move(int playerPosition, int steps, Direction movementDir)
        {
            int move = 0;
            if (movementDir == Direction.Right) { move = 1; }
            else move = -1;
            for (int i = 0; i < steps; i++)
            {
                playerPosition += move;

            }

            if (playerPosition < 0)
            { playerPosition = decks.Length + playerPosition; }
            else if (playerPosition >= decks.Length)
            { playerPosition = playerPosition - decks.Length; }

            return playerPosition;
        }

        /// <summary>
        /// Devuelve el número de puntos que da al jugador una ciudad 
        /// </summary>
        /// <param name="cityIndex">Posición que ocupa la ciudad dentro del array de ciudades</param>
        /// <returns>El número de puntos que da al jugador la ciudad</returns>
        public int GetCityPoints(int cityIndex)
        {
            return cities[cityIndex].points;

        }

        /// <summary>
        /// Comprueba el resultado de atacar una ciudad con unos determinados puntos de ataque.
        /// Devuelve el éxito o fracaso del ataque, teniendo en cuenta que un ataque
        /// es exitoso cuando el número de puntos de ataque es estrictamente mayor que el número de puntos
        /// de defensa de la ciudad atacada.
        /// </summary>
        /// <param name="cityIndex">Posición que ocupa la ciudad dentro del array de ciudades</param>
        /// <param name="attackPoints">Número de puntos con los que se ataca la ciudad</param>
        /// <returns>True si el ataque fue un éxito; false, en otro caso </returns>
        public bool AttackCity(int cityIndex, int attackPoints)
        {
            return cities[cityIndex].defense < attackPoints;
        }

        /// <summary>
        /// Elimina una ciudad de un mazo. Devuelve si la operación se ha podido realizar
        /// </summary>
        /// <param name="deckIndex">Posición del mazo dentro de la secuencia de mazos</param>
        /// <param name="cityIndex">Posición que ocupa la ciudad dentro del array de ciudades</param>
        /// <returns>True, si la ciudad ha sido eliminada; false, en otro caso (el
        /// número de mazo no existe o la ciudad indicada no aparece en el mazo)</returns>
        public bool RemoveCityFromDeck(int deckIndex, int cityIndex)
        {
            return decks[deckIndex].BorraElto(cityIndex);
        }


        /// <summary>
        /// Busca una ciudad por nombre y devuelve su posición dentro del array de ciudades del tablero.
        /// No se espera que haya ciudades con nombres repetidos
        /// </summary>
        /// <param name="cityName">Nombre de la ciudad buscada</param>
        /// <returns>Si existe, devuelve la posición [0, nCities-1] de la ciudad.
        /// En caso contrario, devuelve -1</returns>
        public int FindCityByName(string cityName)
        {
            int i = 0;
            while (i < cities.Length)
            {
                if (cities[i].name == cityName)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        public bool FindCityInDeck(int deckIndex, int cityIndex)
        {
            return decks[deckIndex].Esta(cityIndex);
        }
        /// <summary>
        /// Devuelve una cadena con información sobre las cartas de un mazo
        /// </summary>
        /// <param name="deckIndex">Posición del mazo</param>
        /// <returns>Cadena con las cartas del mazo</returns>
        public string ShowDeck(int deckIndex)
        {
            string result = "";
            if (decks[deckIndex].NumEltos() == 0)
            {
                result = "This deck is empty";
            }
            else
            {
                result = "Cities in this deck: " + Environment.NewLine;
                for (int i = 0; i < decks[deckIndex].NumEltos(); i++)
                {
                    int cityIndex = decks[deckIndex].N_esimo(i);
                    result += (cities[cityIndex].name) + Environment.NewLine;
                }
                result += "Total defense: " + ComputeDefensePointsInDeck(deckIndex);
            }
            return result;
        }

        /// <summary>
        /// Devuelve el número de ciudades que hay en un mazo
        /// </summary>
        /// <param name="deckIndex">Posición del mazo</param>
        /// <returns>Número de ciudades que hay en el mazo (0, si no hay ninguna)</returns>
        public int CitiesInDeck(int deckIndex)
        {
            return decks[deckIndex].NumEltos();
        }

        public bool CreateCity(string l)
        {
            string[] auxiliar = l.Split(' ');
            return AddCity(auxiliar[1], int.Parse(auxiliar[2]), int.Parse(auxiliar[3]));
        }
        public bool CreateCityinDeck(string l)
        {
            string[] auxiliar = l.Split(' ');
            return AddCityToDeck(auxiliar[2], int.Parse(auxiliar[1]));
        }
        
    }
}
