using Plugin.ValidationRules.Interfaces;

namespace maui.Validations;

public class IsNotNullOrEmptyRule<T>: IValidationRule<T>
{
    public string ValidationMessage { get; set; }
    
    public bool Check(T value)
{
    var str = value as string;
    return value != null && !string.IsNullOrWhiteSpace(str);
}
}