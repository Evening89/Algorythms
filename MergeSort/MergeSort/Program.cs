using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> A = new List<int> (new int[] { 1, 5, 3, 2, 6, 8, 3, 2, 4, 1, 7 });
            A = DoMergeSort(A);

            foreach (var a in A)
                Console.Write(a + " ");
            Console.ReadLine();
        }

        static List<int> DoMergeSort(List<int> A)
        {
            int middle = A.Count / 2;
            List<int>   leftA = new List<int>(), 
                        rightA = new List<int>();

            for (int i = 0; i < middle; i++)
                leftA.Add(A[i]);
            for (int i = middle; i < A.Count; i++)
                rightA.Add(A[i]);

            leftA = InsertionSortArray(leftA);
            rightA = InsertionSortArray(rightA);
            return MergeArrays(leftA, rightA);
        }

        static List<int> MergeArrays(List<int> leftA, List<int> rightA)
        {
            List<int> merged = new List<int>();
            //int lessCount = (leftA.Count < rightA.Count)? 
            //            leftA.Count : 
            //            rightA.Count;

            int leftIndex = 0, rightIndex = 0;
            do
            {
                if (leftIndex == leftA.Count)
                {
                    while (rightIndex < rightA.Count)
                    {
                        merged.Add(rightA[rightIndex]);
                        rightIndex++;
                    }
                    break;
                }
                if (rightIndex == rightA.Count)
                {
                    while (leftIndex < leftA.Count)
                    {
                        merged.Add(leftA[leftIndex]);
                        leftIndex++;
                    }
                    break;
                }            
                if (leftA[leftIndex] < rightA[rightIndex])
                {
                    merged.Add(leftA[leftIndex]);
                    leftIndex++;
                    continue;
                }
                if (leftA[leftIndex] > rightA[rightIndex])
                {
                    merged.Add(rightA[rightIndex]);
                    rightIndex++;
                    continue;
                }
                
                if (leftA[leftIndex] == rightA[rightIndex])
                {
                    merged.Add(leftA[leftIndex]);
                    merged.Add(rightA[rightIndex]);
                    leftIndex++;
                    rightIndex++;
                    continue;
                }
            }
            while (leftIndex <= leftA.Count && rightIndex <= rightA.Count);
            return merged;
        }

        static List<int> InsertionSortArray(List<int> array)
        {
            for (int i = 1; i < array.Count; i++)
            {
                if (array[i] < array[i - 1]) 
                {
                    for (int j = i; j > 0; j--)
                    {
                        if (array[j] > array[j - 1]) break;
                        int buf = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = buf;
                    }
                }
            }
            return array;
        }
    }
}
