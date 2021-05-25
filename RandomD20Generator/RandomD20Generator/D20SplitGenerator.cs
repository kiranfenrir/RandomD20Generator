using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomD20Generator
{
    public class D20SplitGenerator
    {
        private int _split = 1;
        private List<int[]> _resultGroups = new List<int[]>();
        private const double _dieSides = 20; //using double for consistent math calculations.
        private List<int> _usedNumbers = new List<int>();

        public int Split => _split;

        public void GetSplit()
        {
            Console.WriteLine("Split how many ways?");
            var entry = Console.ReadLine();

            if(int.TryParse(entry, out int split))
            {
                _split = split;
            }
            else
            {
                Console.WriteLine("Invalid value entered.");

                GetSplit();
            }
        }

        public bool IsEvenSplit()
        {
            Console.WriteLine("Evenly Split results? (Y or N)");
            var entry = Console.ReadKey().KeyChar.ToString().ToLower();
            Console.WriteLine();

            switch (entry)
            {
                case "y":
                    SetEvenSplit();
                    return true;
                case "n":
                    return false; 
                default:
                    Console.WriteLine("Invalid value entered.");
                    return IsEvenSplit();
            }
        }

        private void SetEvenSplit()
        {
            var groupSize = Convert.ToInt32(Math.Floor(_dieSides / _split));
            Enumerable.Range(1, _split).ToList().ForEach(_ => _resultGroups.Add(new int[groupSize]));
        }

        public void SetResultGroup(int groupNum)
        {
            Console.WriteLine($"Enter size of group {groupNum}");
            var entry = Console.ReadLine();

            if(int.TryParse(entry, out int size))
            {
                _resultGroups.Add(new int[size]);
            }
            else
            {
                Console.WriteLine("Invalid value entered.");
                SetResultGroup(groupNum);
            }
        }

        public void FillGroups()
        {
            _resultGroups.ForEach(_ =>
            {
                for(var i = 0; i < _.Length; i++)
                {
                    var num = 0;
                    do
                    {
                        num = new Random().Next(1, (int)_dieSides + 1);
                    } while (_usedNumbers.Contains(num));

                    _usedNumbers.Add(num);
                    _[i] = num;
                }
            });
        }

        public void ShowGroups()
        {
            for(int groupIdx = 0; groupIdx < _resultGroups.Count; groupIdx++)
            {
                Console.WriteLine($"Group {groupIdx + 1} values:");
                Console.WriteLine("-------------------------");
                Console.WriteLine(string.Join(",", _resultGroups[groupIdx]));
                Console.WriteLine();
            }
        }
    }
}
