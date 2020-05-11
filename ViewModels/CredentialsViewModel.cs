using ShinyBooking.ViewModels.Validations;
using ServiceStack.FluentValidation.Attributes;

namespace ShinyBooking.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}