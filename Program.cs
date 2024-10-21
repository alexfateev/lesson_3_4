const int arrayDefaultSize = 12;
int errCount = 0;
int numberCount = 0;
int[] arr = new int[arrayDefaultSize];
int arrayIndex = 0;

while (true)
{
    Console.Write("Введите целое число:");
    var res = int.TryParse(Console.ReadLine(), out int number);
    if (res)
    {
        if (arrayIndex == arr.Length) ArrayResize(ref arr);
        arr[arrayIndex] = number;
        arrayIndex++;
    }
    else
    {
        if (ShowMenu() == MenuAction.Exit) break;
    }
}
//ShowMenu();

int[] ArrayClear()
{
    return new int[arrayDefaultSize];
}
void ArrayResize(ref int[] arr)
{
    int[] temp = new int[arr.Length * 2];
    for (int i = 0; i < arr.Length; i++)
    {
        temp[i] = arr[i];
    }
    arr = temp;
}

MenuAction ShowMenu()
{
    while (true)
    {
        Console.WriteLine("Выберите действие:\n1. Продолжить\n2. Очистить\n3. Выход");
        var res = int.TryParse(Console.ReadLine(), out int number);
        if (res)
        {
            if (number == 1) return MenuAction.Next;
            else if (number == 2)
            {
                arr = ArrayClear();
                arrayIndex = 0;
                Console.WriteLine("Массив очищен");
            }
            else if (number == 3)
            {
                ArrayPrint(arr);
                return MenuAction.Exit;
            }
        }
    }
}

void ArrayPrint(int[] arr)
{
    for (int i = 0; i < arrayIndex; i++)
    {
        Console.Write($"{arr[i]} ");
    }
}

enum MenuAction { Next, Clear, Exit }