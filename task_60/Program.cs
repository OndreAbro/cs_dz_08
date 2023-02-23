// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

int ReadInt(string text)
{
    System.Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int[,,] GenerateMatrix(int l, int m, int n)
{
    Random rand = new Random();
    int[,,] matrix = new int[l, m, n];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                while (true)
                {
                point:
                    int unique = rand.Next(10, 100);
                    for (int x = 0; x < matrix.GetLength(0); x++)
                    {
                        for (int y = 0; y < matrix.GetLength(1); y++)
                        {
                            for (int z = 0; z < matrix.GetLength(2); z++)
                            {
                                if (matrix[x, y, z] == unique) goto point;
                            }
                        }
                    }
                    matrix[i, j, k] = unique;
                    break;
                }
            }
        }
    }
    return matrix;
}

void PrintMatrixWithIndex(int[,,] matrix)
{
    System.Console.WriteLine("\n" + "Трехмерный массив уникальных чисел:");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                System.Console.Write(matrix[i, j, k] + $" ({i + "," + j + "," + k})" + "\t");
            }
            System.Console.WriteLine();
        }
    }
}

int dimension1 = ReadInt("Введите значение первого измерения массива: ");
int dimension2 = ReadInt("Введите значение второго измерения массива: ");
int dimension3 = ReadInt("Введите значение третьего измерения массива: ");
var myMatrix = GenerateMatrix(dimension1, dimension2, dimension3);
PrintMatrixWithIndex(myMatrix);
