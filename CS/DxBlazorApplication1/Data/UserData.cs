using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DxBlazorApplication1.Data
{
    public class UserData
    {
        [Required(ErrorMessage = "The Username value should be specified.")]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "The Password value should be specified.")]
        [MinPasswordLength(6, "The Password must be at least 6 characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]        
        public string Password { get; set; }
        

        [Required(ErrorMessage = "The Email value should be specified.")]
        [Email(ErrorMessage = "The Email value is invalid.")]
        [DataType(DataType.Text)]
        [Display(Name = "Email Address")]        
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The Phone value should be specified.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]        
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]        
        public DateTime BirthDate { get; set; } = new DateTime(1970, 1, 1);

        [DataType("ComboBox")]
        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }

    public class AdditionalData
    {
        public static IEnumerable<string> Occupations { get; set; } = new List<string>() {
        "Academic",
        "Administrative",
        "Art/Entertainment",
        "College Student",
        "Community & Social",
        "Computers",
        "Education",
        "Engineering",
        "Financial Services",
        "Government",
        "High School Student",
        "Law",
        "Managerial",
        "Manufacturing",
        "Medical/Health",
        "Military",
        "Non-government Organization",
        "Other Services",
        "Professional",
        "Retail",
        "Science & Research",
        "Sports",
        "Technical",
        "University Student",
        "Web Building",
    };
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MinPasswordLengthAttribute : ValidationAttribute
    {
        int MinLength { get; }
        public MinPasswordLengthAttribute(int minLength, string errorMsg) : base(errorMsg)
        {
            MinLength = minLength;
        }

        public override bool IsValid(object value)
        {
            return ((string)value).Length >= MinLength;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Regex.IsMatch((string)value, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                             + "@"
                                              + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
        }
    }
   
}
