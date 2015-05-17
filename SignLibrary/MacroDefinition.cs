using System;
using System.Text;

namespace SignLibrary
{
    public class MacroDefinition
    {
        public readonly string Name;
        public readonly string Value;

        public MacroDefinition(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
