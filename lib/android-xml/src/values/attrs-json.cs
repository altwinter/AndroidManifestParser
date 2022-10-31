using Newtonsoft.Json;

namespace AndroidXml
{
    public sealed class AttrsJsonValues
    {
        public static AttrsJsonValues Instance { get { return Nested.instance; } }

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

        public Dictionary<int, string>? GetValue(string attrName)
        {
            Dictionary<int, string>? result;
            if (_values.TryGetValue(attrName, out result))
                return result;

            return null;
        }

        private Dictionary<string, Dictionary<int, string>> _values;

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly AttrsJsonValues instance = new AttrsJsonValues();
        }
    }
}