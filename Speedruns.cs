using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace speedruns
{
    internal class Speedruns
    {
        private string game;
        private float wr;
        private List<Speedrun> runs;
        private List<string> cats;

        public Speedruns(string path)
        {
            StreamReader sr = new StreamReader(path);
            this.game = sr.ReadLine();
            this.cats = new List<string>(sr.ReadLine().Split(';'));
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');
                string runner = line[0];
                int place = int.Parse(line[1]);
                string time = line[2];
                string cat;
                if (ValidCat(line[3]))
                {
                    cat = line[3];
                }
                else
                {
                    throw new DataException("Invalid category, run has not been added to object.");
                }
                Speedrun run = new Speedrun(runner, place, time, cat);
                runs.Add(run);
            }
            sr.Close();
        }

        public List<string> Cats
        {
            get => new List<string>(cats);
        }

        public bool ValidCat(string cat)
        {
            if (this.Cats.Contains(cat))
            {
                return true;
            }
            return false;
        }
    }
}
