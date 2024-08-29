using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GSF;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.OleDb;
using ClassLib;
using System.Drawing;

namespace BAZA
{
        /// <summary>
        /// Класс, позволяющий осуществлять подключение к БД,
        /// а также работать с данными в ней
        /// </summary>
        public class DataBase
        {
        /// <summary>
        protected string constring;
            /// Конструктор класса, позволяющий открыть соединение с сервером SQL Server на основе
            /// имени базы данных и сервера
            /// </summary>
            /// <param name="databaseName">Имя базы данных</param>
            /// <param name="serverName">Имя сервера</param
            public DataBase(string constring)
            {
                this.constring = constring;
            }
            /// <summary>
            /// Функция, получающая названия таблиц в БД
            /// </summary>
            /// <returns>Массив строк-имен таблиц</returns>
            public string[] GetTables()
            {
            List<string> tabnames = new List<string>();
            using (OleDbConnection dbcon = new OleDbConnection(constring))
            {
                string[] restriction = new string[4];
                restriction[3] = "Table";

                dbcon.Open();
                DataTable usertables = dbcon.GetSchema("Tables", restriction);
                for (int i = 0; i < usertables.Rows.Count; i++)
                    tabnames.Add(usertables.Rows[i][2].ToString());
            }
            return tabnames.ToArray();
        }
            /// <summary>
            /// Функция, позволяющая получить имена столбцов из запроса
            /// </summary>
            /// <param name="sql">Строка, представляющая SQL запрос</param>
            /// <returns>Массив строк-имен столбцов</returns>
            public string[] GetColumnNames(string sql)
            {
                DataTable dataTable;
                using (OleDbConnection conn = new OleDbConnection(constring))
                {
                    conn.Open();
                    OleDbCommand command = new OleDbCommand(sql, conn);
                    dataTable = new DataTable();
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    conn.Close();
                }
                int N = dataTable.Columns.Count;
                string[] names = new string[N];
                for (int i = 0; i < N; i++)
                    names[i] = dataTable.Columns[i].ColumnName;

                dataTable.Dispose();

                return names;
            }
            /// <summary>
            /// Функция, возвращающая набор строк без ключевых полкй
            /// по sql-запросу к базе данных
            /// </summary>
            /// <param name="sql">Строка, представляющая SQL-запрос к БД</param>
            /// <returns>DataTable с данными из sql-запроса</returns>
            public DataTable GetTable(string sql)
            {
                DataTable dt = new DataTable();
                using (OleDbConnection conn = new OleDbConnection(constring))
                {
                    conn.Open();
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, conn))
                    {
                        dataAdapter.Fill(dt);
                    }
                    conn.Close();

                }
                return dt;
            }


            /// <summary>
            /// Функция, позволяющая сохранить в текущей БД изменения в таблице
            /// на основе DataGridView, представляющего эту таблицу
            /// </summary>
            /// <param name="tableName"></param>
            /// <param name="dg"></param>
            public void SaveTable(string tableName, DataGridView dg)
            {
                using (OleDbConnection conn = new OleDbConnection(constring))
                {
                    conn.Open();
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM " + tableName, conn))
                    {
                        OleDbCommandBuilder builder = new OleDbCommandBuilder(dataAdapter);
                        dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                        dataAdapter.DeleteCommand = builder.GetDeleteCommand();
                        dataAdapter.InsertCommand = builder.GetInsertCommand();

                        BindingSource bd = (BindingSource)dg.DataSource;
                        DataTable dt = (DataTable)bd.DataSource;
                        dataAdapter.Update(dt);
                    }
                    conn.Close();
                }
            }
            /// <summary>
            /// Функция, позволяющая перенести данные из DataGridView в Word-таблицу
            /// </summary>
            /// <param name="dg">DataGridView, данные которого необходимо перенести</param>

            public void SaveInWord(DataGridView dg)
            {
                var app = new Application();
                var document = app.Documents.Add();
                var table = document.Tables.Add(document.Paragraphs[1].Range, dg.Rows.Count + 1, dg.Columns.Count);

                for (int i = 0; i < dg.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = dg.Columns[i].HeaderText;
                }
                for (int i = 0; i < dg.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dg.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = dg.Rows[i].Cells[j].Value.ToString();
                    }
                }
                app.Visible = true;

                document = null;
                app = null;
            }
            /// <summary>
            /// Функция, позволяющая перенести данные из DataGridView в Excel-таблицу
            /// </summary>
            /// <param name="dg">DataGridView, данные которого необходимо перенести</param>
            public void SaveInExcel(DataGridView dg)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook book = app.Workbooks.Add();
                Excel.Worksheet sheet = book.ActiveSheet;

                for (int i = 0; i < dg.Columns.Count; i++)
                {
                    sheet.Cells[1, i + 1] = dg.Columns[i].HeaderText;
                }

                for (int i = 0; i < dg.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dg.Columns.Count; j++)
                    {
                        sheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();
                    }
                }

                sheet.Rows.AutoFit();
                sheet.Columns.AutoFit();

                app.Visible = true;

                app = null;
                sheet = null;
            }

            public string[] RowsToStr( DataGridViewRowCollection rows)
            {
                string[] strArr = new string[rows.Count];
                for(int i = 0; i< rows.Count; i++)
                {
                    strArr[i] = rows[i].HeaderCell.ToString() + ":" + rows[i].ToString();
                }
                return strArr;
            }
        }
