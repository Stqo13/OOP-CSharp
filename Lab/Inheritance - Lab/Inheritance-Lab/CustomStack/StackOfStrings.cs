using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            bool isEmpty = false;
            if (!this.Any())
            {
                isEmpty = true;
            }
            else
            {
                return isEmpty;
            }
            return isEmpty;
        }
        public void AddRange(Stack<string> collection)
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }
        }
    }
}
