using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
/**
 * Load xml files with static data 
 * */
 
[XmlRoot("data")]
public class StaticResourcesXmlLoader<T>
{
    [XmlArray("elementList")]
    [XmlArrayItem("element")]
    public List<T> dataList = new List<T>();

    public static StaticResourcesXmlLoader<T> LoadContainer(string xmlUrls)
    {
        TextAsset _xml = Resources.Load<TextAsset>(xmlUrls);
        if(_xml == null)
        {
            LoggingManager.AddErrorToLog("Didnt load xml " + xmlUrls);
        }
        StringReader reader = new StringReader(_xml.text);
        XmlSerializer serializer = new XmlSerializer(typeof(StaticResourcesXmlLoader<T>));
        StaticResourcesXmlLoader<T> container = serializer.Deserialize(reader) as StaticResourcesXmlLoader<T>;
        reader.Close();
        return container;
    }
}
