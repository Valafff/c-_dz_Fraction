using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c__dz_Fraction
{

	internal class Fraction
	{

		int numerator;
		int denominator;
		int whole;

		public Fraction(int numerator = 0, int denominator = 1)
		{
			this.numerator = numerator;
			this.denominator = denominator;

			//Чтобы использовать небезопасный код в C#, надо первым делом указать проекту, что он будет работать с небезопасным кодом. Для этого надо установить в настройках проекта соответствующий флаг - в меню Project (Проект) найти Свойства проекта. Затем в меню Build установить флажок Unsafe code (Небезопасный код):
			//unsafe /*void Test()*/
			//{
			//	int a = 0;
			//	int *ptr;
			//	ptr = &a;
			//	ulong addr = (ulong)ptr ;
			//             Console.WriteLine($"Адрес переменной a {addr}");
			//         }

			//if (denominator == 0)
			//{

			//	Console.WriteLine($"Дробь создана. В знаменателе дроби  указан 0!");
			//}
			//else
			//{
			//	Console.WriteLine("Дробь создана");
			//}
		}

		public int NUM
		{
			get { return numerator; }
			set { numerator = value; }
		}
		public int DENOM
		{
			get { return denominator; }
			set { denominator = value; }
		}

		public void printFraction()
		{
			int tempnumerator;
			//int tempdenominator;
			int tempwhole = numerator / denominator; ;
			//Вынос целого
			if (numerator % denominator == 0)
			{
				tempnumerator = numerator;
			}
			else
			{
				tempnumerator = numerator % denominator;
				tempwhole = numerator / denominator;
			}

			//Печать дроби
			if (tempwhole == 0 && tempnumerator != 0)
			{
				Console.WriteLine($"{tempnumerator}/{denominator}");
			}
			else if (tempwhole != 0 && tempnumerator == denominator)
			{
				Console.WriteLine(tempwhole);
			}
			else if (tempwhole != 0 && Math.Abs(denominator) == 1)
			{
				Console.WriteLine(tempwhole);
			}
			else if (tempnumerator == 0)
			{
				Console.WriteLine(0);
			}
			else
			{
				Console.WriteLine($"{tempwhole}({tempnumerator}/{denominator})");
			}
		}

		public string printToString()
		{
			if (denominator == 0)
			{
				return "Знаменатель дроби равен 0!";
			}
			int tempnumerator;
			//int tempdenominator;
			int tempwhole = numerator / denominator;
			//Вынос целого
			if (numerator % denominator == 0)
			{
				tempnumerator = numerator;
			}
			else
			{
				tempnumerator = numerator % denominator;
				tempwhole = numerator / denominator;
			}

			//Печать дроби
			if (tempwhole == 0 && tempnumerator != 0)
			{
				return $"{tempnumerator}/{denominator}";
			}
			else if (tempwhole != 0 && tempnumerator == denominator)
			{
				return Convert.ToString(tempwhole);
			}
			else if (tempwhole != 0 && Math.Abs (denominator) == 1)
			{
				return Convert.ToString(tempwhole);
			}
			else if (tempnumerator == 0)
			{
				return Convert.ToString(0);
			}
			else
			{
				return $"{tempwhole}({tempnumerator}/{denominator})";
			}
		}
		public override string ToString() => printToString();

		//Перегрузка оператора =
		//public static Fraction operator =(Fraction A, Fraction B)
		//{
		//	return A;
		//}
		//Приведение к общему знаменателю и домножение числителей каждой дроби
		static int FractionOneDenominator(ref Fraction arg_1, ref Fraction arg_2)
		{
			if (arg_1.DENOM != arg_2.DENOM)
			{
				arg_1.NUM *= arg_2.DENOM;
				arg_2.NUM *= arg_1.DENOM;
				return arg_1.denominator * arg_2.denominator;
			}
			else
			{
				return arg_1.denominator;
			}
		}
		//Сокращение дроби
		static Fraction FractionDenominator(ref Fraction arg)
		{
			while (arg.NUM % 2 == 0 && arg.DENOM % 2 == 0)
			{
				arg.NUM /= 2;
				arg.DENOM /= 2;
			}
			return arg;
		}

		static void shamanCall(ref Fraction input_a, ref Fraction input_b, ref Fraction temp_first, ref Fraction temp_second)
		{
			temp_first.NUM = input_a.NUM;
			temp_first.DENOM = input_a.DENOM;
			temp_second.NUM = input_b.NUM;
			temp_second.DENOM *= input_b.DENOM;
		}
		//Перегрузка оператора +
		public static Fraction operator +(Fraction A, Fraction B)
		{
			Fraction first = new Fraction();
			Fraction second = new Fraction();
			Fraction tempresult = new Fraction();
			shamanCall(ref A, ref B, ref first, ref second);
			tempresult.DENOM = FractionOneDenominator(ref first, ref second);
			tempresult.NUM = first.NUM + second.NUM;
			return FractionDenominator(ref tempresult);
		}
		//Перегрузка оператора -
		public static Fraction operator -(Fraction A, Fraction B)
		{
			Fraction tempresult = new Fraction();
			Fraction first = new Fraction();
			Fraction second = new Fraction();
			shamanCall(ref A, ref B, ref first, ref second);
			tempresult.DENOM = FractionOneDenominator(ref first, ref second);
			tempresult.NUM = first.NUM - second.NUM;
			return FractionDenominator(ref tempresult);
		}
		// Присвоение минуса
		public static Fraction operator -(Fraction A) => new Fraction(A.NUM*-1, A.DENOM);

		//Перегрузка оператора *
		public static Fraction operator *(Fraction A, Fraction B)
		{
			Fraction first = new Fraction();
			Fraction second = new Fraction();
			Fraction tempresult = new Fraction();
			shamanCall(ref A, ref B, ref first, ref second);
			tempresult.NUM = first.NUM * second.NUM;
			tempresult.DENOM = first.DENOM * second.DENOM;
			return FractionDenominator(ref tempresult);
		}
		//Перегрузка оператора /
		public static Fraction operator /(Fraction A, Fraction B)
		{
			Fraction first = new Fraction();
			Fraction second = new Fraction();
			Fraction tempresult = new Fraction();
			shamanCall(ref A, ref B, ref first, ref second);
			tempresult.NUM = first.NUM * second.DENOM;
			tempresult.DENOM = first.DENOM * second.NUM;
			return FractionDenominator(ref tempresult);
		}
		//Инкремент А++ постфиксный и префиксный определяет сам?
		public static Fraction operator ++(Fraction A)
		{
			return A = A+A;
		}
		//Декеремент А--
		public static Fraction operator --(Fraction A)
		{
			return A = A - A;
		}
		//Оператор == не перегружается без !=
		public static bool operator ==(Fraction A, Fraction B)
		{
			return A.Equals(B);
		}
		//Оператор != не перегружается без ==
		public static bool operator !=(Fraction A, Fraction B)
		{
			return !(A == B);
		}

		//Оператор > 	Оператор <
		public static bool operator >(Fraction A, Fraction B)
		{
			return ((double)A.NUM / A.DENOM) > ((double)B.NUM / B.DENOM);
		}
		public static bool operator <(Fraction A, Fraction B)
		{
			return ((double)A.NUM / A.DENOM) < ((double)B.NUM / B.DENOM);
		}
		//Оператор >=	Оператор <=
		public static bool operator >=(Fraction A, Fraction B)
		{
			return ((double)A.NUM / A.DENOM) >= ((double)B.NUM / B.DENOM);
		}
		public static bool operator <=(Fraction A, Fraction B)
		{

			return ((double)A.NUM / A.DENOM) <= ((double)B.NUM / B.DENOM);
		}
	}
}
