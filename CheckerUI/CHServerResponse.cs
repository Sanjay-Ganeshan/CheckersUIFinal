using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerUI
{
    public class CHServerResponse
    {
        public bool worked { get; }
        public dynamic info { get; }
        public CHServerResponse(bool worked, dynamic info)
        {
            this.worked = worked;
            this.info = info;
        }
    }
}
