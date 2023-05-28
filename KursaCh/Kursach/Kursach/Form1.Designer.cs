namespace Kursach
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
            this.butCheb = new System.Windows.Forms.Button();
            this.butGauss = new System.Windows.Forms.Button();
            this.lbConter = new System.Windows.Forms.Label();
            this.tNcount = new System.Windows.Forms.TextBox();
            this.lbfuncShower = new System.Windows.Forms.Label();
            this.tAeq = new System.Windows.Forms.TextBox();
            this.tBeq = new System.Windows.Forms.TextBox();
            this.lbA = new System.Windows.Forms.Label();
            this.lbB = new System.Windows.Forms.Label();
            this.listCheb = new System.Windows.Forms.ListBox();
            this.listGauss = new System.Windows.Forms.ListBox();
            this.lbChebRes = new System.Windows.Forms.Label();
            this.lbGaussRes = new System.Windows.Forms.Label();
            this.bChebClear = new System.Windows.Forms.Button();
            this.bGauClear = new System.Windows.Forms.Button();
            this.bComparisonClear = new System.Windows.Forms.Button();
            this.lbComparison = new System.Windows.Forms.Label();
            this.listComparison = new System.Windows.Forms.ListBox();
            this.butComparison = new System.Windows.Forms.Button();
            this.bPlot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butCheb
            // 
            this.butCheb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCheb.Location = new System.Drawing.Point(11, 205);
            this.butCheb.Name = "butCheb";
            this.butCheb.Size = new System.Drawing.Size(261, 65);
            this.butCheb.TabIndex = 0;
            this.butCheb.Text = "Расчет Чебышева";
            this.butCheb.UseVisualStyleBackColor = true;
            this.butCheb.Click += new System.EventHandler(this.butCheb_Click);
            // 
            // butGauss
            // 
            this.butGauss.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butGauss.Location = new System.Drawing.Point(11, 276);
            this.butGauss.Name = "butGauss";
            this.butGauss.Size = new System.Drawing.Size(261, 65);
            this.butGauss.TabIndex = 1;
            this.butGauss.Text = "Расчет Гаусса";
            this.butGauss.UseVisualStyleBackColor = true;
            this.butGauss.Click += new System.EventHandler(this.butGauss_Click);
            // 
            // lbConter
            // 
            this.lbConter.AutoSize = true;
            this.lbConter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbConter.Location = new System.Drawing.Point(7, 143);
            this.lbConter.Name = "lbConter";
            this.lbConter.Size = new System.Drawing.Size(266, 24);
            this.lbConter.TabIndex = 2;
            this.lbConter.Text = "Колл-во узлов N ∈ Z[2;inf) ";
            // 
            // tNcount
            // 
            this.tNcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tNcount.Location = new System.Drawing.Point(11, 170);
            this.tNcount.Name = "tNcount";
            this.tNcount.Size = new System.Drawing.Size(261, 29);
            this.tNcount.TabIndex = 3;
            this.tNcount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNcount_KeyPress);
            this.tNcount.Leave += new System.EventHandler(this.tNcount_Leave);
            // 
            // lbfuncShower
            // 
            this.lbfuncShower.AutoSize = true;
            this.lbfuncShower.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbfuncShower.Location = new System.Drawing.Point(7, 9);
            this.lbfuncShower.Name = "lbfuncShower";
            this.lbfuncShower.Size = new System.Drawing.Size(121, 24);
            this.lbfuncShower.TabIndex = 4;
            this.lbfuncShower.Text = "funcShower";
            // 
            // tAeq
            // 
            this.tAeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tAeq.Location = new System.Drawing.Point(100, 50);
            this.tAeq.Name = "tAeq";
            this.tAeq.Size = new System.Drawing.Size(172, 29);
            this.tAeq.TabIndex = 5;
            this.tAeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tAeq_KeyPress);
            this.tAeq.Leave += new System.EventHandler(this.tAeq_Leave);
            // 
            // tBeq
            // 
            this.tBeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBeq.Location = new System.Drawing.Point(100, 99);
            this.tBeq.Name = "tBeq";
            this.tBeq.Size = new System.Drawing.Size(172, 29);
            this.tBeq.TabIndex = 6;
            this.tBeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tAeq_KeyPress);
            this.tBeq.Leave += new System.EventHandler(this.tAeq_Leave);
            // 
            // lbA
            // 
            this.lbA.AutoSize = true;
            this.lbA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbA.Location = new System.Drawing.Point(30, 50);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(45, 24);
            this.lbA.TabIndex = 7;
            this.lbA.Text = "a = ";
            // 
            // lbB
            // 
            this.lbB.AutoSize = true;
            this.lbB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbB.Location = new System.Drawing.Point(30, 104);
            this.lbB.Name = "lbB";
            this.lbB.Size = new System.Drawing.Size(46, 24);
            this.lbB.TabIndex = 8;
            this.lbB.Text = "b = ";
            // 
            // listCheb
            // 
            this.listCheb.FormattingEnabled = true;
            this.listCheb.Location = new System.Drawing.Point(287, 50);
            this.listCheb.Name = "listCheb";
            this.listCheb.Size = new System.Drawing.Size(188, 381);
            this.listCheb.TabIndex = 9;
            // 
            // listGauss
            // 
            this.listGauss.FormattingEnabled = true;
            this.listGauss.Location = new System.Drawing.Point(481, 50);
            this.listGauss.Name = "listGauss";
            this.listGauss.Size = new System.Drawing.Size(188, 381);
            this.listGauss.TabIndex = 10;
            // 
            // lbChebRes
            // 
            this.lbChebRes.AutoSize = true;
            this.lbChebRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbChebRes.Location = new System.Drawing.Point(283, 9);
            this.lbChebRes.Name = "lbChebRes";
            this.lbChebRes.Size = new System.Drawing.Size(180, 24);
            this.lbChebRes.TabIndex = 11;
            this.lbChebRes.Text = "Chebushev Result";
            // 
            // lbGaussRes
            // 
            this.lbGaussRes.AutoSize = true;
            this.lbGaussRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbGaussRes.Location = new System.Drawing.Point(477, 8);
            this.lbGaussRes.Name = "lbGaussRes";
            this.lbGaussRes.Size = new System.Drawing.Size(132, 24);
            this.lbGaussRes.TabIndex = 12;
            this.lbGaussRes.Text = "Gauss Result";
            // 
            // bChebClear
            // 
            this.bChebClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bChebClear.Location = new System.Drawing.Point(287, 443);
            this.bChebClear.Name = "bChebClear";
            this.bChebClear.Size = new System.Drawing.Size(188, 40);
            this.bChebClear.TabIndex = 13;
            this.bChebClear.Text = "Очистить";
            this.bChebClear.UseVisualStyleBackColor = true;
            this.bChebClear.Click += new System.EventHandler(this.bChebClear_Click);
            // 
            // bGauClear
            // 
            this.bGauClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bGauClear.Location = new System.Drawing.Point(481, 443);
            this.bGauClear.Name = "bGauClear";
            this.bGauClear.Size = new System.Drawing.Size(188, 40);
            this.bGauClear.TabIndex = 14;
            this.bGauClear.Text = "Очистить";
            this.bGauClear.UseVisualStyleBackColor = true;
            this.bGauClear.Click += new System.EventHandler(this.bGauClear_Click);
            // 
            // bComparisonClear
            // 
            this.bComparisonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bComparisonClear.Location = new System.Drawing.Point(675, 443);
            this.bComparisonClear.Name = "bComparisonClear";
            this.bComparisonClear.Size = new System.Drawing.Size(188, 40);
            this.bComparisonClear.TabIndex = 17;
            this.bComparisonClear.Text = "Очистить";
            this.bComparisonClear.UseVisualStyleBackColor = true;
            this.bComparisonClear.Click += new System.EventHandler(this.bComparisonClear_Click);
            // 
            // lbComparison
            // 
            this.lbComparison.AutoSize = true;
            this.lbComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbComparison.Location = new System.Drawing.Point(671, 8);
            this.lbComparison.Name = "lbComparison";
            this.lbComparison.Size = new System.Drawing.Size(122, 24);
            this.lbComparison.TabIndex = 16;
            this.lbComparison.Text = "Comparison";
            // 
            // listComparison
            // 
            this.listComparison.FormattingEnabled = true;
            this.listComparison.Location = new System.Drawing.Point(675, 50);
            this.listComparison.Name = "listComparison";
            this.listComparison.Size = new System.Drawing.Size(188, 381);
            this.listComparison.TabIndex = 15;
            // 
            // butComparison
            // 
            this.butComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butComparison.Location = new System.Drawing.Point(11, 347);
            this.butComparison.Name = "butComparison";
            this.butComparison.Size = new System.Drawing.Size(261, 65);
            this.butComparison.TabIndex = 18;
            this.butComparison.Text = "Сравнить результаты";
            this.butComparison.UseVisualStyleBackColor = true;
            this.butComparison.Click += new System.EventHandler(this.butComparison_Click);
            // 
            // bPlot
            // 
            this.bPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bPlot.Location = new System.Drawing.Point(11, 418);
            this.bPlot.Name = "bPlot";
            this.bPlot.Size = new System.Drawing.Size(261, 65);
            this.bPlot.TabIndex = 19;
            this.bPlot.Text = "Показать графики";
            this.bPlot.UseVisualStyleBackColor = true;
            this.bPlot.Click += new System.EventHandler(this.bPlot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 493);
            this.Controls.Add(this.bPlot);
            this.Controls.Add(this.butComparison);
            this.Controls.Add(this.bComparisonClear);
            this.Controls.Add(this.lbComparison);
            this.Controls.Add(this.listComparison);
            this.Controls.Add(this.bGauClear);
            this.Controls.Add(this.bChebClear);
            this.Controls.Add(this.lbGaussRes);
            this.Controls.Add(this.lbChebRes);
            this.Controls.Add(this.listGauss);
            this.Controls.Add(this.listCheb);
            this.Controls.Add(this.lbB);
            this.Controls.Add(this.lbA);
            this.Controls.Add(this.tBeq);
            this.Controls.Add(this.tAeq);
            this.Controls.Add(this.lbfuncShower);
            this.Controls.Add(this.tNcount);
            this.Controls.Add(this.lbConter);
            this.Controls.Add(this.butGauss);
            this.Controls.Add(this.butCheb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCheb;
        private System.Windows.Forms.Button butGauss;
        private System.Windows.Forms.Label lbConter;
        private System.Windows.Forms.TextBox tNcount;
        private System.Windows.Forms.Label lbfuncShower;
        private System.Windows.Forms.TextBox tAeq;
        private System.Windows.Forms.TextBox tBeq;
        private System.Windows.Forms.Label lbA;
        private System.Windows.Forms.Label lbB;
        private System.Windows.Forms.ListBox listCheb;
        private System.Windows.Forms.ListBox listGauss;
        private System.Windows.Forms.Label lbChebRes;
        private System.Windows.Forms.Label lbGaussRes;
        private System.Windows.Forms.Button bChebClear;
        private System.Windows.Forms.Button bGauClear;
        private System.Windows.Forms.Button bComparisonClear;
        private System.Windows.Forms.Label lbComparison;
        private System.Windows.Forms.ListBox listComparison;
        private System.Windows.Forms.Button butComparison;
        private System.Windows.Forms.Button bPlot;
    }
}

