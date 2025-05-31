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
                AddRun(line[0], line[1], line[2]);
            }
            sr.Close();
        }

        public void AddRun(string runner, string time, string cat)
        {
            if (ValidCat(cat))
            {
                int j = 1;
                foreach (Speedrun s in runs)
                {
                    if (s.Cat == cat)
                    {
                        j++;
                    }
                }
                int place = j;
                string[] tl = time.Split(':');
                Speedrun run;
                if (tl.Length == 1)
                {
                    float t = float.Parse(time);
                    run = new Speedrun(runner, place, t, cat);
                }
                else
                {
                    string t = time;
                    run = new Speedrun(runner, place, t, cat);
                }
                runs.Add(run);
            }
            else
            {
                Console.WriteLine("Invalid category, run not added.");
            }
        }

        public List<Speedrun> GetRuns(string cat = "all", bool sort = true, bool asc = true)
        {
            if (cat == "all")
            {
                List<Speedrun> list = new List<Speedrun>(runs);
                if (sort) Sort(list, asc);
                return list;
            }
            else if (ValidCat(cat) && runs.Count > 0)
            {
                List<Speedrun> list = new List<Speedrun>(runs).FindAll(e => e.Cat == cat);
                if (sort) Sort(list, asc); else Renum(list);
                return list;
            }
            Console.WriteLine("Incorrect category");
            return new List<Speedrun>();
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

        public void Sort(List<Speedrun> runs, bool asc = true)
        {
            int n = runs.Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if ((!asc && runs[j+1].Time_F > runs[j].Time_F) || (asc && runs[j].Time_F > runs[j+1].Time_F))
                    {
                        (runs[j], runs[j + 1]) = (runs[j + 1], runs[j]);
                    }
                }
            }
            Renum(runs, asc);
        }

        private void Renum(List<Speedrun> runs, bool asc = true)
        {
            int k = 0;
            for (int i = asc ? 0 : runs.Count; (asc ? i : runs.Count) < (asc ? runs.Count : i); i += asc ? 1 : -1)
            {
                runs[k].Place = i + 1;
                k++;
            }
        }
    }
}
