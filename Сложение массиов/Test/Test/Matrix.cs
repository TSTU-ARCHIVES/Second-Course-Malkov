using System.Reflection;
using System.Text;

namespace Test
{
    /// <summary>
    /// Класс, позволяющий осуществлять работу с типом данных Двумерный массив,
    /// хранящим числа в виде двумерного массива
    /// </summary>
    public class TwoDismentionArray
    {
        /// <summary>
        /// Поле класса, отображающее количество строк
        /// </summary>
        protected int AmountOfRows;
        /// <summary>
        /// Поле класса, отображающее количество столбцов
        /// </summary>
        protected int AmountOfCols;
        /// <summary>
        /// Основное поле класса - двумерный массив, 
        /// и являющийся матрицей
        /// </summary>
        protected double[,] Mtx;
        /// <summary>
        /// Пустой конструктор, создающий матрицу 3x3, 
        /// заполненную случайными элементами от 0 до 10
        /// </summary>
        public TwoDismentionArray()
        {
            this.AmountOfRows = 3;
            this.AmountOfCols = 3;
            this.Mtx = new double[3, 3];
            this.FillRandom(0, 10);
        }
        /// <summary>
        /// Конструктор, создающий экземпляр класса на основе данного массива - 
        /// целочисленного
        /// </summary>
        /// <param name="mtx">
        /// Двумерный целочисленный массив, на основе
        /// которого создается экземпляр класса
        /// </param>
        public TwoDismentionArray(double[,] mtx)
        {
            this.AmountOfCols = mtx.GetLength(0);
            this.AmountOfRows = mtx.GetLength(1);
            this.Mtx = mtx;
        }
        /// <summary>
        /// Конструктор, создающий новую пустую квадратную
        /// матрицу с заданной длиной
        /// </summary>
        /// <param name="size">Длина квадратной матрицы</param>
        public TwoDismentionArray(int size)
        {
            this.AmountOfRows = size;
            this.AmountOfCols = size;
            this.Mtx = new double[size, size];
        }
        /// <summary>
        /// Создает новую пустую матрицу с заданным количеством
        /// строк и столбцов
        /// </summary>
        /// <param name="amountOfRows">Количество строк в новой матрице</param>
        /// <param name="amountOfCols">Количество столбцов в новой матрице</param>
        public TwoDismentionArray(int amountOfRows, int amountOfCols)
        {
            this.AmountOfCols = amountOfCols;
            this.AmountOfRows = amountOfRows;
            this.Mtx = new double[amountOfRows, amountOfCols];
        }
        /// <summary>
        /// Возвращает длину матрицы по горизонтали
        /// </summary>
        /// <returns>Длина матрицы по горизонтали, т.е.
        /// количество столбцов</returns>
        public int GetHorizontalLength()
        {
            return AmountOfCols;
        }
        /// <summary>
        /// Возвращает длину матрицы по вертикали
        /// </summary>
        /// <returns>Длина матрицы по вертикали, т.е.
        /// количество строк</returns>
        public int GetVerticalLength()
        {
            return AmountOfRows;
        }
        /// <summary>
        /// Возвращает элемент по заданной строке и столбцу
        /// </summary>
        /// <param name="row">Заданная строка</param>
        /// <param name="col">Заданный столбец</param>
        /// <returns>Элемент, имеющий координаты [строка; столбец]</returns>
        public double GetElem(int row, int col)
        {
            return this.Mtx[row, col];
        }
        /// <summary>
        /// Позволяет установить элемент на данную позицию
        /// </summary>
        /// <param name="row">Строка, на которой будет находиться элемент</param>
        /// <param name="col">Столбец, на котором будет находиться элемент</param>
        /// <param name="elem">Вствляемый элемент</param>
        public void SetElem(int row, int col, double elem)
        {
            this.Mtx[row, col] = elem;
        }

