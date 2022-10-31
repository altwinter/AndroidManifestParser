using System.Xml.Linq;

namespace AndroidXml
{
    public sealed class PublicValues
    {
        public static PublicValues Instance { get { return Nested.instance; } }

        private PublicValues()
        {

            _values = new Dictionary<uint, string>();

            var path = System.IO.Path.Combine(DirectoryPath.Instance.CurrentProject(), @"lib/android-xml/resource/values/public-final.xml");
            XDocument xdoc = XDocument.Load(File.OpenRead(path));

            XElement? elem;
            if ((elem = xdoc.Element("resources")) != null)
                elem.Elements("public").ToList().ForEach(pv => AddValue(pv));

        }

        public Dictionary<uint, string> Values => _values;

        private void AddValue(XElement publicValue)
        {
            var id = publicValue.Attribute("id");
            var name = publicValue.Attribute("name");
            if (id != null && name != null)
                _values.Add(Convert.ToUInt32(id.Value, 16), name.Value);
        }

        private readonly Dictionary<uint, string> _values;

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly PublicValues instance = new PublicValues();
        }
    }
}