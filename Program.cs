using System;
using System.Collections.Generic;
using System.Linq;

namespace dstra
{
    class Program
    {
        public static IEnumerable<int[]> Dikjstra(int [] src)
        {
            while(true)
            {
                yield return src;
                int j = src.Length - 2;
                while (j != -1 && src[j] >= src[j + 1]) 
                    j--;
                if (j == -1)
                   break; 
                int k = src.Length-1;
                while(src[k]<=src[j]) 
                    k--;
                Swap(ref src[j],ref src[k]);
                j++;
                k = src.Length-1;
                while(j<k)
                    Swap(ref src[j++],ref src[k--]);
            }
            void Swap(ref int left, ref int right)
            {
                int temp = left;
                left = right;
                right = temp;
            }
        }
        static void Main(string[] args)
        {
            int [] a =Enumerable.Range(1,5).ToArray();
            int permutation = 1;
            foreach (var item in Dikjstra(a))
            {
                ConsoleColor temp = System.Console.ForegroundColor;
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Write($"Permutation {permutation++} ");
                System.Console.ForegroundColor = temp;
                foreach (var el in a)
                    System.Console.Write(el+" ");
                System.Console.WriteLine();
            }
        }
    }
}
