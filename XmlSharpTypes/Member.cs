using System.Xml.Linq;

namespace XmlSharp.Types;

/// <summary>
/// A wrapper class for XElements being parsed into C# code.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Member
{
    public readonly Member?[] immediateDescendants;
    public readonly XElement element;



    public Member(XElement element)
    {
        this.element = element;

        List<Member> intermediate = [];

        foreach (XElement childElement in element.Descendants().Where(x => x.Parent == element).Cast<XElement>().ToArray())
        {
            intermediate.Add(new(childElement));
        }

        immediateDescendants = [.. intermediate];
    }



    public static implicit operator Member(XElement element) => new(element);
}