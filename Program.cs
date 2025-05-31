using System;
using System.Collections.Generic;
using System.IO;
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

            Console.WriteLine("\nAll categories:");
            foreach (Speedrun s in hl1.GetRuns())
            {
                Console.WriteLine(s.ToString());
            }

            Console.WriteLine("\nwon category, descending:");
            foreach (Speedrun s in hl1.GetRuns(hl1.Cats[2], true, false))
            {
                Console.WriteLine(s.ToString());
            }

            Console.WriteLine("\nwon category, ascending:");
            foreach (Speedrun s in hl1.GetRuns(hl1.Cats[2]))
            {
                Console.WriteLine(s.ToString());
            }

            Console.WriteLine("\nwon category world record (fastest time): " + hl1.GetWR(hl1.Cats[2]).ToString());
            Console.WriteLine("worst recorded won category run: " + hl1.GetWR(hl1.Cats[2], true).ToString());

            //----------------------------------

            Speedruns sm64 = new Speedruns("sm64.txt");

            sm64.GetRuns();
            sm64.General("sql.sql");
        }
    }
}
