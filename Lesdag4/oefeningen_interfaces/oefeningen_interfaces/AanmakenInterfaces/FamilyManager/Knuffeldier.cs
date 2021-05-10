using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyManager
{
    // must implement the interface
    class Knuffeldier : INameable
    {
        private string _name { get; set; }

        public Knuffeldier(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
