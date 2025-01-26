namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 2, 6, 1, 3, 5, 8, 7 };

            DisplayArray($"Start array: ", arr);

            ShowColored($"\n\n - - - - - - - - - - - - COUNT/MIN/MAX - - - - - - - - - - -", ConsoleColor.Green);

            var сount = FindCountElementsInArr_Recursion(arr);
            Console.WriteLine($"Count: {сount}.");

            var minMax = MinMax(arr);
            Console.WriteLine($"Min: {minMax.Item1}.");
            Console.WriteLine($"Max: {minMax.Item2}.");

            ShowColored($"\n - - - - - - - - - - - - Selection sort - - - - - - - - - - - -", ConsoleColor.Green);

            var selectionSorted = SelectionSort(Rewrite(arr));
            DisplayArray($"Sorted: ", selectionSorted);

            ShowColored($"\n\n - - - - - - - - - - - - Bubble sort - - - - - - - - - - - - -", ConsoleColor.Green);

            var bubbleSorted = BubbleSort(Rewrite(arr));
            DisplayArray($"Sorted: ", bubbleSorted);

            ShowColored($"\n\n - - - - - - - - - - - - Quick sort - - - - - - - - - - - - - -", ConsoleColor.Green);

            int countIteration = 0;
            QuickSort(arr, 0, arr.Length - 1, ref countIteration);
            ShowColored($"Count iteration: {countIteration}.", ConsoleColor.Red);
            DisplayArray($"Sorted: ", arr);

            ShowColored($"\n\n - - - - - - - - - - - - Binary search - - - - - - - - - - - -", ConsoleColor.Green);

            Console.Write("Enter number for searching: ");
            if (int.TryParse(Console.ReadLine(), out int search))
            {
                Console.WriteLine($"BinarySearch result(array index): {BinarySearch(arr, search)}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        static (int, int) MinMax(int[] arr)
        {
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
            return (min, max);
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
            ShowColored($"Count iteration: {countIteration}.", ConsoleColor.Red);

            return sorted;
        }

        static int[] BubbleSort(int[] arr)
        {
            int temp, countIteration = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    if ((j + 1) < arr.Length && arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                    countIteration++;
                }
            }
            ShowColored($"Count iteration: {countIteration}.", ConsoleColor.Red);

            return arr;
        }

        static int BinarySearch(int[] sortedArr, int searchNum)
        {
            int countIteration = 0, low = 0;
            int high = sortedArr.Length - 1;

            while (low <= high)
            {
                countIteration++;
                int mid = (low + high) / 2;

                if (sortedArr[mid] == searchNum)
                {
                    ShowColored($"Count iteration: {countIteration}.", ConsoleColor.Red);
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

            ShowColored($"Count iteration: {countIteration}.", ConsoleColor.Red);
            return -1;
        }

        static void QuickSort(int[] arr, int low, int high, ref int countIteration)
        {
            if (low < high)
            {
                int pivotValue = arr[high];
                int pivotIndex = low;

                for (int i = low; i < high; i++)
                {
                    if (arr[i] < pivotValue)
                    {
                        int curr = arr[i];
                        arr[i] = arr[pivotIndex];
                        arr[pivotIndex] = curr;
                        pivotIndex++;
                    }
                    countIteration++;
                }

                int pivot = arr[pivotIndex];
                arr[pivotIndex] = arr[high];
                arr[high] = pivot;

                QuickSort(arr, low, pivotIndex - 1, ref countIteration);
                QuickSort(arr, pivotIndex + 1, high, ref countIteration);
            }
        }

        static int FindCountElementsInArr_Recursion(int[] arr, int index = 0)
        {
            if (index >= arr.Length)
            {
                return index;
            }

            return FindCountElementsInArr_Recursion(arr, index + 1);
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

        static void ShowColored(string text, ConsoleColor color)
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
                if (i == arr.Length - 1)
                {
                    Console.Write($"{arr[i]}.");
                    break;
                }
                Console.Write($"{arr[i]} ");
            }
        }
    }
}
