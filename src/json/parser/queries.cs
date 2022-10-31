using System.Xml.Linq;

public sealed partial class JsonParser
{
    public Queries QueriesParser(XElement queriesElement)
    {
        var result = new Queries();

        var q = queriesElement.Elements();

        foreach (var query in queriesElement.Elements())
        {
            switch (query.Name.ToString())
            {
                case "package":
                    {
                        if (result.packages is null) result.packages = new List<Package>();
                        result.packages.Add(PackageParser(query));
                        break;
                    }
                case "intent":
                    {
                        if (result.intents is null) result.intents = new List<IntentFilter>();
                        result.intents.Add(IntentFilterParser(query));
                        break;
                    }
                case "provider":
                    {
                        if (result.provider is null) result.provider = new List<QProvider>();
                        result.provider.Add(QProviderParser(query));
                        break;
                    }

                default: break;
            }
        }

        return result;
    }
}
