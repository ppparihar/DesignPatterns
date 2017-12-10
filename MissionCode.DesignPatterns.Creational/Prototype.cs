using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionCode.DesignPatterns.Creational
{
    public class Coordinate
    {
        public int X, Y;

        public Coordinate DeepCopy()
        {
            return new Coordinate
            {
                X = X,
                Y = Y
            };

        }
    }

    public class Line
    {
        public Coordinate Start, End;

        public Line DeepCopy()
        {
            var copy = new Line { Start = Start.DeepCopy(), End = End.DeepCopy() };
            return copy;
        }
    }
}
