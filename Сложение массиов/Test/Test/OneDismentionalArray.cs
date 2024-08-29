using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// Класс, позволяющий осуществлять работу с типом данных Двумерный массив,
    /// хранящим числа в виде двумерного массива
    /// </summary>
    public class OneDismentionalArray
    {
        /// <summary>
        /// Длина текущего массива
        /// </summary>
        protected int Length;
        /// <summary>
        /// Основное поле класса - массив, 
        /// и являющийся матрицей
        /// </summary>
        protected double[] Arr;
        /// <summary>
        /// Пустой конструктор, создающий массив из одного случайного элемента
        /// от 0 до 10
        /// </summary>
        public OneDismentionalArray()
        {
            this.Length = 1;
            this.Arr = new double[1];
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
        public OneDismentionalArray(double[] arr)
        {
            this.Arr = arr;
            this.Length = arr.Length;
        }
        /// <summary>
        /// Конструктор, создающий новую пустую квадратную
        /// матрицу с заданной длиной
        /// </summary>
        /// <param name="size">Длина квадратной матрицы</param>
        public OneDismentionalArray(int size)
        {
            this.Length = size;
            this.Arr = new double[size];
        }
        /// <summary>
        /// Возвращает длину массива
        /// </summary>
        /// <returns>Длина массива, т.е.
        /// количество элементов массива</returns>
        public int GetLength()
        {
            return this.Length;
        }
        /// <summary>
        /// Возвращает элемент по заданной позиции (индексу)
        /// </summary>
        /// <param name="pos">Заданная позиция</param>
        /// <returns>Элемент, имеющий координаты [позиция]</returns>
        public double GetElem(int pos)
        {
            return this.Arr[pos];
        }
        /// <summary>
        /// Позволяет установить элемент на данную позицию
        /// </summary>
        /// <param name="pos">Позиция, на которой будет находиться элемент</param>
        /// <param name="elem">Вствляемый элемент</param>
        public void SetElem(int pos, double elem)
        {
            this.Arr[pos] = elem;
        }
        /// <summary>
        /// Проверяет, состоит ли текущий массив
        /// исключительно из нулей
        /// </summary>
        /// <returns>
        /// True: текущий массив состоит только из нулей;
        /// False: текущий массив не состоит только из нулей;
        /// </returns>
        public bool IsZeroMatrix()
        {
            for (int i = 0; i < Length; i++)
            { 
                if (Arr[i] != 0)
                   return true;
            }
            return false;
        }
        /// <summary>
        /// Добавляет к текущему массиву данный, если это возможно
        /// </summary>
        /// <param name="matrix">
        /// Складываемый массив, размеры которого
        /// совпадают с размерами текущего
        /// </param>
        /// <returns>Массив - сумма текущего и складываемого</returns>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае, если размеры массивов не совпадают,
        /// и сложение невозможно
        /// </exception>
        public OneDismentionalArray AddMatrix(OneDismentionalArray matrix)
        {
            if (!HasSameSize(this, matrix))
                throw new ArgumentException("Матрицы должны иметь одинаковый размер. " +
                    "Вычитание невозможно.");
            OneDismentionalArray mat = new OneDismentionalArray(Length);
            for (int i = 0; i < Length; i++)
            {
                mat.SetElem(i, Arr[i] + matrix.GetElem(i));
            }
            return mat;
        }
        /// <summary>
        /// Вычитает из текущего массиву данный, если это возможно
        /// </summary>
        /// <param name="matrix">
        /// Вычитаемый массив, размеры которого
        /// совпадают с размерами текущего
        /// </param>
        /// <returns>Массив - разность текущего и складываемого</returns>
        /// <exception cref="ArgumentException">
        /// Исключение, возникающее в случае, если размеры массивов не совпадают,
        /// и вычитание невозможно
        /// </exception>
        public OneDismentionalArray SubMatrix(OneDismentionalArray matrix)
        {
            if (!HasSameSize(this, matrix))
                throw new ArgumentException("Матрицы должны иметь одинаковый размер. " +
                    "Вычитание невозможно.");
            OneDismentionalArray mat = new OneDismentionalArray(Length);
            for (int i = 0; i < Length; i++)
            {
                mat.SetElem(i, Arr[i] - matrix.GetElem(i));
            }
            return mat;
        }
        /// <summary>
        /// Умножает текущий массив на скаляр
        /// </summary>
        /// <param name="value">Целочисленный скаляр,
        /// на который умножается текущий массив</param>
        /// <returns>Произведение текущего массива и скаляра</returns>
        public OneDismentionalArray MultiplyMatrx(double value)
        {
            OneDismentionalArray mat = new OneDismentionalArray(Length);

            for (int i = 0; i < Length; i++)
            {
                mat.SetElem(i, Arr[i] * value);
            }

            return mat;
        }

        /// <summary>
        /// Оператор, осуществляющий сложение двух заданных массивов
        /// </summary>
        /// <param name="matrix">Первое слагаемое - массив</param>
        /// <param name="secondMatrix">Второе слагаемое - массив</param>
        /// <returns>Сумма данных массивов</returns>
        public static OneDismentionalArray operator +(OneDismentionalArray matrix, OneDismentionalArray secondMatrix)
        {
            return matrix.AddMatrix(secondMatrix);
        }
        /// <summary>
        /// Оператор, осуществляющий вычитание двух заданных массивов
        /// </summary>
        /// <param name="matrix">Уменьшаемое - массив</param>
        /// <param name="secondMatrix">Вычитаемое - массив</param>
        /// <returns>Разность данных массивов</returns>
        public static OneDismentionalArray operator -(OneDismentionalArray matrix, OneDismentionalArray secondMatrix)
        {
            return matrix.SubMatrix(secondMatrix);
        }
        /// <summary>
        /// Оператор, осуществляющий умножение двух массива на скаляр
        /// </summary>
        /// <param name="matrix">Умножаемый массив</param>
        /// <param name="scalar">Умножаемый скаляр</param>
        /// <returns>Произведение массива на скаляр</returns>
        public static OneDismentionalArray operator *(OneDismentionalArray matrix, double scalar)
        {
            return matrix.MultiplyMatrx(scalar);
        }
        /// <summary>
        /// Проверяет массивы на полное равенство
        /// </summary>
        /// <param name="obj">Сравниваемый объект, предположительно, массив</param>
        /// <returns>
        /// True: массиы равны либо ссылаются на один и тот же 
        /// объект в памяти;
        /// False: все остальные случаи
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (!typeof(OneDismentionalArray).IsInstanceOfType(obj))
                return false;

            OneDismentionalArray matrix = (OneDismentionalArray)obj;
            if (!HasSameSize(matrix, this))
                return false;

            for (int i = 0; i < Length; i++)
            {
                if (Arr[i] != matrix.GetElem(i))
                        return false;
                
            }
            return true;
        }
        /// <summary>
        /// Возвращает строку, отображающую массив
        /// </summary>
        /// <returns>Строка, отображающая массив</returns>
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append("[");
            for (int i = 0; i < Length; i++)
            {
                res.Append(Arr[i].ToString() + ", ");
            }
            res.Remove(res.Length - 2, res.Length - 2);
            res.Append("]");
            return res.ToString();
        }
        /// <summary>
        /// Заполняет текущий массив случайными элементами
        /// из заданного отрезка
        /// </summary>
        /// <param name="start">Начало отрезка, из которого берутся элементы</param>
        /// <param name="end">Конец отрезка, из которого берутся элементы</param>
        public void FillRandom(double start, double end)
        {
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                Arr[i] = (end - start) * random.NextDouble() + start;
                
            }
        }

        /// <summary>
        /// Метод, позволяющий создавать новый массив
        /// заданного размера, заполненный случайными элементами
        /// в заданном отрезке
        /// </summary>
        /// <param name="len">Количество элементов в новом массиве</param>
        /// <param name="start">Начало отрезка, из которого берутся случайные числа</param>
        /// <param name="end">Конец отрезка, из которого берутся случайные числа</param>
        /// <returns>Матрица заданного размера, заполненная случайными элементами</returns>
        public static OneDismentionalArray GenerateRandomMatrix(int len, double start, double end)
        {
            OneDismentionalArray matrix = new OneDismentionalArray(len);
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
        public static bool HasSameSize(OneDismentionalArray first, OneDismentionalArray second)
        {
            return
                first.GetLength() == second.GetLength();
        }
    }
}
