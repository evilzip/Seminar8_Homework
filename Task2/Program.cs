// Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int InputInt32(string message)
{
    System.Console.Write(($"{message}: "));
    int value;
    bool isCorrectInt32 = int.TryParse(Console.ReadLine(), out value);
    if (isCorrectInt32)
    {
        return value;
    }
    System.Console.WriteLine("You entered not a number");
    Environment.Exit(-1);
    return 0;
}
int[,] GenerateArrayInt32(int row, int col, int MinValue, int MaxValue) //Создание ТОЛЬКО двумерного массива. Если невозможно - то выход из программы.
{
    int[,] array = new int[,] { };
    if (row > 1 && col > 1)
    {
        array = new int[row, col];
        Random random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(MinValue, MaxValue + 1);
            }
        }
        return array;
    }
    System.Console.WriteLine("Error! Can not generate array: invalid String or column numbers");
    Environment.Exit(-3);
    return array;
}
void PrintArray2D(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
    }
    Console.WriteLine();
}

int[] FindRowSum(int[,] array)
{
    int[] result = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int CurrentRowSum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            CurrentRowSum += array[i, j];
        }
        result[i] = CurrentRowSum;
    }
    return result;
}
int FindMinElementIndex(int[] array)
{
    int MinElementIndex = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] < array[MinElementIndex]) MinElementIndex = i;
    }
    return MinElementIndex;
}
System.Console.WriteLine("Please, enter you 2D array");
int NumberStrings = InputInt32("Enter number of strings");
int NumberColumns = InputInt32("Enter number of columns");
int MinLimit = InputInt32("Enter minimal array range");
int MaxLimit = InputInt32("Enter maximal array range");
int[,] UserArray = GenerateArrayInt32(NumberStrings, NumberColumns, MinLimit, MaxLimit);
PrintArray2D(UserArray);
System.Console.WriteLine($"Number of row with minimal sum is {FindMinElementIndex(FindRowSum(UserArray))}");