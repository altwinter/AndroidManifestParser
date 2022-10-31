namespace AndroidXml
{
    public sealed class MaskValues
    {
        public static MaskValues Instance { get { return Nested.instance; } }

        private MaskValues()
        {
            _configChanges = AttrsJsonValues.Instance.GetValue("configChanges");
            _windowSoftInputMode = AttrsJsonValues.Instance.GetValue("windowSoftInputMode");
        }

        public string? GetConfigChanges(string value)
        {
            if (_configChanges == null) return null;

            string result = "";
            int intValue = Convert.ToInt32(value, 16);

            foreach (var tuple in _configChanges)
            {
                if (tuple.Key == intValue) return tuple.Value;
                ;
                if ((intValue & tuple.Key) == tuple.Key)
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        result = tuple.Value;
                    }
                    else
                    {
                        result += "|" + tuple.Value;
                    }
                }

            }

            return result;
        }

        public string? GetWindowSoftInputMode(string value)
        {
            if (_windowSoftInputMode == null) return null;

            string result = "";
            int intValue = Convert.ToInt32(value, 16);

            // 0x33 => 51 special case causing problem
            // it's seems that we can only have 1 adjust* with 1 state*, but the priority are blurry so i put this hotfix here
            if (intValue == 51) return "adjustNothing|stateAlwaysHidden";

            foreach (var tuple in _windowSoftInputMode)
            {
                if (tuple.Key == intValue) return tuple.Value;

                if (tuple.Key == 0) continue;

                if ((intValue & tuple.Key) == tuple.Key)
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        result = tuple.Value;
                    }
                    else
                    {
                        result += "|" + tuple.Value;
                    }
                }
            }

            return result;
        }

        public string? IsListed(string name, string value)
        {
            string? result;
            switch (name)
            {
                case "configChanges":
                    {
                        result = GetConfigChanges(value);
                        break;
                    }
                case "windowSoftInputMode":
                    {
                        result = GetWindowSoftInputMode(value);
                        break;
                    }
                default:
                    result = null;
                    break;
            }

            return result;
        }

        private readonly Dictionary<int, string>? _configChanges;
        private readonly Dictionary<int, string>? _windowSoftInputMode;

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly MaskValues instance = new MaskValues();
        }
    }
}