// Задайте две матрицы. 
// Напишите программу, которая будет находить произведение двух матриц.

int ReadInt(string text)
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int[,] GenerateMatrix(int m, int n)
{
    Random rand = new Random();
    int[,] matrix = new int[m, n];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(0, 10);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

int[,] MatrixProduct(int[,] matrix1, int[,] matrix2)
{
    int[,] matrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            int newElement = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                newElement += matrix1[i, k] * matrix2[k, j];
            }
            matrix[i, j] = newElement;
        }
    }
    return matrix;
}

int rows1 = ReadInt("Введите количество строк первой матрицы: ");
int cols1 = ReadInt("Введите количество столбцов первой матрицы: ");
int rows2 = ReadInt("Введите количество строк второй матрицы: ");
int cols2 = ReadInt("Введите количество столбцов второй матрицы: ");
var myMatrix1 = GenerateMatrix(rows1, cols1);
System.Console.WriteLine("\n" + "Первая матрица:");
PrintMatrix(myMatrix1);

var myMatrix2 = GenerateMatrix(rows2, cols2);
System.Console.WriteLine("\n" + "Вторая матрица:");
PrintMatrix(myMatrix2);

if (myMatrix1.GetLength(1) != myMatrix2.GetLength(0)) System.Console.WriteLine("\n" + "Некорректный ввод, произведение невозможно!");
else
{
    System.Console.WriteLine("\n" + "Результирующая матрица:");
    PrintMatrix(MatrixProduct(myMatrix1, myMatrix2));
}