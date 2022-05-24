using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input_num = 1;

            Console.Write("請輸入六邊形的寬度(n>=2), 輸入0離開: ");

            // input a integer until the integer == 0
            while (input_num != 0)
            {

                // input a integer when while loop run repeatly
                input_num = int.Parse(Console.ReadLine());

                if (input_num == 0)
                {
                    Console.WriteLine("The End");
                }

                if (input_num >= 2)
                {

                    // set the blank spaces in front of the stars
                    for (int i = 0; i < input_num; i++)
                    {
                        Console.Write(" ");
                    }

                    // set the continuous stars(first line)
                    for (int i = 0; i < (2 * input_num) - 1; i++)
                    {
                        Console.Write("*");
                    }

                    Console.Write("\n");

                    // set the stars of hypotenuse(upper)
                    for (int i = 0; i < input_num - 1; i++)
                    {

                        for (int j = 0; j < (4 * input_num) - 3 ; j++)
                        {
                            Console.Write(" ");
                            if ( (j == input_num - i - 2) || (j == ((4 * input_num - 3) - 1 - (input_num - 1)) + i) )
                            {
                                Console.Write("*");
                            }
                        }

                        Console.Write("\n");
                    }

                    // set the stars of hypotenuse(lower)
                    for (int i = 0; i < input_num - 2; i++)
                    {
                        for (int j = 0; j < (4 * input_num) - 3 ; j++)
                        {
                            Console.Write(" ");
                            if (j == i + 1 || j == ( (4 * input_num) - 3 - 3 - i) )
                            {
                                Console.Write("*");
                            }
                        }
                        Console.Write("\n");
                    }

                    // set the blank spaces in front of the stars
                    for (int i = 0; i < input_num; i++)
                    {
                        Console.Write(" ");
                    }

                    // set the continuous stars(last line)
                    for (int i = 0; i < (2 * input_num) - 1; i++)
                    {
                        Console.Write("*");
                    }

                    Console.Write("\n");
                }
            }
        }
    }
}
