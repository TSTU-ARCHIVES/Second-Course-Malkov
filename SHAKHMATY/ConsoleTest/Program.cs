using GraphsADT__L10to12_;
using System.Data;
using System;
using System.Reflection;

namespace P
{
    public static class ext
    {
        public static int[] RowAt(this int[,] arr, int n)
        {
            int[] res = new int[arr.GetLength(0)];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = arr[n, i];
            }
            return res;
        } 
    }
    public class P
    {
        public static int[,] res;
        public static void Solve(int N, int[] constrains)
        {
            if (constrains.Sum() % 2 == 1)
                return;

            int[,] mat = new int[N, N];
            RecursiveFillVoid(N, mat, constrains, 0, 0, 0);
        }

        static void RecursiveFillVoid(int N,int[,] arr, int[] cons, int row, int col, int used)
        {

            if (row >= N) // если все единицы размещены, выводим результат
            {
                WriteIfCorrect(arr, cons);
                return;
            }


            int rest = cons[row] - used;

            if ((rest == 0 && col <= N))
            {
                return;
            }



            if (rest == 0 || col >= N) // если достигнут конец строки, возвращаемся
            {
                RecursiveFillVoid(N, arr, cons, row + 1, 0, 0);
                return;
            }



            if (arr[row, col] == 1) // если на текущей позиции уже есть единица, пропускаем ее и переходим к следующей позиции
            {
                RecursiveFillVoid(N, arr, cons, row, col + 1, used);
            }
            else
            {
                if (row != col)
                {
                    arr[row, col] = 1; // размещаем единицу на текущей позиции
                    arr[col, row] = 1;
                    RecursiveFillVoid(N, arr, cons, row, col + 1, used + 1); // рекурсивно вызываем функцию для следующей позиции
                }
                arr[row, col] = 0; // размещаем единицу на текущей позиции
                arr[col, row] = 0;
                RecursiveFillVoid(N, arr, cons, row, col + 1, used);
            }


        }

        static bool WriteIfCorrect(int[,] mat, int[] cons)
        {
            for(int i = 0; i < mat.GetLength(0); i++)
            {
                if (mat.RowAt(i).Sum() != cons[i])
                    return false;
            }
            int N = mat.GetLength(0);
            int[,] newRes = (int[,])mat.Clone();
            res = newRes;
            return true;
        }

        
    }

    class Program
    {
        static void Main()
        {
            Dictionary<int, string> names = new Dictionary<int, string>()
            {
                {0, "Ваня" },
                {1, "Толя" },
                {2, "Алексей" },
                {3, "Дмитрий" },
                {4, "Семен" },
                {5, "Илья" },
                {6, "Евгений" }
            };
            int[] cons = new int[] { 6, 5, 3, 3, 2, 2, 1 };
            int N = 7;
            P.Solve(N, cons); 
            Graph g = new GraphOnMatrixADJ(P.res);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (g.Adjastent(i,j))
                    {
                        Console.WriteLine("{0} знает {1}", names[i], names[j]);
                    }
                }
            }
            //// РЕБРА !
            //// 0 - Ваня
            //// 1 - Толя
            //// 2 - Алексей
            //// 3 - Дмитрий
            //// 4 - Семен
            //// 5 - Илья   
            //// 6 - Евгений
            ///
            /*
            solution.AddEgde(0, 1, 1);
            solution.AddEgde(0, 2, 1);
            solution.AddEgde(0, 3, 1);
            solution.AddEgde(0, 4, 1);
            solution.AddEgde(0, 5, 1);
            solution.AddEgde(0, 6, 1);

            solution.AddEgde(1, 0, 1);
            solution.AddEgde(1, 2, 1);
            solution.AddEgde(1, 3, 1);
            solution.AddEgde(1, 4, 1);
            solution.AddEgde(1, 5, 1);

            solution.AddEgde(2, 0, 1);
            solution.AddEgde(2, 1, 1);
            solution.AddEgde(2, 3, 1);

            solution.AddEgde(3, 0, 1);
            solution.AddEgde(3, 1, 1);
            solution.AddEgde(3, 2, 1);

            solution.AddEgde(4, 0, 1);
            solution.AddEgde(4, 1, 1);

            solution.AddEgde(5, 0, 1);
            solution.AddEgde(5, 1, 1);

            solution.AddEgde(6, 0, 1);
            
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(vertexName[i] + " знает: ");
                for (int j = 0; j < 7; j++)
                {
                    if (solution.Adjastent(i, j)) 
                        Console.WriteLine(vertexName[j] + " ");
                }
                Console.WriteLine();
            }
            */
        }
    }
}

