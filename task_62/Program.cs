// Напишите программу, которая заполнит массив спирально.  

int ReadInt(string text)
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int[,] GenerateMatrix(int rows, int cols)
{
    int[,] matrix = new int[rows + 1, cols + 2];
    for (int m = 0; m < matrix.GetLength(0); m++)
    {
        matrix[m, 0] = 1;
        matrix[m, matrix.GetLength(1) - 1] = 1;
    }
    for (int m = 0; m < matrix.GetLength(1); m++)
    {
        matrix[matrix.GetLength(0) - 1, m] = 1;
    }
    int element = 1;
    int i = 0;
    int j = 0;
leftToRigthToDownToLeft:
    if (element <= rows * cols)
    {
        if (matrix[i, j + 1] == 0)
        {
            matrix[i, j + 1] = element;
            element++;
            j++;
            goto leftToRigthToDownToLeft;
        }
        else if (matrix[i + 1, j] == 0)
        {
            matrix[i + 1, j] = element;
            element++;
            i++;
            goto leftToRigthToDownToLeft;
        }
        else if (matrix[i, j - 1] == 0)
        {
            matrix[i, j - 1] = element;
            element++;
            j--;
            goto leftToRigthToDownToLeft;
        }
    downToUp:
        if (matrix[i - 1, j] == 0)
        {
            matrix[i - 1, j] = element;
            element++;
            i--;
            goto downToUp;
        }
        else
        {
            goto leftToRigthToDownToLeft;
        }
    }
    int[,] result_matrix = new int[rows, cols];
    for (int x = 0; x < rows; x++)
    {
        for (int y = 0; y < cols; y++)
        {
            result_matrix[x, y] = matrix[x, y + 1];
        }
    }
    return result_matrix;
}

void PrintMatrix(int[,] matrix)
{
    System.Console.WriteLine("\n" + $"Двумерный спиральный массив размером {matrix.GetLength(0)}x{matrix.GetLength(1)}:");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

int rows = ReadInt("Введите число строк массива: ");
int cols = ReadInt("Введите число столбцов массива: ");

var myMatrix = GenerateMatrix(rows, cols);

PrintMatrix(myMatrix);
