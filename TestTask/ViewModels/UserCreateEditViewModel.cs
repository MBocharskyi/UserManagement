using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestTask.Domain;

namespace TestTask.ViewModels
{
    public class UserCreateEditViewModel
    {
        public UserCreateEditViewModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            FilePath = string.Empty;
            SkypeLogin = string.Empty;
            Note = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(
            Constants.User.Name.MAX_NAME_LENGTH,
            MinimumLength = Constants.User.Name.MIN_NAME_LENGTH,
            ErrorMessage = "Name length must be bigger than 6 and less than 21 symbols.")]
        [RegularExpression(Constants.User.Name.NAME_REGEX_PATTERN,
            ErrorMessage = "Name can only contain letters from a to z and digits.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(Constants.User.Email.EMAIL_REGEX_PATTERN,
            ErrorMessage = "Not valid email")]
        public string Email { get; set; }

        [Display(Name ="Avatar")]
        public string FilePath { get; set; }

        [Display(Name = "Skype login")]
        [RegularExpression(Constants.User.Skype.SKYPE_REGEX_PATTERN,
            ErrorMessage = "Not valid skype")]
        public string SkypeLogin { get; set; }

        public string Note { get; set; }
    }
}