﻿using System.ComponentModel.DataAnnotations;

namespace CMS.API.Models.Accounts;

public class VerifyEmailRequest
{
    [Required]
    public string Token { get; set; }
}
