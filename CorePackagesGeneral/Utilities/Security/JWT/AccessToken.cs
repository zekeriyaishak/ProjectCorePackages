﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackagesGeneral.Utilities.Security.JWT;
public class AccessToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
