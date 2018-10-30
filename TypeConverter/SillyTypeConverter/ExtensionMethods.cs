using System;

namespace SillyTypeConverter
{
    public static class ExtensionMethods
    {
        public static dynamic ConvertToDestinationProperty(this object valueToConvert, object destinationObject, string propertyName)
        {
            var property = destinationObject.GetType().GetProperty(propertyName);
            var method = typeof(ExtensionMethods).GetMethod("ConvertTo");
            var genericMethod = method.MakeGenericMethod(property.PropertyType);
            var returnValue = genericMethod.Invoke(null, new[] { valueToConvert });
            return returnValue;

        }

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
