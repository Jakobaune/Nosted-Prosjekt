// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;

namespace NostedServicePro.Models.Account;

public class ResetPasswordViewModel
{
    [DataType(DataType.Password)]
    [Display(Name = "Nåværende passord")]
    public string OldPassword { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = " {0} må være minst {2} karakterer lang.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Nytt passord")]
    public string NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Bekreft nytt passord")]
    [Compare("NewPassword", ErrorMessage = "Passordene stemmer ikke overens med hverandre.")]
    public string ConfirmPassword { get; set; }
}
