using System.Collections.Generic;

namespace MissionCode.DesignPatterns.SOLID
{
    //Liskov Substition Principle
    //You should be able to substitute a base type for a subtype
    public abstract class WidgetBase
    {
        public virtual WidgetBase[] Relatives()
        {
            return new WidgetBase[0];
        }
    }

    public class NotLspWidget : WidgetBase
    {
        public override WidgetBase[] Relatives()
        {
            return new NotLspWidget[1] { this };
        }
    }

    public class LspWidget : WidgetBase
    {
        public override WidgetBase[] Relatives()
        {
            return new WidgetBase[1] { this };
        }
    }
}