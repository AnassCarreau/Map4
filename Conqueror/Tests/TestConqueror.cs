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
    }

    [TestFixture]
    public class PlayerTest
    {
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


        [Test]
        public void ComputePlayerPoints()
        {
            //Arrange
            Player player = new Player(5, 9, 0);
            Board board = new Board(10, 10);
            int puntos = 0;

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
        public void ReadMapArchivoEncontrado()
        {
        }
        [Test]
        public void ReadMapArchivoNoEncontrado()
        {
        }
        [Test]
        public void ReadMapArchivoFormatoCorrecto()
        {
        }
        [Test]
        public void ReadMapArchivoFormatoInCorrecto()
        {
        }

        [Test]
        public void CreateCityCorrecto()
        {
        }
        [Test]
        public void CreateCityIncorrecto()
        {
        }
        [Test]
        public void CreateCityinDeckCorrecto()
        {

        }
        [Test]
        public void CreateCityinDeckInCorrecto()
        {

        }
    }
}
