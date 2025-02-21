using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] propertyInfos = type
                .GetProperties()
                .Where(p => p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                IEnumerable<MyValidationAttribute> attributes = propertyInfo
                    .GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    object value = propertyInfo.GetValue(obj);

                    if (!attribute.IsValid(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
