using System;
using System.Collections.Generic;
using System.Linq;

namespace MissionCode.DesignPatterns.SOLID
{
    public enum Color
    {
        Blue, Green, Red
    }

    public enum Size
    {
        Small, Midium, Large
    }
    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Color: {Color}, Size: {Size}";
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> ByColor(IEnumerable<Product> products, Color color)
        {
            return products?.Where(product => product.Color == color);
        }

        // breaks Open close principle. (every time when you add new filter)
        public IEnumerable<Product> BySize(IEnumerable<Product> products, Size size)
        {
            return products?.Where(product => product.Size == size);
        }
    }

    // handles the OCP.
    public interface IFilter<T> where T : class
    {
        IEnumerable<T> Filter(IEnumerable<T> items);
    }

    public class ColorFilter : IFilter<Product>
    {
        private readonly Color _color;

        public ColorFilter(Color color)
        {
            this._color = color;
        }

        public IEnumerable<Product> Filter(IEnumerable<Product> items)
        {
            return items?.Where(product => product.Color == _color);
        }
    }

    public class SizeFilter : IFilter<Product>
    {
        private readonly Size _size;

        public SizeFilter(Size size)
        {
            _size = size;
        }

        public IEnumerable<Product> Filter(IEnumerable<Product> items)
        {
            return items?.Where(product => product.Size == _size);
        }
    }
}