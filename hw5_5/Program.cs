using System;

namespace hw5_5
    //Заменить в строке все маленькие «а» на большие «А»
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст на русском языке");
            string text = Console.ReadLine();

            text = text.Replace('а', 'А');

            Console.WriteLine("Текст после замены символов:");
            Console.WriteLine(text);

            Console.WriteLine("Нажмите любую клавишу для выхода из программы");
            Console.ReadKey();
        }
    }
}
