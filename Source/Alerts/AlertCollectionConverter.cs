using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ScriptFUSION.WarframeAlertTracker.Alerts {
    /// <summary>
    /// Converts AlertCollection to and from a JSON string.
    /// </summary>
    internal sealed class AlertCollectionConverter : TypeConverter {
        private static readonly Dictionary<AlertType, Type> classMap = new Dictionary<AlertType, Type>
        {
            { AlertType.Fissure, typeof(FissureAlert) }
        };

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            var alerts = new AlertCollection();

            foreach (var token in (JArray)JsonConvert.DeserializeObject((string)value)) {
                alerts.Add((Alert)token.ToObject(classMap[(AlertType)token["Type"].Value<byte>()]));
            }

            return alerts;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            return JsonConvert.SerializeObject(value);
        }
    }
}
