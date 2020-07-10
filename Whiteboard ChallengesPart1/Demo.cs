using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard_ChallengesPart1
{
    class Demo
    {

        AdditionByIndex additionByIndex;


        public Demo()
        {
            additionByIndex = new AdditionByIndex();

        }


        public void AdditionByIndex(int minValue, int maxValue, int arraySize)
        {

            additionByIndex.DisplayProblemSet(additionByIndex.GetProblemSet(minValue, maxValue, arraySize));

            Console.ReadLine();
        }

    }
}
