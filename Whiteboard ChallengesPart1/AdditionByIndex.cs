using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard_ChallengesPart1
{
    class AdditionByIndex
    {
        Random rng;

        public AdditionByIndex()
        {
            rng = new Random();
        }
        public int[][] GetProblemSet(int minValue, int maxValue, int arraySize)
        {
            int[] randomArray = new int[arraySize];
            int[] allPossibleSums = new int[CalculateCountOfSums(arraySize)];
            int sumsIndex = 0;

            randomArray = InitializeRandomArray(minValue, maxValue, arraySize);

            for(int i = 0; i < arraySize - 1; i++)
            {
                for(int j = i + 1; j < arraySize; j++)
                {
                    int sumOfPair = randomArray[i] + randomArray[j];
                    allPossibleSums[sumsIndex] = sumOfPair;
                    sumsIndex++;
                }   
            }
            int[][] problemSet = new int[][] { randomArray, allPossibleSums };

            return problemSet;
        }
        public int[] InitializeRandomArray(int minValue, int maxValue, int arraySize)
        {
            
            int[] randomArray = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                randomArray[i] = rng.Next(minValue, maxValue);
            }

            randomArray = CheckforDuplicates(randomArray, minValue, maxValue, arraySize);

            return randomArray;
        }
        private int[] CheckforDuplicates(int[] array, int minValue, int maxValue, int arraySize)
        {
            bool hasDuplicate = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if(array[i] == array[j])
                    {
                        hasDuplicate = true;
                    }
                }

            }
            if(hasDuplicate)
            {

                array = InitializeRandomArray(minValue, maxValue, arraySize);
            }
            return array;
        }
        public int CalculateCountOfSums(int arraySize)
        {
            int result = 0;

            for(int i = (arraySize - 1); i > 0; i--)
            {
                result += i;
            }
            return result;
        }
        public void DisplayProblemSet(int[][] problemSet)
        {
            int[] givenArray = problemSet[0];
            int[] allPossibleSums = problemSet[1];
            int spacer = 0; // Spaces to push #+ in tree
            int sumsIndex = 0;

            foreach (int number in givenArray)
            {
                Console.Write($"{number,5},");
            }
            Console.WriteLine();
            for (int i = 0; i < givenArray.Length - 1; i++)
            {
                Console.Write($"{givenArray[i],5}+");
                for (int j = i + 1; j < givenArray.Length; j++)
                {
                    Console.Write($"{allPossibleSums[sumsIndex],5},");
                    sumsIndex++;
                }
                Console.WriteLine("");
                while(spacer < i + 1)
                {
                    Console.Write($"------");
                    spacer++;
                }
                spacer = i < givenArray.Length - 3 ? 0 : -1;
            }
            Console.ReadLine();
        }

    }
}
