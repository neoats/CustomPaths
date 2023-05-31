namespace Utilities.CustomAttribute;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class StringAttribute : Attribute
{
    public StringAttribute(string Information)
    {
        Text = Information;
    }

    public string Text { get; }
}