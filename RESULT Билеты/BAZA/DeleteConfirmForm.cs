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
    /// <summary>
    /// Вспомогательная форма, отображающая удаляемые данные и подтверждающая их удаление
    /// </summary>
    public partial class DeleteConfirmForm : Form
    {
        private bool _confirm = false;
        /// <summary>
        /// Конструктор формы, в которой передается массив,
        /// содержащий данные гипотетически удаляемых строк,
        /// который будет отображен на форме
        /// </summary>
        /// <param name="inf">Массив гипотетический удаляемых строк</param>
        public DeleteConfirmForm(string[] inf)
        {
            
            InitializeComponent();
            foreach (string s in inf)
            {
                this.txBx_delInf.Text += (s + "\r\n");
            }
        }

        /// <summary>
        /// Обработчик кнопки, подтверждающей удаление выбранных строк пользователем
        /// </summary>
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            this._confirm = true;
            this.Close();
        }
        /// <summary>
        /// Обработчик кнопки отмены удаления
        /// </summary>

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close ();
        }
        /// <summary>
        /// Функция, определяющая, будет ли совершено удаление строк
        /// </summary>
        /// <returns>
        /// True: пользователь нажал на кнопку, отвечающую за подтверждение удаления
        /// False: во всех иных сценариях
        /// </returns>
        public bool GetChoice()
        {
            return _confirm;
        }
    }
}
