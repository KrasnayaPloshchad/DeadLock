using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLock.Classes
{
    internal class HandleLocker
    {
        internal string ActualPath { get; set; }
        internal string Status { get; set; }
        internal string Ownership { get; set; }
    }
}
