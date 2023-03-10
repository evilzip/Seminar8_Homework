//Напишите программу, которая заполнит спирально квадратный массив.

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
int[,] SquareMatrixSpiralFill(int Size)
{
    int N = Size;
    int[,] ResultMatrix = new int[N, N];
    int LastNumber = 1;
    for (int k = 0; k < (N / 2 + N % 2); k++)
    {

        for (int j = k; j < N - k; j++)//заполнение верхней стороны
        {
            
            ResultMatrix[k, j] = LastNumber;
            LastNumber = LastNumber + 1;            
        }
        for (int i = 1 + k; i < (N - 1) - k; i++)// заполнение правой стороны
        {
           
            ResultMatrix[i, (N - 1) - k] = LastNumber;
             LastNumber = LastNumber + 1;
            
        }
        for (int j = (N - 1) - k; j > k; j--)// заполнение нижней стороны
        {
            
            ResultMatrix[(N - 1) - k, j] = LastNumber;
            LastNumber = LastNumber + 1;

        }
        for (int i = (N - 1) - k; i > k; i--)//заполнение левой стороны
        {
            
            ResultMatrix[i, k] = LastNumber;
            LastNumber = LastNumber + 1;
        }

    }
    return ResultMatrix;
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


int MatrixSize = InputInt32("Enter size of your square matrix");
PrintArray2D(SquareMatrixSpiralFill(MatrixSize));



