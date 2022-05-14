using System.Diagnostics;

namespace Task4;


static class TopGrade
{
    // При сортировке массива из 1 000 000 000 чисел занимается ~3815МБ памяти и массив сортируется за 4465 миллисекунд.
    // Использовал сортировку подсчетом, ее сложность по времени O(n + k), ее сложность по памяти O(n + k).
    // Выбрал этот алгоритм сортировки, потому что у нас достаточно не большой промежуток возможных чисел в массиве.
    // Что по поводу sortFactor, я разобрался для чего он, но не совсем понял как реализовать решением с ним.
    // Выражение: Xn-sortFactor<=Xn+j | n,j - индексы
    // => неотсортированные числа относительно Xn будут находиться в промежутке [array[i]-sortFactor;array[i]]
    // мы можем облегчить память храня счетчики только этих чисел
    // sortFactor = 6
    // 13, [1, 5, 2, 3, 4, 7], 16, [11, 13, 15, 12] 20 ...
    // По запросу потребителя будут сбрасываться части потока чисел, которые в квадратных скобках, по очереди и этот 
    // небольшой участок будет сортироваться с помощью сортировки подсчетом
    // у меня произошел ступор, как мне это оптимизировать не храня в массиве с количеством вхождений чисел.
    // Пример: [1, 5, 2, 3, 4, 7] -> [0,1,1,1,1,0,0,1] => у  нас остаются места в массиве, которые просто так занимают память
    // Пример: [100, 30, 2000] -> [... , 1, ... , 1, ... 1] => и как тогда получается, что мы оптимизируем хранимые счетчики
    // если вместо них просто нули, которые тоже занимают память
    //    
    //       :\     /;               _
    //      ;  \___/  ;             ; ;
    //     ,:-"'   `"-:.            / ;
    //_   /,---.   ,---.\   _     _; /
    //_:>((  |  ) (  |  ))<:_ ,-""_,"         Я правда старался решить, но почему-то не получилось :)
    //    \`````   `````/""""",-""
    //     '-.._ v _..-'      )
    //       / ___   ____,..  \
    //      / /   | |   | ( \. \
    //     / /    | |    | |  \ \
    //     `"     `"     `"    `"
    
    private static IEnumerable<int> Sort(IEnumerable<int> inputStream, int maxValue)
    {
        var stream = inputStream as int[] ?? inputStream.ToArray();
        int[] countArray = new int[maxValue + 1];
        for (int i = 0; i < stream.Length; i++) countArray[stream[i]]++;
        int sortedArrayIndex = 0;
        for (int i = 0; i < countArray.Length-1; i++) for (int j = 0; j < countArray[i]; j++) stream[sortedArrayIndex++] = i;
        return stream;
    }
    
    // Это одна из неудачных попыток реализовать метод
    private static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
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
        int[] longArray = new[]
        {
            16, 10, 12, 11, 15, 20, 19, 18, 17, 110, 106,
            105, 125
        };
        Sort(longArray, 5,125);
    }
}