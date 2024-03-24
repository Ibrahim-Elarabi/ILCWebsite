using ILC.BL.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace ILC.BL.CustomAttributes
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            if (value is bool)
                return (bool)value;

            throw new InvalidOperationException("The property must be a boolean.");
        }
    }
}