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
            Assert.That(numName, Is.GreaterThan(-1), "ER");
        }

        [Test]
        public void FindCityByNameNoExistente()
        {
            //Arrange 
            Board b = new Board(10, 10);
            //Act

        }

        [Test]
        public void FindCityByNameMayusculas()
        {
        }

        [Test]
        public void FindCityByNameMinusculas()
        {

        }

        [Test]
        public void AttackCityExito()
        {
        }

        [Test]
        public void AttackCityFallo()
        {
        }

        [Test]
        public void AttackCityMismoAtaqueDefensa()
        {
        }

        [Test]
        public void RemoveCityFromDeckCiudadExistenteEnMazo()
        {
        }

        [Test]
        public void RemoveCityFromDeckCiudadNoExistenteEnMazo()
        {
        }

        [Test]
        public void RemoveCityFromDeckNumeroDeMazoNoExistente()
        {
        }

        [Test]
        public void MoveIzq()
        {
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
    }

    [TestFixture]
    public class Player
    {
        [Test]
        public void MoveIzq()
        {
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