        /// <summary>
        /// Индексатор, позволяющий устанавливать или получать элемент
        /// в текущей матрице по данному индексу
        /// </summary>
        /// <param name="a">Номер строки элемента</param>
        /// <param name="b">Номер столбца элемента</param>
        /// <returns>Элемент, имеющий координаты [строка; столбец]</returns>
        public double this[int a, int b]
        {
            get { return this.Mtx[a, b]; }
            set { this.Mtx[a, b] = value; }
        }
        /// <summary>
        /// Проверяет, состоит ли текущая матрица
        /// исключительно из нулей
        /// </summary>
        /// <returns>
        /// True: текущая матрица состоит только из нулей;
        /// False: текущая матрица не состоит только из нулей;
        /// </returns>
        public bool IsZeroMatrix()
        {
            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    if (Mtx[i, j] != 0)
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Проверяет, является ли текущая матрица квадратной, т.е.
        /// с одинаковым числом строк и столбцов
        /// </summary>
        /// <returns>
        /// True: текущая матрица является квадратной ;
        /// False: текущая матрица не является квадратной;
        /// </returns>
        public bool IsSquareMatrix()
        {
            return AmountOfCols == AmountOfRows;
        }
        /// <summary>
        /// Добавляет к текущей матрице данную, если это возможно
        /// </summary>
        /// <param name="matrix">
        /// Складываемая матрица, размеры которой
        /// совпадают с размерами данной
        /// </param>
        /// <returns>Матрица - сумма текущей матрицы и складываемой</returns>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае, если размеры матриц не совпадают,
        /// и сложение невозможно
        /// </exception>
        public TwoDismentionArray AddMatrix(TwoDismentionArray matrix)
        {
            if (!HasSameSize(this, matrix))
                throw new ArgumentException("Матрицы должны иметь одинаковый размер. " +
                    "Сложение невозможно.");

            TwoDismentionArray mat = new TwoDismentionArray(AmountOfRows, AmountOfCols);
            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    mat.SetElem(i,j, Mtx[i,j] + matrix.GetElem(i,j));
                }
            }
            return mat;
        }
        /// <summary>
        /// Вычитает из текущей матрицы данную, если это возможно
        /// </summary>
        /// <param name="matrix">Вычитаемая матрица</param>
        /// <returns>Разность текущей матрицы и вычитаемой</returns>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае, если размеры матриц не совпадают,
        /// и вычитание невозможно
        /// </exception>
        public TwoDismentionArray SubMatrix(TwoDismentionArray matrix)
        {
            if (!HasSameSize(this, matrix))
                throw new ArgumentException("Матрицы должны иметь одинаковый размер. " +
                    "Вычитание невозможно.");
            TwoDismentionArray mat = new TwoDismentionArray(AmountOfRows, AmountOfCols);
            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    mat.SetElem(i, j, Mtx[i, j] - matrix.GetElem(i, j));
                }
            }
            return mat;
        }

        /// <summary>
        /// Возращает результат матричного умножения текущей матрицы
        /// и данной в случае, если оно возможно
        /// </summary>
        /// <param name="matrix">
        /// Матрица, на которую умножается текущая,
        /// имеющая количество строк равное количеству столбцов текущей
        /// </param>
        /// <returns>Произведение текущей матрицы и данной</returns>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае,
        /// если размеры количество строк умножаемой матрицы не равно
        /// количеству столбцов текущей,
        /// и умножение невозможно
        /// </exception>
        public virtual TwoDismentionArray MultiplyMatrx(TwoDismentionArray matrix)
        {
            if (matrix.GetHorizontalLength() != this.AmountOfRows)
                throw new ArgumentException("Матрицы несовместимы, умножение невозможно!");

            TwoDismentionArray res = new TwoDismentionArray(this.GetVerticalLength() ,matrix.GetHorizontalLength());

            for (int i = 0; i < res.GetHorizontalLength(); i++)
            {
                for (int j = 0; j < res.GetVerticalLength(); j++)
                {
                    double sum = 0;
                    for (int r = 0; r < this.GetVerticalLength(); r++)
                    {
                        sum += Mtx[i, r] * matrix.GetElem(r, j);
                    }
                    res.SetElem(i, j, sum);
                }
            }

            return res;
        }
        /// <summary>
        /// Умножает текущую матрицу на скаляр
        /// </summary>
        /// <param name="value">Целочисленный скаляр,
        /// на который умножается текущая матрица</param>
        /// <returns>Произведение текущей матрицы и скаляра</returns>
        public TwoDismentionArray MultiplyMatrx(double value)
        {
            TwoDismentionArray mat = new TwoDismentionArray(AmountOfRows, AmountOfCols);

            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    mat.SetElem(i, j, Mtx[i, j] * value);
                }
            }

            return mat;
        }

        /// <summary>
        /// Оператор, осуществляющий сложение двух заданный матрица
        /// </summary>
        /// <param name="matrix">Первая складываемая матрица</param>
        /// <param name="secondMatrix">Вторая складываемая матрица</param>
        /// <returns>Сумма данных матриц</returns>
        public static TwoDismentionArray operator +(TwoDismentionArray matrix, TwoDismentionArray secondMatrix)
        {
            return matrix.AddMatrix(secondMatrix);
        }
        /// <summary>
        /// Оператор, осуществляющий вычитание двух заданный матрица
        /// </summary>
        /// <param name="matrix">Матрица, из которой вычитается вторая</param>
        /// <param name="secondMatrix">Вычитаемая матрица</param>
        /// <returns>Разность данных матриц</returns>
        public static TwoDismentionArray operator -(TwoDismentionArray matrix, TwoDismentionArray secondMatrix)
        {
            return matrix.SubMatrix(secondMatrix);
        }
        /// <summary>
        /// Оператор, осуществляющий умножение двух заданный матриц
        /// </summary>
        /// <param name="matrix">Первая умножаемая матрица</param>
        /// <param name="secondMatrix">Вторая умножаемая матрица</param>
        /// <returns>Произведение данных матриц</returns>
        public static TwoDismentionArray operator *(TwoDismentionArray matrix, TwoDismentionArray secondMatrix)
        {
            return matrix.MultiplyMatrx(secondMatrix);
        }
        /// <summary>
        /// Оператор, осуществляющий умножение данной матрицы на скаляр
        /// </summary>
        /// <param name="matrix">Умножаемая матрица</param>
        /// <param name="scalar">Скаляр, на который умножеается матрица</param>
        /// <returns>Произведение матрицы на скаляр</returns>
        public static TwoDismentionArray operator *(TwoDismentionArray matrix, double scalar)
        {
            return matrix.MultiplyMatrx(scalar);
        }
        /// <summary>
        /// Проверяет матрицы на полное равенство
        /// </summary>
        /// <param name="obj">Сравниваемый объект, предположительно, матрица</param>
        /// <returns>
        /// True: матрицы равны либо ссылаются на один и тот же 
        /// объект в памяти;
        /// False: все остальные случаи
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) 
                return false;

            if (obj is not TwoDismentionArray)
                return false;

            if (!ReferenceEquals(obj, this))
                return false;

            TwoDismentionArray matrix = (TwoDismentionArray)obj;
            if (!HasSameSize(matrix, this))
                return false;

            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    if (Mtx[i, j] != matrix.GetElem(i,j))
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Возвращает строку, отображающую матрицу
        /// </summary>
        /// <returns>Строка, отображающая матрицу</returns>
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append("[");
            for (int i = 0; i < AmountOfCols; i++)
            {
                res.Append("[");
                for (int j = 0; j < AmountOfRows; j++)
                {
                    string symbol = Mtx[i, j].ToString();
                    res.Append(symbol + ", ");
                }
                res.Remove(res.Length - 2, 2);
                res.Append("], ");
            }
            res.Remove(res.Length - 2, 2);
            res.Append("]");
            return res.ToString();
        }
        /// <summary>
        /// Заполняет текущую матрицу случайными элементами
        /// из заданного отрезка
        /// </summary>
        /// <param name="start">Начало отрезка, из которого берутся элементы</param>
        /// <param name="end">Конец отрезка, из которого берутся элементы</param>
        public void FillRandom(double start, double end)
        {
            Random random = new Random();
            for (int i = 0; i < AmountOfCols; i++)
            {
                for (int j = 0; j < AmountOfRows; j++)
                {
                    Mtx[i,j] = ( end - start ) * random.NextDouble() + start; 
                }
            }
        }
        /// <summary>
        /// Сортирует каждую строку в данной матрице
        /// по возрастанию
        /// </summary>
        public void SortRows()
        {
            for (int i = 0; i < AmountOfRows; i++)
            {
                SortRow(i);
            }
        }
        /// <summary>
        /// Сортирует данную строку в текущей матрице
        /// по возрастанию методом вставок
        /// </summary>
        /// <param name="row">Номер сортируемой строки</param>
        protected void SortRow(int row)
        {
            for (int i = 0; i < AmountOfCols; i++)
            {
                int j = i;
                while (j > 0 && Mtx[row, j] <= Mtx[row, j - 1])
                {
                    double temp = Mtx[row, j - 1];
                    Mtx[row, j - 1] = Mtx[row, j];
                    Mtx[row, j] = temp;

                    j--;
                }
            }
        }
        /// <summary>
        /// Метод, позволяющий создавать новую матрицу
        /// заданного размера, заполненную случайными элементами
        /// в заданном отрезке
        /// </summary>
        /// <param name="rows">Количество строк в новой матрице</param>
        /// <param name="cols">Количество столбцов в новой матрице</param>
        /// <param name="start">Начало отрезка, из которого берутся случайные числа</param>
        /// <param name="end">Конец отрезка, из которого берутся случайные числа</param>
        /// <returns>Матрица заданного размера, заполненная случайными элементами</returns>
        public static TwoDismentionArray GenerateRandomMatrix(int rows, int cols, double start, double end)
        {
            TwoDismentionArray matrix = new TwoDismentionArray(rows, cols);
            matrix.FillRandom(start, end);
            return matrix;
        }
        /// <summary>
        /// Метод, проверяющий, имеют ли одинаковые размеры по вертикали
        /// и по горизонтали заданные матрицы
        /// </summary>
        /// <param name="first">Первая матрица</param>
        /// <param name="second">Вторая матрица</param>
        /// <returns>
        /// True: матрицы имеют одинаковое число строк и столбцов;
        /// False: все иные случаи ;
        /// </returns>
        public static bool HasSameSize(TwoDismentionArray first, TwoDismentionArray second)
        {
            return
                first.GetHorizontalLength() == second.GetHorizontalLength() &&
                first.GetVerticalLength() == second.GetVerticalLength();
        }
    }

}