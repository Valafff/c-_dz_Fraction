using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__dz_Fraction
{
	internal class Program
	{
		const string delimetr = "\n--------------------------------\n";
		static void Main(string[] args)
		{


            Fraction A = new Fraction(1, 2);
			Fraction B = new Fraction(1, 3);
			Fraction C = new Fraction(1, 4);
			Fraction X = new Fraction(0, 0);
			Fraction D = new Fraction(2, 1);
			Console.WriteLine($"Дробь А: {A}");
			Console.WriteLine($"Дробь B: {B}");
			Console.WriteLine($"Дробь C: {C}");
			Console.WriteLine($"Дробь D: {D}");
			Console.WriteLine($"Дробь X: {X}");
			Console.WriteLine(delimetr);
			Console.WriteLine($"Выражение A+B+C = {A + B + C}");
			Console.WriteLine($"Выражение A-B-C = {A - B - C}");
			Console.WriteLine($"Выражение A*B*C = {A * B * C}");
			Console.WriteLine($"Выражение A/B/C = {A / B / -C}");
			Console.WriteLine($"Выражение (A*D+B/D+-C)*-D = {(A * D + B / D + -C) * -D}");
			Console.WriteLine($"Выражение A++ = {A++}");
			Console.WriteLine($"Дробь А: {A}");
			Console.WriteLine($"Выражение ++B = {++B}");
			Console.WriteLine($"Дробь B: {B}");
			A = A / D;
			X.NUM=0; X.DENOM=1;
			Console.WriteLine($"A = {A}  C = {C} D = {D} X = {X}");
			Console.WriteLine($"Выражение D == A {D == A}");
			Console.WriteLine($"Выражение A == A {A == A}");
			Console.WriteLine($"Выражение A != A {A != A}");
			Console.WriteLine($"Выражение D != A {D != A}");
			Console.WriteLine($"Выражение A > D {A > D}");
			Console.WriteLine($"Выражение A < D {A < D}");
			Console.WriteLine($"Выражение X <= X {X <= X}");
			Console.WriteLine($"Выражение -D >= X {-D >= X}");
			Console.WriteLine($"Выражение -D <= X {-D <= X}");
			Console.WriteLine($"Выражение -C <= X {-C <= X}");
			Console.WriteLine($"Выражение C >= X {C >= X}");
		}
	}
}
