﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Service
{
    public class SpecialService : ISpecialService
    {
        public void AddSpecial()
        {
            throw new NotImplementedException();
        }

        public string GetName() => "I am from special service";
    }
}