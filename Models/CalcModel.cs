using System;

namespace Backend1.Models
{
    public class CalcModel
    {
        public int _firstRandom;
        public int _secondRandom;

        public CalcModel()
        {
            var rand = new Random();

            _firstRandom = rand.Next(0, 10);
            _secondRandom = rand.Next(0, 10);
        }

        public int add()
        {
            return _firstRandom + _secondRandom;
        }

        public int sub()
        {
            return _firstRandom - _secondRandom;
        }

        public int mult()
        {
            return _firstRandom * _secondRandom;
        }

        public int div()
        {
            try {
                int result = _firstRandom / _secondRandom;
                return result;
            }
            catch (DivideByZeroException) {
                Console.Write("error");
                return -1;
            }
        }
    }
}
