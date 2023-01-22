using System.Xml.Linq;

namespace AndroidXml
{
    /// <summary>
    /// Public values resources Class
    /// </summary>
    public sealed class PublicValues
    {

        /// <summary>
        /// PublicValues Instance
        /// </summary>
        /// <returns>An instance of the <see cref="PublicValues"/> class.</returns>
        public static PublicValues Instance { get { return Nested.instance; } }

        /// <summary>
        /// PublicValues private instance
        /// </summary>
        private PublicValues()
        {
            _values = new Dictionary<uint, string>();

            var path = System.IO.Path.Combine(DirectoryPath.Instance.CurrentProject(), @"lib/android-xml/resource/values/public-final.xml");
            XDocument xdoc = XDocument.Load(File.OpenRead(path));

            XElement? elem;
            if ((elem = xdoc.Element("resources")) != null)
                elem.Elements("public").ToList().ForEach(pv => AddValue(pv));
        }

        /// <summary>
        /// Key-value dictionary of id-name values from public-final.xml
        /// </summary>
        public Dictionary<uint, string> Values => _values;

        /// <summary>
        /// Add a new id-name value to the dictionary
        /// </summary>
        /// <param name="publicValue">The <see cref="XElement"/> to parse.</param>
        private void AddValue(XElement publicValue)
        {
            var id = publicValue.Attribute("id");
            var name = publicValue.Attribute("name");
            if (id != null && name != null)
                _values.Add(Convert.ToUInt32(id.Value, 16), name.Value);
        }

        private readonly Dictionary<uint, string> _values;

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
            internal static readonly PublicValues instance = new PublicValues();
        }
    }
}