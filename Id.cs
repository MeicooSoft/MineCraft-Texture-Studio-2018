using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftTextureStudio
{
    public class Id : IComparable
    {
        public string name;
        public int id;

        public Id(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public int CompareTo(object obj)
        {
            Id otherBlockId = (Id)obj;

            if (otherBlockId.id < this.id)
            {
                return 1;
            }
            else if (otherBlockId.id > this.id)
            {
                return -1;
            }
            else
            {
                return -1 * (otherBlockId.name.CompareTo(this.name));
            }
        }
    }
}
