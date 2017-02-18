using System.Xml.Serialization;

namespace wxCore
{
    /// <summary>
    /// The Types of elements that can invoke the Click method
    /// </summary>
    public enum ClickableType
    {
        [XmlEnum(Name = "None")]
        Unknown,
        [XmlEnum(Name = "Radio")]
        Radio,
        [XmlEnum(Name = "Check")]
        Check,
        [XmlEnum(Name = "Button")]
        Button,
        [XmlEnum(Name = "TableCell")]
        TableCell,
        [XmlEnum(Name = "Div")]
        Div,
        [XmlEnum(Name = "Image")]
        Image
    }  
}
