using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionCode.DesignPatterns.Structural
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }


    class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }

    class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }

    public abstract class Shape
    {
        protected IRenderer renderer;
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {

        public Triangle(IRenderer renderer)
        {
            this.renderer = renderer;
            Name = "Circle";
        }


    }

    public class Square : Shape
    {
        public Square(IRenderer renderer)
        {
            Name = "Square";
            this.renderer = renderer;
        }
    }


}
