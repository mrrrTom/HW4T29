// Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// 6, 1, 33 -> [6, 1, 33]

using System.Text;

namespace GBArrayGenerator
{
    public class ConsoleApp
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the integer array generator!");
            var stringArray = new StringArray(8);
            stringArray.RandomInitialization();
            Console.WriteLine(stringArray.Output);
        }
    }

    public static class ArrayExtension
    {
        public static void RandomInitialization(this StringArray array)
        {
            var l = default(int);
            if (array == null ||  (l = array.Length) < 1)
            {
                return;
            }

            var rnd = new Random();
            for (var i = 0; i < l; i++)
            {
                array.Add(rnd.Next());
            }
        }
    }

    public class StringArray
    {
        private readonly int _arraySize;
        private int _addCount;
        private string _array = string.Empty;
        private StringBuilder _tempArray;
        public StringArray (int arraySize)
        {
            _tempArray = new StringBuilder();
            _tempArray.Append('[');
            _arraySize = arraySize;
            _addCount = 1;
        }

        public int Length { get => _arraySize; }
        public string Output { get => _array; }

        public void Add(int input)
        {
            if (_addCount > _arraySize)
            {
                return;
            }
            
            _tempArray.Append(input);
            if (_addCount == _arraySize)
            {
                _tempArray.Append(']');
                _array = _tempArray.ToString();
            }
            else
            {
                _tempArray.Append(',');
                _tempArray.Append(' ');
            }

            _addCount++;
        }
    }
}