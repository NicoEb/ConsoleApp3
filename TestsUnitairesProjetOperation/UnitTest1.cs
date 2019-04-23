using System;
using System.Collections.Generic;
using ExercicesControlleursEtVue.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitairesProjetOperation
{
    [TestClass]
    public class UnitTest1
    {
       [TestMethod]
       public void AdditionSimple()
        {
            //Etat initial
            Operation addition = new Operation(2, "+", 3);

            //Lorsque
            float resultat = addition.GetResultat();

            //Alors
            Assert.AreEqual(5, resultat, "L'addition de 2+3 doit renvoyer 5");
        }

        [TestMethod]
        public void Soustraction()
        {
            Operation soustraction = new Operation(3, "-", 5);

            float resultat = soustraction.GetResultat();

            Assert.AreEqual(-2.0f, resultat, "la soustraction de 3-5 doit renvoyer -2");
        }

        [TestMethod]
        public void Multiplication()
        {
            Operation multiplication = new Operation(6, "*", 8);

            float resultat = multiplication.GetResultat();

            Assert.AreEqual(48, resultat, "la multiplication de 6 * 8 doit renvoyer 48");
        }
        [TestMethod]
        public void recupererResultatEnBDD()
        {
            int nombreOperation = DataAccess.GetNombreOperationsEnBdd();

            Operation operation = new Operation(2,"+",3);

            DataAccess.EnregistrerOperation(operation);

            int recupereNombreOp = DataAccess.GetNombreOperationsEnBdd();

            Assert.IsTrue(recupereNombreOp == nombreOperation + 1, "l'operation n'a pas ete enregister en BDD");
        }

        [TestMethod]
        public void recupererDernierOperationENBDD()
        {
           

            Operation operation = new Operation(4, "-", 4);

            DataAccess.EnregistrerOperation(operation);
            DataAccess.RecupererListeOperationsEffectuees();

            List<Operation> resultat = DataAccess.RecupererListeOperationsEffectuees();

            int index = resultat.Count - 1;

            Assert.IsTrue(resultat[index].OperandeGauche == 4 && resultat[index].Operateur=="-" && resultat[index].OperandeDroite== 4,"l'opération n'a pas ete enregister");
        }
        [TestMethod]
        public void DivisionParZero()
        {
            Operation multiplication = new Operation(6, "/", 0);

            Assert.ThrowsException<Exception>(() =>
            {
                multiplication.GetResultat();
            });
        }
        [TestMethod]
        public void puissance()
        {
            Operation operation = new Operation(6,"^",-1);

            Assert.ThrowsException<Exception>(() =>
            {
                operation.GetResultat();
            });
        }
        [TestMethod]
        public void addition1()
        {
            Operation operation = new Operation(2, "+", 3);

            bool siValide = operation.IsValide();

            Assert.IsTrue(siValide, "l'operation n'est pas valide");
        }
        [TestMethod]
        public void Puissance1()
        {
            Operation operation = new Operation(6, "^", -1);

            bool siValide = operation.IsValide();

            Assert.IsFalse(siValide, "l'operation n'est pas valide");
        }
    }
}
