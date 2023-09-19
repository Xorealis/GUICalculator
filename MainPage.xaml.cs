namespace GUICalculator
{
    class Calculator
    {
        public static double compute(double val1, double val2, string operand)
        {
            double result = double.NaN; //Initializes result as Not a Number
            switch (operand) //Switches to perform the desired operation based on operand
            {
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "/":
                    if (val2 == 0) //Checks for divide by 0, exits and method returns NaN
                    {
                        break;
                    }
                    result = val1 / val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                default: //If invalid operand, exits method and returns NaN
                    break;

            }

            return result;
        }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void EqualsBtn_Clicked(object sender, EventArgs e)
        {
            string operand = ""; //Stores user input operand
            string firstVal = ""; //Stores user input first Value
            string secondVal = ""; //Stores user input second Value
            string input = ""; //Stores final determined equation
            double output = double.NaN; //Output answer initialized as NaN
            int temp = 0; //Dummy variable for TryParse output
            int charCount = 0;
            String finalOut = "";

            input = EquationEntry.Text;
            //Iterates through loop until end of number detected by either operand or space
            if(input == "What's my name?")
            {
                finalOut = "Chase";
                goto endFunction;
            }
            while (charCount < input.Length)
                {
                    if (input[charCount] == ' ') //If space encountered, end of first value
                    {
                        charCount++;
                        break;
                    }
                    //Tries to convert current place to digit, if it fails, checks if it's a decimal or negative sign
                    else if (!(int.TryParse(input[charCount].ToString(), out temp)))
                    {
                        if (!((input[charCount] == '.') || (input[charCount] == '-')))
                        {
                            break;
                        }
                    }
                    firstVal += input[charCount];
                    charCount++;
                }
            //Try catch block designed to catch if the user didn't enter anything after first value
            try
            {
                operand += input[charCount];
            }
            //Prints explanation for error and jumps to end of function
            catch (Exception parseError)
            {
                AnswerOut.Text = "Only one value was entered";
                goto endFunction;
            }
            //Increments to next character and checks if it's a space
                charCount++;
                if (input[charCount] == ' ')
                {
                    charCount++; //If user added space, skip past it
                }

                while (charCount < input.Length)
                {
                    secondVal += input[charCount];
                    charCount++;
                }
                if(operand == "/" & secondVal == "0")
            {
                AnswerOut.Text = "Cannot divide by 0";
            }
            //Tries to convert first and second Val to double, if successful, passes to Compute method
                try
                {
                    output = Calculator.compute(double.Parse(firstVal), double.Parse(secondVal), operand);
                }
                catch (Exception parseError)
                {
                    AnswerOut.Text = "An invalid value was entered";
                }
            finalOut = output.ToString();
            endFunction:
            //Outputs final computer answer
                AnswerOut.Text = ("Answer: " + finalOut);
            }

        }
    }