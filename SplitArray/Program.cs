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
            //int[] A = { 1, 7, 9, 11, 15, 29 }; 
            int[] A = { 1, 2, 3, 4, 5, 6, 7, 8 }; 

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
            /* if A=sum(a) B=sum(b) C=sum(c) a=A.length b=B.length c=C.length and B+C=A b+c=a
            then B/b==C/c => B/b=(A-B)/(a-b) => B*a-B*b=A*b-B*b => B=A*b/a 
            A is an integer sum => B is an integer => A*b%a==0
            */
            Array.Sort(array);
            A=sum(array);
            a=array.Length;
            for(int i = 1; i <= a/2; i++)
            {
                if (A * i % a == 0) //obtain targeted sum + length
                {
                    b = i;   // first array length
                    B = A * i / a; // first array sum
                    return rec(0, B, array, b, 0, a - 1); //checking if it's possible to obtain the sum
                    
                    /*
                    int[] finalarray = {};
                    return rec(0, B, array, b,0, a - 1, finalarray);
                    */ //for displaying the splitted array in console
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

        private static bool rec(int current_sum, int target_sum, int[] array, int b, int c, int index, int[] finalarray)
        {
            if (b == c && current_sum == target_sum)
            {
                for (int i = 0; i < finalarray.Length; i++)
                {
                    Console.Write(finalarray[i] + " ");
                }
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
