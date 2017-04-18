using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLock.Classes
{
    internal class HandleLockerDetails
    {
        public string FilePath { get; set; }
        // ReSharper disable once InconsistentNaming
        public string ProcessID { get; set; }
    }
}
