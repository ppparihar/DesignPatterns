using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MissionCode.DesignPatterns.Structural
{
    public interface IBird
    {
        void Fly();
    }

    public class Bird : IBird
    {
        public void Fly()
        {
            WriteLine("Flying...");
            
        }
    }


    public interface ILizard
    {
        void Crawl();
    }
    public class Lizard : ILizard
    {
        public void Crawl()
        {
            WriteLine("Crawling...");
        }
    }

    public class Dragan : IBird, ILizard
    {
        private IBird bird;
        private ILizard lizard;

        public Dragan(IBird bird, ILizard lizard)
        {
            this.bird = bird;
            this.lizard = lizard;
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }

       
 
}
