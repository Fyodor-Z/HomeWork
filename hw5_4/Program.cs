using System;

namespace hw5_4
//Подсчитать количество гласных в строке
{

    class Program

    {
        /// <summary>
        /// Проверяет является ли буква гласной
        /// </summary>
        /// <param name="text">текст для анализа</param>
        /// <param name="arrVowels">массив гласных</param>
        /// <returns>true если данная буква является гласной из данного массива</returns>
        public static bool IsVowel(char text, char[] arrayVowels)
        {
            for (int i = 0; i < arrayVowels.Length; i++)
            {
                if (text == arrayVowels[i])
                {
                    return true;
                }
            }
            return false;
        }


        static void Main(string[] args)
        {
            char[] arrVowels = new char[] { 'а', 'о', 'и', 'е', 'ё', 'э', 'ы', 'у', 'ю', 'я', 'А', 'О', 'И', 'Е', 'Ё', 'Э', 'Ы', 'У', 'Ю', 'Я' };
            int VowelsCount = 0;

            Console.WriteLine("Введите текст на русском языке");
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
                if (IsVowel(text[i], arrVowels))
                {
                    VowelsCount++;
                }
            if (VowelsCount==0)
            {
                Console.WriteLine("Данный текст не содержит гласных");
            }
            else if (VowelsCount%10 == 1)
            {
                Console.WriteLine($"Данный текст содержит {VowelsCount} гласную");
            }
            else
            {
                Console.WriteLine($"Данный текст содержит {VowelsCount} гласных");
            }
     

            Console.WriteLine("Нажмите любую клавишу для выхода из программы");
            Console.ReadKey();
        }
    }
}
