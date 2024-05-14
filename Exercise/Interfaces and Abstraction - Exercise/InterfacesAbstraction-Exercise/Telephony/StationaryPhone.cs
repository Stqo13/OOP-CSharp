using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            return $"Dialing... {phoneNumber}";
        }
    }
}
