using GraphsADT__L10to12_;
namespace P
{
    class P
    {
        const int MAX_LEN = 500;
        const int MIN_LEN = 2;
        const string FILE_NAME = "LAB31.txt";
        static int[,] ReadMatrix(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            int[,] matrix;
            int len;
            //перенос файла в массив
            try
            {
                //читаем len, проверяем на корректность
                if (!int.TryParse(file.ReadLine(), out len))
                    throw new Exception("Количество вершин графа нечисленно");

                if (len < MIN_LEN || len > MAX_LEN)
                    throw new Exception("Недопустимое количество вершин графа");

                matrix = new int[len, len];
                //читаем матрицу, проверяем на корректность длину строк
                for (int i = 0; i < len; i++)
                {
                    string str = file.ReadLine();
                    if (ReferenceEquals(str, null))
                        throw new Exception("Одна из строк пустая");
                    string[] buf = str.Split(" ");
                    if (buf.Length != len)
                        throw new Exception("Одна из строк содержит некорректное количество вершин");
                    for (int j = 0; j < len; j++)
                    {
                        if (!int.TryParse(buf[j], out matrix[i, j]))
                            throw new Exception("Некорректное значение веса");
                    }

                }
                return matrix;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка чтения ф айла, неправильный формат.");
                Console.WriteLine(e.Message);
            }
            finally
            {
                file.Close();
            }
            return null;
        }
        static void Main()
        {

            int[,] matrix = ReadMatrix(FILE_NAME);
            Graph g = new GraphOnMatrixADJ(matrix);
            if (g.IsLinked)
                Console.WriteLine("Да");
            else
                Console.WriteLine("Нет");
        }
    }
}