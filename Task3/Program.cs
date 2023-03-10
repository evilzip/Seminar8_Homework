// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

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
int[,] GenerateArrayInt32(int row, int col, int MinValue, int MaxValue) 
{
    int[,] array = new int[,] { };
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
void PrintArray2D(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}
int[,] MatrixProduct(int[,] Matrix1, int[,] Matrix2)
{
    int[,] result = new int[,] { };
    if (Matrix1.GetLength(1) == Matrix2.GetLength(0))
    {
        result = new int[Matrix1.GetLength(0), Matrix2.GetLength(1)];
        for (int i = 0; i < Matrix1.GetLength(0); i++)
        {
            for (int k = 0; k < Matrix2.GetLength(1); k++)
            {
                int Sum = 0;
                for (int j = 0; j < Matrix1.GetLength(1); j++)
                {
                    Sum = Sum + Matrix1[i, j] * Matrix2[j, k];
                }
                result[i, k] = Sum;
            }
        }
        return result;
    }
    System.Console.WriteLine("Error! Matrix product dose not exist: number of column MatrixA must be equal numbers of row MatrixA");
    Environment.Exit(-3);
    return result;    
}
System.Console.WriteLine("Please, enter your Matrix A");
int NumberStringsA = InputInt32("Enter number of strings");
int NumberColumnsA = InputInt32("Enter number of columns");
int MinLimitA = InputInt32("Enter minimal element");
int MaxLimitA = InputInt32("Enter maximal element");
int[,] MatrixA = GenerateArrayInt32(NumberStringsA, NumberColumnsA, MinLimitA, MaxLimitA);
System.Console.WriteLine("Matrix A");
PrintArray2D(MatrixA);
System.Console.WriteLine("Please, enter your MatrixB");
int NumberStringsB = InputInt32("Enter number of strings");
int NumberColumnsB = InputInt32("Enter number of columns");
int MinLimitB = InputInt32("Enter minimal element");
int MaxLimitB = InputInt32("Enter maximal element");
int[,] MatrixB = GenerateArrayInt32(NumberStringsB, NumberColumnsB, MinLimitB, MaxLimitB);
System.Console.WriteLine("Matrix B");
PrintArray2D(MatrixB);
System.Console.WriteLine("Matrix Product = MatrixA * Matrix B");
PrintArray2D(MatrixProduct(MatrixA, MatrixB));
