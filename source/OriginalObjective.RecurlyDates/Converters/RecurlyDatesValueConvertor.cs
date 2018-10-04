using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using OriginalObjective.RecurlyDates.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;

namespace OriginalObjective.RecurlyDates.Converters
{
    [PropertyValueType(typeof(List<string>))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class RecurlyDatesValueConvertor : PropertyValueConverterBase, IPropertyValueConverterMeta
    {
        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null || string.IsNullOrWhiteSpace(source.ToString()))
            {
                return null;
            }

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return UmbracoContext.Current == null
                ? null
                : JsonConvert.DeserializeObject<Schedule>(source.ToString(), settings);
        }

        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("OriginalObjective.RecurlyDates");
        }

        public Type GetPropertyValueType(PublishedPropertyType propertyType)
        {
            return typeof(Schedule);
        }

        public PropertyCacheLevel GetPropertyCacheLevel(PublishedPropertyType propertyType,
            PropertyCacheValue cacheValue)
        {
            return PropertyCacheLevel.Content;
        }
    }
}