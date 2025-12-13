namespace calculator
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
            tableLayoutPanel1 = new TableLayoutPanel();
            textBoxSymbol = new TextBox();
            btnResult = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnDivide = new Button();
            btnMultiply = new Button();
            btnSubtruct = new Button();
            btnAdd = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnClear = new Button();
            btn0 = new Button();
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
            textBoxResult = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(textBoxSymbol, 1, 0);
            tableLayoutPanel1.Controls.Add(btnResult, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(textBoxResult, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(382, 453);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxSymbol
            // 
            textBoxSymbol.Dock = DockStyle.Fill;
            textBoxSymbol.Font = new Font("Arial", 20F);
            textBoxSymbol.Location = new Point(291, 20);
            textBoxSymbol.Margin = new Padding(10);
            textBoxSymbol.Name = "textBoxSymbol";
            textBoxSymbol.Size = new Size(71, 46);
            textBoxSymbol.TabIndex = 9;
            // 
            // btnResult
            // 
            tableLayoutPanel1.SetColumnSpan(btnResult, 2);
            btnResult.Dock = DockStyle.Fill;
            btnResult.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnResult.Location = new Point(15, 382);
            btnResult.Margin = new Padding(5);
            btnResult.Name = "btnResult";
            btnResult.Size = new Size(352, 56);
            btnResult.TabIndex = 7;
            btnResult.Text = "=";
            btnResult.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.Controls.Add(btnDivide, 0, 3);
            tableLayoutPanel5.Controls.Add(btnMultiply, 0, 2);
            tableLayoutPanel5.Controls.Add(btnSubtruct, 0, 1);
            tableLayoutPanel5.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(291, 84);
            tableLayoutPanel5.Margin = new Padding(10);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.Size = new Size(71, 283);
            tableLayoutPanel5.TabIndex = 3;
            // 
            // btnDivide
            // 
            btnDivide.Dock = DockStyle.Fill;
            btnDivide.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDivide.Location = new Point(5, 215);
            btnDivide.Margin = new Padding(5);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(61, 63);
            btnDivide.TabIndex = 4;
            btnDivide.Text = "/";
            btnDivide.UseVisualStyleBackColor = true;
            // 
            // btnMultiply
            // 
            btnMultiply.Dock = DockStyle.Fill;
            btnMultiply.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnMultiply.Location = new Point(5, 145);
            btnMultiply.Margin = new Padding(5);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(61, 60);
            btnMultiply.TabIndex = 3;
            btnMultiply.Text = "*";
            btnMultiply.UseVisualStyleBackColor = true;
            // 
            // btnSubtruct
            // 
            btnSubtruct.Dock = DockStyle.Fill;
            btnSubtruct.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSubtruct.Location = new Point(5, 75);
            btnSubtruct.Margin = new Padding(5);
            btnSubtruct.Name = "btnSubtruct";
            btnSubtruct.Size = new Size(61, 60);
            btnSubtruct.TabIndex = 2;
            btnSubtruct.Text = "-";
            btnSubtruct.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAdd.Location = new Point(5, 5);
            btnAdd.Margin = new Padding(5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(61, 60);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.Controls.Add(btnClear, 2, 3);
            tableLayoutPanel2.Controls.Add(btn0, 1, 3);
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
            tableLayoutPanel2.Location = new Point(20, 84);
            tableLayoutPanel2.Margin = new Padding(10);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(251, 283);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Fill;
            btnClear.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnClear.Location = new Point(171, 215);
            btnClear.Margin = new Padding(5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 63);
            btnClear.TabIndex = 11;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btn0
            // 
            btn0.Dock = DockStyle.Fill;
            btn0.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn0.Location = new Point(88, 215);
            btn0.Margin = new Padding(5);
            btn0.Name = "btn0";
            btn0.Size = new Size(73, 63);
            btn0.TabIndex = 10;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            // 
            // btnDecimal
            // 
            btnDecimal.Dock = DockStyle.Fill;
            btnDecimal.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDecimal.Location = new Point(5, 215);
            btnDecimal.Margin = new Padding(5);
            btnDecimal.Name = "btnDecimal";
            btnDecimal.Size = new Size(73, 63);
            btnDecimal.TabIndex = 9;
            btnDecimal.Text = ",";
            btnDecimal.UseVisualStyleBackColor = true;
            // 
            // btn9
            // 
            btn9.Dock = DockStyle.Fill;
            btn9.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn9.Location = new Point(171, 145);
            btn9.Margin = new Padding(5);
            btn9.Name = "btn9";
            btn9.Size = new Size(75, 60);
            btn9.TabIndex = 8;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            // 
            // btn8
            // 
            btn8.Dock = DockStyle.Fill;
            btn8.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn8.Location = new Point(88, 145);
            btn8.Margin = new Padding(5);
            btn8.Name = "btn8";
            btn8.Size = new Size(73, 60);
            btn8.TabIndex = 7;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            // 
            // btn7
            // 
            btn7.Dock = DockStyle.Fill;
            btn7.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn7.Location = new Point(5, 145);
            btn7.Margin = new Padding(5);
            btn7.Name = "btn7";
            btn7.Size = new Size(73, 60);
            btn7.TabIndex = 6;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            // 
            // btn6
            // 
            btn6.Dock = DockStyle.Fill;
            btn6.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn6.Location = new Point(171, 75);
            btn6.Margin = new Padding(5);
            btn6.Name = "btn6";
            btn6.Size = new Size(75, 60);
            btn6.TabIndex = 5;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            // 
            // btn5
            // 
            btn5.Dock = DockStyle.Fill;
            btn5.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn5.Location = new Point(88, 75);
            btn5.Margin = new Padding(5);
            btn5.Name = "btn5";
            btn5.Size = new Size(73, 60);
            btn5.TabIndex = 4;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            btn4.Dock = DockStyle.Fill;
            btn4.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn4.Location = new Point(5, 75);
            btn4.Margin = new Padding(5);
            btn4.Name = "btn4";
            btn4.Size = new Size(73, 60);
            btn4.TabIndex = 3;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            // 
            // btn3
            // 
            btn3.Dock = DockStyle.Fill;
            btn3.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn3.Location = new Point(171, 5);
            btn3.Margin = new Padding(5);
            btn3.Name = "btn3";
            btn3.Size = new Size(75, 60);
            btn3.TabIndex = 2;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.Dock = DockStyle.Fill;
            btn2.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn2.Location = new Point(88, 5);
            btn2.Margin = new Padding(5);
            btn2.Name = "btn2";
            btn2.Size = new Size(73, 60);
            btn2.TabIndex = 1;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            btn1.Dock = DockStyle.Fill;
            btn1.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn1.Location = new Point(5, 5);
            btn1.Margin = new Padding(5);
            btn1.Name = "btn1";
            btn1.Size = new Size(73, 60);
            btn1.TabIndex = 0;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            // 
            // textBoxResult
            // 
            textBoxResult.Dock = DockStyle.Fill;
            textBoxResult.Font = new Font("Arial", 20F);
            textBoxResult.Location = new Point(20, 20);
            textBoxResult.Margin = new Padding(10);
            textBoxResult.Name = "textBoxResult";
            textBoxResult.Size = new Size(251, 46);
            textBoxResult.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 453);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel5;
        private Button btn1;
        private Button btnAdd;
        private Button btn3;
        private Button btn2;
        private Button btnResult;
        private Button btnDivide;
        private Button btnMultiply;
        private Button btnSubtruct;
        private Button btnClear;
        private Button btn0;
        private Button btnDecimal;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private TextBox textBoxResult;
        private TextBox textBoxSymbol;
    }
}
