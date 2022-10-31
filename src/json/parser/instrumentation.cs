using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Instrumentation InstrumentationParser(XElement instrumentationElement)
    {
        var result = new Instrumentation();

        // Attribute
        var functionalTest = instrumentationElement.Attribute(_androidNamespace + "functionalTest");
        var handleProfiling = instrumentationElement.Attribute(_androidNamespace + "handleProfiling");
        var icon = instrumentationElement.Attribute(_androidNamespace + "icon");
        var label = instrumentationElement.Attribute(_androidNamespace + "label");
        var name = instrumentationElement.Attribute(_androidNamespace + "name");
        var targetPackage = instrumentationElement.Attribute(_androidNamespace + "targetPackage");
        var targetProcesses = instrumentationElement.Attribute(_androidNamespace + "targetProcesses");

        if (functionalTest != null)
        {
            result.functionalTest = Convert.ToBoolean(functionalTest.Value);
        }
        else
        {
            result.functionalTest = false;
        }

        if (handleProfiling != null)
        {
            result.handleProfiling = Convert.ToBoolean(handleProfiling.Value);
        }
        else
        {
            result.handleProfiling = false;
        }

        if (icon != null)
            result.icon = icon.Value;

        if (label != null)
            result.label = label.Value;

        if (name != null)
            result.name = name.Value;

        if (targetPackage != null)
            result.targetPackage = targetPackage.Value;

        if (targetProcesses != null)
            result.targetProcesses = targetProcesses.Value;

        return result;
    }
}