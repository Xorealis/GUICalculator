namespace GUICalculator
{
    class Calculator
    {
        public static double compute(double val1, double val2, string operand)
        {
            double result = double.NaN;
            Console.WriteLine("Calculating...");
            switch (operand)
            {
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "/":
                    if (val2 == 0)
                    {
                        break;
                    }
                    result = val1 / val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                default:
                    break;

            }

            return result;
        }
    }
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void EqualsBtn_Clicked(object sender, EventArgs e)
        {
            string operand = "";
            string firstVal = "";
            string secondVal = "";
            string input = "";
            double output = double.NaN;
            int temp = 0;
            int charCount = 0;
                input = EquationEntry.Text;
                charCount = 0;
                firstVal = "";
                secondVal = "";
                operand = "";
                output = double.NaN;

                if (input == "q" || input == "Q")
                {
                    return;
                }
                while (charCount < input.Length)
                {
                    if (input[charCount] == ' ')
                    {
                        charCount++;
                        break;
                    }
                    else if (!(int.TryParse(input[charCount].ToString(), out temp)))
                    {
                        if (!(input[charCount] == '.'))
                        {
                            break;
                        }
                    }
                    firstVal += input[charCount];
                    charCount++;
                }

                operand += input[charCount];
                charCount++;
                if (input[charCount] == ' ')
                {
                    charCount++;
                }

                while (charCount < input.Length)
                {
                    secondVal += input[charCount];
                    charCount++;
                }
                try
                {
                    output = Calculator.compute(double.Parse(firstVal), double.Parse(secondVal), operand);
                }
                catch (Exception parseError)
                {
                    AnswerOut.Text = "An invalid value was entered";
                }
                AnswerOut.Text = ("Answer: " + output.ToString());
            }

        }
    }