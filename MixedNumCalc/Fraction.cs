using System.Text;
namespace MixedNumCalc
{
    internal class Fraction
    {

		public int Numerator { get; private set; }
		public int Denominator { get; private set; }

		public static readonly Fraction Ident = new Fraction() { Numerator = 1, Denominator = 1 };
				
		private static int gcd(int a, int b)
		{
			return b == 0 ? a : gcd(b, a % b);
		}

		private static int lcm(int a, int b)
		{
			return (a / gcd(a, b)) * b;
		}

		public static Fraction operator *(Fraction a, Fraction b) //multiplication
		{
			return new Fraction() { Numerator = (a.Numerator * b.Numerator), Denominator = (a.Denominator * b.Denominator) };
		}

		public static Fraction operator /(Fraction a, Fraction b) //division
		{
			return new Fraction() { Numerator = (a.Numerator * b.Denominator), Denominator = (a.Denominator * b.Numerator) };
		}

		public static Fraction operator +(Fraction a, Fraction b) //addition
		{
			if (a.Denominator != b.Denominator)
			{
				var NewDenominator = lcm(a.Denominator, b.Denominator);
				var aMultiplier = NewDenominator / a.Denominator;
				var bMultiplier = NewDenominator / b.Denominator;

				a = new Fraction() { Numerator = a.Numerator * aMultiplier, Denominator = NewDenominator };
				b = new Fraction() { Numerator = b.Numerator * bMultiplier, Denominator = NewDenominator };
			}

			return new Fraction() { Numerator = (a.Numerator + b.Numerator), Denominator = a.Denominator };
		}

		public static Fraction operator -(Fraction a, Fraction b) //substraction
		{
			
			return a + new Fraction() { Numerator = -b.Numerator, Denominator = b.Denominator };
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			var LNumerator = Numerator;

			// If the numerator is greater than the denominator then there will be a whole num

			if (System.Math.Abs(LNumerator) >= Denominator)
			{
				int FullNum = LNumerator / Denominator;
				LNumerator -= (FullNum * Denominator);
				stringBuilder.Append(FullNum);

				if (LNumerator != 0)
				{
					stringBuilder.Append('_');
				}
			}

			// If there is anything left in the numerator, append the fractional part

			if (LNumerator != 0)
			{
				stringBuilder.Append(System.Math.Abs(LNumerator));
				stringBuilder.Append('/');
				stringBuilder.Append(Denominator);
			}

			return stringBuilder.ToString();
		}

		
		public static Fraction FromString(string fraction)
		{
			int underscoreIndex = fraction.IndexOf('_');
			int fractionIndex = fraction.IndexOf('/');

			int FullNum = 0;
			int numerator = 0;
			int denominator = 0;

			// If there is an underscore, it is a whole number component before the fraction

			if (underscoreIndex >= 0)
			{
				// Prune off whole number

				FullNum = int.Parse(fraction.Substring(0, underscoreIndex));
			}

			// If there is no fraction sign, this is a whole number

			if (fractionIndex < 0)
			{
				FullNum = int.Parse(fraction);
				denominator = 1;
			}
			else
			{
				// The numerator and denominator surround the "/" in the expression

				numerator = int.Parse(fraction.Substring(underscoreIndex + 1, fractionIndex - (underscoreIndex + 1)));
				denominator = int.Parse(fraction.Substring(fractionIndex + 1));
			}

			// If FullNum is negative, make the numerator negative

			if (FullNum < 0)
			{
				numerator = -numerator;
			}

			// Make an improper fraction and include the whole number part

			numerator += (FullNum * denominator);

			return new Fraction() { Numerator = numerator, Denominator = denominator };
		}

	}
}
