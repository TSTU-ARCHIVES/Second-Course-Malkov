using Test;
namespace P
{
    class P
    {
        static void Main()
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
            double[,] m3 = {
                {10, 3, 40, 31 },
                {10, 2, 35, 31 },
                {12, 8, 65, 34 },
                {10, 1, 30, 31 },
            };

            TwoDismentionArray matrix1 = new TwoDismentionArray(m1);
            TwoDismentionArray matrix2 = new TwoDismentionArray(m2);
            TwoDismentionArray matrix3 = matrix2 * matrix1 + matrix1;
            matrix3.SortRows();
            Console.WriteLine(matrix3 );
        }
    }
}