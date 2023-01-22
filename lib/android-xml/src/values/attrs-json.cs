using Newtonsoft.Json;

namespace AndroidXml
{

    /// <summary>
    /// Attrs values resources Class
    /// </summary>
    public sealed class AttrsJsonValues
    {
        /// <summary>
        /// AttrsJsonValues Instance
        /// </summary>
        /// <returns>An instance of the <see cref="AttrsJsonValues"/> class.</returns>
        public static AttrsJsonValues Instance { get { return Nested.instance; } }

        /// <summary>
        /// AttrsJsonValues private instance
        /// </summary>
        private AttrsJsonValues()
        {
            _values = new Dictionary<string, Dictionary<int, string>>();

            var pathAttrs = System.IO.Path.Combine(DirectoryPath.Instance.CurrentProject(), @"lib/android-xml/resource/values/attrs.json");

            string json = File.ReadAllText(pathAttrs);
            ResourceData data = JsonConvert.DeserializeObject<ResourceData>(json);

            foreach (var attr in data.attrs!)
            {
                var Items = new Dictionary<int, string>();

                if (attr.flags is not null)
                {
                    foreach (var flag in attr.flags)
                    {
                        if (!Items.ContainsKey(flag.value))
                            Items.Add(flag.value, flag.name!);
                    }
                }

                if (attr.enums is not null)
                {
                    foreach (var enumi in attr.enums)
                    {
                        if (!Items.ContainsKey(enumi.value))
                            Items.Add(enumi.value, enumi.name!);
                    }
                }
                _values.Add(attr.name!, Items);
            }
        }

        /// <summary>
        /// Get the Attrs value from the Name and Id
        /// </summary>
        /// <param name="attrName">The <see cref="string"/> attr name value.</param>
        /// <param name="value">The <see cref="string"/> Id value.</param>
        /// <returns>The value.</returns>
        public string? GetValue(string attrName, string value)
        {
            Dictionary<int, string>? result;
            if (_values.TryGetValue(attrName, out result))
            {
                string? res;
                int intValue;
                if (value.StartsWith("0x"))
                {
                    intValue = Convert.ToInt32(value, 16);
                }
                else
                {
                    intValue = Convert.ToInt32(value);
                }

                if (result.TryGetValue(intValue, out res))
                    return res;
            }


            return null;
        }

        /// <summary>
        /// Get the Attrs dictionary value from a Name
        /// </summary>
        /// <param name="attrName">The <see cref="string"/> attr name value.</param>
        /// <returns>Dictionary of values.</returns>
        public Dictionary<int, string>? GetValue(string attrName)
        {
            Dictionary<int, string>? result;
            if (_values.TryGetValue(attrName, out result))
                return result;

            return null;
        }

        /// <summary>
        /// The Id-Value dictionary of Attrs
        /// </summary>
        private Dictionary<string, Dictionary<int, string>> _values;

        /// <summary>
        /// Nested class
        /// </summary>
        private class Nested
        {
            /// <summary>
            /// Private Nested instance
            /// </summary>
            static Nested()
            {
            }

            /// <summary>
            /// Singleton of AttrsJsonValues class
            /// </summary>
            internal static readonly AttrsJsonValues instance = new AttrsJsonValues();
        }
    }
}