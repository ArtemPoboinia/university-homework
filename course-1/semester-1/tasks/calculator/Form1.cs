namespace calculator
{
    public partial class Calculator : Form
    {
        // Задание переменных
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string currentOperator = "";
        private bool isNewCalculation = true;
        private bool hasDecimalPoint = false;

        public Calculator()
        {
            InitializeComponent();
            tbOutput.Text = "0";

            // Убрал фокус с текстового поля на clear
            this.Shown += (s, e) =>
            {
                btnClear.Focus();
            };
        }

        // Функция добавления цифры
        private void AddDigit(string digit)
        {
            if (isNewCalculation || tbOutput.Text == "0")
            {
                tbOutput.Text = digit;
                isNewCalculation = false;
            }
            else
            {
                tbOutput.Text += digit;
            }
        }

        // Функция установки оператора
        private void SetOperator(string op)
        {
            if (tbOutput.Text == "Error")
            {
                ClearAll();
                tbOutput.Text = "0";
                return;
            }

            if (!string.IsNullOrEmpty(tbOutput.Text))
            {
                firstNumber = double.Parse(tbOutput.Text);
                currentOperator = op;
                tbOperator.Text = $"{op}";
                tbOutput.Clear();
                hasDecimalPoint = false;
                isNewCalculation = false;
            }
            else if (!string.IsNullOrEmpty(tbOperator.Text))
            {
                currentOperator = op;
                tbOperator.Text = $"{op}";
            }
        }

        // Функция вычисления результата
        private void CalculateResult()
        {
            if (string.IsNullOrEmpty(currentOperator) ||
                string.IsNullOrEmpty(tbOutput.Text))
                return;

            secondNumber = double.Parse(tbOutput.Text);
            double result = 0;

            switch (currentOperator)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        tbOutput.Text = "Error";
                        tbOperator.Text = "";
                        currentOperator = "";
                        isNewCalculation = true;
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
            }

            tbOperator.Text = "";
            tbOutput.Text = result.ToString();

            currentOperator = "";
            firstNumber = result;
            isNewCalculation = false;
        }

        // Функция сброса
        private void ClearAll()
        {
            tbOutput.Text = "0";
            tbOperator.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            currentOperator = "";
            isNewCalculation = true;
            hasDecimalPoint = false;
        }

        // Функция добавления ,
        private void AddDecimalPoint()
        {
            if (!hasDecimalPoint)
            {
                if (string.IsNullOrEmpty(tbOutput.Text) || isNewCalculation)
                {
                    tbOutput.Text = "0,";
                }
                else
                {
                    tbOutput.Text += ",";
                }
                hasDecimalPoint = true;
                isNewCalculation = false;
            }
        }

        // Функции взаимодействий с кнопками
        private void btn1_Click(object sender, EventArgs e)
        {
            AddDigit("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AddDigit("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AddDigit("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AddDigit("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AddDigit("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AddDigit("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AddDigit("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AddDigit("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AddDigit("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddDigit("0");
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            AddDecimalPoint();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            CalculateResult();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOperator("+");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            SetOperator("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            SetOperator("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            SetOperator("/");
        }
    }
}
