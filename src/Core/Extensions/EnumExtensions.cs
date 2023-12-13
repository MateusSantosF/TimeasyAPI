using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDescription(this Enum GenericEnum)
    {
        Type genericEnumType = GenericEnum.GetType();
        MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (_Attribs != null && _Attribs.Count() > 0)
            {
                return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
            }
        }
        return GenericEnum.ToString();
    }

    public static T GetEnumFromString<T>(this string value)
    {
        if (Enum.IsDefined(typeof(T), value))
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        else
        {
            string[] enumNames = Enum.GetNames(typeof(T));
            foreach (string enumName in enumNames)
            {
                object e = Enum.Parse(typeof(T), enumName);
                if (value == GetDescription((Enum)e))
                {
                    return (T)e;
                }
            }
        }
        throw new ArgumentException("The value '" + value
            + "' does not match a valid enum name or description.");
    }
}
