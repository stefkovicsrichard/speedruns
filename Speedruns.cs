using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedruns
{
    internal class Speedruns
    {
        private string game;
        private float wr;
        private List<Speedrun> runs;

        public Speedruns(string game, List<Speedrun> runs)
        {
            this.game = game;
            this.runs = runs;
            this.wr = runs[0].Time;
        }

        public Speedruns(string path)
        {
            StreamReader sr = new StreamReader(path);
            this.game = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');
                string runner = line[0];
                int place = int.Parse(line[1]);
                //float time = TimeSpan.TryParse();
            }
        }
    }
}
