using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string BrowsNet(string url)
        {
            if (!ValudateURl(url))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!ValidateNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {phoneNumber}";
        }
        static bool ValidateNumber(string phoneNumber)
        {
            return phoneNumber.All(x => char.IsDigit(x));
        }
        static bool ValudateURl(string url)
        {
            return url.All(x => !char.IsDigit(x));
        }
    }
}
