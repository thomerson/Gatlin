using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Thomerson.Gatlin.Core
{
    public class NullToEmptyStringValueProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _MemberInfo = memberInfo;
        }

        public object GetValue(object target)
        {
            object result = _MemberInfo.GetValue(target);
            if (result == null)
            {
                var type = _MemberInfo.PropertyType;
                if (type == typeof(string)) result = "";
                //else if (type == typeof(DateTime?))
                //    result = new DateTime(1, 1, 1);
            }
            return result;
        }

        public void SetValue(object target, object value)
        {
            _MemberInfo.SetValue(target, value);
        }
    }
}
