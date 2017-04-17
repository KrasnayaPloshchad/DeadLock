using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLock.Classes
{
    internal class HandleLockerDetails
    {
        private string _filePath;

        internal HandleLockerDetails(string path)
        {
            _filePath = path;
        }

        public string Path { get; set; }
        // ReSharper disable once InconsistentNaming
        public string ProcessID { get; set; }
    }
}
