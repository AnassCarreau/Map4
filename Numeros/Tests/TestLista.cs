using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Listas;
namespace Tests
{
    [TestFixture]
    public class TestLista
    {

        [Test]
        public void CuentaEltos()
        {
            // Arrange
            Lista l = new Lista(3, 2);
            // Act
            int numElemLista = l.NumEltos();
            // Assert
            Assert.That(numElemLista,Is.EqualTo(6), "ERROR: Hay 6 elementos");
           //Is.EqualTo(numElemLista).Within(l.NumEltos());
        }
        [Test]
        public void CuentaEltosListaVacia()
        {

            // Arrange
            Lista l = new Lista();
            // Act
            int numElemLista = l.NumEltos();
            // Assert
            Assert.That(numElemLista,
                       Is.EqualTo(0),
                       "ERROR: NumEltos en lista vacía no devuelve 0");
        }
        [Test]
        public void InsertaFin()
        {
            // Arrange
            Lista l = new Lista(3,4);
            // Act
            l.InsertaFin(10);
            // Assert
            Assert.That(13, Is.EqualTo(l.NumEltos()), "ERROR: Hay 13 elementos");
            Assert.AreEqual(10, l.N_esimo(12), "ERROR: El ultimo elemento es un 10");
        }
        [Test]
        public void InsertaFinVacia()
        {           
            // Arrange
            Lista l = new Lista();
            // Act
            l.InsertaFin(10);
            // Assert
            Assert.That(1,Is.EqualTo(l.NumEltos()), "ERROR: Hay 1 elemento");
            Assert.AreEqual(10, l.N_esimo(0), "ERROR: El ultimo elemento es un 10");
        }
        [Test]
        public void BorraEltoExistente()
        {
            // Arrange
            Lista l = new Lista(5, 1);
            // Assert
            Assert.IsTrue(l.Esta(4), "ERROR: El elemento 4 existe");
            // Act && Assert    
            Assert.IsTrue(l.BorraElto(4), "ERROR: Se ha borrado el elemento ");
            // Assert
            Assert.IsFalse(l.Esta(4), "ERROR:  El elemento 4 no existe");
        } 
        [Test]
        public void BorraEltoNoExistente()
        {
            // Arrange
            Lista l = new Lista(3, 1);
            // Act
            Assert.IsFalse(l.BorraElto(4), "ERROR: La operacion se ha producido");
            // Assert
            Assert.IsFalse(l.Esta(4), "ERROR: La operacion se ha producido");
        }
        [Test]
        public void BorraEltoFinal()
        {
            // Arrange
            Lista l = new Lista(5, 1);

            // Assert
            Assert.IsTrue(l.Esta(5), "ERROR: La operacion se ha producido");
            // Act
            Assert.IsTrue(l.BorraElto(5), "ERROR: La operacion se ha producido");
            // Assert
            Assert.IsFalse(l.Esta(5), "ERROR: La operacion se ha producido");
        }
        [Test]
        public void BorraEltoPrincipio()
        {
            // Arrange
            Lista l = new Lista(5, 1);

            // Assert
            Assert.IsTrue(l.Esta(1), "ERROR: La operacion se ha producido");
            // Act
            Assert.IsTrue(l.BorraElto(1), "ERROR: La operacion se ha producido");
            // Assert
            Assert.IsFalse(l.Esta(1), "ERROR: La operacion se ha producido");
        }
        [Test]
        public void BorraEltoListaVacia()
        {
            // Arrange
            Lista l = new Lista();
            // Act
            Assert.IsFalse(l.BorraElto(0), "ERROR: La operacion se ha producido");
            // Assert
            Assert.IsFalse(l.Esta(0), "ERROR: La operacion se ha producido");
        }
        [Test]
        public void BorraEltoUnico()
        {
            // Arrange
            Lista l = new Lista(1,1);
            // Act
            Assert.IsTrue(l.BorraElto(1), "ERROR: La operacion se ha producido");
            // Assert
            Assert.That(l.NumEltos(),Is.EqualTo(0), "ERROR: La operacion se ha producido");
        }
        public void BorraEltoRepetido()
        {
            // Arrange
            Lista p = new Lista(3, 2);
            // Act           
            Assert.IsTrue(p.BorraElto(3), "ERROR: La operacion se ha producido");
            Assert.That(p.NumEltos(), Is.EqualTo(5), "ERROR: La operacion se ha producido");
            Assert.IsTrue(p.Esta(3), "ERROR: La operacion se ha producido");

        }
        public void BorraEltoRepetidoVarias()
        {
            // Arrange
            Lista l = new Lista(3, 3);
            // Act      
            int num=0;
            while (l.Esta(3))
            { 
                l.BorraElto(3);
                num++;
            } 
            Assert.That(l.NumEltos(), Is.EqualTo(9-num), "ERROR: La operacion se ha producido");
            Assert.IsFalse(l.Esta(3), "ERROR: La operacion se ha producido");

        }

        [Test]
        public void nEsimo()
        {
            Lista l = new Lista(5, 3);

            
            Assert.That(5,Is.EqualTo( l.N_esimo(14)), "ERROR: El elemento numero 13 es un 4");
            Assert.That(1,Is.EqualTo( l.N_esimo(0)), "ERROR: El elemento numero 13 es un 4");
            Assert.That(2,Is.EqualTo( l.N_esimo(6)), "ERROR: El elemento numero 13 es un 4");

        }
        [Test]
        public void nEsimoVacia()
        {
            // Arrange
            Lista l = new Lista();

            Assert.That(() => { l.N_esimo(1); },Throws.Exception, "ERROR:Hay elementos en la lista");
        }
        [Test]
        public void nEsimoNegativo()
        {
            Lista l = new Lista(5, 3);


            Assert.That(() => { l.N_esimo(-1); }, Throws.Exception, "ERROR:Hay elementos en la lista");


        }
        [Test]
        public void nEsimoMayorqueElem()
        {
            Lista l = new Lista(5, 3);


            Assert.That(() => { l.N_esimo(20); }, Throws.Exception, "ERROR:Hay elementos en la lista");


        }
        [Test]
        public void nEsimoUltimo()
        {
            // Arrange
            Lista r = new Lista(8, 1);
            int posicion = 7;
            // Act
            int valor = r.N_esimo(posicion);
            // Assert
            Assert.That(valor, Is.EqualTo(posicion + 1), "ERROR: nEsimo(0) en lista no devuelve valor 8");
        }
        [Test]
        public void nEsimoRep()
        {
            // Arrange
            Lista r = new Lista(4, 3);
            int posicion = 7;
            // Act
            int valor = r.N_esimo(posicion);
            // Assert
            Assert.That(valor, Is.EqualTo(4), "ERROR: nEsimo(0) en lista no devuelve valor 8");
        }
        [Test]
        public void nEsimoPrimero()
        {
            // Arrange
            Lista r = new Lista(3, 2);
            int posicion = 0;
            // Act
            int valor = r.N_esimo(posicion);
            // Assert
            Assert.That(valor, Is.EqualTo(1), "ERROR: nEsimo(0) en lista no devuelve valor 1");
        }
    }
}
