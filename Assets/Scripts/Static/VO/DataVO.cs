using System;
using System.Xml.Serialization;
/**
 * Base static data of acorns, weapons, bugs
 * */
public class DataVO:IVisualization,IStaticData
{
    [XmlAttribute("name")]
    public string name;
    public string Name { get { return name; } }

    [XmlAttribute("view")]
    public string view;
    //for view information in UI
    protected string _localizationDescription = "";
    protected string _localizationName = "";
    protected string _picturePreview = "";
    public virtual string LocalizationDescription
    {
        get
        {
            if (_localizationDescription == "")
            {
                _localizationDescription = "Description " + name;
            }

            return _localizationDescription;
        }
    }
    // return localization name by id
    public virtual string LocalizationName
    {
        get
        {
            if (_localizationName == "")
            {
                _localizationName = name;
            }
            return _localizationName;
        }
    }
    //return description by id
    public virtual string PicturePreview
    {
        get
        {
            return _picturePreview;
        }
    }

    public virtual EnumStaticDataType Type
    {
        get
        {
            return EnumStaticDataType.withOutType;
        }
    }
}
                        