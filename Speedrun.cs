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
            float ts = Convert.ToSingle(Math.Round(TimeSpan.Parse(time).TotalSeconds, 2));
            this.time = ts;
            this.cat = cat;
        }

        public TimeSpan Time_TS
        {
            get { return TimeSpan.FromSeconds(this.time); }
        }

        public float Time_F
        {
            get { return this.time; }
        }

        public string Cat
        {
            get => this.cat;
        }
    }
}
