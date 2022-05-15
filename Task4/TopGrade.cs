using System.Diagnostics;

namespace Task4;


static class TopGrade
{   
    // Сортировка подсчетом
    private static IEnumerable<int> CountingSort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var stream = inputStream as int[] ?? inputStream.ToArray();
        int[] countArray = new int[maxValue + 1];
        for (int i = 0; i < stream.Length; i++) countArray[stream[i]]++;
        int sortedArrayIndex = 0;
        for (int i = 0; i < countArray.Length; i++) for (int j = 0; j < countArray[i]; j++) stream[sortedArrayIndex++] = i;
        return stream;
    }
    // Переводит словарь число: количество в массив
    private static int[] DictToArray(Dictionary<short, uint> counts, int arrayLen, short minValue, short maxValue)
    {
        int[] array = new int[arrayLen];
        short arrayIndex = 0;
        for (short i = minValue; i <= maxValue; i++)
        {
            counts.TryGetValue(i, out uint value);
            if (value == 1)
            {
                array[arrayIndex] = i;
                arrayIndex++;
            }
            if (value > 1)
            {
                for (short j = 0; j < value; j++)
                {
                    array[arrayIndex] = i;
                    arrayIndex++;
                }
            }
        }
        return array;
    }

    private static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var stream = inputStream as int[] ?? inputStream.ToArray();
        if (sortFactor >= maxValue)
        {
            IEnumerable<int> sortedArray = CountingSort(stream, sortFactor, maxValue);
            var enumerable = sortedArray as int[] ?? sortedArray.ToArray();
            for (int i = 0; i < enumerable.Length; i++) yield return enumerable[i];
            yield break;
        }
        short selectN = (short)stream[0];
        int arrayLen = 0;
        Dictionary<short, uint> counts = new Dictionary<short, uint>();
        for (int i = 0; i < stream.Length; i++)
        {
            if (selectN >= stream[i])
            {
                if (counts.TryGetValue((short) stream[i], out _)) counts[(short) stream[i]]++;
                else counts.Add((short) stream[i], 1);
                arrayLen++;
                if (i == stream.Length - 1)
                {
                    int[] sortedPartStream = DictToArray(counts, arrayLen, (short) (selectN-sortFactor), selectN);
                    for (int k = 0; k < sortedPartStream.Length; k++)
                    {
                        yield return sortedPartStream[k];
                    }
                }
            }
            else
            {
                int[] sortedPartStream = DictToArray(counts, arrayLen, (short) (selectN-sortFactor), selectN);
                for (int k = 0; k < sortedPartStream.Length; k++)
                {
                    yield return sortedPartStream[k];
                }
                counts = new Dictionary<short, uint>();
                arrayLen = 0;
                selectN = (short)stream[i];
                if (counts.TryGetValue((short) stream[i], out _)) counts[(short) stream[i]]++;
                else counts.Add((short) stream[i], 1);
                arrayLen++;
            }
        }
    }

    static void Main(string[] args)
    {
    }
}
