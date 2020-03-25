using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Thomerson.Gatlin.Core
{
    public class NullWithEmptyStringResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties()
                       .Select(p =>
                       {
                           var jp = base.CreateProperty(p, memberSerialization);
                           jp.ValueProvider = new NullToEmptyStringValueProvider(p);
                           return jp;
                       }).ToList();
        }

        /// <summary>
        /// 将所有返回字段转换为小写
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        //protected override string ResolvePropertyName(string propertyName)
        //{
        //    return propertyName.ToLower();
        //}
    }
}
