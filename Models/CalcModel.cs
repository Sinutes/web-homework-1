using System;

namespace Backend1.Models
{
    public class CalcModel
    {
        public int _firstRandom;
        public int _secondRandom;
        public string _title = "PassUsingModel";


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

        public string div()
        {
            try {
                var result = _firstRandom / _secondRandom;
                return result.ToString();
            }
            catch (DivideByZeroException) {
                Console.Write("error");
                return "error";
            }
        }
    }
}
