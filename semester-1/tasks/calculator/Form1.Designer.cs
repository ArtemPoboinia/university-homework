namespace calculator
{
    partial class Calculator
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tbOperator = new TextBox();
            btnEquals = new Button();
            tbOutput = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnClear = new Button();
            button10 = new Button();
            btnDecimal = new Button();
            btn9 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btn3 = new Button();
            btn2 = new Button();
            btn1 = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnDivide = new Button();
            btnMultiply = new Button();
            btnSubtract = new Button();
            btnAdd = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(tbOperator, 1, 0);
            tableLayoutPanel1.Controls.Add(btnEquals, 0, 2);
            tableLayoutPanel1.Controls.Add(tbOutput, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Size = new Size(282, 353);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tbOperator
            // 
            tbOperator.Dock = DockStyle.Fill;
            tbOperator.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbOperator.Location = new Point(228, 10);
            tbOperator.Margin = new Padding(3, 10, 3, 3);
            tbOperator.Name = "tbOperator";
            tbOperator.ReadOnly = true;
            tbOperator.Size = new Size(51, 42);
            tbOperator.TabIndex = 6;
            // 
            // btnEquals
            // 
            tableLayoutPanel1.SetColumnSpan(btnEquals, 2);
            btnEquals.Dock = DockStyle.Fill;
            btnEquals.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnEquals.Location = new Point(3, 302);
            btnEquals.Name = "btnEquals";
            btnEquals.Size = new Size(276, 48);
            btnEquals.TabIndex = 4;
            btnEquals.Text = "=";
            btnEquals.UseVisualStyleBackColor = true;
            btnEquals.Click += btnEquals_Click;
            // 
            // tbOutput
            // 
            tbOutput.Dock = DockStyle.Fill;
            tbOutput.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbOutput.Location = new Point(10, 10);
            tbOutput.Margin = new Padding(10, 10, 10, 3);
            tbOutput.Name = "tbOutput";
            tbOutput.ReadOnly = true;
            tbOutput.Size = new Size(205, 42);
            tbOutput.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.Controls.Add(btnClear, 2, 3);
            tableLayoutPanel2.Controls.Add(button10, 1, 3);
            tableLayoutPanel2.Controls.Add(btnDecimal, 0, 3);
            tableLayoutPanel2.Controls.Add(btn9, 2, 2);
            tableLayoutPanel2.Controls.Add(btn8, 1, 2);
            tableLayoutPanel2.Controls.Add(btn7, 0, 2);
            tableLayoutPanel2.Controls.Add(btn6, 2, 1);
            tableLayoutPanel2.Controls.Add(btn5, 1, 1);
            tableLayoutPanel2.Controls.Add(btn4, 0, 1);
            tableLayoutPanel2.Controls.Add(btn3, 2, 0);
            tableLayoutPanel2.Controls.Add(btn2, 1, 0);
            tableLayoutPanel2.Controls.Add(btn1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 62);
            tableLayoutPanel2.Margin = new Padding(3, 10, 10, 10);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(212, 227);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Fill;
            btnClear.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnClear.Location = new Point(143, 171);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(66, 53);
            btnClear.TabIndex = 11;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // button10
            // 
            button10.Dock = DockStyle.Fill;
            button10.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button10.Location = new Point(73, 171);
            button10.Name = "button10";
            button10.Size = new Size(64, 53);
            button10.TabIndex = 10;
            button10.Text = "0";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // btnDecimal
            // 
            btnDecimal.Dock = DockStyle.Fill;
            btnDecimal.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDecimal.Location = new Point(3, 171);
            btnDecimal.Name = "btnDecimal";
            btnDecimal.Size = new Size(64, 53);
            btnDecimal.TabIndex = 9;
            btnDecimal.Text = ",";
            btnDecimal.UseVisualStyleBackColor = true;
            btnDecimal.Click += btnDecimal_Click;
            // 
            // btn9
            // 
            btn9.Dock = DockStyle.Fill;
            btn9.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn9.Location = new Point(143, 115);
            btn9.Name = "btn9";
            btn9.Size = new Size(66, 50);
            btn9.TabIndex = 8;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // btn8
            // 
            btn8.Dock = DockStyle.Fill;
            btn8.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn8.Location = new Point(73, 115);
            btn8.Name = "btn8";
            btn8.Size = new Size(64, 50);
            btn8.TabIndex = 7;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btn7
            // 
            btn7.Dock = DockStyle.Fill;
            btn7.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn7.Location = new Point(3, 115);
            btn7.Name = "btn7";
            btn7.Size = new Size(64, 50);
            btn7.TabIndex = 6;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn6
            // 
            btn6.Dock = DockStyle.Fill;
            btn6.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn6.Location = new Point(143, 59);
            btn6.Name = "btn6";
            btn6.Size = new Size(66, 50);
            btn6.TabIndex = 5;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn5
            // 
            btn5.Dock = DockStyle.Fill;
            btn5.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn5.Location = new Point(73, 59);
            btn5.Name = "btn5";
            btn5.Size = new Size(64, 50);
            btn5.TabIndex = 4;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn4
            // 
            btn4.Dock = DockStyle.Fill;
            btn4.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn4.Location = new Point(3, 59);
            btn4.Name = "btn4";
            btn4.Size = new Size(64, 50);
            btn4.TabIndex = 3;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn3
            // 
            btn3.Dock = DockStyle.Fill;
            btn3.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn3.Location = new Point(143, 3);
            btn3.Name = "btn3";
            btn3.Size = new Size(66, 50);
            btn3.TabIndex = 2;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn2
            // 
            btn2.Dock = DockStyle.Fill;
            btn2.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn2.Location = new Point(73, 3);
            btn2.Name = "btn2";
            btn2.Size = new Size(64, 50);
            btn2.TabIndex = 1;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn1
            // 
            btn1.Dock = DockStyle.Fill;
            btn1.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn1.Location = new Point(3, 3);
            btn1.Name = "btn1";
            btn1.Size = new Size(64, 50);
            btn1.TabIndex = 0;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(btnDivide, 0, 3);
            tableLayoutPanel3.Controls.Add(btnMultiply, 0, 2);
            tableLayoutPanel3.Controls.Add(btnSubtract, 0, 1);
            tableLayoutPanel3.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(225, 62);
            tableLayoutPanel3.Margin = new Padding(0, 10, 0, 10);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Size = new Size(57, 227);
            tableLayoutPanel3.TabIndex = 5;
            // 
            // btnDivide
            // 
            btnDivide.Dock = DockStyle.Fill;
            btnDivide.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDivide.Location = new Point(3, 171);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(51, 53);
            btnDivide.TabIndex = 6;
            btnDivide.Text = "/";
            btnDivide.UseVisualStyleBackColor = true;
            btnDivide.Click += btnDivide_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Dock = DockStyle.Fill;
            btnMultiply.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnMultiply.Location = new Point(3, 115);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(51, 50);
            btnMultiply.TabIndex = 5;
            btnMultiply.Text = "*";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += btnMultiply_Click;
            // 
            // btnSubtract
            // 
            btnSubtract.Dock = DockStyle.Fill;
            btnSubtract.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSubtract.Location = new Point(3, 59);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new Size(51, 50);
            btnSubtract.TabIndex = 4;
            btnSubtract.Text = "-";
            btnSubtract.UseVisualStyleBackColor = true;
            btnSubtract.Click += btnSubtract_Click;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(51, 50);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 353);
            Controls.Add(tableLayoutPanel1);
            Name = "Calculator";
            Text = "Calculator";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tbOutput;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btn1;
        private Button btn2;
        private Button btnEquals;
        private Button btnClear;
        private Button button10;
        private Button btnDecimal;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private Button btn3;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnMultiply;
        private Button btnSubtract;
        private Button btnAdd;
        private Button btnDivide;
        private TextBox tbOperator;
    }
}
