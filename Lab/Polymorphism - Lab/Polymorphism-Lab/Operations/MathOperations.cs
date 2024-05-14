﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class MathOperations
    {
        public int Add(int first, int second)
        {
            return first + second;
        }
        public double Add(double first, double second, double third) 
        {
            return first + second + third;
        }
        public decimal Add(decimal first, decimal second, decimal third)
        {
            return first + second + third;
        }
    }
}
