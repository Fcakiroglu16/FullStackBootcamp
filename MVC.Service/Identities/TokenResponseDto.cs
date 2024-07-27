﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Service.Identities
{
    public record TokenResponseDto(string AccessToken, string RefreshToken, long RefreshTokenExpire);
}