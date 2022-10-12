using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Note
    {
        private string name;
        private string description;
        private DateTime time;

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set{time = value; }
        }

    }
}
