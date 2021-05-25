using System;
using System.Linq;

namespace RandomD20Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new D20SplitGenerator();

            generator.GetSplit();

            if (!generator.IsEvenSplit())
            {
                Enumerable.Range(1, generator.Split).ToList().ForEach(_ => {
                    generator.SetResultGroup(_);
                });
            }

            generator.FillGroups();
            generator.ShowGroups();
        }
    }
}
