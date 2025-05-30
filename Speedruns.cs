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
        private List<Speedrun> runs = new List<Speedrun>();
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
                string cat;
                if (ValidCat(line[2]))
                {
                    cat = line[2];
                    int j = 1;
                    foreach (Speedrun s in runs)
                    {
                        if (s.Cat == cat)
                        {
                            j++;
                        }
                    }
                    int place = j;
                    Console.WriteLine($"{runner} {place}");
                    string[] tl = line[1].Split(':');
                    Speedrun run;
                    if (tl.Length == 1)
                    {
                        float time = float.Parse(line[1]);
                        run = new Speedrun(runner, place, time, cat);
                    }
                    else
                    {
                        string time = line[1];
                        run = new Speedrun(runner, place, time, cat);
                    }
                    runs.Add(run);
                }
                else
                {
                    Console.WriteLine("Invalid category, run skipped.");
                }
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
