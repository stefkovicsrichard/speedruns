using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedruns
{
    internal class Speedrun
    {
        private string game;
        private string runner;
        private int place;
        private float time;
        private string cat;

        public Speedrun(string game, string runner, int place, float time, string cat)
        {
            this.game = game;
            this.runner = runner;
            this.place = place;
            this.time = time;
            this.cat = cat;
        }

        public Speedrun(string game, string runner, int place, string time, string cat)
        {
            this.game = game;
            this.runner = runner;
            this.place = place;
            string[] formats = { @"hh\:mm\:ss\.fff", @"hh\:mm\:ss", @"h\:mm\:ss\.fff", @"h\:mm\:ss", @"mm\:ss\.fff", @"mm\:ss", @"ss\.fff", @"ss" };
            float ts = Convert.ToSingle(Math.Round(TimeSpan.ParseExact(time, formats, null).TotalSeconds, 2));
            this.time = ts;
            this.cat = cat;
        }

        public string Runner
        {
            get => this.runner;
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
            get => this.place;
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
            return $"{this.runner} placed No. {place} on {game}'s {cat} leaderboards with a time of {formatted}";
        }

        
    }
}
