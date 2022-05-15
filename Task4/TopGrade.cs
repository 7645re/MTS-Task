﻿using System.Diagnostics;

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
        for (int i = 0; i < countArray.Length-1; i++) for (int j = 0; j < countArray[i]; j++) stream[sortedArrayIndex++] = i;
        return stream;
    }
    // Переводит словарь число: количество в массив
    private static IEnumerable<int> DictToArray(Dictionary<short, uint> counts, int arrayLen, short minValue, short maxValue)
    {
        int[] array = new int[arrayLen];
        short arrayIndex = 0;
        for (short i = minValue; i <= maxValue; i++)
        {
            counts.TryGetValue(i, out uint value);
            if (value == 1)
            {
                array[arrayIndex] = i;
                Console.WriteLine($"{arrayIndex} : {i} : {value}");
                arrayIndex++;
            }
            if (value > 1)
            {
                for (short j = 0; j < value; j++)
                {
                    array[arrayIndex] = i;
                    Console.WriteLine($"{arrayIndex} : {i} : {value}");
                    arrayIndex++;
                }
            }
        }
        return array;
    }

    private static IEnumerable<IEnumerable<int>> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var stream = inputStream as int[] ?? inputStream.ToArray();
        short selectN = (short)stream[0];
        int selectNIndex = 0;
        int arrayLen = 0;
        Dictionary<short, uint> counts = new Dictionary<short, uint>();
        for (int i = 0; i < stream.Length; i++)
        {
            if (selectN >= stream[i])
            {
                if (counts.TryGetValue((short) stream[i], out _)) counts[(short) stream[i]]++;
                else counts.Add((short) stream[i], 1);
                arrayLen++;
            }
            else
            {
                yield return DictToArray(counts, arrayLen, (short) (selectN-sortFactor), selectN);
                counts = new Dictionary<short, uint>();
                arrayLen = 0;
                selectN = (short)stream[i];
                selectNIndex = i;
                if (counts.TryGetValue((short) stream[i], out _)) counts[(short) stream[i]]++;
                arrayLen++;
            }
            Console.WriteLine($"SelectNum: {selectN} Num: {stream[i]} | Index: {selectNIndex}  Index: {i} | {i - selectNIndex + 1}");
        }
    }

    private static void Main(string[] args)
    {
        int[] array = {5, 2, 1, 1, 4, 5, 3, 9, 6, 10, 8, 7, 110, 106,
            108, 120};
        var unWorkSort = Sort(array, 4, 120);
        foreach(IEnumerable<int> test in unWorkSort)
        {
            Console.WriteLine(test);
            Console.ReadKey();
        }
    }
}
