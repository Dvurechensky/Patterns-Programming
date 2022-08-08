static class Program
{
    /// <summary>
    /// Какие числа массива дают в сумме указанное число
    /// </summary>
    /// <param name="nums">Массив чисел</param>
    /// <param name="target">Искомая сумма</param>
    /// <returns>Массив индексов чисел</returns>
    public static int[] TwoSum(int[] nums, int target)
    {
        int countNew = 0;
        int[] weeks = { };
        for (int k = 0; k < nums.Length-1; k++)
        {
            for(int i = 1; i < nums.Length; i++)
            {
                int a1 = nums[k];
                int a2 = nums[i];
                if (a1 + a2 == target)
                {
                    if(k != i && k < i)
                    {
                        countNew++;
                        Array.Resize(ref weeks, weeks.Length + 2);
                        weeks[weeks.Length - 2] = k;
                        weeks[weeks.Length - 1] = i;
                    }
                }
            }
        }
        return weeks;
    }

    /// <summary>
    /// Проверяет число на верность свойствам полиндрома
    /// </summary>
    /// <param name="x">Число</param>
    /// <returns>Полиндром или нет</returns>
    public static bool IsPalindrome(int x)
    {
        if(x.ToString().Length > 3)
        {
            for (int i = 0; i < x.ToString().Length; i++)
            {
                if (x.ToString()[i] != x.ToString()[x.ToString().Length - (i + 1)])
                    return false;
            } 
        }
        if(x >= 0 && x.ToString()[0] == x.ToString()[x.ToString().Length-1])
            return true;
        return false;
    }

    /// <summary>
    /// Переводит римские цифры в реальное число
    /// </summary>
    /// <param name="s">Римский символ</param>
    /// <returns>Число</returns>
    public static int RomanToInt(string s)
    {
        var mapNumbers = new Dictionary<int, char>()
        {
            { 1, 'I' }, { 5, 'V' }, { 10, 'X' }, { 50, 'L' }, { 100, 'C' }, { 500, 'D' }, { 1000, 'M' }
        };
        char symTmp = ' ';
        int[] sumArray = { };
        for (int i = 0; i < s.Length; i++)
        {
            foreach (var number in mapNumbers.Values)
            {
                if(number == s[i])
                {
                    int numberRes = 0;
                    switch($"{symTmp}{number}")
                    {
                        case "IV":
                            numberRes = 4;
                            Array.Resize(ref sumArray, sumArray.Length - 1);
                            break;
                        case "IX":
                            numberRes = 9;
                            Array.Resize(ref sumArray, sumArray.Length - 1);
                            break;
                        case "XL":
                            numberRes = 40;
                            Array.Resize(ref sumArray, sumArray.Length - 1);
                            break;
                        case "XC":
                            numberRes = 90;
                            Array.Resize(ref sumArray, sumArray.Length - 1);
                            break;
                        case "CD":
                            numberRes = 400;
                            Array.Resize(ref sumArray, sumArray.Length - 1);
                            break;
                        case "CM":
                            numberRes = 900;
                            Array.Resize(ref sumArray, sumArray.Length - 1);
                            break;
                    }
                    if(numberRes == 0)
                        numberRes = mapNumbers.Where(x => x.Value == number).FirstOrDefault().Key;
                    Array.Resize(ref sumArray, sumArray.Length + 1);
                    sumArray[sumArray.Length - 1] = numberRes;
                    symTmp = number;
                }
            }
        }
        return sumArray.Sum();
    }

    static void Main()
    {
        //Console.WriteLine(RomanToInt("MCMXCIV")); //1994
        Console.ReadLine();
    }
}