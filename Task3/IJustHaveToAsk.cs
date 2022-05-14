namespace Task3;

static class IJustHaveToAsk
{
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        int eLen = enumerable.Count();
        var test = new (T item, int? tail)[eLen];
        var eE = enumerable.GetEnumerator();
        eLen--;
        for (var i = 0; i <= eLen; i++)
        {
            eE.MoveNext();
            if (i >= enumerable.Count() - tailLength) test[i].tail = eLen - i ;
            test[i].item = eE.Current;
        }

        return test;
    }

    private static void Main(string[] args)
    {
        IEnumerable<(int item, int? tail)> test = new[] {1, 2, 3, 4}.EnumerateFromTail(2);
        foreach (var item in test)
        {
            Console.WriteLine(item);
        }
        Console.ReadKey();
    }
}