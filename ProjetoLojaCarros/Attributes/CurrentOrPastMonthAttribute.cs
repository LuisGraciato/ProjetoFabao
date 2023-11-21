using System.ComponentModel.DataAnnotations;

namespace DevIOApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CurrentOrPastMonthAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                return date >= firstDayOfMonth;
            }
            return false;
        }
    }
}
