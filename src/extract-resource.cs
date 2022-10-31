using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ExtractResource
{

    public static ExtractResource Instance { get { return Nested.instance; } }

    private ExtractResource()
    {
        _data = new ResourceData();
        _data.attrs = new List<Attr>();
    }

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

    private void AddDeclareStyleableValue(XElement declareStyleableValue)
    {
        if (declareStyleableValue.HasElements)
            declareStyleableValue.Elements("attr").ToList().ForEach(pv => AddAttrValue(pv));
    }


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


    private class Nested
    {
        static Nested()
        {
        }

        internal static readonly ExtractResource instance = new ExtractResource();
    }

    private ResourceData _data;
}