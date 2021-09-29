using System;

namespace _2_1P11_Nest
{
    public class Bird
    {
        public Nest NestBuild()
        {
            return new Nest();
        }

    }

    public class Nest
    {
        public delegate void EggsFellDelegate(int eggs_count);
        public event EggsFellDelegate EggsFell;
        static Random rnd = new Random();
        int eggs_count = 0;

        public int EggsCount
        {
            get { return this.eggs_count; }
        }

        public void LayEggs(Bird bird)
        {
            this.eggs_count = rnd.Next(10);
        }

        public void PullBranch()
        {
            if(rnd.NextDouble() < 0.1 && EggsFell != null)
            {
                Console.WriteLine("EggsFell");
                int eggs_count = rnd.Next(this.eggs_count + 1);
                this.eggs_count -= eggs_count;
                EggsFell(eggs_count);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            Nest nest = bird.NestBuild();
            nest.EggsFell += Happy;
            nest.LayEggs(bird);
            while(nest.EggsCount > 0)
                nest.PullBranch();
            Console.ReadKey();
        }

        static void Happy(int eggs_count)
        {
            for (int i = 0; i < eggs_count; i++)
            {
                Console.WriteLine("Happy");
            }
        }
    }
}
