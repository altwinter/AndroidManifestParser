using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Profileable ProfileableParser(XElement profileableElement)
    {
        var result = new Profileable();

        // Attribute
        var shell = profileableElement.Attribute(_androidNamespace + "shell");
        var enabled = profileableElement.Attribute(_androidNamespace + "enabled");


        if (shell != null)
            result.shell = Convert.ToBoolean(shell.Value);

        if (enabled != null)
        {
            result.enabled = Convert.ToBoolean(enabled.Value);
        }
        else
        {
            result.enabled = true;
        }


        return result;
    }
}