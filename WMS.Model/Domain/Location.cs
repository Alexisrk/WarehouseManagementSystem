using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Domain
{
    public class Location
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Type { get; set; }
        public virtual int W { get; set; }
        public virtual int B { get; set; }
        public virtual int A { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
        public virtual int Z { get; set; }
        public virtual int Capacity { get; set; }
    }
}
