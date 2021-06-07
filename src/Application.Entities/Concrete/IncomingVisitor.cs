using Application.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities.Concrete
{
    public class IncomingVisitor : BaseEntity<int>
    {
        public string IpAddress { get; set; }
    }
}
