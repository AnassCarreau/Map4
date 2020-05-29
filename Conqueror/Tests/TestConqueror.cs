using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Conqueror;

namespace Tests
{
    [TestFixture]
    public class BoardTest
    {
        /// <summary>
        /// PRUEBAS DE int FindCityByName(string cityName);
        /// casos
        /// 1. Ciudad que no existe
        /// 2. Ciudad que existe
        /// 3. Ciudad con mayusculas
        /// 4. Ciudad con minusculas
        /// </summary>
        [Test]
        public void FindCityByNameExistente()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numName = b.FindCityByName("Troya");
            //Assert
            Assert.That(numName, Is.GreaterThan(-1), "ERROR: el nombre de la ciudad no existe");
        }

        [Test]
        public void FindCityByNameNoExistente()
        {
            //Arrange 
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numName = b.FindCityByName("Madrid");
            //Assert
            Assert.That(numName, Is.EqualTo(-1), "ERROR: el nombre de la ciudad si existe");
        }

        [Test]
        public void FindCityByNameMayusculas()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numName = b.FindCityByName("TROYA");
            //Assert
            Assert.That(numName, Is.EqualTo(-1), "ERROR: el nombre de la ciudad esta escrito en mayusculas");

        }

        [Test]
        public void FindCityByNameMinusculas()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numName = b.FindCityByName("troya");
            //Assert
            Assert.That(numName, Is.EqualTo(-1), "ERROR: el nombre de la ciudad esta escrito en minusculas");
        }

        /// <summary>
        /// PRUEBAS DE bool AttackCity(int cityIndex, int attackPoints);
        /// casos
        /// 1. Ataque con exito
        /// 2. Ataque fallido
        /// 3. Ataque con mismo numero de defensa de la ciudad
        /// 4. Ataque con numero negativo
        /// </summary>

        [Test]
        public void AttackCityExito()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsTrue(b.AttackCity(0,5), "ERROR: No se ha podido atacar a la ciudad");
        }

        [Test]
        public void AttackCityFallo()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsFalse(b.AttackCity(0, 3), "ERROR: Se ataco a la ciudad con exito");
        }

        [Test]
        public void AttackCityMismoAtaqueDefensa()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsFalse(b.AttackCity(0, 4), "ERROR: el ataque no fue el mismo que la defensa de la torre");
        }

        public void AttackCityAtaqueNegativo()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsFalse(b.AttackCity(0, -4), "ERROR: el ataque no es negativo");
        }

        /// <summary>
        /// PRUEBAS DE bool RemoveCityFromDeck(int deckIndex, int cityIndex);
        /// casos
        /// 1. Ciudad existente en mazo
        /// 2. Ciudad no existente en mazo
        /// 3. Numero de mazo no existente
        /// </summary>

        [Test]
        public void RemoveCityFromDeckCiudadExistenteEnMazo()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsTrue(b.RemoveCityFromDeck(0, 0), "ERROR: La ciudad no esta en ningun mazo del tablero");
        }

        [Test]
        public void RemoveCityFromDeckCiudadNoExistenteEnMazo()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsFalse(b.RemoveCityFromDeck(0, 1), "ERROR: La ciudad existe en uno de los mazos del tablero");
        }

        [Test]
        public void RemoveCityFromDeckNumeroDeMazoNoExistente()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsFalse(b.RemoveCityFromDeck(9, 0), "ERROR: El mazo existe en el tablero");
        }

        /// <summary>
        /// PRUEBAS DE int Move(int playerPosition, int steps, Direction movementDir);
        /// casos
        /// 1. Moverse cero derecha e izquierda
        /// 2. Moverse derecha e izquierda no ciclico
        /// 3. Moverse derecha e izquierda ciclico
        /// 4. No moverse si entra un numero negativo derecha e izquierda
        /// </summary>

        [Test]
        public void MoveCeroIzq()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numPos = b.Move(9, 0, Direction.Left);
            //Assert
            Assert.That(numPos, Is.EqualTo(9), "ERROR: no te mueves 0 pasos");
        }

        [Test]
        public void MoveCeroDer()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numPos = b.Move(9, 0, Direction.Right);
            //Assert
            Assert.That(numPos, Is.EqualTo(9), "ERROR: no te mueves 0 pasos");
        }

        [Test]
        public void MoveIzq()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numPos = b.Move(9, 2, Direction.Left);
            //Assert
            Assert.That(numPos, Is.EqualTo(7),"ERROR: no te mueves correctamente a la izquierda");
        }

        [Test]
        public void MoveIzqCiclico()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numPos = b.Move(0, 2, Direction.Left);
            //Assert
            Assert.That(numPos, Is.EqualTo(8), "ERROR: no se hace correctamente el movimiento ciclico a la izquierda");
        }

        [Test]
        public void MoveDer()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numPos = b.Move(7, 1, Direction.Right);
            //Assert
            Assert.That(numPos, Is.EqualTo(8), "ERROR: no te mueves correctamente a la derecha");
        }

        [Test]
        public void MoveDerCiclico()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numPos = b.Move(9, 2, Direction.Right);
            //Assert
            Assert.That(numPos, Is.EqualTo(1), "ERROR: no se hace correctamente el movimiento ciclico a la derecha");
        }

        [Test]
        public void MoveNumNegativoDer()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numPos = b.Move(9, -2, Direction.Right);
            //Assert
            Assert.That(numPos, Is.EqualTo(9), "ERROR: no se hace correctamente el movimiento ciclico a la derecha");
        }

        [Test]
        public void MoveNumNegativoIzq()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            int numPos = b.Move(9, -2, Direction.Left);
            //Assert
            Assert.That(numPos, Is.EqualTo(9), "ERROR: no se hace correctamente el movimiento ciclico a la derecha");
        }
    }

    [TestFixture]
    public class PlayerTest
    {
        /// <summary>
        /// PRUEBAS DE bool Move(Board theBoard, int steps, Direction movementDir);
        /// casos
        /// 1. Moverse cero derecha e izquierda
        /// 2. Moverse derecha e izquierda no ciclico
        /// 3. Moverse derecha e izquierda ciclico
        /// 4. No moverse si entra un numero negativo derecha e izquierda
        /// 5. Moverse y no agotar movimientos max
        /// 6. Moverse y justo agotar los movimientos max
        /// 7. No moverse porque no quedan movimientos max
        /// </summary>
        [Test]
        public void MoveCeroDer()
        {
            //Arrange
            Player p = new Player(3, 3, 3);
            Board b = new Board(10, 10);
            int pos;
            //Act
            p.Move(b, 0, Direction.Right);
            pos = p.GetPosition();
            //Assert
            Assert.That(pos, Is.EqualTo(3), "ERROR: el player no se mueve correctamente a la izquierda");
        }

        [Test]
        public void MoveCeroIzq()
        {
            //Arrange
            Player p = new Player(3, 3, 3);
            Board b = new Board(10, 10);
            int pos;
            //Act
            p.Move(b, 0, Direction.Left);
            pos = p.GetPosition();
            //Assert
            Assert.That(pos, Is.EqualTo(3), "ERROR: el player no se mueve correctamente a la izquierda");
        }

        [Test]
        public void MoveIzq()
        {
            //Arrange
            Player p = new Player(3, 3, 3);
            Board b = new Board(10, 10);
            int pos;
            //Act
            p.Move(b, 1, Direction.Left);
            pos = p.GetPosition();
            //Assert
            Assert.That(pos, Is.EqualTo(2), "ERROR: el player no se mueve correctamente a la izquierda");
        }

        [Test]
        public void MoveIzqCiclico()
        {
            //Arrange
            Player p = new Player(4, 3, 3);
            Board b = new Board(10, 10);
            int pos;
            //Act
            p.Move(b, 4, Direction.Left);
            pos = p.GetPosition();
            //Assert
            Assert.That(pos, Is.EqualTo(9), "ERROR: el player no se mueve correctamente a la izquierda de forma ciclica");
        }

        [Test]
        public void MoveDer()
        {
            //Arrange
            Player p = new Player(3, 3, 3);
            Board b = new Board(10, 10);
            int pos;
            //Act
            p.Move(b, 1, Direction.Right);
            pos = p.GetPosition();
            //Assert
            Assert.That(pos, Is.EqualTo(4), "ERROR: el player no se mueve correctamente a la derecha");
        }

        [Test]
        public void MoveDerCiclico()
        {
            //Arrange
            Player p = new Player(5, 0, 9);
            Board b = new Board(10, 10);
            int pos;
            //Act
            p.Move(b, 4, Direction.Right);
            pos = p.GetPosition();
            //Assert
            Assert.That(pos, Is.EqualTo(3), "ERROR: el player no se mueve correctamente a la derecha de forma ciclica");
        }

        [Test]
        public void MoveValorNegativo()
        {
            //Arrange
            Player player = new Player(5, 0, 9);
            Board board = new Board(10, 10);

            //Assert
            Assert.That(() => { player.Move(board, -6, Direction.Left); }, Throws.Exception, "ERROR: No salta la excepcion de numero de pasos negativos");
            Assert.That(() => { player.Move(board, -1, Direction.Right); }, Throws.Exception, "ERROR: No salta la excepcion de numero de pasos negativos");
        }

        [Test]
        public void MoveMayorQueRestantes()
        {
            //Arrange
            Player player = new Player(5, 0, 9);
            Board board = new Board(10, 10);

            //Act
            board.CrearBoardTest(board);

            //Assert
            Assert.That(() => { player.Move(board, 6, Direction.Left); }, Throws.Exception, "ERROR: No salta la excepcion de pasos mayor que los pasos posibles del player");
            Assert.That(() => { player.Move(board, 9, Direction.Right); }, Throws.Exception, "ERROR: No salta la excepcion de pasos mayor que los pasos posibles del player");
        }

        [Test]
        public void MoveAgotarMovimientos()
        {
            //Arrange
            Player player = new Player(5, 0, 9);
            Board board = new Board(10, 10);

            //Act
            board.CrearBoardTest(board);

            //Assert
            Assert.IsTrue(player.Move(board, 5, Direction.Right), "ERROR: el movimiento del player max no se ha agotado");
        }

        [Test]
        public void MoveQuedanMovimientos()
        {
            //Arrange
            Player player = new Player(5, 0, 9);
            Board board = new Board(10, 10);

            //Act
            board.CrearBoardTest(board);

            //Assert
            Assert.IsFalse(player.Move(board, 4, Direction.Right), "ERROR: no quedan movimientos en el player");
        }

        /// <summary>
        /// PRUEBAS DE int ComputePlayerPoints(Board theBoard);
        /// casos
        /// 1. Recoger el numero de conquista de la ciudad conquistada (solo una ciudad)
        /// 2. Recoge la suma de las ciudades conquistadas (mas de una ciudad)
        /// 3. Recoger los numeros del player cuando son 0
        /// </summary>

        [Test]
        public void ComputePlayerPointsUna()
        {
            //Arrange
            Player player = new Player(5, 9, 0);
            Board board = new Board(10, 10);
            int puntos;

            //Act
            board.CrearBoardTest(board);
            player.AttackCity(board, "Alejandretta");
            puntos = player.ComputePlayerPoints(board);
            //Assert
            Assert.That(puntos, Is.EqualTo(5), "ERROR: El metodo no recoge bien los puntos de conquista");
        }

        [Test]
        public void ComputePlayerPointsSuma()
        {
            //Arrange
            Player player = new Player(5, 9, 0);
            Board board = new Board(10, 10);
            int puntos ;

            //Act
            board.CrearBoardTest(board);
            player.AttackCity(board, "Alejandretta");
            player.AttackCity(board, "Troya");
            puntos = player.ComputePlayerPoints(board);
            //Assert
            Assert.That(puntos, Is.EqualTo(7), "ERROR: El metodo no recoge bien los puntos de conquista");
        }

        [Test]
        public void ComputePlayerPointsSinConquistas()
        {
            //Arrange
            Player player = new Player(5, 9, 0);
            Board board = new Board(10, 10);
            int puntos;

            //Act
            board.CrearBoardTest(board);
            puntos = player.ComputePlayerPoints(board);

            //Assert
            Assert.That(puntos, Is.EqualTo(0), "ERROR: no recoge bien los puntos de conquista al ser 0");
        }

        /// <summary>
        /// PRUEBAS DE bool AttackCity(Board theBoard, string cityName);
        /// casos
        /// 1. El ataque a la ciudad ha tenido exito
        /// 2. El ataque a la ciudad ha fracasado
        /// 3. La ciudad a la que se queire atacar no existe
        /// 4. La ciudad a la que se queire atacar no existe en el mazo
        /// </summary>

        [Test]
        public void AttackCityExito()
        {
            //Arrange
            Player player = new Player(5, 9, 0);
            Board board = new Board(10, 10);

            //Act
            board.CrearBoardTest(board);

            //Assert
            Assert.IsTrue(player.AttackCity(board, "Alejandretta"), "ERROR: no se ataco la ciudad con exito");
        }

        [Test]
        public void AttackCityFracaso()
        {
            //Arrange
            Player player = new Player(5, 0, 0);
            Board board = new Board(10, 10);

            //Act
            board.CrearBoardTest(board);

            //Assert
            Assert.IsFalse(player.AttackCity(board, "Alejandretta"), "ERROR: se ataco a la ciudad con exito");
        }

        [Test]
        public void AttackCityNoExistente()
        {
            //Arrange
            Player player = new Player(5, 0, 0);
            Board board = new Board(10, 10);

            //Act
            board.CrearBoardTest(board);

            //Assert
            Assert.That(() => { player.AttackCity(board, "Madrid"); }, Throws.Exception, "ERROR: No salta la excepcion de ciudad no existente");
        }

        [Test]
        public void AttackCityCiudadInexistenteEnMazo()
        {
            //Arrange
            Player player = new Player(5, 0, 0);
            Board board = new Board(10, 10);

            //Act
            board.CrearBoardTest(board);

            //Assert
            Assert.That(() => { player.AttackCity(board, "Babilonia"); }, Throws.Exception, "ERROR: No salta la excepcion de ciudad inexistente en mazo");
        }
    }
    [TestFixture]
    public class Opcional
    {

        [Test]
        public void ReadMapArchivoEncontradoYCorrecto()
        {
            //Arrange && //Act &&
            //Assert
            Assert.That(() => { MainClass.ReadMap("Board.dat"); }, Throws.Exception, "ERROR: ");
        }

        [Test]
        public void ReadMapArchivoNoEncontrado()
        {
            //Arrange && //Act &&
            //Assert            
            Assert.That(() => { MainClass.ReadMap("Hola.dat"); }, Throws.Exception, "ERROR: ");
        }

        [Test]
        public void ReadMapArchivoFormatoInCorrecto()
        {
            //Arrange && //Act &&
            //Assert    
            Assert.That(() => { MainClass.ReadMap("BoardMalo.txt"); }, Throws.Exception, "ERROR: ");
        }
        [Test]
        public void CreateCityAñadido()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Assert  &&   //Act
            Assert.IsTrue(b.CreateCity("city Troya 2 2"), "ERROR: ");
            Assert.IsTrue(b.CreateCity("city Madrid 5 5"), "ERROR: ");
        }

        [Test]
        public void CreateCityNoAñadidoPorTamaño()
        {
            //Arrange
            Board b = new Board(1, 1);
            //Assert  &&   //Act
            Assert.IsTrue(b.CreateCity("city Troya 2 2"), "ERROR: ");
            Assert.IsFalse(b.CreateCity("city Madrid 5 2"), "ERROR: ");
        }
        [Test]
        public void CreateCityMalFormato()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Assert
            Assert.That(() => { b.CreateCity("city 7 7 Hola"); },Throws.Exception , "ERROR: el formato de entrada no es correcto");
        }
        [Test]

        public void CreateCityinDeckAñadido()
        {
            //Arrange
            Board b = new Board(10, 10);

            //Act
            b.CreateCity("city Barcelona 4 4");
            //Assert
            Assert.IsTrue(b.CreateCityinDeck("deck 0 Barcelona"), "ERROR: ");
        }

        [Test]
        public void CreateCityinDeckNoAñadidoPorNombreInexistente()
        {
            //Arrange
            Board b = new Board(1, 1);

            //Act
            b.CreateCity("city Barcelona 4 4");
            //Assert
            Assert.IsFalse(b.CreateCityinDeck("deck 0 Barcelonasss"), "ERROR: ");
        }
        [Test]
        public void CreateCityinDeckNoAñadidoPorDeckInexistente()
        {
            //Arrange
            Board b = new Board(1, 1);

            //Act
            b.CreateCity("city Barcelona 4 4");
            //Assert
            Assert.IsFalse(b.CreateCityinDeck("deck 1 Barcelona"), "ERROR: ");
            // Assert.IsFalse(b.CreateCity("city 5 Madrid 5"), "ERROR: ");
        }
        [Test]
        public void CreateCityinDeckMalFormato()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Assert
            Assert.That(() => { b.CreateCityinDeck("deck Madrid 0"); }, Throws.Exception, "ERROR: el formato de entrada no es correcto");
        }
    }
}
