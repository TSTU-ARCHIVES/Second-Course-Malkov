using System.Diagnostics.Metrics;

namespace Lab0
{
    using IntMatrix = BoxedMatrix<int>;
    /// <summary>
    /// Класс, реализующий квадратную матрицу с данными определнного типа
    /// </summary>
    /// <typeparam name="T">Тип данных, хранимых в матрице</typeparam>
    class Matrix<T>
    {
        /// <summary>
        /// Ребро матрицы
        /// </summary>
        private int size = 0;
        /// <summary>
        /// Двумерный массив, реализующий матрицу
        /// </summary>
        private T[,] matrix = { };
        /// <summary>
        /// Конструктор, создающий пустую матрицу данного размера
        /// </summary>
        /// <param name="size">Размер матрицы</param>
        public Matrix(int size)
        {
            this.size = size;
            this.matrix = new T[size, size];
        }
        /// <summary>
        /// Конструктор, создающий экземпляр класса на основе
        /// двумерного квадратного массива
        /// </summary>
        /// <param name="matrix">Двумерный массив, оборажающий матрицу</param>
        public Matrix(T[,] matrix)
        {
            this.size = matrix.GetLength(0);
            this.matrix = matrix;
        }
        /// <summary>
        /// Возвращает размер матрицы
        /// </summary>
        /// <returns>Размер матрицы</returns>
        public int getSize()
        {
            return size;
        }
        /// <summary>
        /// Назначает элемент в данную позицию
        /// </summary>
        /// <param name="row">Номер ряда вставляемого элемента</param>
        /// <param name="col">Номер столбца вставляемого элемента</param>
        /// <param name="elem">Вставляемый элемент</param>
        public void setElem(int row, int col, T elem)
        {
            matrix[row, col] = elem;
        }
        /// <summary>
        /// Удаляет элемент по данной позиции
        /// </summary>
        /// <param name="row">Номер ряда удаляемого элемента</param>
        /// <param name="col">Номер столбца удаляемого элемента</param>
        public void delete(int row, int col)
        {
            matrix[row, col] = default(T);
        }
        /// <summary>
        /// Возращает элемент на данной позиции
        /// </summary>
        /// <param name="row">Номер ряда получаемого элемента</param>
        /// <param name="col">Номер столбца получаемого элемента</param>
        /// <returns>Элемент на данной позиции</returns>
        public T getElem(int row, int col)
        {
            return matrix[row, col];
        }
        /// <summary>
        /// Возращает верхний треугольник матрицы
        /// </summary>
        /// <returns>Верхний треугольник матрицы</returns>
        public T[][] getUpperTriagle()
        {
            T[][] upperT = new T[size][];
            for (int i = 0; i < size; i++)
            {
                T[] temp = new T[size - i];
                for (int j = i; j < size; j++)
                {
                    temp[j - i] = matrix[i, j];
                }
                upperT[i] = temp;
            }
            return upperT;
        }
        /// <summary>
        /// Возвращает вектор из элементов матрицы
        /// </summary>
        /// <returns>Вектор из элементов матрицы</returns>
        public T[] getVector()
        {
            return Matrix<T>.GetVector(this.getUpperTriagle());
        }
        /// <summary>
        /// Возвращает упакованную матрицу
        /// </summary>
        /// <returns>Упаковываемая матрицы</returns>
        public int[][] box()
        {
            return Matrix<T>.Box(this.getUpperTriagle());
        }
        /// <summary>
        /// Возвращает вектор от произвольного массива массивов
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <returns>Вектор от произвольной матрицы</returns>
        public static T[] GetVector(T[][] matrix)
        {
            List<T> list = new List<T>();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                    if (!matrix[i][j].Equals(default(T)))
                        list.Add(matrix[i][j]);
            return list.ToArray();

        }
        /// <summary>
        /// Упаковывает произвольный массив массивов 
        /// </summary>
        /// <param name="matrix">Произвольный массив массивов</param>
        /// <returns>Упакованный массив массивов</returns>
        public static int[][] Box(T[][] matrix)
        {
            List<int> boxedCols = new List<int>();
            List<int> boxedRows = new List<int>();
            int rows = 0, cols = 0;
            int notNullElems = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                boxedRows.Add(notNullElems);
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (!matrix[i][j].Equals(default(T)))
                    {
                        boxedCols.Add(j);
                        notNullElems++;
                    }
                }
            }
            return new int[][] { boxedRows.ToArray(), boxedCols.ToArray() };
        }

    }
    /// <summary>
    /// Класс, отображающий упакованную квадратную симметричную матрицу
    /// </summary>
    /// <typeparam name="T">Тип элементов в упакованной матрице</typeparam>
    class BoxedMatrix<T>
    {
        /// <summary>
        /// Вектор упакованной матрицы
        /// </summary>
        private T[] vector;
        /// <summary>
        /// Массивы индексов упанованной матрицы
        /// </summary>
        private int[][] indexes;
        /// <summary>
        /// Размер упакованной матрицы
        /// </summary>
        private int size;
        /// <summary>
        /// Размер упакованной матрицы
        /// </summary>
        public int Size { get { return this.size; } }
        /// <summary>
        /// Конструктор, создающий объект на основе вектора матрицы
        /// и массивов индексов
        /// </summary>
        /// <param name="vector">Вектор матрицы</param>
        /// <param name="indexes">Массив индексов</param>
        public BoxedMatrix(T[] vector, int[][] indexes) {
            this.vector = vector;
            this.indexes = indexes;
            this.size = indexes[0].Length;
        }
        /// <summary>
        /// Конструктор, создающий объект на основе двумерного массива
        /// представляющего собой матрицу
        /// </summary>
        /// <param name="matrix">Двумерный массив - матрица</param>
        public BoxedMatrix(T[,] matrix)
        {
            Matrix<T> tempMat = new Matrix<T>(matrix);
            this.vector = tempMat.getVector();
            this.indexes = tempMat.box();
            this.size = tempMat.getSize();
        }
        /// <summary>
        /// Конструктор, создающий объект на основе матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        public BoxedMatrix(Matrix<T> matrix)
        {
            this.vector = matrix.getVector();
            this.indexes = matrix.box();
            this.size = matrix.getSize();
        }
        /// <summary>
        /// Конструктор, создающий новую пустую матрицу длины 0
        /// </summary>
        public BoxedMatrix()
        {
            this.vector = new T[0];
            this.indexes = new int[][] { };
            this.size = 0;
        }
        /// <summary>
        /// Определяет положение элемента в верхнем треугольнике
        /// на основе данного положения в полной матрице
        /// </summary>
        private (int, int) defineRowColInUpper(int factrow, int factcol)
        {
            int row, col;

            if (factcol >= factrow)
                (row, col) = (factrow, factcol);
            else
                (row, col) = (factcol, factrow);

            return (row, col - row);

        }
        /// <summary>
        /// Находит позицию в векторе элемента по
        /// его позиции в цельной матрице
        /// </summary>
        /// <param name="factRow">Строка элемента</param>
        /// <param name="factCol">Столбец элемента</param>
        /// <returns>Индекс элемента в векторе</returns>
        private int findInVector(int factRow, int factCol)
        {
            int row, col;
            (row, col) = defineRowColInUpper(factRow, factCol);

            if (row + 1 < indexes[0].Length)
            {
                for (int i = indexes[0][row]; i < indexes[0][row + 1]; i++)
                {
                    if (indexes[1][i] == col)
                        return i;
                }
            } else
            {
                for (int i = indexes[0][row]; i < indexes[1].Length; i++)
                {
                    if (indexes[1][i] == col)
                        return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Возвращает элемент по данной позиции
        /// </summary>
        /// <param name="factRow">Номер строки элемента</param>
        /// <param name="factCol">Номер столбца элемента</param>
        /// <returns>Элемент на данной позиции</returns>
        public T getElem(int factRow, int factCol)
        {

            int index = findInVector(factRow, factCol);
            if (index == -1)
                return default(T);
            else
                return vector[index];
        }
        /// <summary>
        /// Удаляет элемент по данной позиции
        /// </summary>
        /// <param name="factRow">Номер строки элемента</param>
        /// <param name="factCol">Номер столбца элемента</param>
        public void deleteElem(int factRow, int factCol)
        {
            vector[findInVector(factRow, factCol)] = default(T);
        }
        /// <summary>
        /// Назначает элемент на данную позицию
        /// </summary>
        /// <param name="factRow">Номер строки элемента</param>
        /// <param name="factCol">Номер столбца элемента</param>
        /// <param name="elem">Назначаемый элемент</param>
        public void setElem(int factRow, int factCol, T elem)
        {
            int row, col;
            (row, col) = defineRowColInUpper(factRow, factCol);

            //replacement
            int pos = findInVector(row, col);
            if (pos != -1)
            {
                vector[pos] = elem;
                return;
            }

            //insertion in col
            for (int i = indexes[0][row]; i < indexes[0][row + 1]; i++)
            {
                if (i == indexes[0][row + 1] - 1 || indexes[1][i + 1] >= col)
                {
                    List<int> newCols = new List<int>(indexes[1]);
                    newCols.Insert(i, col);

                    List<T> newVector = new List<T> { };
                    foreach (T val in vector)
                        newVector.Add(val);
                    newVector.Insert(i, elem);

                    indexes[1] = newCols.ToArray();
                    vector = newVector.ToArray();

                    break;
                }
            }

            for (int i = row; i < size; i++)
                indexes[0][i]++;
        }

    }
    /// <summary>
    /// Класс, отобрающий матрицу, описываемую 
    /// математически как шахматную с нулями на белых клетках
    /// </summary>
    public class ChessMatrix
    {
        /// <summary>
        /// Длина матрицы
        /// </summary>
        public int len;
        /// <summary>
        /// Вектор матрицы
        /// </summary>
        public int[] vector;
        /// <summary>
        /// Конструктор, создающий шахматную матрицу данной длины
        /// </summary>
        /// <param name="size">Длина шахматной матрицы</param>

        public ChessMatrix(int size)
        {
            len = size;
            vector = new int[(len * len) / 2];
        }
        private int VectorIndex(int x, int y)
        {
            return x * len / 2 + y / 2;
        }
        /// <summary>
        /// Назначает удаляет элемент на данной позиции
        /// </summary>
        /// <param name="x">x- координата элемента</param>
        /// <param name="y">y- координата элемента</param>
        /// <returns>True: назначение возможно
        /// False: во всех иных случаях </returns>
        public void DeleteValue(int x, int y)
        {
            this.SetValue(x, y, default);
        }
        /// <summary>
        /// Назначает новый элемент на данную позицию
        /// </summary>
        /// <param name="x">x- координата нового элемента</param>
        /// <param name="y">y- координата нового элемента</param>
        /// <param name="value">Назначаемый элемент</param>
        /// <returns>True: назначение возможно
        /// False: во всех иных случаях </returns>
        public bool SetValue(int x, int y, int value)
        {
            if (!(
                (y % 2 == 0 && x % 2 == 0) ||
                ((y + 1) % 2 == 0 && (x + 1) % 2 == 0)
               ))
            {
                vector[VectorIndex(x, y)] = value;
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Получает элемент по данной позиции
        /// </summary>
        /// <param name="x">x- координата элемента</param>
        /// <param name="y">y- координата элемента</param>
        /// <returns>Элемент на данной позиции</returns>
        public int GetValue(int x, int y)
        {
            if (
                (y % 2 == 0 && x % 2 == 0) ||
                ((y + 1) % 2 == 0 && (x + 1) % 2 == 0)
               )
                return 0;
            else
                return vector[VectorIndex(x, y)];
        }
    }
    class Program
    {
        static IntMatrix mat;
        static ChessMatrix chessMatrix;
        static int choice;
        static int GetUserInput(int from, int to)
        {
            int res;
            Console.WriteLine($"Введите число от {from} до {to}");
            if (!int.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Некорректный ввод");
                return from - 1;
            }
            if (res > to || res < from)
            {
                Console.WriteLine("Число вне отрезка значений");
                return from - 1;
            }
            return res;
        }
        static void FillIntMat()
        {
            Console.WriteLine("Введите размер симметричной матрицы");
            int N = GetUserInput(1, 1000);
            int[,] matx = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = i; j < N; j++)
                {
                    Console.WriteLine($"Введите число на позиции [{i},{j}]");
                    matx[i, j] = GetUserInput(-1000, 1000);
                    if (matx[i, j] == -1001)
                        return;
                }
            }
            mat = new(matx);
        }
        static void FillChessMat()
        {
            Console.WriteLine("Введите размер матрицы");
            int N = GetUserInput(1, 1000);
            chessMatrix = new(N);

            for (int i = 0; i < N; i++)
            {
                int start = 1;
                if (i % 2 == 1)
                    start = 0;
                for (int j = start; j < N; j += 2)
                {
                    Console.WriteLine($"Введите число на позиции [{i},{j}]");
                    if (!chessMatrix.SetValue(i, j, GetUserInput(-1000, 1000)))
                    {
                        Console.WriteLine("Числа не может быть на позиции");
                    }

                    if (chessMatrix.GetValue(i, j) == -1001)
                        return;
                }
            }
        }
        static void FillMatrixes()
        {
            Console.WriteLine("Нажмите 1, чтобы продолжить работу с симметричными матрицами, \n" +
                "либо 2, чтобы продолжить работу с матрицей, у которой положение фоновых элементов " +
                "задано математически");
            choice = GetUserInput(1, 2);
            if (choice == 0)
                return;
            if (choice == 1)
            {
                FillIntMat();
            } else
            {
                FillChessMat();
            }
        }
        static void PrintMatrixes()
        {
            int N;
            if (choice == 1)
            {
                N = mat.Size;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write("{0}", mat.getElem(i, j).ToString().PadRight(7));
                    }
                    Console.WriteLine();
                }
            } else
            {
                N = chessMatrix.len;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write($"{chessMatrix.GetValue(i, j).ToString().PadRight(7)}");
                    }
                    Console.WriteLine();
                }
            }
        }
        public static (int, int) GetElemPos(int N)
        {

            Console.WriteLine("Введите номер строки элемента");
            int row = GetUserInput(0, N);
            Console.WriteLine("Введите номер строки элемента");
            int col = GetUserInput(0, N);
            return (row, col);
        }
        public static void Work()
        {
            if (mat != null)
            {
                do
                {
                    int N = mat.Size;
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write("{0}", mat.getElem(i, j).ToString().PadRight(7));
                        }
                        Console.WriteLine();
                    }
                    (int row, int col) = GetElemPos(N - 1);
                    Console.WriteLine("Выберите действие");
                    Console.WriteLine("1. Замена элемента\n" + "2. Удаление элемента\n" + "3. Вывод элемента\n" + "4.Выход");
                    int C = GetUserInput(1, 4);
                    if (C == 0 || C == 4)
                        return;
                    switch (C)
                    {
                        case 1:
                            mat.setElem(row, col, GetUserInput(int.MinValue, int.MaxValue));
                            break;
                        case 2:
                            mat.deleteElem(row, col);
                            break;
                        case 3:
                            Console.WriteLine(mat.getElem(row, col));
                            break;
                    }
                } while (true);
            }
            else
            {
                do 
                { 
                    int N = chessMatrix.len;
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write("{0}", chessMatrix.GetValue(i, j).ToString().PadRight(7));
                        }
                        Console.WriteLine();
                    }
                    (int row, int col) = GetElemPos(N - 1);
                    Console.WriteLine("Выберите действие");
                    Console.WriteLine("1. Замена элемента\n" + "2. Удаление элемента\n" + "3. Вывод элемента\n" + "4.Выход");
                    int C = GetUserInput(1, 4);
                    if (C == 0 || C == 4)
                        return;
                    switch (C)
                    {
                        case 1:
                            chessMatrix.SetValue(row, col, GetUserInput(int.MinValue, int.MaxValue));
                            break;
                        case 2:
                            chessMatrix.DeleteValue(row, col);
                            break;
                        case 3:
                            Console.WriteLine(chessMatrix.GetValue(row, col));
                            break;
                    }
                } while (true) ;
            } 
        
        }

        static void Main()
        {
            FillMatrixes();
            PrintMatrixes();
            Work();
        }
    }
}