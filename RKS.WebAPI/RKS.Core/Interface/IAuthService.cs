﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKS.Core.Interface
{
    public interface IAuthService
    {
        Task<string> ValidateUser();
    }
}
