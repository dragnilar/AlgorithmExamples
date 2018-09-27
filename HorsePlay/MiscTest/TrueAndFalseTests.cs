using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
    class TrueAndFalseTests
    {
        public void RunTests()
        {
            Console.Clear();
            IfTrueTest();
            Console.WriteLine();
            IfFalseTest();
            Console.WriteLine();
            IfTrueAndFalseTest();
            Console.WriteLine();
            IfTrueOrFalseTest();
            Console.WriteLine();
            IfTrueAndFalseOrFalseOrTrueTest();
            Console.WriteLine();
            IfTrueAndFalseAndTrueAndFalse();
            Console.WriteLine();
            Summary();
        }
        private void IfTrueTest()
        {
            Console.WriteLine("If true...");
            if (true)
            {
                Console.WriteLine("Always true, will always run.");
            }
        }

        private void IfFalseTest()
        {
            Console.WriteLine("If false....");
            if (false)
            {
            }

            Console.WriteLine("Always false, will never run.");
        }

        private void IfTrueAndFalseTest()
        {
            Console.WriteLine("If true && false....");
            if (true && false)
            {

            }

            Console.WriteLine("True and false is always false and will never run.");
        }

        private void IfTrueOrFalseTest()
        {
            Console.WriteLine("If true || false....");
            if (true || false)
            {
                Console.WriteLine("True or false is always true and will always run.");
            }
        }

        private void IfTrueAndFalseOrFalseOrTrueTest()
        {
            Console.WriteLine("If (true && false) || (true || false)....");
            if ((true && false) || (false || true))
            {
                Console.WriteLine("(True and False) or (False or True) is always true and will always run.");
            }
        }

        private void IfTrueAndFalseAndTrueAndFalse()
        {
            Console.WriteLine("If (true && false) && (true && false)....");
            if ((true && false) && (true && false))
            {

            }

            Console.WriteLine("(True and False) and (True And False) is always false and will never run.");
        }

        private void Summary()
        {
            Console.WriteLine("----SUMMARY-----");
            Console.WriteLine("When true or false, true always trumps false.");
            Console.WriteLine("When true AND false, false always trumps true.");
            Console.WriteLine("When mixing nested conditions, evaluate each one internally for true or false\n" +
                              "and then compare the overall trues versus falses to get the actual outcome.");
            Console.WriteLine("End of true and false test, press any key to return to main menu.\n");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
