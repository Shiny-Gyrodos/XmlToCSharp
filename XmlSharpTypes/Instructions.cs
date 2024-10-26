using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlSharp.Types;

internal static class Instructions
{
    /// <summary>
    /// Parses a field or variable from an XElement.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="builder"></param>
    /// <param name="indent"></param>
    internal static void FieldOrVariable(XElement element, StringBuilder builder, string indent)
    {
        string? access = ((string?)element.Attribute("access"))?.Replace(",", string.Empty);
        string? modifiers = ((string?)element.Attribute("modifiers"))?.Replace(",", string.Empty);
        string? type = (string?)element.Attribute("type");
        string? name = (string?)element.Attribute("name");
        string? value = (string?)element.Attribute("value");

        builder.AppendLine($"{indent}{access} {modifiers} {type} {name}{(value == null ? ";" : $" = {value};")}");
    }


    // Not finished
    internal static void Property(XElement element, StringBuilder builder, string indent)
    {
        if (element.Element("backingField") == null)
        {
            throw new MissingFieldException("No backing field found.");
            // TODO : Finish implementing auto generated code for future version.
            // element.Add(new XElement("backingField", new XAttribute("type", (string?)element.Attribute("type")), new XAttribute("value", "")));
            // FieldOrVariable(element.Element("backingField"), builder, indent);
        }

        bool isAuto = (bool?)element.Attribute("autoImplemented") ?? throw new MissingMemberException("Property is missing autoImplemented attribute");

        if (isAuto)
        {
            string? access = ((string?)element.Attribute("access"))?.Replace(",", string.Empty);
            string? modifiers = ((string?)element.Attribute("modifiers"))?.Replace(",", string.Empty);
            string? type = (string?)element.Attribute("type");
            string? name = (string?)element.Attribute("name");
            string? value = (string?)element.Attribute("value");

            builder.AppendLine($"{indent}{access} {modifiers} {type} {name} {{ get; set; }}{(value == null ? "" : $" = {value};")}");
        }
    }



    internal static void Method(XElement element, StringBuilder builder, string indent)
    {

    }



    internal static void Interface(XElement element, StringBuilder builder, string indent)
    {

    }



    internal static void Type(XElement element, StringBuilder builder, string indent)
    {

    }



    internal static void Enum(XElement element, StringBuilder builder, string indent)
    {

    }



    internal static void Indexer(XElement element, StringBuilder builder, string indent)
    {

    }
    /// <summary>
    /// Parses an attribute attachment from an XElement.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="builder"></param>
    /// <param name="indent"></param>
    internal static void Attribute(XElement element, StringBuilder builder, string indent)
    {
        string? type = (string?)element.Attribute("type");
        string? parameters = (string?)element.Attribute("parameters");
        builder.AppendLine($"{indent}[{type}({parameters})]");
    }
    /// <summary>
    /// Parses XText from an XElement to form a single-line comment.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="builder"></param>
    /// <param name="indent"></param>
    internal static void Comment(XElement element, StringBuilder builder, string indent)
    {
        builder.AppendLine($"{indent}// {(string)element}");
    }
}