using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedruns
{
    internal class Speedrun
    {
        private string runner;
        private int place;
        private float time;
        private string cat;

        public Speedrun(string runner, int place, float time, string cat)
        {
            this.runner = runner;
            this.place = place;
            this.time = time;
            this.cat = cat;
        }

        public Speedrun(string runner, int place, string time, string cat)
        {
            this.runner = runner;
            this.place = place;
            string[] formats = { @"hh\:mm\:ss\.fff", @"mm\:ss\.fff", @"ss\.fff" };
            float ts = Convert.ToSingle(Math.Round(TimeSpan.ParseExact(time, formats, null).TotalSeconds, 2));
            this.time = ts;
            this.cat = cat;
        }

        public TimeSpan Time_TS
        {
            get => TimeSpan.FromSeconds(this.time);
        }

        public float Time_F
        {
            get => this.time; 
        }

        public string Cat
        {
            get => this.cat;
        }

        public int Place
        {
            set
            {
                if (value > 0)
                {
                    this.place = value;
                }
            }
        }

        public override string ToString()
        {
            TimeSpan ts = TimeSpan.FromSeconds(time);
            string formatted = ts.TotalHours >= 1
                ? $"{((int)ts.TotalHours).ToString("D2")}:" + ts.ToString(@"mm\:ss\.fff")
                : ts.ToString(@"mm\:ss\.fff");
            return $"{this.runner} placed No. {place} on the {cat} leaderboards with a time of {formatted}";
        }
    }
}
