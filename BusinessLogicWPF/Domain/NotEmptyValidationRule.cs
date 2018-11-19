using BusinessLogicWPF.Helper;
using System.Globalization;
using System.Windows.Controls;

namespace BusinessLogicWPF.Domain
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (ErrorLabelHelper.Check())
                return string.IsNullOrWhiteSpace((value ?? "").ToString())
                    ? new ValidationResult(false, "Field is required.")
                    : ValidationResult.ValidResult;
            return ValidationResult.ValidResult;
        }
    }
}