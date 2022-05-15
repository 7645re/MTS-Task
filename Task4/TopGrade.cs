using System.Diagnostics;

namespace Task4;


static class TopGrade
{   
    // Сортировка подсчетом
    private static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var stream = inputStream as int[] ?? inputStream.ToArray();
        int[] countArray = new int[maxValue + 1];
        for (int i = 0; i < stream.Length; i++) countArray[stream[i]]++;
        int sortedArrayIndex = 0;
        for (int i = 0; i < countArray.Length-1; i++) for (int j = 0; j < countArray[i]; j++) stream[sortedArrayIndex++] = i;
        return stream;
    }
    
    // Это одна из неудачных попыток реализовать метод
    private static IEnumerable<int> UnWorkSort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var stream = inputStream as int[] ?? inputStream.ToArray();
        int selectN = stream[0];
        int selectNIndex = 0;
        int[] countArray = new int[maxValue + 1];
        for (int i = 0; i < stream.Length; i++)
        {
            if (selectN > stream[i])
            {
                Console.WriteLine($"{selectN} {stream[i]}");
            }
            else
            {
                int[] windowNums = new int[i - selectNIndex + 1];
                Console.ReadKey();
                selectN = stream[i];
                selectNIndex = i;
            }
            Console.WriteLine($"SelectNum: {selectN} Index: {selectNIndex} | Num: {stream[i]} Index: {i}");
        }

        int sortedArrayIndex = 0;
        for (int i = 0; i < countArray.Length-1; i++) for (int j = 0; j < countArray[i]; j++) stream[sortedArrayIndex++] = i;
        return stream;
    }

    private static void Main(string[] args)
    {
        int[] array = new[]
        {
            16, 10, 12, 11, 15, 20, 19, 18, 17, 110, 106,
            105, 125
        };
        Sort(array, 4, 2000);
    }
}
