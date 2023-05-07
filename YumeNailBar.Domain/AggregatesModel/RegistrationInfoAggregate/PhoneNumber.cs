using System.Text.RegularExpressions;
using YumeNailBar.Domain.Exceptions.CustomerExceptions;

namespace YumeNailBar.Domain.AggregatesModel.CustomerAggregate;

public partial record PhoneNumber
{
    public PhoneNumber(string value)
    {
        if (!PhoneNumberValidationRegex().IsMatch(value))
        {
            throw new InvalidPhoneNumberException();
        }

        Value = value;
    }

    public string Value { get; }

    /// <summary>
    /// Regex для валидации номера телефона
    /// </summary>
    [GeneratedRegex("^\\+?[1-9][0-9]{7,14}$")]
    private static partial Regex PhoneNumberValidationRegex();
}