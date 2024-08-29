using ClassLib;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BAZA
{
    /// <summary>
    /// Основная форма, позволяющая взаимодействовать с данными БД и запросами
    /// </summary>
    public partial class MainForm : Form
    {
        private TicketDB DB;
        private bool ChangesMade = false;

        Label[] typesNames;
        System.Windows.Forms.TextBox[] typesCBs;
        public MainForm(string constr)
        {
            InitializeComponent();
            DB = new TicketDB(constr);
            DPIFix.DpiFix();
        }
        /// <summary>
        /// Обработчик события нажатия таблицы в меню во вкладке "открыть"
        /// </summary>
        private void tableHandler(object sender, EventArgs e)
        {

            bindingSource1.DataSource = DB.GetTable("SELECT * FROM " +
                    (cb_tables.Text = sender.ToString()));
            dataGridView.DataSource = bindingSource1;
            tabControl1.SelectedIndex = 0;
        }
        /// <summary>
        /// Обработчик события нажатия таблицы в меню во вкладке "открыть форму"
        /// </summary>
        private void formHandler(object sender, EventArgs e)
        {
            cb_tables.SelectedItem = sender.ToString();
            btn_opnTable_Click(null, null);
            btn_OpenEditForm_Click(null, null);
        }
        private void FillTableList()
        {
            foreach (string tblName in DB.GetTables())
            {
                cb_tables.Items.Add(tblName);
                открытьToolStripMenuItem.DropDownItems.Add(tblName, null, new EventHandler(tableHandler));
                добавитьДанныеToolStripMenuItem.DropDownItems.Add(tblName, null, new EventHandler(formHandler));
            }
        }

        private void FillTicketGeneratorFields()
        {
            string[] types = DB.GetTaskTypes();
            typesNames = new Label[types.Length];
            typesCBs = new System.Windows.Forms.TextBox[types.Length];
            for (int i = 0; i < types.Length; i++)
            {
                typesNames[i] = new Label();
                typesNames[i].Text = types[i].ToString();
                typesNames[i].Location = new Point(12, 262 + i * 50);
                typesNames[i].Font = new Font("Times New Roman", 12);

                typesCBs[i] = new System.Windows.Forms.TextBox();
                typesCBs[i].Location = new Point(173, 262 + i * 50);
                typesCBs[i].Font = new Font("Times New Roman", 12);

                groupBox1.Controls.Add(typesNames[i]);
                groupBox1.Controls.Add(typesCBs[i]);
            }
        }
        /// <summary>
        /// Обработчик загрузки формы, заполняющий список таблиц и форм в comboBox
        /// </summary>
        /// 

        public (ClassLib.Task.TYPE, int)[] DefineValues()
        {
            List<(ClassLib.Task.TYPE, int)> values = new List<(ClassLib.Task.TYPE, int)>();
            for (int i = 0; i <typesNames.Length; i++)
            {
                values.Add(
                    (ClassLib.Task.DefineType(typesNames[i].Text), int.Parse(typesCBs[i].Text))
                    );
            }
            return values.ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillTableList();
            FillTicketGeneratorFields();
        }
        /// <summary>
        /// Обработчик кнопки, отвечающей за открытие выбранной 
        /// в comboBox таблице
        /// </summary>

        private void btn_opnTable_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (ChangesMade)
            {
                if (MessageBox.Show(FormText.TABLE_CHANGED, FormText.SAVE_CHANGES,
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            try
            {
                Object selectedItem = cb_tables.SelectedItem;
                DataTable dt = DB.GetTable("SELECT * FROM " + selectedItem.ToString());
                bindingSource1.DataSource = dt;
                dataGridView.DataSource = bindingSource1;
            } catch
            {
                MessageBox.Show(FormText.ERR_INCORRECT_TABLE_SELECT);
                return;
            }
                ChangesMade = false;
        }
        /// <summary>
        /// Обработчик кнопки, отвечающий за удаление строк
        /// </summary>>
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                if (row.IsNewRow)
                    break;
                string tempRec = "";
                foreach (DataGridViewCell c in row.Cells)
                {
                   tempRec += (c.OwningColumn.Name.ToString() + " : " + c.Value.ToString() + "\r\n");
                }
                temp.Add(tempRec);
            }
            if (temp.Count == 0)
            {
                MessageBox.Show(FormText.ERR_NO_ROWS_SELECTED);
                return;
            }
            DeleteConfirmForm F = new DeleteConfirmForm(temp.ToArray());
            F.ShowDialog();
            if (F.GetChoice())
            {
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    dataGridView.Rows.Remove(row);
                    dataGridView.Refresh();
                }
                ChangesMade = true;
            }
        }
        /// <summary>
        /// Обработчик кнопки сохранения данных в таблице
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(FormText.ARE_YOU_SURE_SAVE, FormText.SAVE_CHANGES, 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Object selectedItem = cb_tables.SelectedItem;
                    DB.SaveTable(selectedItem.ToString(), dataGridView);
                    ChangesMade = false;
                }
            } catch (Exception )
            {
                MessageBox.Show(FormText.ERR_UNABLE_TO_SAVE);
                return;
            } finally
            {
                dataGridView.Refresh();
            }
        }
        /// <summary>
        /// Обработчик кнопки, открывающей форму для редактирования данных
        /// </summary>
        private void btn_OpenEditForm_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                Object selectedItem = cb_tables.SelectedItem;
                Form1 F = new Form1((DataTable)bindingSource1.DataSource, selectedItem.ToString());
                F.ShowDialog();
                DataTable dt = F.GetResDT();
                bindingSource1.DataSource = dt;
                dataGridView.DataSource = bindingSource1;
                ChangesMade = false || F.GetRes();
            }
            catch
            {
                errorProvider1.SetError(cb_tables, FormText.ERR_INCORRECT_TABLE_SELECT);
                return;
            }
        }
        /// <summary>
        /// Обработчик кнопки выхода из приложения
        /// </summary>
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        /// <summary>
        /// Обработчик кнопки, отвечающий за закрытие приложения в меню
        /// </summary>
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show(FormText.ARE_YOU_SURE_EXIT, FormText.EXIT_FROM_APP,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        /// <summary>
        /// Обработчик кнопки "О приложении" в меню
        /// </summary>
        private void оПриложенииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FormText.ABOUT_APP);
        }
        
        private void добавитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            btn_OpenEditForm_Click(null, null);
        }
        /// <summary>
        /// Обработчик кнопки открытия таблицы в меню
        /// </summary>

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            btn_opnTable_Click(null, null);
        }
        /// <summary>
        /// Обработчик кнопки сохранения в меню
        /// </summary>

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            button3_Click(null, null);
        }
        /// <summary>
        /// Обработчик кнопки удаления в меню
        /// </summary>

        private void удалитьСтрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            button1_Click(null, null);
        }
        /// <summary>
        /// Обработчик кноки, выполняющей запрос на выборку ФИО, тип номера клиентов в меню
        /// </summary>

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show(FormText.ERR_NO_DATA);
                return;
            }
            DB.SaveInWord(dataGridView);
        }
        /// <summary>
        /// Обработчик кнопки, отвечающей за сохранение таблицы в Excel
        /// </summary>
        private void btn_PrintInExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show(FormText.ERR_NO_DATA);
                return;
            }
            DB.SaveInExcel(dataGridView);
        }


        /// <summary>
        /// Обработчик кнопки печати текущей таблицы в word в меню
        /// </summary>
        private void печатьТекущейТаблицыВWordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button10_Click(null, null);
        }
        /// <summary>
        /// Обработчик кнопки печати текущей таблицы в excel в меню
        /// </summary>
        private void печатьТекущейТаблицыВExcelToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            btn_PrintInExcel_Click(null, null);
        }
        /// <summary>
        /// Обрабочик закрытия формы
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Обработчик ошибки сохранения данных в DataGridView
        /// </summary>
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(FormText.ERR_UNABLE_TO_SAVE);
        }
        /// <summary>
        /// Обработчик изменения данных в ячейке DataGridView
        /// </summary>

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ChangesMade = true;
        }
        /// <summary>
        /// Обработчик добавления строки в DataGridView
        /// </summary>
        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ChangesMade = true;
        }
        /// <summary>
        /// Обработчик удаления строки в DataGridView
        /// </summary>
        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ChangesMade = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                int startInt = int.Parse(txBx_DifInt_from.Text);
                int end = int.Parse(txBx_DifInt_to.Text);
                int amount = int.Parse(txBx_amountOfTasks.Text);
                (ClassLib.Task.TYPE, int)[] values = DefineValues();
                ClassLib.Task[] TaskDB = DB.GetTaskBase();

                if (!DB.TicketGeneratorExists())
                {
                    DB.CreateTicketGen(amount, startInt, end, values, TaskDB);
                }
                Ticket ticket = DB.GenerateNextTicket();
                txBx_tickets.Text += TicketDB.TicketNum + " вариант.\r\n" + ticket.ToString() + "\r\n\r\n";
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(button1, ex.Message + ". Reboot generator");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txBx_tickets.Text = "";
            DB.ClearGen();
        }
    }
}
