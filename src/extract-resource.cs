using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Extract resources from XML files Class
/// </summary>
public class ExtractResource
{

    /// <summary>
    /// ExtractRecource Instance
    /// </summary>
    /// <returns>An instance of the <see cref="ExtractResource"/> class.</returns>
    public static ExtractResource Instance { get { return Nested.instance; } }

    /// <summary>
    /// ExtractResource private constructor
    /// </summary>
    private ExtractResource()
    {
        _data = new ResourceData();
        _data.attrs = new List<Attr>();
    }

    /// <summary>
    /// Extract resouces from attr-manifest.xml and attr.xml files
    /// </summary>
    /// <returns>A <see cref="Json"/> format value representing the key-value of name-flag/enum</returns>
    public string? Extract()
    {

        var pathAttrs = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"lib/android-xml/resource/attrs.xml");
        var pathAttrsManifest = System.IO.Path.Combine(AndroidXml.DirectoryPath.Instance.CurrentProject(), @"lib/android-xml/resource/attrs-manifest.xml");

        XDocument xdocAttrs = XDocument.Load(File.OpenRead(pathAttrs));
        XElement? elem;
        if ((elem = xdocAttrs.Element("resources")) != null)
        {
            elem.Elements("attr").ToList().ForEach(av => AddAttrValue(av));
            elem.Elements("declare-styleable").ToList().ForEach(dsv => AddDeclareStyleableValue(dsv));
        }

        XDocument xdocAttrsManifest = XDocument.Load(File.OpenRead(pathAttrsManifest));
        XElement? attrElem;
        if ((attrElem = xdocAttrsManifest.Element("resources")) != null)
        {
            attrElem.Elements("attr").ToList().ForEach(av => AddAttrValue(av));
            attrElem.Elements("declare-styleable").ToList().ForEach(dsv => AddDeclareStyleableValue(dsv));
        }


        // Convert manifest to Json
        var opt = new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
        string result = JsonSerializer.Serialize(_data, opt);
        return result;
    }

    /// <summary>
    /// Add a value (name-flag/enum) to the list
    /// </summary>
    /// <param name="attrValue">The <see cref="XElement"/> value to add to the list.</param>
    private void AddAttrValue(XElement attrValue)
    {
        var name = attrValue.Attribute("name");
        if (attrValue.HasElements && (name != null))
        {
            var flags = GetFlags(attrValue);
            var enums = GetEnums(attrValue);

            if ((flags.Count > 0) || (enums.Count > 0))
            {
                var newAttr = new Attr
                {
                    name = name.Value
                };

                if (flags.Count > 0)
                    newAttr.flags = flags;

                if (enums.Count > 0)
                    newAttr.enums = enums;

                _data.attrs!.Add(newAttr);
            }
        }
    }

    /// <summary>
    /// Get the list of key-value (name-flag/enum) from the DeclareStyleableValue <see cref="XElement"/>
    /// </summary>
    /// <param name="declareStyleableValue">Add the <see cref="XElement"/> values to the list of datas.</param>
    private void AddDeclareStyleableValue(XElement declareStyleableValue)
    {
        if (declareStyleableValue.HasElements)
            declareStyleableValue.Elements("attr").ToList().ForEach(pv => AddAttrValue(pv));
    }

    /// <summary>
    /// Get the flag values from an Element
    /// </summary>
    /// <param name="attr">The <see cref="XElement"/> to extract the flag element from.</param>
    /// <returns>List of <see cref="AttrFlag"/> found.</returns>
    public List<AttrFlag> GetFlags(XElement attr)
    {
        List<AttrFlag> result = new List<AttrFlag>();

        foreach (var flagElem in attr.Elements("flag"))
        {
            var res = GetFlag(flagElem);
            if (res is not null)
                result.Add(res);
        }

        return result;
    }

    /// <summary>
    /// Get the enum values from an Element
    /// </summary>
    /// <param name="attr">The <see cref="XElement"/> to extract the enum element from.</param>
    /// <returns>List of <see cref="AttrEnum"/> found.</returns>
    public List<AttrEnum> GetEnums(XElement attr)
    {
        List<AttrEnum> result = new List<AttrEnum>();

        foreach (var enumElem in attr.Elements("enum"))
        {
            var res = GetEnum(enumElem);
            if (res is not null)
                result.Add(res);
        }

        return result;
    }

    /// <summary>
    /// Get the enum value from an Element
    /// </summary>
    /// <param name="enumValue">The <see cref="XElement"/> to extract the enum element from.</param>
    /// <returns>The <see cref="AttrEnum"/> found.</returns>
    private AttrEnum? GetEnum(XElement enumValue)
    {
        var value = enumValue.Attribute("value");
        var name = enumValue.Attribute("name");
        if (value != null && name != null)
        {
            if (value.Value.StartsWith("0x"))
            {
                return new AttrEnum
                {
                    name = name.Value,
                    value = Convert.ToInt32(value.Value, 16)
                };
            }
            else
            {
                return new AttrEnum
                {
                    name = name.Value,
                    value = Convert.ToInt32(value.Value)
                };
            }
        }

        return null;
    }

    /// <summary>
    /// Get the flag value from an Element
    /// </summary>
    /// <param name="flagValue">The <see cref="XElement"/> to extract the flag element from.</param>
    /// <returns>The <see cref="AttrFlag"/> found.</returns>
    private AttrFlag? GetFlag(XElement flagValue)
    {
        var value = flagValue.Attribute("value");
        var name = flagValue.Attribute("name");

        if (value != null && name != null)
        {
            if (value.Value.StartsWith("0x"))
            {
                return new AttrFlag
                {
                    name = name.Value,
                    value = Convert.ToInt32(value.Value, 16)
                };
            }
            else
            {
                return new AttrFlag
                {
                    name = name.Value,
                    value = Convert.ToInt32(value.Value)
                };
            }
        }

        return null;
    }


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
        /// Singleton of ExtractResource class
        /// </summary>
        internal static readonly ExtractResource instance = new ExtractResource();
    }

    /// <summary>
    /// ResourceData containing a list of resources
    /// </summary>
    private ResourceData _data;
}