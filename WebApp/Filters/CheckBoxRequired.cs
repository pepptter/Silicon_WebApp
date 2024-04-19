using System.ComponentModel.DataAnnotations;

namespace WebApp.Filters;

public class CheckBoxRequired : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is bool boolean && boolean;
    }
    public override string FormatErrorMessage(string name)
    {
        return $"The {name} field is required.";
    }
}