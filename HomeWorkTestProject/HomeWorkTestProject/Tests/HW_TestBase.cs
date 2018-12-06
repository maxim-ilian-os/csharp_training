﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HW_WebAddressbookTests
{
    public class HW_TestBase
    {       
        protected ApplicationManager appMan;
                
        [SetUp]
        public void SetupApplicationManager()
        {
            appMan = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i<l; i++)
            {
                //builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() * 233 + 32)));
                builder.Append(Convert.ToChar(rnd.Next('a', 'a' + 27)));
            }
            return builder.ToString();
        }
    }
}