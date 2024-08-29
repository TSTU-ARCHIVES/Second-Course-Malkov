using System.Diagnostics.Metrics;
using System.Numerics;

namespace Lab0
{
    /// <summary>
    /// Класс, реализующий квадратную матрицу с данными определнного типа
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Значение фонового элемента
        /// </summary>
        const double def = 0;
        /// <summary>
        /// Размер матрицы
        /// </summary>
        private int size = 0;
        /// <summary>
        /// Двумерный массив, реализующий матрицу
        /// </summary>
        private double[,] matrix = { };
        /// <summary>
        /// Конструктор, создающий пустую матрицу данного размера
        /// </summary>
        /// <param name="size">Размер матрицы</param>
        public Matrix(int size)
        {
            this.size = size;
            this.matrix = new double[size, size];
        }

        /// <summary>
        /// Конструктор, создающий экземпляр класса на основе
        /// двумерного квадратного массива
        /// </summary>
        /// <param name="matrix">Двумерный массив, оборажающий матрицу</param>
        public Matrix(double[,] matrix)
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
        public void setElem(int row, int col, double elem)
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
            matrix[row, col] = def;
        }
        /// <summary>
        /// Возращает элемент на данной позиции
        /// </summary>
        /// <param name="row">Номер ряда получаемого элемента</param>
        /// <param name="col">Номер столбца получаемого элемента</param>
        /// <returns>Элемент на данной позиции</returns>
        public double getElem(int row, int col)
        {
            return matrix[row, col];
        }
        /// <summary>
        /// Возращает верхний треугольник матрицы
        /// </summary>
        /// <returns>Верхний треугольник матрицы</returns>
        public double[][] getUpperTriagle()
        {
            double[][] upperT = new double[size][];
            for (int i = 0; i < size; i++)
            {
                double[] temp = new double[size - i];
                for (int j = i; j < size; j++)
                {
                    temp[j - i] = matrix[i, j];
                }
                upperT[i] = temp;
            }
            return upperT;
        }
        public double[] GetAssymetricVector()
        {
            return Matrix.GetVector(matrix);
        }
        /// <summary>
        /// Возвращает упакованную матрицу
        /// </summary>
        /// <returns>Упаковываемая матрицы</returns>
        public int[][] AssymtricBox()
        {
            return Matrix.Box(matrix);
        }
        /// <summary>
        /// Возвращает вектор из элементов матрицы
        /// </summary>
        /// <returns>Вектор из элементов матрицы</returns>
        public double[] GetSymmetricVector()
        {
            return Matrix.GetVector(this.getUpperTriagle());
        }
        /// <summary>
        /// Возвращает упакованную матрицу
        /// </summary>
        /// <returns>Упаковываемая матрицы</returns>
        public int[][] SymmetricBox()
        {
            return Matrix.Box(this.getUpperTriagle());
        }
        /// <summary>
        /// Возвращает вектор от произвольного массива массивов
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <returns>Вектор от произвольной матрицы</returns>
        private static double[] GetVector(double[][] matrix)
        {
            List<double> list = new List<double>();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                    if (!matrix[i][j].Equals(def))
                        list.Add(matrix[i][j]);
            return list.ToArray();

        }
        /// <summary>
        /// Возвращает вектор от произвольного массива массивов
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <returns>Вектор от произвольной матрицы</returns>
        private static double[] GetVector(double[,] matrix)
        {
            List<double> list = new List<double>();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (!matrix[i,j].Equals(def))
                        list.Add(matrix[i,j]);
            return list.ToArray();

        }
        /// <summary>
        /// Упаковывает произвольный массив массивов 
        /// </summary>
        /// <param name="matrix">Произвольный массив массивов</param>
        /// <returns>Упакованный массив массивов</returns>
        private static int[][] Box(double[][] matrix)
        {
            List<int> boxedCols = new List<int>();
            List<int> boxedRows = new List<int>();
            int notNullElems = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                boxedRows.Add(notNullElems);
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (!matrix[i][j].Equals(def))
                    {
                        boxedCols.Add(j);
                        notNullElems++;
                    }
                }
            }
            return new int[][] { boxedRows.ToArray(), boxedCols.ToArray() };
        }/// <summary>
         /// Упаковывает произвольный массив массивов 
         /// </summary>
         /// <param name="matrix">Произвольный массив массивов</param>
         /// <returns>Упакованный массив массивов</returns>
        private static int[][] Box(double[,] matrix)
        {
            List<int> boxedCols = new List<int>();
            List<int> boxedRows = new List<int>();
            int notNullElems = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                boxedRows.Add(notNullElems);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!matrix[i,j].Equals(def))
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
    /// <typeparam name="double">Тип элементов в упакованной матрице</typeparam>
    public class BoxedSymmetricMatrix
    {
        const double def = 0;
        /// <summary>
        /// Вектор упакованной матрицы
        /// </summary>
        private double[] vector;

        public double[] Vector { get => vector; }

        private List<int> rows;
        private List<int> columns;

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
        public BoxedSymmetricMatrix(double[] vector, int[][] indexes) {
            this.vector = vector;
            this.rows = indexes[0].ToList();
            this.columns = indexes[1].ToList();
            this.size = indexes[0].Length;
        }
        /// <summary>
        /// Конструктор, создающий объект на основе двумерного массива
        /// представляющего собой матрицу
        /// </summary>
        /// <param name="matrix">Двумерный массив - матрица</param>
        public BoxedSymmetricMatrix(double[,] matrix)
        {
            Matrix tempMat = new Matrix(matrix);
            this.vector = tempMat.GetSymmetricVector();

            var indexes = tempMat.SymmetricBox();
            this.rows = indexes[0].ToList();
            this.columns = indexes[1].ToList();

            this.size = tempMat.getSize();
        }
        /// <summary>
        /// Конструктор, создающий объект на основе матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        public BoxedSymmetricMatrix(Matrix matrix)
        {
            this.vector = matrix.GetSymmetricVector();

            var indexes = matrix.SymmetricBox();
            this.rows = indexes[0].ToList();
            this.columns = indexes[1].ToList();

            this.size = matrix.getSize();
        }
        /// <summary>
        /// Конструктор, создающий новую пустую матрицу длины 0
        /// </summary>
        public BoxedSymmetricMatrix()
        {
            this.vector = new double[0];
            this.rows = new List<int>();
            this.columns = new List<int>();
            this.size = 0;
        }
        /// <summary>
        /// Определяет положение элемента в верхнем треугольнике
        /// на основе данного положения в полной матрице
        /// </summary>
        public (int, int) defineRowColInUpper(int factrow, int factcol)
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
        public int findInVector(int factRow, int factCol)
        {
            int row, col;
            (row, col) = defineRowColInUpper(factRow, factCol);

            if (row + 1 < rows.Count)
            {
                for (int i = rows[row]; i < rows[row + 1]; i++)
                {
                    if (columns[i] == col)
                        return i;
                }
            } else
            {
                for (int i = rows[row]; i < columns.Count; i++)
                {
                    if (columns[i] == col)
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
        public double getElem(int factRow, int factCol)
        {

            int index = findInVector(factRow, factCol);
            if (index == -1)
                return def;
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
            vector[findInVector(factRow, factCol)] = def;
        }
        /// <summary>
        /// Назначает элемент на данную позицию
        /// </summary>
        /// <param name="factRow">Номер строки элемента</param>
        /// <param name="factCol">Номер столбца элемента</param>
        /// <param name="elem">Назначаемый элемент</param>
        public void setElem(int factRow, int factCol, double elem)
        {

            int row, col;
            (row, col) = defineRowColInUpper(factRow, factCol);
            //replacement
            int pos = findInVector(factRow, factCol);
            if (pos != -1)
            {
                vector[pos] = elem;
                return;
            }

            //insertion in col

            if (row < rows.Count - 1)
            {
                for (int i = rows[row]; i < rows[row + 1]; i++)
                {
                    if (i == rows[row + 1] - 1 || columns[i] >= col)
                    {
                        List<int> newCols = new List<int>(columns);
                        newCols.Insert(i + 1, col);

                        List<double> newVector = new List<double> { };
                        foreach (double val in vector)
                            newVector.Add(val);
                        newVector.Insert(i + 1, elem);

                        columns = newCols;
                        vector = newVector.ToArray();

                        break;
                    }
                }

                for (int i = row + 1; i < size; i++)
                    rows[i]++;
            }
            else
            {
                for (int i = rows[row]; i <= columns.Count; i++)
                {

                    if (i >= columns.Count - 1 || columns[i] >= col)
                    {
                        i = Math.Min(i + 1, columns.Count);
                        List<int> newCols = new List<int>(columns);
                        newCols.Insert(i, col);

                        List<double> newVector = new List<double> { };
                        foreach (double val in vector)
                            newVector.Add(val);
                        newVector.Insert(i, elem);

                        columns = newCols;
                        vector = newVector.ToArray();

                        break;
                    }

                }

                for (int i = row + 1; i < size; i++)
                    rows[i]++;
            }
        }

        public BoxedSymmetricMatrix Add(BoxedSymmetricMatrix second)
        {
            BoxedSymmetricMatrix newMat = this;
            int i = 0;
            for (int row = 0; row < second.rows.Count; row++)
            {
                int end = row == second.rows.Count - 1 ?
                    second.columns.Count : second.rows[row + 1];
                for (int col = second.rows[row]; col < end; col++)
                {
                    int factCol = second.columns[col];
                    double value = newMat.getElem(row, factCol + i) + second.Vector[col];
                    newMat.setElem(row, factCol + i, value);
                }
                i++;
            }

            return newMat;
        }


    }
    /// <summary>
    /// Класс, отображающий упакованную квадратную матрицу
    /// </summary>
    public class BoxedAsymmetricMatrix
    {
        public const double def = 0;
        /// <summary>
        /// Вектор упакованной матрицы
        /// </summary>
        private double[] vector;

        public double[] Vector { get => vector; }

        private List<int> rows;
        private List<int> columns;

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
        public BoxedAsymmetricMatrix(double[] vector, int[][] indexes)
        {
            this.vector = vector;
            this.rows = indexes[0].ToList();
            this.columns = indexes[1].ToList();
            this.size = indexes[0].Length;
        }
        /// <summary>
        /// Конструктор, создающий объект на основе двумерного массива
        /// представляющего собой матрицу
        /// </summary>
        /// <param name="matrix">Двумерный массив - матрица</param>
        public BoxedAsymmetricMatrix(double[,] matrix)
        {
            Matrix tempMat = new Matrix(matrix);
            this.vector = tempMat.GetAssymetricVector();

            var indexes = tempMat.AssymtricBox();
            this.rows = indexes[0].ToList();
            this.columns = indexes[1].ToList();

            this.size = tempMat.getSize();
        }
        /// <summary>
        /// Конструктор, создающий объект на основе матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        public BoxedAsymmetricMatrix(Matrix matrix)
        {
            this.vector = matrix.GetAssymetricVector();

            var indexes = matrix.AssymtricBox();
            this.rows = indexes[0].ToList();
            this.columns = indexes[1].ToList();

            this.size = matrix.getSize();
        }
        /// <summary>
        /// Конструктор, создающий новую пустую матрицу длины 0
        /// </summary>
        public BoxedAsymmetricMatrix()
        {
            this.vector = new double[0];
            this.rows = new List<int>();
            this.columns = new List<int>();
            this.size = 0;
        }
        /// <summary>
        /// Находит позицию в векторе элемента по
        /// его позиции в цельной матрице
        /// </summary>
        /// <param name="factRow">Строка элемента</param>
        /// <param name="factCol">Столбец элемента</param>
        /// <returns>Индекс элемента в векторе</returns>
        public int findInVector(int factRow, int factCol)
        {
            int row = factRow, col = factCol;

            if (row + 1 < rows.Count)
            {
                for (int i = rows[row]; i < rows[row + 1]; i++)
                {
                    if (columns[i] == col)
                        return i;
                }
            }
            else
            {
                for (int i = rows[row]; i < columns.Count; i++)
                {
                    if (columns[i] == col)
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
        public double getElem(int factRow, int factCol)
        {

            int index = findInVector(factRow, factCol);
            if (index == -1)
                return def;
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
            vector[findInVector(factRow, factCol)] = def;
        }
        /// <summary>
        /// Назначает элемент на данную позицию
        /// </summary>
        /// <param name="row">Номер строки элемента</param>
        /// <param name="col">Номер столбца элемента</param>
        /// <param name="elem">Назначаемый элемент</param>
        public void setElem(int row, int col, double elem)
        {

            //replacement
            int pos = findInVector(row, col);
            if (pos != -1)
            {
                vector[pos] = elem;
                return;
            }

            //insertion in col

            if (row < rows.Count - 1)
            {
                for (int i = rows[row]; i < rows[row + 1]; i++)
                {
                    if (i == rows[row + 1] - 1 || columns[i + 1] >= col)
                    {
                        List<int> newCols = new List<int>(columns);
                        newCols.Insert(i + 1, col);

                        List<double> newVector = new List<double> { };
                        foreach (double val in vector)
                            newVector.Add(val);
                        newVector.Insert(i + 1, elem);

                        columns = newCols;
                        vector = newVector.ToArray();

                        break;
                    }
                }

                for (int i = row + 1; i < size; i++)
                    rows[i]++;
            }
            else
            {
                for (int i = rows[row]; i < columns.Count; i++)
                {

                    if (columns[i] >= col || i == columns.Count - 1)
                    {
                        List<int> newCols = new List<int>(columns);
                        newCols.Insert(i + 1, col);

                        List<double> newVector = new List<double> { };
                        foreach (double val in vector)
                            newVector.Add(val);
                        newVector.Insert(i + 1, elem);

                        columns = newCols;
                        vector = newVector.ToArray();

                        break;
                    }

                }

                for (int i = row + 1; i < size; i++)
                    rows[i]++;
            }
        }

        public BoxedAsymmetricMatrix Add(BoxedAsymmetricMatrix second)
        {
            BoxedAsymmetricMatrix newMat = this;

            for (int row = 0; row < second.rows.Count; row++)
            {
                int end = row == second.rows.Count - 1 ?
                    second.columns.Count : second.rows[row + 1];
                for (int col = second.rows[row]; col < end; col++)
                {
                    int factCol = second.columns[col];
                    double value = newMat.getElem(row, factCol) + second.Vector[col];
                    newMat.setElem(row, factCol, value);
                }
            }

            return newMat;
        }

    }


    /// <summary>
    /// Класс, отобрающий матрицу, описываемую 
    /// математически как шахматную с нулями на белых клетках
    /// </summary>
    public class ChessMatrix
    {
        const double def = 0;
        /// <summary>
        /// Длина матрицы
        /// </summary>
        public int len;
        /// <summary>
        /// Вектор матрицы
        /// </summary>
        public double[] vector;
        /// <summary>
        /// Конструктор, создающий шахматную матрицу данной длины
        /// </summary>
        /// <param name="size">Длина шахматной матрицы</param>

        public ChessMatrix(int size)
        {
            len = size;
            vector = new double[(len * len) / 2];
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
            this.SetValue(x, y, def);
        }
        /// <summary>
        /// Назначает новый элемент на данную позицию
        /// </summary>
        /// <param name="x">x- координата нового элемента</param>
        /// <param name="y">y- координата нового элемента</param>
        /// <param name="value">Назначаемый элемент</param>
        /// <returns>True: назначение возможно
        /// False: во всех иных случаях </returns>
        public bool SetValue(int x, int y, double value)
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
        public double GetValue(int x, int y)
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

    public static class ExtClass
    {

        

        public static BoxedSymmetricMatrix Multiply(this BoxedSymmetricMatrix first, BoxedSymmetricMatrix second)
        {
            Matrix mtx = new(first.Size);
            BoxedSymmetricMatrix res = new BoxedSymmetricMatrix(mtx);

            for (int i = 0; i < res.Size; i++)
            {
                for (int j = 0; j < res.Size; j++)
                {
                    double sum = 0;
                    for (int r = 0; r < first.Size; r++)
                    {
                        sum += first.getElem(i, r) * second.getElem(r, j);
                    }
                    res.setElem(i, j, sum);
                }
            }

            return res;
        }

        public static BoxedAsymmetricMatrix Multiply(this BoxedAsymmetricMatrix first, BoxedAsymmetricMatrix second)
        {
            Matrix mtx = new(first.Size);
            BoxedAsymmetricMatrix res = new BoxedAsymmetricMatrix(mtx);

            for (int i = 0; i < res.Size; i++)
            {
                for (int j = 0; j < res.Size; j++)
                {
                    double sum = 0;
                    for (int r = 0; r < first.Size; r++)
                    {
                        sum += first.getElem(i, r) * second.getElem(r, j);
                    }
                    res.setElem(i, j, sum);
                }
            }

            return res;
        }

    }
    class Program
    {
        static BoxedAsymmetricMatrix mat;
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
            double[,] matx = new double[N, N];
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
            }
            else
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
            }
            else
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
                } while (true);
            }

        }

        static void Main()
        {
            //FillMatrixes();
            //PrintMatrixes();
            //Work();

            BoxedAsymmetricMatrix mat = new(new double[,]
            {
                {0, 2, 4, 5 },
                {1, 0, 4, 5 },
                {1, 2, 0, 5 },
                {1, 2, 4, 0 },
            }
            
            );

            BoxedAsymmetricMatrix second = new(new double[,]
            {
                {1, 2, 4, 0 },
                {1, 2, 0, 5 },
                {1, 0, 4, 5 },
                {0, 2, 4, 5 },
            }

            );

            mat = mat.Add(second);
            int N = mat.Size;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0}", mat.getElem(i, j).ToString().PadRight(7));
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            BoxedSymmetricMatrix symmat = new(new double[,]
            {
                {0, 2, 4, 5 },
                {2, 0, 4, 5 },
                {4, 4, 0, 5 },
                {5, 5, 5, 0 },
            }

            );

            BoxedSymmetricMatrix symsecond = new(new double[,]
            {
                {1, 2, 4, 0 },
                {2, 2, 0, 5 },
                {4, 0, 4, 5 },
                {0, 5, 5, 6 },
            }

            );

            symmat = symmat.Add(symsecond);
            N = mat.Size;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0}", symmat.getElem(i, j).ToString().PadRight(7));
                }
                Console.WriteLine();
            }

        }
    }
}