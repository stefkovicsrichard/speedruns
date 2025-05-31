using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedruns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Speedruns hl1 = new Speedruns("hl1.txt");
            foreach (Speedrun s in hl1.GetRuns("won"))
            {
                Console.WriteLine(s.ToString());
            }
        }
    }
}