/// <summary>
/// Класс, позволяющий осуществлять генерацию билетов
/// на основе базы данных
/// </summary>
    public class TicketDB : DataBase
    {
        /// <summary>
        /// Статический генератор билетов
        /// </summary>
        private static TicketGenerator tg;
        /// <summary>
        /// Статический порядковый номер текущего билета
        /// </summary>
        private static int _TicketNum = 0;
        /// <summary>
        /// Возвращает номер текущего билета
        public static int TicketNum { 
            get { return _TicketNum; } 
        }
        /// Конструктор класса, создающий его экземпляр на основе строки соединения
        /// </summary>
        /// <param name="constring">Строка соединения</param>
        public TicketDB(string constring)
            : base(constring) { }
        /// <summary>
        /// Получает список типов заданий в билетах
        /// </summary>
        /// <returns>Массив типов заданий в билетах</returns>
        public string[] GetTaskTypes()
        {
            DataTable dt = GetTable("select distinct [Тип Задания] from Задания ");
            List<string> types = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                types.Add(dt.Rows[i][0].ToString());
            }
            return types.ToArray();
        }
        /// <summary>
        /// Получает массив заданий из текущей базы данных
        /// </summary>
        /// <returns>Массив заданий, приведенных к типу Task</returns>
        public ClassLib.Task[] GetTaskBase()
        {
            DataTable dt = GetTable("select * from Задания");
            List<ClassLib.Task> list = new List<ClassLib.Task>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ClassLib.Task t;
                DataRow row = dt.Rows[i];
                int diff = (int)row["Сложность"];
                ClassLib.Task.TYPE type = ClassLib.Task.DefineType(row["Тип задания"].ToString());
                ClassLib.Theme th = new Theme(row["Тема"].ToString());
                t = new ClassLib.Task(diff, type, th);
                list.Add(t);
            }
            return list.ToArray();
        }
        /// <summary>
        /// Проверяет, существует ли генератор билетов
        /// в текущей базе данных
        /// </summary>
        /// <returns>
        /// True: генератор билетов в текущей базе данных создан
        /// False: все остальные случаи
        /// </returns>
        public bool TicketGeneratorExists()
        {
            return tg != null;
        }
        /// <summary>
        /// Создает генератор билетов в текущей базе данных
        /// </summary>
        /// <param name="amount">Необходимое количество заданий в билете</param>
        /// <param name="startInt">Начало интервала сложности заданий в билете</param>
        /// <param name="endInt">Конец интервала сложности заданий в билете</param>
        /// <param name="values">Массив пар элементов:
        /// (тип задания, количество заданий этого типа)</param>
        /// <param name="taskBase">Массив всех заданий</param>
        public void CreateTicketGen(int amount, double startInt, double endInt,
            (ClassLib.Task.TYPE, int)[] values, ClassLib.Task[] taskBase
            )
        {
            tg = new TicketGenerator(amount, startInt, endInt, values, taskBase);
            _TicketNum = 0;
        }
        /// <summary>
        /// Создает следующий билет
        /// </summary>
        /// <returns></returns>
        public Ticket GenerateNextTicket()
        {
            _TicketNum++;
            return tg.GenerateTicket();
        }
        /// <summary>
        /// Сбрасывает текущий генератор билетов
        /// </summary>
        public void ClearGen()
        {
            _TicketNum = 0;
            tg = null;
        }


    }

    /// <summary>
    /// Класс, предоставляющий текстовые данные для формы, 
    /// тексты ошибок, справочную информациюю, тексты запросов 
    /// </summary>
    public static class FormText
    {

        public const string ABOUT_APP = "Данное приложение разработано Ивановым Алексеем, " +
                "студентом второго курса группы Б.ПИН.РИС.2206, для работы " +
                "с базами данных MS SQL Server, и генерации билетов";
        public const string ARE_YOU_SURE_EXIT = "Вы действительно хотите выйти из программы?";
        public const string EXIT_FROM_APP = "Выход из программы";

        public const string ERR_NO_DATA = "Отсутствуют данные!";
        public const string ERR_NO_ROWS_SELECTED = "Необходимо выбрать одну полную строку или несколько!";
        public const string ERR_INCORRECT_TABLE_SELECT = "Существующая таблица не выбрана!";
        public const string ERR_UNABLE_TO_SAVE = "Сохранение в таком виде невозможно!";
        public const string ERR_INCORRECT_QUERY = "Неверно построен запрос!";
        public const string ARE_YOU_SURE_SAVE = "Вы действительно хотите сохранить изменения в таблице?";
        public const string SAVE_CHANGES = "Сохранение изменений";
        public const string ARE_YOU_SURE_DELETE = "Вы действительно хотите удалить текующую строку?";
        public const string TABLE_CHANGED = "Таблица была изменена, но изменения не были сохранены на сервер. Вы уверены, что хотите покинуть таблицу? Все несохраненные изменения будут утеряны.";

    }
}
