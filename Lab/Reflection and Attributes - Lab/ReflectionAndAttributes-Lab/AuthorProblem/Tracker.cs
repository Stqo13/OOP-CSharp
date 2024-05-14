using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[]methods = type.GetMethods((BindingFlags)60);
            foreach (var method in methods)
            {
                AuthorAttribute[] authorAttributes = method.GetCustomAttributes<AuthorAttribute>().ToArray();
                if (authorAttributes.Length > 0)
                {
                    foreach (var attr in authorAttributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
