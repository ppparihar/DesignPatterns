using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionCode.DesignPatterns.Creational
{
    /// <summary>
    /// Builder Design Pattern
    /// A builder is a separate component for building an object
    /// Can either give builder a constructor or return it via a static function
    /// To Make builder fluent, return this
    /// </summary>
    public class CodeBuilder
    {
        private Class _class;

        public CodeBuilder(string name)
        {
            _class = new Class(name);
        }

        public CodeBuilder AddField(string name, string type)
        {
            _class.AddField(name, type);
            return this;
        }

        public override string ToString()
        {
            return _class.ToString();
        }
    }

    public class Field
    {
        private string _type, _name;

        public Field(string type, string name)
        {
            _type = type;
            _name = name;
        }

        public override string ToString()
        {
            return $"public {_type} {_name};";
        }
    }

    public class Class
    {
        private string _name;

        private List<Field> fields = new List<Field>();
        public Class(string name)
        {
            _name = name;
        }

        public void AddField(string name, string type)
        {
            fields.Add(new Field(type, name));
        }

        public override string ToString()
        {
            var indent = new string(' ', 2);
            var builder = new StringBuilder();
            builder.AppendLine($"public class {_name}");
            builder.AppendLine("{");
            foreach (var field in fields)
            {
                builder.Append(indent).AppendLine(field.ToString());
            }
            builder.Append("}");

            return builder.ToString();
        }
    }
}
