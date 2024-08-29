namespace BAZA
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lbl_DBName = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_OpenEditForm = new System.Windows.Forms.Button();
            this.btn_PrintInExcel = new System.Windows.Forms.Button();
            this.btn_PrintInWord = new System.Windows.Forms.Button();
            this.btn_opnTable = new System.Windows.Forms.Button();
            this.cb_tables = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txBx_tickets = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txBx_amountOfTasks = new System.Windows.Forms.TextBox();
            this.txBx_DifInt_to = new System.Windows.Forms.TextBox();
            this.txBx_DifInt_from = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСтрокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьТекущейТаблицыВWordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьТекущейТаблицыВExcelToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.оПриложенииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.фИОИТипНомераКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мужчиныГостиницыТверьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фИОДатаПрибытияДатаОкончанияБрониToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сколькоКлиентовСАктивнойБроньюВГостиницахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьТекущегоЗапросаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьТекущегоЗапросаВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(14, 98);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(886, 527);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_RowsRemoved);
            // 
            // lbl_DBName
            // 
            this.lbl_DBName.AutoSize = true;
            this.lbl_DBName.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_DBName.Location = new System.Drawing.Point(6, 42);
            this.lbl_DBName.Name = "lbl_DBName";
            this.lbl_DBName.Size = new System.Drawing.Size(169, 45);
            this.lbl_DBName.TabIndex = 8;
            this.lbl_DBName.Text = "Задания";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Delete.Location = new System.Drawing.Point(911, 415);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(194, 78);
            this.btn_Delete.TabIndex = 10;
            this.btn_Delete.Text = "Удалить строки";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Save.Location = new System.Drawing.Point(911, 499);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(194, 126);
            this.btn_Save.TabIndex = 12;
            this.btn_Save.Text = "Сохранить изменения на сервер";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.button3_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1119, 679);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bindingNavigator1);
            this.tabPage1.Controls.Add(this.btn_OpenEditForm);
            this.tabPage1.Controls.Add(this.btn_PrintInExcel);
            this.tabPage1.Controls.Add(this.btn_PrintInWord);
            this.tabPage1.Controls.Add(this.lbl_DBName);
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Controls.Add(this.btn_Save);
            this.tabPage1.Controls.Add(this.btn_opnTable);
            this.tabPage1.Controls.Add(this.cb_tables);
            this.tabPage1.Controls.Add(this.btn_Delete);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1111, 644);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "База заданий";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 3);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1105, 27);
            this.bindingNavigator1.TabIndex = 16;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btn_OpenEditForm
            // 
            this.btn_OpenEditForm.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_OpenEditForm.Location = new System.Drawing.Point(911, 283);
            this.btn_OpenEditForm.Name = "btn_OpenEditForm";
            this.btn_OpenEditForm.Size = new System.Drawing.Size(194, 126);
            this.btn_OpenEditForm.TabIndex = 15;
            this.btn_OpenEditForm.Text = "Открыть форму для изменения данных";
            this.btn_OpenEditForm.UseVisualStyleBackColor = true;
            this.btn_OpenEditForm.Click += new System.EventHandler(this.btn_OpenEditForm_Click);
            // 
            // btn_PrintInExcel
            // 
            this.btn_PrintInExcel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_PrintInExcel.Location = new System.Drawing.Point(911, 98);
            this.btn_PrintInExcel.Name = "btn_PrintInExcel";
            this.btn_PrintInExcel.Size = new System.Drawing.Size(194, 84);
            this.btn_PrintInExcel.TabIndex = 14;
            this.btn_PrintInExcel.Text = "Напечатать отчет в Excel";
            this.btn_PrintInExcel.UseVisualStyleBackColor = true;
            this.btn_PrintInExcel.Click += new System.EventHandler(this.btn_PrintInExcel_Click);
            // 
            // btn_PrintInWord
            // 
            this.btn_PrintInWord.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_PrintInWord.Location = new System.Drawing.Point(911, 188);
            this.btn_PrintInWord.Name = "btn_PrintInWord";
            this.btn_PrintInWord.Size = new System.Drawing.Size(194, 89);
            this.btn_PrintInWord.TabIndex = 13;
            this.btn_PrintInWord.Text = "Напечатать отчет в Word";
            this.btn_PrintInWord.UseVisualStyleBackColor = true;
            this.btn_PrintInWord.Click += new System.EventHandler(this.button10_Click);
            // 
            // btn_opnTable
            // 
            this.btn_opnTable.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_opnTable.Location = new System.Drawing.Point(914, 48);
            this.btn_opnTable.Name = "btn_opnTable";
            this.btn_opnTable.Size = new System.Drawing.Size(194, 45);
            this.btn_opnTable.TabIndex = 4;
            this.btn_opnTable.Text = "Открыть таблицу";
            this.btn_opnTable.UseVisualStyleBackColor = true;
            this.btn_opnTable.Click += new System.EventHandler(this.btn_opnTable_Click);
            // 
            // cb_tables
            // 
            this.cb_tables.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_tables.FormattingEnabled = true;
            this.cb_tables.Location = new System.Drawing.Point(555, 48);
            this.cb_tables.Name = "cb_tables";
            this.cb_tables.Size = new System.Drawing.Size(336, 39);
            this.cb_tables.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(316, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 33);
            this.label2.TabIndex = 9;
            this.label2.Text = "Выберите таблицу";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txBx_tickets);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1111, 644);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Генерация билетов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txBx_tickets
            // 
            this.txBx_tickets.Location = new System.Drawing.Point(388, 22);
            this.txBx_tickets.Multiline = true;
            this.txBx_tickets.Name = "txBx_tickets";
            this.txBx_tickets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txBx_tickets.Size = new System.Drawing.Size(717, 616);
            this.txBx_tickets.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 506);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(371, 63);
            this.button2.TabIndex = 2;
            this.button2.Text = "Сбросить генератор";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 575);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(371, 63);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сгенерировать билет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txBx_amountOfTasks);
            this.groupBox1.Controls.Add(this.txBx_DifInt_to);
            this.groupBox1.Controls.Add(this.txBx_DifInt_from);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 494);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры билета";
            // 
            // txBx_amountOfTasks
            // 
            this.txBx_amountOfTasks.Location = new System.Drawing.Point(12, 174);
            this.txBx_amountOfTasks.Name = "txBx_amountOfTasks";
            this.txBx_amountOfTasks.Size = new System.Drawing.Size(82, 39);
            this.txBx_amountOfTasks.TabIndex = 7;
            // 
            // txBx_DifInt_to
            // 
            this.txBx_DifInt_to.Location = new System.Drawing.Point(179, 84);
            this.txBx_DifInt_to.Name = "txBx_DifInt_to";
            this.txBx_DifInt_to.Size = new System.Drawing.Size(82, 39);
            this.txBx_DifInt_to.TabIndex = 6;
            // 
            // txBx_DifInt_from
            // 
            this.txBx_DifInt_from.Location = new System.Drawing.Point(53, 84);
            this.txBx_DifInt_from.Name = "txBx_DifInt_from";
            this.txBx_DifInt_from.Size = new System.Drawing.Size(82, 39);
            this.txBx_DifInt_from.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 33);
            this.label6.TabIndex = 4;
            this.label6.Text = "Тип и количество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 33);
            this.label5.TabIndex = 3;
            this.label5.Text = "до";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 33);
            this.label4.TabIndex = 2;
            this.label4.Text = "от";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 33);
            this.label3.TabIndex = 1;
            this.label3.Text = "Интервал сложности";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество заданий";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицыToolStripMenuItem,
            this.оПриложенииToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 30);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьДанныеToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.удалитьСтрокиToolStripMenuItem,
            this.печатьТекущейТаблицыВWordToolStripMenuItem1,
            this.печатьТекущейТаблицыВExcelToolStripMenuItem2});
            this.таблицыToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(100, 26);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // добавитьДанныеToolStripMenuItem
            // 
            this.добавитьДанныеToolStripMenuItem.Name = "добавитьДанныеToolStripMenuItem";
            this.добавитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.добавитьДанныеToolStripMenuItem.Text = "Открыть формы";
            this.добавитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.добавитьДанныеToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить ";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // удалитьСтрокиToolStripMenuItem
            // 
            this.удалитьСтрокиToolStripMenuItem.Name = "удалитьСтрокиToolStripMenuItem";
            this.удалитьСтрокиToolStripMenuItem.Size = new System.Drawing.Size(371, 26);
            this.удалитьСтрокиToolStripMenuItem.Text = "Удалить строки";
            this.удалитьСтрокиToolStripMenuItem.Click += new System.EventHandler(this.удалитьСтрокиToolStripMenuItem_Click);
            // 
            // печатьТекущейТаблицыВWordToolStripMenuItem1
            // 
            this.печатьТекущейТаблицыВWordToolStripMenuItem1.Name = "печатьТекущейТаблицыВWordToolStripMenuItem1";
            this.печатьТекущейТаблицыВWordToolStripMenuItem1.Size = new System.Drawing.Size(371, 26);
            this.печатьТекущейТаблицыВWordToolStripMenuItem1.Text = "Печать текущей таблицы в Word";
            this.печатьТекущейТаблицыВWordToolStripMenuItem1.Click += new System.EventHandler(this.печатьТекущейТаблицыВWordToolStripMenuItem1_Click);
            // 
            // печатьТекущейТаблицыВExcelToolStripMenuItem2
            // 
            this.печатьТекущейТаблицыВExcelToolStripMenuItem2.Name = "печатьТекущейТаблицыВExcelToolStripMenuItem2";
            this.печатьТекущейТаблицыВExcelToolStripMenuItem2.Size = new System.Drawing.Size(371, 26);
            this.печатьТекущейТаблицыВExcelToolStripMenuItem2.Text = "Печать текущей таблицы в Excel";
            this.печатьТекущейТаблицыВExcelToolStripMenuItem2.Click += new System.EventHandler(this.печатьТекущейТаблицыВExcelToolStripMenuItem2_Click);
            // 
            // оПриложенииToolStripMenuItem
            // 
            this.оПриложенииToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.оПриложенииToolStripMenuItem.Name = "оПриложенииToolStripMenuItem";
            this.оПриложенииToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.оПриложенииToolStripMenuItem.Text = "О приложении";
            this.оПриложенииToolStripMenuItem.Click += new System.EventHandler(this.оПриложенииToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.закрытьToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(94, 26);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // фИОИТипНомераКлиентовToolStripMenuItem
            // 
            this.фИОИТипНомераКлиентовToolStripMenuItem.Name = "фИОИТипНомераКлиентовToolStripMenuItem";
            this.фИОИТипНомераКлиентовToolStripMenuItem.Size = new System.Drawing.Size(484, 26);
            this.фИОИТипНомераКлиентовToolStripMenuItem.Text = "Товар: полный маршрут";
            // 
            // мужчиныГостиницыТверьToolStripMenuItem
            // 
            this.мужчиныГостиницыТверьToolStripMenuItem.Name = "мужчиныГостиницыТверьToolStripMenuItem";
            this.мужчиныГостиницыТверьToolStripMenuItem.Size = new System.Drawing.Size(484, 26);
            this.мужчиныГостиницыТверьToolStripMenuItem.Text = "Цена проданых товаров";
            // 
            // фИОДатаПрибытияДатаОкончанияБрониToolStripMenuItem
            // 
            this.фИОДатаПрибытияДатаОкончанияБрониToolStripMenuItem.Name = "фИОДатаПрибытияДатаОкончанияБрониToolStripMenuItem";
            this.фИОДатаПрибытияДатаОкончанияБрониToolStripMenuItem.Size = new System.Drawing.Size(484, 26);
            this.фИОДатаПрибытияДатаОкончанияБрониToolStripMenuItem.Text = "Сумма цен товаров, отправленных из городов";
            // 
            // сколькоКлиентовСАктивнойБроньюВГостиницахToolStripMenuItem
            // 
            this.сколькоКлиентовСАктивнойБроньюВГостиницахToolStripMenuItem.Name = "сколькоКлиентовСАктивнойБроньюВГостиницахToolStripMenuItem";
            this.сколькоКлиентовСАктивнойБроньюВГостиницахToolStripMenuItem.Size = new System.Drawing.Size(484, 26);
            this.сколькоКлиентовСАктивнойБроньюВГостиницахToolStripMenuItem.Text = "Количество товаров в пути";
            // 
            // печатьТекущегоЗапросаToolStripMenuItem
            // 
            this.печатьТекущегоЗапросаToolStripMenuItem.Name = "печатьТекущегоЗапросаToolStripMenuItem";
            this.печатьТекущегоЗапросаToolStripMenuItem.Size = new System.Drawing.Size(484, 26);
            this.печатьТекущегоЗапросаToolStripMenuItem.Text = "Печать текущего запроса в Word";
            // 
            // печатьТекущегоЗапросаВExcelToolStripMenuItem
            // 
            this.печатьТекущегоЗапросаВExcelToolStripMenuItem.Name = "печатьТекущегоЗапросаВExcelToolStripMenuItem";
            this.печатьТекущегоЗапросаВExcelToolStripMenuItem.Size = new System.Drawing.Size(484, 26);
            this.печатьТекущегоЗапросаВExcelToolStripMenuItem.Text = "Печать текущего запроса в Excel";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1136, 725);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Работа с БД SQL Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lbl_DBName;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПриложенииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСтрокиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.Button btn_PrintInWord;
        private System.Windows.Forms.Button btn_PrintInExcel;
        private System.Windows.Forms.ToolStripMenuItem печатьТекущейТаблицыВWordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem печатьТекущейТаблицыВExcelToolStripMenuItem2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Button btn_OpenEditForm;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Button btn_opnTable;
        private System.Windows.Forms.ComboBox cb_tables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem фИОИТипНомераКлиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мужчиныГостиницыТверьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фИОДатаПрибытияДатаОкончанияБрониToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сколькоКлиентовСАктивнойБроньюВГостиницахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьТекущегоЗапросаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьТекущегоЗапросаВExcelToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txBx_amountOfTasks;
        private System.Windows.Forms.TextBox txBx_DifInt_to;
        private System.Windows.Forms.TextBox txBx_DifInt_from;
        private System.Windows.Forms.TextBox txBx_tickets;
    }
}

