using System;

namespace Incapsulation.RationalNumbers;

public class Rational
{
    public int Numerator { get; }
    public int Denominator { get; }
    public bool IsNan { get; }

    public Rational(int numerator, int denominator = 1)
    {
        Numerator = numerator;
        Denominator = denominator;
        IsNan = Denominator == 0;
    }

    private static Tuple<Rational, Rational> BringToCommonDenominator 
        (Rational a, Rational b)
    {
        var resultA = new Rational
            (a.Numerator * b.Denominator, a.Denominator * b.Denominator);
        var resultB = new Rational
            (b.Numerator * a.Denominator, b.Denominator * a.Denominator);
        return Tuple.Create (resultA, resultB);
    }
    private static int Nod(int n, int d)
    {
        n = Math.Abs(n);
        d = Math.Abs(d);
        while (d != 0 && n != 0)
        {
            if (n % d > 0)
            {
                var temp = n;
                n = d;
                d = temp % d;
            }
            else break;
        }
        if (d != 0 && n != 0) return d;
        return 0;
    }

    public static Rational operator +(Rational a, Rational b)
    {
        var commonDenominatorTuple = BringToCommonDenominator(a, b);
        var tempNumerator = commonDenominatorTuple.Item1.Numerator
            + commonDenominatorTuple.Item2.Numerator;
        var tempDenominator = commonDenominatorTuple.Item1.Denominator;
        var NOD = Nod(tempNumerator, tempDenominator);

        var result = new Rational(tempNumerator / NOD, tempDenominator / NOD);
        return result;

    }

    public static Rational operator -(Rational a, Rational b)
    {
        var commonDenominatorTuple = BringToCommonDenominator(a, b);
        var tempNumerator = commonDenominatorTuple.Item1.Numerator
            - commonDenominatorTuple.Item2.Numerator;
        var tempDenominator = commonDenominatorTuple.Item1.Denominator;
        var NOD = Nod(tempNumerator, tempDenominator);

        var result = new Rational(tempNumerator / NOD, tempDenominator / NOD);
        return result;
    }

    public static Rational operator *(Rational a, Rational b)
    {
        var resultNumerator = a.Numerator * b.Numerator;
        var resultDenominator = a.Denominator * b.Denominator;
        var NOD = Nod(resultNumerator, resultDenominator);
        return new Rational(resultNumerator / NOD, resultDenominator / NOD);
    }

    public static Rational operator /(Rational a, Rational b)
    {
        var invertedB = new Rational(b.Denominator, b.Numerator);
        return a * invertedB;
    }

    // Неявное приведение к double
    public static implicit operator double(Rational fraction)
    {
        return (double)fraction._numerator / fraction._denominator;
    }

    // Явное приведение к double
    public static explicit operator Fraction(double value)
    {




    }