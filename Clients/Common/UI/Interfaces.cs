﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viking.Common
{ 
    /// <summary>
    /// Provides an array of strings used to provide help in context for users
    /// </summary>
    public interface IHelpStrings
    {
        string[] HelpStrings { get; }
    }
}
