
using System.Xml.Linq;

public sealed partial class JsonParser
{
    public IntentFilter IntentFilterParser(XElement intentElement)
    {
        var result = new IntentFilter();

        // Attribute
        var icon = intentElement.Attribute(_androidNamespace + "icon");
        var label = intentElement.Attribute(_androidNamespace + "label");
        var priority = intentElement.Attribute(_androidNamespace + "priority");
        var order = intentElement.Attribute(_androidNamespace + "order");
        var autoVerify = intentElement.Attribute(_androidNamespace + "autoVerify");

        if (icon is not null)
            result.icon = icon.Value;

        if (label is not null)
            result.label = label.Value;

        if (priority is not null)
        {
            result.priority = Convert.ToInt32(priority.Value);
        }
        else
        {
            result.priority = 0;
        }

        if (order is not null)
        {
            result.order = Convert.ToInt32(order.Value);
        }
        else
        {
            result.order = 0;
        }

        if (autoVerify is not null)
        {
            result.autoVerify = Convert.ToBoolean(autoVerify.Value);
        }
        else
        {
            result.autoVerify = false;
        }

        // Element
        var action = intentElement.Element("action");
        var categories = intentElement.Elements("category");
        var datas = intentElement.Elements("data");

        if (action is not null)
            result.action = ActionParser(action);
        foreach (var category in categories)
        {
            if (result.categories is null) result.categories = new List<Category>();
            result.categories.Add(CategoryParser(category));
        }

        foreach (var data in datas)
        {
            if (result.datas is null) result.datas = new List<Data>();
            result.datas.Add(DataParser(data));
        }

        return result;
    }
}