using System;

namespace hw5_3
//all elements after maximum in every row have to be assigned to 0
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
        /// Gets the size (integer>0)
        /// </summary>
        /// <param name="annotationText">Descripton shown for user</param>
        /// <returns></returns>
        public static int GetSize(string annotationText)
        {
            int size = 0;
            bool result = false;
            do
            {
                Console.Write(annotationText);
                result = int.TryParse(Console.ReadLine(), out size);
                if (result == false || size <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Wrong input, please retry");
                    Console.ResetColor();
                }
            }
            while (result == false && size <= 0);

            return size;
        }
        /// <summary>
        /// Return assigned array of arrays of defined size
        /// </summary>
        /// <param name="rowsCount">Count of array raws</param>
        /// <param name="randomArrayFill">True for random fill, false for manual input</param>
        /// <returns>array of arrays</returns>
        public static int[][] ArrayFill(int rowsCount, bool randomArrayFill)
        {
            int[][] outputArray = new int[rowsCount] [];
            int colCount = 0;

            if (randomArrayFill)
            {
                Random random = new Random();
                for (int i = 0; i < rowsCount; i++)
                {
                    colCount = random.Next(9) + 1; //random column count for every row
                    outputArray[i] = new int[colCount];
                    for (int j = 0; j < colCount; j++)
                    {
                        outputArray[i][j] = random.Next(499) * 2;
                        int sign = random.Next(2);  //to get some negative numbers
                        if (sign < 1)
                        {
                            outputArray[i][j] *= -1;
                        }
                    }

                }

            }
            else
            {
                for (int i = 0; i < rowsCount; i++)

                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Row {i} ");
                    Console.ResetColor();
                    colCount = GetSize($"Enter number of elements for row {i} ");
                    outputArray[i] = new int[colCount];
                    for (int j = 0; j < colCount; j++)
                    {
                        bool result = false;
                        do
                        {
                            Console.Write($"Enter integer element of array indexed {j} in row {i}:");
                            result = int.TryParse(Console.ReadLine(), out outputArray[i][j]);
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
            }
            return outputArray;
        }

        /// <summary>
        /// Output array to the screen
        /// </summary>
        /// <param name="array"></param>
        public static void ArrayOutput(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j],5} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Returns index of max element in a row of array
        /// </summary>
        /// <param name="rowNumber"></param>
        public static int MaxElementIndex(int[] array)
        {
            int max = int.MinValue;
            int maxElementIndex = -1;
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] > max)
                {
                    maxElementIndex = j;
                    max = array[j];
                }

            }
            //Console.WriteLine($"{max},  {maxElementIndex}");
            return maxElementIndex;
        }

        static void Main(string[] args)
        {

            int rowsCount = GetSize("Please enter the number of rows:");
            
            int[][] array = new int[rowsCount][];

            array = ArrayFill(rowsCount, RandomArrayFill());

            Console.WriteLine("Given array:");
            ArrayOutput(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = MaxElementIndex(array[i]) + 1; j < array[i].Length; j++)
                {
                    array[i][j] = 0;
                }
            }

            Console.WriteLine("Modified array:");
            ArrayOutput(array);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
