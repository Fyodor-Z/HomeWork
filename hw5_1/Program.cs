using System;

namespace hw5_1


//Find the value and number of the last negative element of one dimensional array
//of[8] elements.
{
    class Program
    {

        /// <summary>
        /// Gets from user the way of array fill
        /// </summary>
        /// <returns>True for random fill, false for manual input</returns>
        public static bool RandomArrayFill()
        {
            bool result = false;
            do
            {
                Console.WriteLine("Choose the source of array values");
                Console.WriteLine("1 - random generation, 2 - manual input");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        return true;
                    case "2":
                        return false;
                    default:
                        result = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error! Wrong input");
                        Console.ResetColor();
                        break;
                }

            }
            while (result == false);
            return true;
        }

        /// <summary>
        /// Return assigned array of defined size
        /// </summary>
        /// <param name="size">Size of array</param>
        /// <param name="randomArrayFill">True for random fill, false for manual input</param>
        /// <returns></returns>

        public static int[] ArrayFill(int size, bool randomArrayFill)
        {
            int[] outputArray = new int[size];
            if (randomArrayFill)
            {
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    outputArray[i] = random.Next(499) * 2;
                    int sign = random.Next(2);  //to get some negative numbers
                    if (sign < 1)
                    {
                        outputArray[i] *= -1;
                    }
                }

            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    bool result = false;
                    do
                    {
                        Console.Write($"Enter integer element of array indexed {i}:");
                        result = int.TryParse(Console.ReadLine(), out outputArray[i]);
                        if (result == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error! Wrong input, please retry");
                            Console.ResetColor();
                        }

                    }
                    while (result == false);

                }
            }
            return outputArray;
        }


        static void Main(string[] args)
        {
            int[] array = new int[8];
            array = ArrayFill(8, RandomArrayFill());
            Console.WriteLine("Array:");
            Console.WriteLine(string.Join(',', array));
            Console.ReadKey();


            int elementIndex = -1;
            

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    elementIndex = i;
                }
            }

            if (elementIndex==-1)
            {
                Console.WriteLine("All array elements are non-negative");
            }
            else
            {
                Console.WriteLine($"Index of last negative element of array is {elementIndex}, value is {array[elementIndex]}");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();


        }

    }
}
