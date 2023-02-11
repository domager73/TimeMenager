using Time;

Console.WriteLine("Вводите параметры типа dd/mm/gggg hh:mm");
Console.ReadLine();
Console.Clear();

Console.Write("Введите начальную дату: ");
string strStart = Console.ReadLine();

Console.Write("Введите конечную дату: ");
string strLast = Console.ReadLine();

Console.ReadLine();

TimeManeger timemen = new TimeManeger(strStart, strLast);

timemen.TranslateHours();
timemen.TranslateDays();
timemen.TranslateMinutes();