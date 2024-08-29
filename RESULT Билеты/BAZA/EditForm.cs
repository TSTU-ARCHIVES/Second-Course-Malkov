using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAZA
{
    public partial class Form1 : Form
    {
        private bool changesMade = false;
        private bool isNewRow = false;
        private Label[] lblArr;
        private TextBox[] txtArr;
        private DataTable dt;
        private int curRow = 0;
        /// <summary>
        /// Конструктор формы, определяющий ее вид
        /// </summary>
        /// <param name="srcDT">Исходная таблица, по которой будет строиться форма</param>
        /// <param name="tableName">Имя таблицы, отображаемое в заголовке</param>
        public Form1(DataTable srcDT, string tableName)
        {
            InitializeComponent();

            this.Text = tableName;
            this.dt = srcDT;
            this.lbl_tableName.Text = tableName;
            int N = srcDT.Columns.Count;
            string[] names = new string[N];
            for (int f = 0; f < N; f++)
                names[f] = srcDT.Columns[f].ColumnName;

            lblArr = new Label[N];
            txtArr = new TextBox[N];
            int x = 20, y = 60;
            int i;
            for (i = 0; i < N; i++)
            {
                lblArr[i] = new Label();
                lblArr[i].Text = names[i];
                lblArr[i].Location = new Point(x, y + i * 50);
                lblArr[i].Font = new Font("Times New Roman", 12);
                lblArr[i].AutoSize = true;

                txtArr[i] = new TextBox();
                txtArr[i].Location = new Point(x + 200, y + i * 50);
                txtArr[i].Font = new Font("Times New Roman", 12);
                txtArr[i].ReadOnly = dt.Columns[i].ReadOnly;

                this.Controls.Add(txtArr[i]);
                this.Controls.Add(lblArr[i]);
                this.Height += 50;
            }
            btn_First.Location = new Point(12, 100 + 50 * i);
            btn_Prev.Location = new Point(142, 100 + 50 * i);
            btn_Next.Location = new Point(282, 100 + 50 * i);
            btn_Last.Location = new Point(422, 100 + 50 * i);
            btn_Add.Location = new Point(142, 150 + 50 * i);
            btn_Delete.Location = new Point(282, 150 + 50 * i);
            FillTextBoxes();

        }
        /// <summary>
        /// Обработчик кнопки, отвечающей за переключение записи на первую
        /// </summary>
        private void btn_First_Click(object sender, EventArgs e)
        {
            isNewRow = false;
            SaveRow();
            curRow = 0;
            FillTextBoxes();
        }

        /// <summary>
        /// Обработчик кнопки, отвечающей за переключение записи на предыдущую
        /// </summary>
        private void btn_Prev_Click(object sender, EventArgs e)
        {
            isNewRow = false;
            SaveRow();
            if (curRow != 0)
                curRow--;
            FillTextBoxes();
        }

        /// <summary>
        /// Обработчик кнопки, отвечающей за переключение записи на следующую
        /// </summary>
        private void btn_Next_Click(object sender, EventArgs e)
        {
            isNewRow = false;
            SaveRow();
            if (curRow != dt.Rows.Count-1)
                curRow++;
            FillTextBoxes();
        }

        /// <summary>
        /// Обработчик кнопки, отвечающей за переключение записи на последнюю
        /// </summary>
        private void btn_Last_Click(object sender, EventArgs e)
        {
            isNewRow = false;
            SaveRow();
            curRow = dt.Rows.Count - 1;
            FillTextBoxes();
        }

        /// <summary>
        /// Обработчик кнопки, отвечающей за добавление новой записи
        /// </summary>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            isNewRow = true;
            SaveRow();
            dt.Rows.Add();
            curRow = dt.Rows.Count - 1;
            FillTextBoxes();
            isNewRow = false;
        }

        /// <summary>
        /// Обработчик кнопки, отвечающей за удаление текущей записи
        /// </summary>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            isNewRow = false;
            SaveRow();
            DeleteRow();
            if (curRow != 0)
                curRow--;
            FillTextBoxes();
        }

        /// <summary>
        /// Обработчик кнопки, отвечающей за завершнеие работы формы
        /// </summary>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            SaveRow();
            this.Close();
        }

        //
        //Далее идут методы, необходимые для функционирования формы
        //

        /// <summary>
        /// Возвращает итоговую таблицу, включающую все изменения пользователем
        /// </summary>
        /// <returns>Таблица в формате DataTable</returns>
        public DataTable GetResDT()
        {
            return dt;
        }
        /// <summary>
        /// Функция, определяющая, использовалась ли форма для изменения данных
        /// </summary>
        /// <returns>
        /// True: пользователь изменял данные
        /// False: во всех иных сценариях
        /// </returns>
        public bool GetRes()
        {
            return changesMade;
        }
        /// <summary>
        /// Определяет, была ли изменена текущая строка
        /// </summary>
        /// <returns>
        /// True: пользователь изменял текущую строку
        /// False: во всех остальных случаях
        /// </returns>
        private bool IsChanged()
        {
            
            for (int i = 0; i < txtArr.Length; i++)
            {
                if (txtArr[i].Text != dt.Rows[curRow].ItemArray[i].ToString())
                {
                    changesMade = true;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Заполняет текстовые поля данными из таблицы
        /// текущей строки
        /// </summary>
        private void FillTextBoxes()
        {
            for (int i = 0; i < txtArr.Length; i++)
            {
                txtArr[i].Text = dt.Rows[curRow].ItemArray[i].ToString();
            }
        }
        /// <summary>
        /// Сохраняет изменения в текущей строке
        /// </summary>

        private void SaveRow()
        {
            if (isNewRow || (IsChanged() &&
                MessageBox.Show(FormText.ARE_YOU_SURE_SAVE, FormText.SAVE_CHANGES,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                    )
            {
                string[] cur = GetCurrentRow();
                for (int i = 0; i< dt.Rows[curRow].ItemArray.Length; i++)
                {
                    if (!dt.Columns[i].ReadOnly)
                        dt.Rows[curRow].SetField(i, cur[i]);
                }
            }
        }
        /// <summary>
        /// Удаляет текующую строку
        /// </summary>
        private void DeleteRow()
        {
            if (MessageBox.Show(FormText.ARE_YOU_SURE_DELETE, FormText.SAVE_CHANGES,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dt.Rows.RemoveAt(curRow);
                changesMade = true;
            }
        }
        /// <summary>
        /// Возвращает текущую строку
        /// </summary>
        /// <returns>Текущая строка в виде массива строк</returns>
        private string[] GetCurrentRow()
        {
            string[] txtbxInf = new string[txtArr.Length];
            for (int i = 0; i < txtArr.Length; i++)
            {
                txtbxInf[i] = (txtArr[i].Text);
            }
            return txtbxInf;
        }

    }
}
