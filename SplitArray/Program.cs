using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 11, 22, 31, 42, 4}; 

            // for manual input
            /*
            int n;
            Console.Write("n= ");
            n = Convert.ToInt32(Console.ReadLine());
            int[] A=new int[n] ;
            Console.WriteLine("A[]=: ");
            var stringArray=Console.ReadLine().Split(' ');
            for (int i = 0; i < stringArray.Length; i++)
            {
                A[i] = Convert.ToInt32(stringArray[i]);
            }
            */
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine(splitArray(A));
            Console.Read();
        }

        private static bool splitArray(int[] array)
        {
            int b,B,A,a;
            /* if A is the sum of the given array and B and C are the sum of the splitted arrays
             and a,b and c are the lengths of the arrays
             then if the splitted arrays have the same average 
             then B/b==C/c => B/b=(A-B)/(a-b) => B*a-B*b=A*b-B*b => B=A*b/a 
             A is an integer sum => B is an integer sum => A*b%a==0
            */
            Array.Sort(array);
            A=sum(array);
            a=array.Length;
            for(int i = 1; i <= a/2; i++) //checking the lengths from 1 to a/2 so we will obtain the shorter array that is !=null
            {
                if (A * i % a == 0) //obtain targeted sum + length 
                {
                    b = i;   // first array length
                    B = A * i / a; // first array sum
                    //if(rec(0, B, array, b, 0, a - 1)) return true; //checking if it's possible to obtain the sum

                    //for displaying the splitted arrays in console
                   
                    int[] finalarray = {};
                    if(rec(0, B, array, b,0, a - 1, finalarray)) return true;
                    
                }
            }
            return false;
        }
        // using recursivity we will try to obtain the targeted sum starting from biggest integer in the sorted array
        private static bool rec(int current_sum, int target_sum,int[] array,int b,int c,int index)
        {
            if (b == c && current_sum == target_sum) return true; // checking if the resulted length and sum meet the required values
            if (b == c && current_sum != target_sum) return false;
            if (index < 0) return false;
            for (int i = index; i >=0; i--)
            {
                if (current_sum + array[i] <= target_sum) 
                    if(rec(current_sum + array[i], target_sum, array, b, c + 1, i - 1)) return true;
            }
            return rec(current_sum , target_sum, array, b,c, index - 1);
        }
        // this function has an extra parameter the display the splitted arrays
        private static bool rec(int current_sum, int target_sum, int[] array, int b, int c, int index, int[] finalarray)
        {
            if (b == c && current_sum == target_sum)
            {
                Array.Sort(finalarray);
                Console.Write("{");
                for (int i = 0; i < finalarray.Length; i++)
                {
                    Console.Write(finalarray[i] + ",");
                }
                Console.Write("\b} {");
                int j = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if(array[i] == finalarray[j]) { j++; }
                    else Console.Write(array[i] + ",");
                }
                Console.Write("\b}");Console.WriteLine();
                return true;
            }
            if (b == c && current_sum != target_sum) return false;
            if (index < 0) return false;

            for (int i = index; i >= 0; i--)
            {
                if (current_sum + array[i] <= target_sum)
                {
                    if (rec(current_sum + array[i], target_sum, array, b, c + 1, i - 1, finalarray.Concat(new int[] { array[i] }).ToArray())) return true;
                }
            }
            return rec(current_sum, target_sum, array, b, c, index - 1, finalarray);
        }
        private static int sum(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
                sum += a[i];
            return sum;
        }
        
    }
}
