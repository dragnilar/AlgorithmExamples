using System;

namespace SillyTypeConverter
{
    public static class ExtensionMethods
    {
        public static T ConvertTo<T>(this object valueToConvert)
        {
            if (ValueIsNullOrEmptyString(valueToConvert))
            {
                return default;
            }
            var destinationType = Nullable.GetUnderlyingType(typeof(T));
            if (destinationType == null)
            {
                return (T)Convert.ChangeType(valueToConvert, typeof(T));

            }
            var result = Convert.ChangeType(valueToConvert, destinationType);
            return (T)result;

        }

        private static bool ValueIsNullOrEmptyString(object value)
        {
            switch (value)
            {
                case null:
                case string s when string.IsNullOrWhiteSpace(s):
                    return true;
            }

            return false;
        }
    }
}
