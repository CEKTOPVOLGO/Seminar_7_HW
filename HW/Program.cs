Console.Clear();
int num = TaskNumber("Введите номер задачи: 47 или 50 или 52: ", "Ошибка ввода!");
if (num == 47) FirstTask();
else if (num == 50) SecondTask();
else ThirdTask();

void FirstTask()
{
    int columns = UserNumber("Введите количество строк: ", "Ошибка ввода!");
    int rows = UserNumber("Введите количество столбцов: ", "Ошибка ввода!");
    double[,] array = GetRandomDoubleArray(columns, rows);
    Console.WriteLine($"Массив размером {columns} на {rows}:");
    PrintDoubleArray(array);
}

void SecondTask()
{
    Console.WriteLine("Имеется массив из случайных цифр: ");
    int[,] array = GetRandomArray();   
    PrintArray(array);
    Console.WriteLine("Выводим число по введенным значениям позиций");
    int columns = UserNumber("Введите номер строки: ", "Ошибка ввода!") - 1;
    int rows = UserNumber("Введите номер столбца: ", "Ошибка ввода!") - 1;
    PrintResult(columns, rows, array);
}

void ThirdTask()
{
    Console.WriteLine("Имеется массив из случайных цифр: ");
    int[,] array = GetRandomArray();
    PrintArray(array);
    Console.Write("Среднее арифметическое каждого столбца: ");
    PrintAverage(array);
}

int TaskNumber(string message, string errorMessage)
{
    while(true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if(isCorrect && (userNumber == 47 || userNumber == 50 || userNumber == 52))
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

int UserNumber(string message, string errorMessage)
{
    while(true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if(isCorrect)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

void PrintAverage(int[,] array)
{
    double averageRows = 0;
    for(int i = 0; i < array.GetLength(1); i++)
    {
        for(int j = 0; j < array.GetLength(0); j++)
        {
            averageRows += array[j, i];
        }
        Console.Write($" {Math.Round(averageRows / array.GetLength(0), 2)};");
        averageRows = 0;
    }
}

void PrintResult(int columns, int rows, int[,] array)
{
    if (columns < array.GetLength(0) && rows < array.GetLength(1))
    {
        Console.WriteLine($"Искомое число: {array[columns, rows]}");
    }
    else Console.WriteLine("Такого числа не существует");
}

void PrintArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}  ");
        }
        Console.WriteLine();
    }
}

int[,] GetRandomArray()
{
    Random rnd = new Random();
    int[,] array = new int[rnd.Next(1, 10), rnd.Next(1, 10)];
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(0, 100);
        }
    }
    return array;
}

void PrintDoubleArray(double[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}  ");
        }
        Console.WriteLine();
    }
}

double[,] GetRandomDoubleArray(int columns, int rows)
{    
    double[,] result = new double[columns, rows];
    var rnd = new Random();
    for(int i = 0; i < columns; i++)
    {
        for(int j = 0; j < rows; j++)
        {
            result[i, j] = Math.Round(rnd.NextDouble() * 100, 2);
        }
    }
    return result;
}