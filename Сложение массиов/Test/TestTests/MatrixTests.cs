using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void IsZeroMatrixTest()
        {
            TwoDismentionArray matrix = new TwoDismentionArray(5,5);
            if (!matrix.IsZeroMatrix())
                Assert.Fail();
        }
        [TestMethod()]
        public void IsZeroMatrixTest2()
        {
            TwoDismentionArray matrix = new TwoDismentionArray(5, 5);
            matrix.SetElem(1, 1, 4);
            if (matrix.IsZeroMatrix())
                Assert.Fail();
        }

        [TestMethod()]
        public void IsSquareMatrixTest()
        {
            TwoDismentionArray matrix = new TwoDismentionArray(5, 5);
            if (!matrix.IsSquareMatrix())
                Assert.Fail();
        }

        [TestMethod()]
        public void IsSquareMatrixTest2()
        {
            TwoDismentionArray matrix = new TwoDismentionArray(5, 6);
            if (matrix.IsSquareMatrix())
                Assert.Fail();
        }

        [TestMethod()]
        public void AddMatrixTest()
        {
            double[,] m1 = { 
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] m2 = {
                {1, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] mRes = {
                {1, 2, 10, 4 },
                {0, 2, 10, 2 },
                {4, 0, 10, 12 },
                {0, 2, 10, 0 },
            };

            TwoDismentionArray matrix1 = new TwoDismentionArray(m1);
            TwoDismentionArray matrix2 = new TwoDismentionArray(m2);

            TwoDismentionArray matrixRes = new TwoDismentionArray(mRes);
            TwoDismentionArray matrixRes2 = matrix1.AddMatrix(matrix2);

            Assert.AreEqual(matrixRes, matrixRes2);
        }

        [TestMethod()]
        public void SubMatrixTest()
        {
            double[,] m1 = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] m2 = {
                {1, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] mRes = {
                {-1, 0, 0, 0 },
                {0, 0, 0, 0 },
                {0, 0, 0, 0 },
                {0, 0, 0, 0 },
            };

            TwoDismentionArray matrix1 = new TwoDismentionArray(m1);
            TwoDismentionArray matrix2 = new TwoDismentionArray(m2);

            TwoDismentionArray matrixRes = new TwoDismentionArray(mRes);
            TwoDismentionArray matrixRes2 = matrix1.SubMatrix(matrix2);

            Assert.AreEqual(matrixRes, matrixRes2);
        }

        [TestMethod()]
        public void MultiplyMatrxTest()
        {
            double[,] m1 = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double scalar = 3;
            double[,] mRes = {
                {0, 3, 15, 6 },
                {0, 3, 15, 3 },
                {6, 0, 15, 18 },
                {0, 3, 15, 0 },
            };

            TwoDismentionArray matrix1 = new TwoDismentionArray(m1);

            TwoDismentionArray matrixRes = new TwoDismentionArray(mRes);
            TwoDismentionArray matrixRes2 = matrix1.MultiplyMatrx(scalar);

            Assert.AreEqual(matrixRes, matrixRes2);
        }

        [TestMethod()]
        public void MultiplyMatrxTest1()
        {
            double[,] m1 = {
                {0, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] m2 = {
                {1, 1, 5, 2 },
                {0, 1, 5, 1 },
                {2, 0, 5, 6 },
                {0, 1, 5, 0 },
            };
            double[,] mRes = {
                {10, 3, 40, 31 },
                {10, 2, 35, 31 },
                {12, 8, 65, 34 },
                {10, 1, 30, 31 },
            };

            TwoDismentionArray matrix1 = new TwoDismentionArray(m1);
            TwoDismentionArray matrix2 = new TwoDismentionArray(m2);

            TwoDismentionArray matrixRes = new TwoDismentionArray(mRes);
            TwoDismentionArray matrixRes2 = matrix1.MultiplyMatrx(matrix2);

            Assert.AreEqual(matrixRes, matrixRes2);
        }

    }
}