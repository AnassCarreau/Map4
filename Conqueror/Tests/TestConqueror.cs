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
            Assert.That(numName, Is.GreaterThan(-1), "ERROR:");
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
            Assert.That(numName, Is.EqualTo(-1), "ERROR:");
        }

        [Test]
        public void FindCityByNameMayusculas()
        {
            //Arrange
            Board b = new Board(10,10);
            //Act
            b.CrearBoardTest(b);
            int numName = b.FindCityByName("TROYA");
            //Assert
            Assert.That(numName, Is.EqualTo(-1), "ERROR:");

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
            Assert.That(numName, Is.EqualTo(-1), "ERROR:");
        }

        [Test]
        public void AttackCityExito()
        {
            //Arrange
            Board b = new Board(10,10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsTrue(b.AttackCity(0,5), "ERROR:");
        }

        [Test]
        public void AttackCityFallo()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsFalse(b.AttackCity(0, 3), "ERROR:");
        }

        [Test]
        public void AttackCityMismoAtaqueDefensa()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsFalse(b.AttackCity(0, 4), "ERROR:");
        }

        [Test]
        public void RemoveCityFromDeckCiudadExistenteEnMazo()
        {
            //Arrange
            Board b = new Board(10,10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsTrue(b.RemoveCityFromDeck(0, 0), "ERROR:");
        }

        [Test]
        public void RemoveCityFromDeckCiudadNoExistenteEnMazo()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsFalse(b.RemoveCityFromDeck(0, 1), "ERROR:");
        }

        [Test]
        public void RemoveCityFromDeckNumeroDeMazoNoExistente()
        {
            //Arrange
            Board b = new Board(10, 10);
            //Act
            b.CrearBoardTest(b);
            //Assert
            Assert.IsFalse(b.RemoveCityFromDeck(9, 0), "ERROR:");
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
            Assert.That(numPos, Is.EqualTo(7),"ERROR:");
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
            Assert.That(numPos, Is.EqualTo(8), "ERROR:");
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
            Assert.That(numPos, Is.EqualTo(8), "ERROR:");
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
            Assert.That(numPos, Is.EqualTo(1), "ERROR:");
        }
    }

    [TestFixture]
    public class Player
    {
        [Test]
        public void MoveIzq()
        {
            //Arrange
            Player p = new Player(3, 2, 0);
            //Act

            //Assert

        }
        [Test]
        public void MoveIzqCiclico()
        {
        }
        [Test]
        public void MoveDer()
        {
        }
        [Test]
        public void MoveDerCiclico()
        {
        }
        [Test]
        public void MoveValorNegativo()
        {
        }
        [Test]
        public void MoveMayorQueRestantes()
        {
        }
        [Test]
        public void MoveAgotarMovimientos()
        {
        }
        [Test]
        public void MoveQuedanMovimientos()
        {
        }


        [Test]
        public void ComputePlayerPoints()
        {
        }
        [Test]
        public void ComputePlayerPointsSinConquistas()
        {
        }


        [Test]
        public void AttackCityExito()
        {

        }
        [Test]
        public void AttackCityFracaso()
        {

        }
        [Test]
        public void AttackCityNoExistente()
        {

        }
        [Test]
        public void AttackCityCiudadInexistenteEnMazo()
        {

        }
    }
    [TestFixture]
    public class Opcional
    {

    }
}
