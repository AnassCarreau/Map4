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
            Assert.IsFalse(l.BorraElto(4), "ERROR: El elemento 4 no existe");
            // Assert
            Assert.IsFalse(l.Esta(4), "ERROR: El elemento 4 no existe");
        }
        [Test]
        public void BorraEltoFinal()
        {
            // Arrange
            Lista l = new Lista(5, 1);
            // Assert
            Assert.IsTrue(l.Esta(5), "ERROR:  El elemento 5  existe");
            // Act
            Assert.IsTrue(l.BorraElto(5), "ERROR:  El elemento 5 no existe");
            // Assert
            Assert.IsFalse(l.Esta(5), "ERROR:  El elemento 5 no existe");
        }
        [Test]
        public void BorraEltoPrimero()
        {
            // Arrange
            Lista l = new Lista(5, 1);
            // Assert
            Assert.IsTrue(l.Esta(1), "ERROR:  El elemento 1  existe");
            // Act && Assert
            Assert.IsTrue(l.BorraElto(1), "ERROR:  El elemento 1  no existe");
            // Assert
            Assert.IsFalse(l.Esta(1), "ERROR:  El elemento  1 no existe");
        }
        [Test]
        public void BorraEltoListaVacia()
        {
            // Arrange
            Lista l = new Lista();
            // Act && Assert
            Assert.IsFalse(l.BorraElto(0), "ERROR:  El elemento  0 no existe");
            // Assert
            Assert.IsFalse(l.Esta(0), "ERROR:  El elemento  0 no existe");
        }
        [Test]
        public void BorraEltoUnico()
        {
            // Arrange
            Lista l = new Lista(1,1);
            // Act && Assert
            Assert.IsTrue(l.BorraElto(1), "ERROR: El elemento 1 no existe");
            // Assert
            Assert.That(l.NumEltos(),Is.EqualTo(0), "ERROR:No hay elementos");
        }
        [Test]

        public void BorraEltoRepetido()
        {
            // Arrange
            Lista p = new Lista(3, 2);
            // Act && Assert
            Assert.IsTrue(p.BorraElto(3), "ERROR: El elemento 1 no existe");
            Assert.That(p.NumEltos(), Is.EqualTo(5), "ERROR:Hay 5 elementos");
            Assert.IsTrue(p.Esta(3), "ERROR: El elemento 1 no existe");

        }
        [Test]
        public void BorraEltoRepetidoMientrasExista()
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
            //  Assert
            Assert.That(l.NumEltos(), Is.EqualTo(9-num), "Hay 6 elementos");
            Assert.IsFalse(l.Esta(3), "ERROR: El elemento 3 no existe");

        }

        [Test]
        public void nEsimo()
        {
            // Arrange
            Lista l = new Lista(5, 3);
            // Act && Assert
            Assert.That(l.N_esimo(14),Is.EqualTo(5), "ERROR: El elemento numero 14 es un 5");
            Assert.That(l.N_esimo(0),Is.EqualTo(1), "ERROR: El elemento numero 0 es un 1");
            Assert.That(l.N_esimo(6),Is.EqualTo(2), "ERROR: El elemento numero 6 es un 2");

        }
        [Test]
        public void nEsimoVacia()
        {
            // Arrange
            Lista l = new Lista();
            // Act && Assert
            Assert.That(() => { l.N_esimo(1); },Throws.Exception, "ERROR:No hay elementos en la lista");
        }
        [Test]
        public void nEsimoNegativo()
        {
            // Arrange
            Lista l = new Lista(5, 3);      
            // Act && Assert
            Assert.That(() => { l.N_esimo(-1); }, Throws.Exception, "ERROR:No hay  posiciones negativas  en la lista");
        }
        [Test]
        public void nEsimoMayorqueNumdeElem()
        {       
            // Arrange
            Lista l = new Lista(5, 3);
            // Act && Assert
            Assert.That(() => { l.N_esimo(20); }, Throws.Exception, "ERROR:No existe la posicion 20 en la lista");
        }
        [Test]
        public void nEsimoUltimo()
        {
            // Arrange
            Lista l = new Lista(8, 1);
            // Act && Assert
            Assert.That(l.N_esimo(l.NumEltos() - 1), Is.EqualTo(8), "ERROR: El elemento final es un 8");
        }
        [Test]
        public void nEsimoRep()
        {
            // Arrange
            Lista l= new Lista(5, 3);
            // Act && Assert
            Assert.That(l.N_esimo(9), Is.EqualTo(5), "ERROR: El elemento numero 9 es un 5");
        }
        [Test]
        public void nEsimoPrimero()
        {
            // Arrange
            Lista l = new Lista(3, 2);
            // Act && Assert
            Assert.That(l.N_esimo(0), Is.EqualTo(1), "ERROR: El elemento numero 0 es un 1");
        }
    }
}
