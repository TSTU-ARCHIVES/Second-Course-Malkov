namespace Visualisation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txBx_NOfVs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_DFS = new System.Windows.Forms.Button();
            this.btn_BFS = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(25, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(886, 463);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сгенерировать граф";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txBx_NOfVs
            // 
            this.txBx_NOfVs.Location = new System.Drawing.Point(255, 524);
            this.txBx_NOfVs.Name = "txBx_NOfVs";
            this.txBx_NOfVs.Size = new System.Drawing.Size(149, 27);
            this.txBx_NOfVs.TabIndex = 2;
            this.txBx_NOfVs.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 501);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество вершин";
            // 
            // btn_DFS
            // 
            this.btn_DFS.Location = new System.Drawing.Point(927, 75);
            this.btn_DFS.Name = "btn_DFS";
            this.btn_DFS.Size = new System.Drawing.Size(210, 57);
            this.btn_DFS.TabIndex = 4;
            this.btn_DFS.Text = "DFS";
            this.btn_DFS.UseVisualStyleBackColor = true;
            this.btn_DFS.Click += new System.EventHandler(this.btn_DFS_Click);
            // 
            // btn_BFS
            // 
            this.btn_BFS.Location = new System.Drawing.Point(927, 138);
            this.btn_BFS.Name = "btn_BFS";
            this.btn_BFS.Size = new System.Drawing.Size(210, 57);
            this.btn_BFS.TabIndex = 5;
            this.btn_BFS.Text = "BFS";
            this.btn_BFS.UseVisualStyleBackColor = true;
            this.btn_BFS.Click += new System.EventHandler(this.btn_BFS_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(951, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 38);
            this.label2.TabIndex = 6;
            this.label2.Text = "Операции";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(927, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 57);
            this.button2.TabIndex = 7;
            this.button2.Text = "Вывести все пути";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(927, 264);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 57);
            this.button3.TabIndex = 8;
            this.button3.Text = "Скобочная структура";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(927, 327);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(210, 57);
            this.button4.TabIndex = 9;
            this.button4.Text = "Время \"посещения вешин\"";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(927, 390);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(210, 57);
            this.button5.TabIndex = 10;
            this.button5.Text = "Отрисовать граф предшествования ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 563);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_BFS);
            this.Controls.Add(this.btn_DFS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txBx_NOfVs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private TextBox txBx_NOfVs;
        private Label label1;
        private Button btn_DFS;
        private Button btn_BFS;
        private Label label2;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}