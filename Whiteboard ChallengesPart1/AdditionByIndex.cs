﻿using System;
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
            int[] allPossibleSums = new int[CalculateCountOfSumsFormula(arraySize)];
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
        public int CalculateCountOfSumsFormula(int arraySize)
        {
            // Answers are recognizable as Triangular Numbers according to research.
            // 1,3,4,5  Accept ours with value arraySize = 2 is the first number.
            // Equation for nth term = 1/2n(n + 1)
            // Our modification for nth term where (1/2(n-1))((n-1) + 1) = (1/2(n-1))*n
            //double result = (.5 * ((double)arraySize-1)) * (double)arraySize;
            
            return  ((arraySize -1) * arraySize) / 2;
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
        public void SolveProblemSet(int[][] problemSet)
        {
            int[] givenArray = problemSet[0];
            int[] allPossibleSums = problemSet[1];

            int indexOfToSolve = rng.Next(0, allPossibleSums.Length + 1); // study note: Bound(inclusive, exclusive)
            int solveFor = allPossibleSums[indexOfToSolve];

            DisplaySolveParameters(givenArray, solveFor);

        }

        private void DisplaySolveParameters(int[] givenArray, int solveFor)
        {
            Console.WriteLine("Given an array of integers and a value, find the indices of the two values\nthat when added together equal the value.\nThe Given Array:\n");
            for(int i = 0; i < givenArray.Length; i++)
            {
                Console.Write($"{givenArray[i]}{(i != (givenArray.Length - 1) ? "," : "\n")}");
            }
            Console.WriteLine($"The value to solve for.\n{solveFor}\n");
        }
    }
}


