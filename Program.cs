namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 55, 2, 3, 44, 78, 99, 4 };
            int max = arr[0];
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }

                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            DisplayArray($"Start array: ", arr);

            ChangeColorAndShow($"\n\n - - - - - - - - - - - - MAX/MIN - - - - - - - - - - - - - - -", ConsoleColor.Green);

            Console.WriteLine($"Max: " + max);
            Console.WriteLine($"Min: " + min);

            ChangeColorAndShow($"\n - - - - - - - - - - - - Selection sort - - - - - - - - - - - -", ConsoleColor.Green);

            var selectionSorted = SelectionSort(Rewrite(arr));
            DisplayArray($"Sorted: ", selectionSorted);

            ChangeColorAndShow($"\n\n - - - - - - - - - - - - Bubble sort - - - - - - - - - - - - -", ConsoleColor.Green);

            var bubbleSorted = BubbleSort(Rewrite(arr));
            DisplayArray($"Sorted: ", bubbleSorted);

            ChangeColorAndShow($"\n\n - - - - - - - - - - - - Searching - - - - - - - - - - - - - -", ConsoleColor.Green);

            Console.Write("Enter number for searching: ");
            int search;
            if (int.TryParse(Console.ReadLine(), out search))
            {
                Console.WriteLine($"BinarySearch result(array index): {BinarySearch(selectionSorted, search)}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

        }

        static int[] SelectionSort(int[] arr)
        {
            int countIteration = 0;

            int[] sorted = new int[arr.Length];
            int min;
            int minIndex = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                min = int.MaxValue;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }

                    countIteration++;
                }
                sorted[i] = min;
                arr[minIndex] = int.MaxValue;
            }
            ChangeColorAndShow($"Count iteration: {countIteration}", ConsoleColor.Red);

            return sorted;
        }

        static int BinarySearch(int[] sortedArr, int searchNum)
        {
            int countIteration = 0;

            int low = 0;
            int high = sortedArr.Length - 1;
            while (low <= high)
            {
                countIteration++;

                int mid = (low + high) / 2;
                if (sortedArr[mid] == searchNum)
                {
                    ChangeColorAndShow($"Count iteration: {countIteration}", ConsoleColor.Red);
                    return mid;
                }
                else if (sortedArr[mid] < searchNum)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            ChangeColorAndShow($"Count iteration: {countIteration}", ConsoleColor.Red);

            return -1;
        }

        static int[] BubbleSort(int[] arr)
        {
            int countIteration = 0;
            int r;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    if ((j + 1) < arr.Length && arr[j] > arr[j + 1])
                    {
                        r = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = r;
                    }
                    countIteration++;
                }
            }
            ChangeColorAndShow($"Count iteration: {countIteration}", ConsoleColor.Red);

            return arr;
        }

        static int[] Rewrite(int[] arr)
        {
            int[] newArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            return newArr;
        }

        static void ChangeColorAndShow(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void DisplayArray(string text, int[] arr)
        {
            Console.Write(text);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}
