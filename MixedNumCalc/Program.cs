using System;


namespace MixedNumCalc
{
	public class Program
	{

		public static string[] ParseInput(string text)
		{
			string[] items = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			return items;
		}


		public static string CalcOp(string expression)
		{
			var actual = "Your Result = ";

            try
            {
                string[] items = ParseInput(expression);
                if (items.Length == 4)
                {
                    var operand1 = Fraction.FromString(items[1]);
                    var operand2 = Fraction.FromString(items[3]);
                    var MathOp = items[2];


                    Fraction result = Fraction.Ident;

                    switch (MathOp)
                    {
                        case "+": /*Addition*/
                            result = operand1 + operand2;
                            break;

                        case "-": /*Substraction*/
                            result = operand1 - operand2;
                            break;

                        case "*": /*Multiplication*/
                            result = operand1 * operand2;
                            break;

                        case "/": /*Division*/
                            result = operand1 / operand2;
                            break;
                        default:
                            actual = "Thas was not a valid option";
                            
                            break;
                    }
                    actual += result;

                }

                else
                {
                    actual = "Bad Format.";
                }
            }

            catch (Exception ex)
            {
                actual = ex.Message;
            }

            return actual;
		}

		public static void Main()

		{
			do
			{
				string MyKeyInput = Console.ReadLine();
				Console.WriteLine(CalcOp(MyKeyInput));
				Console.WriteLine("Again? (Y = yes, any key to exit): ");

			} while (Console.ReadLine().ToUpper() == "Y");

            Console.WriteLine("Bye!");
            Console.ReadKey();

		}
	}
}
