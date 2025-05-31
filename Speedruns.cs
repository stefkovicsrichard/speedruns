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
        private List<Speedrun> runs = new List<Speedrun>();
        private List<string> cats;

        public Speedruns(string path)
        {
            StreamReader sr = new StreamReader(path);
            this.game = sr.ReadLine();
            this.cats = new List<string>(sr.ReadLine().Split(';'));
            Random r = new Random();
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(';');
                AddRun(this.game, line[0], line[1], line[2], r);
            }
            sr.Close();
        }

        public void AddRun(string game, string runner, string time, string cat, Random r)
        {
            if (ValidCat(cat) || cat == "r")
            {
                if (cat == "r")
                {
                    cat = Cats[r.Next(Cats.Count)];
                }
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
                    if (float.Parse(time) == 0)
                    {
                        string ts = $"{r.Next(5):D2}:{r.Next(60):D2}:{r.Next(60)+r.NextDouble():00.000}";
                        Console.WriteLine(ts);
                        run = new Speedrun(game, runner, place, ts, cat);
                    }
                    else
                    {
                        float t = float.Parse(time);
                        run = new Speedrun(game, runner, place, t, cat);
                    }
                }
                else
                {
                    string t = time;
                    run = new Speedrun(game, runner, place, t, cat);
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
                Renum(list, asc);
                return list;
            }
            else if (ValidCat(cat))
            {
                //find all elements (e) where element.Category equals the desired category
                List<Speedrun> list = new List<Speedrun>(runs).FindAll(e => e.Cat == cat);
                if (sort) Sort(list, asc); 
                Renum(list, asc);
                return list;
            }
            Console.WriteLine("Incorrect category");
            return new List<Speedrun>();
        }

        public Speedrun GetWR(string cat = "all", bool slowrun = false)
        {
            List<Speedrun> list = new List<Speedrun>(runs).FindAll(e => e.Cat == cat);
            Sort(list, slowrun);
            return list[list.Count-1];
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

        public void Sort(List<Speedrun> list, bool asc = true)
        {
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if ((!asc && list[j+1].Time_F > list[j].Time_F) || (asc && list[j].Time_F > list[j+1].Time_F))
                    {
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    }
                }
            }
        }

        private void Renum(List<Speedrun> list, bool asc = true)
        {
            int j = 0;
            for (int i = asc ? 0 : list.Count-1; (asc ? i : 0) < (asc ? list.Count : i); i += asc ? 1 : -1)
            {
                list[j].Place = i + 1;
                j++;
            }
        }

        public void General(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine("TRUNCATE speedrun;");
            sw.WriteLine("INSERT INTO speedrun(runner,place,ido,category)");
            sw.WriteLine("VALUES");
            sw.Write($"({runs[0].Runner}, {runs[0].Place}, {runs[0].Time_F}, {runs[0].Cat}");
            for (int i = 1; i < runs.Count; i++)
            {
                sw.Write($"),\n({runs[i].Runner}, {runs[i].Place}, {runs[i].Time_F}, {runs[i].Cat}");
            }
            sw.WriteLine(");");
            sw.Close();
        }
    }
}
