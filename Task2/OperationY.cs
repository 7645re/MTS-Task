using System.Globalization;

namespace Task2;

class OperationY
{
    static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;
    class Number
    {
        readonly int _number;
 
        public Number(int number)
        {
            _number = number;
        }
 
        public override string ToString()
        {
            return _number.ToString(_ifp);
        }
        public static string operator +(Number n1, string n2)
        {
            return (n1._number + int.Parse(n2, _ifp)).ToString();
        }
    }
 
    static void Main(string[] args)
    {
        int someValue1 = 10;
        int someValue2 = 5;
        
        string result = new Number(someValue1) + someValue2.ToString(_ifp);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
