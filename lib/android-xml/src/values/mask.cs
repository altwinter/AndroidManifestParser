namespace AndroidXml
{
    /// <summary>
    /// Mask values resources Class
    /// </summary>
    public sealed class MaskValues
    {
        /// <summary>
        /// MaskValues Instance
        /// </summary>
        /// <returns>An instance of the <see cref="MaskValues"/> class.</returns>
        public static MaskValues Instance { get { return Nested.instance; } }

        /// <summary>
        /// MaskValues private instance
        /// </summary>
        private MaskValues()
        {
            _configChanges = AttrsJsonValues.Instance.GetValue("configChanges");
            _windowSoftInputMode = AttrsJsonValues.Instance.GetValue("windowSoftInputMode");
        }

        /// <summary>
        /// Get the configChange value from the Id
        /// </summary>
        /// <param name="value">The <see cref="string"/> Id value.</param>
        /// <returns>The value.</returns>
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

        /// <summary>
        /// Get the WindowSoftInputMode value from the Id
        /// </summary>
        /// <param name="value">The <see cref="string"/> Id value.</param>
        /// <returns>The value.</returns>
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

        /// <summary>
        /// Verify if the value is listed in our registry
        /// </summary>
        /// <param name="name">The <see cref="string"/> type of the value.</param>
        /// <param name="value">The <see cref="string"/> Id value.</param>
        /// <returns>The value.</returns>
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

        /// <summary>
        /// The Id-value dictionary of ConfigChanges
        /// </summary>
        private readonly Dictionary<int, string>? _configChanges;

        /// <summary>
        /// The Id-value dictionary of WindowSofInputMode
        /// </summary>
        private readonly Dictionary<int, string>? _windowSoftInputMode;

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
            /// Singleton of PublicValues class
            /// </summary>
            internal static readonly MaskValues instance = new MaskValues();
        }
    }
}