using System.Text.RegularExpressions;
using YumeNailBar.Domain.Exceptions.CustomerExceptions;

namespace YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

public record PhoneNumber
{
    private Regex _phoneNumberRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
    public PhoneNumber(string value)
    {
        if (!_phoneNumberRegex.IsMatch(value))
        {
            throw new InvalidPhoneNumberException();
        }

        Value = value;
    }

    public string Value { get; init; }
    
    
    public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;

    public static implicit operator PhoneNumber(string phoneNumber) => new(phoneNumber);
}