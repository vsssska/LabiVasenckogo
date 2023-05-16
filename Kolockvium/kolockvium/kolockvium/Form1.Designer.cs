namespace kolockvium
{
    partial class Form1
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
            this.buttonReplace = new System.Windows.Forms.Button();
            this.buttonToFile = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxRow = new System.Windows.Forms.ComboBox();
            this.groupBoxRow = new System.Windows.Forms.GroupBox();
            this.textBoxRowIndex = new System.Windows.Forms.TextBox();
            this.groupBoxRange = new System.Windows.Forms.GroupBox();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.textBoxTargetNumb = new System.Windows.Forms.TextBox();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelIndex = new System.Windows.Forms.Label();
            this.labelTargetNumb = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxRow.SuspendLayout();
            this.groupBoxRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReplace
            // 
            this.buttonReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReplace.Location = new System.Drawing.Point(527, 12);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(211, 66);
            this.buttonReplace.TabIndex = 0;
            this.buttonReplace.Text = "Заменить";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // buttonToFile
            // 
            this.buttonToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToFile.Location = new System.Drawing.Point(527, 84);
            this.buttonToFile.Name = "buttonToFile";
            this.buttonToFile.Size = new System.Drawing.Size(211, 66);
            this.buttonToFile.TabIndex = 1;
            this.buttonToFile.Text = "В файл...";
            this.buttonToFile.UseVisualStyleBackColor = true;
            this.buttonToFile.Click += new System.EventHandler(this.buttonToFile_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(527, 156);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(211, 66);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxRow
            // 
            this.comboBoxRow.FormattingEnabled = true;
            this.comboBoxRow.Location = new System.Drawing.Point(6, 91);
            this.comboBoxRow.Name = "comboBoxRow";
            this.comboBoxRow.Size = new System.Drawing.Size(227, 28);
            this.comboBoxRow.TabIndex = 3;
            // 
            // groupBoxRow
            // 
            this.groupBoxRow.Controls.Add(this.labelIndex);
            this.groupBoxRow.Controls.Add(this.textBoxRowIndex);
            this.groupBoxRow.Controls.Add(this.comboBoxRow);
            this.groupBoxRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxRow.Location = new System.Drawing.Point(260, 12);
            this.groupBoxRow.Name = "groupBoxRow";
            this.groupBoxRow.Size = new System.Drawing.Size(261, 138);
            this.groupBoxRow.TabIndex = 4;
            this.groupBoxRow.TabStop = false;
            this.groupBoxRow.Text = "Ряд";
            // 
            // textBoxRowIndex
            // 
            this.textBoxRowIndex.Location = new System.Drawing.Point(6, 40);
            this.textBoxRowIndex.Name = "textBoxRowIndex";
            this.textBoxRowIndex.Size = new System.Drawing.Size(100, 26);
            this.textBoxRowIndex.TabIndex = 5;
            this.textBoxRowIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRowIndex_KeyPress);
            // 
            // groupBoxRange
            // 
            this.groupBoxRange.Controls.Add(this.labelMax);
            this.groupBoxRange.Controls.Add(this.labelMin);
            this.groupBoxRange.Controls.Add(this.textBoxMax);
            this.groupBoxRange.Controls.Add(this.textBoxMin);
            this.groupBoxRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxRange.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRange.Name = "groupBoxRange";
            this.groupBoxRange.Size = new System.Drawing.Size(242, 138);
            this.groupBoxRange.TabIndex = 5;
            this.groupBoxRange.TabStop = false;
            this.groupBoxRange.Text = "Диапозон значений";
            // 
            // textBoxMin
            // 
            this.textBoxMin.Location = new System.Drawing.Point(6, 40);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(100, 26);
            this.textBoxMin.TabIndex = 6;
            this.textBoxMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMin_KeyPress);
            this.textBoxMin.Leave += new System.EventHandler(this.textBoxMin_Leave);
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(6, 91);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(100, 26);
            this.textBoxMax.TabIndex = 7;
            this.textBoxMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMin_KeyPress);
            this.textBoxMax.Leave += new System.EventHandler(this.textBoxMax_Leave);
            // 
            // textBoxTargetNumb
            // 
            this.textBoxTargetNumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTargetNumb.Location = new System.Drawing.Point(18, 175);
            this.textBoxTargetNumb.Name = "textBoxTargetNumb";
            this.textBoxTargetNumb.Size = new System.Drawing.Size(100, 26);
            this.textBoxTargetNumb.TabIndex = 8;
            this.textBoxTargetNumb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMin_KeyPress);
            this.textBoxTargetNumb.Leave += new System.EventHandler(this.textBoxTargetNumb_Leave);
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(112, 43);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(78, 20);
            this.labelMin.TabIndex = 9;
            this.labelMin.Text = "Минимум";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(112, 97);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(85, 20);
            this.labelMax.TabIndex = 10;
            this.labelMax.Text = "Максимум";
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Location = new System.Drawing.Point(112, 43);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(24, 20);
            this.labelIndex.TabIndex = 11;
            this.labelIndex.Text = "№";
            // 
            // labelTargetNumb
            // 
            this.labelTargetNumb.AutoSize = true;
            this.labelTargetNumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTargetNumb.Location = new System.Drawing.Point(124, 178);
            this.labelTargetNumb.Name = "labelTargetNumb";
            this.labelTargetNumb.Size = new System.Drawing.Size(125, 20);
            this.labelTargetNumb.TabIndex = 11;
            this.labelTargetNumb.Text = "Целевое число";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 233);
            this.Controls.Add(this.labelTargetNumb);
            this.Controls.Add(this.textBoxTargetNumb);
            this.Controls.Add(this.groupBoxRange);
            this.Controls.Add(this.groupBoxRow);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonToFile);
            this.Controls.Add(this.buttonReplace);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxRow.ResumeLayout(false);
            this.groupBoxRow.PerformLayout();
            this.groupBoxRange.ResumeLayout(false);
            this.groupBoxRange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.Button buttonToFile;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxRow;
        private System.Windows.Forms.GroupBox groupBoxRow;
        private System.Windows.Forms.TextBox textBoxRowIndex;
        private System.Windows.Forms.Label labelIndex;
        private System.Windows.Forms.GroupBox groupBoxRange;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.TextBox textBoxTargetNumb;
        private System.Windows.Forms.Label labelTargetNumb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

