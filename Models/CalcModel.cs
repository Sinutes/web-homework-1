using System;

namespace Backend1.Models
{
    public class CalcModel
    {
        public int add(int firstInt, int secondInt)
        {
            return firstInt + secondInt;
        }

        public int sub(int firstInt, int secondInt)
        {
            return firstInt - secondInt;
        }

        public int mult(int firstInt, int secondInt)
        {
            return firstInt * secondInt;
        }

        public int div(int firstInt, int secondInt)
        {
            try {
                int result = firstInt / secondInt;
                return result;
            }
            catch (DivideByZeroException) {
                Console.Write("error");
                return -1;
            }
        }
    }
}
