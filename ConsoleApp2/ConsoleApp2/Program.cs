using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check whether the total of the number of sequence is odd.
            int n=0;
            int i=0;
            int[] arr = new int[11];

            string[] num = new string[11];

            // Initialize arr
            for(int j=0; j<11; j++)
            {
                arr[j] = 0;
            }
            
            Console.Write("請輸入整數序列(輸入空行結束): ");
            Console.Write("\n");

            while (true)
            {
                num[i] = Console.ReadLine();
                if(num[i] != "")
                {
                    arr[i] = int.Parse(num[i]);
                }  

                if(num[i] == "")
                {
                    break;
                }

                // Count the times of loop(i), and count the elements of input arr(n)
                i++;
                n++;
            }
  
            // Sort the elements of arr from small to big 
            for (int j = 0; j < n - 1; j++)
            {
                for (int k = 0; k < n - j - 1; k++)
                {
                    if (arr[k] > arr[k + 1])
                    {
                        int temp = arr[k];
                        arr[k] = arr[k + 1];
                        arr[k + 1] = temp;
                    }
                }
            }

            // find the median
            int m = arr[n / 2];

            // Sort the elements of arr for the rule
            for (int j = 0; j < n - 1; j++)
            {
                for (int k = 0; k < n - j - 1; k++)
                {
                    if (Math.Abs(arr[k] - m) < Math.Abs(arr[k + 1] - m))
                    {
                        int temp = arr[k];
                        arr[k] = arr[k + 1];
                        arr[k + 1] = temp;
                    }
                    if ((Math.Abs(arr[k] - m) == Math.Abs(arr[k + 1] - m)) && (arr[k] < arr[k + 1]))
                    {
                        int temp = arr[k];
                        arr[k] = arr[k + 1];
                        arr[k + 1] = temp;
                    }
                }
            }

            for (int j = 0; j < n; j++)
            {
                Console.Write(arr[j]);
                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}
