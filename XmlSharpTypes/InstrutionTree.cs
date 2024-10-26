using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualBasic;

using static XmlSharp.Types.Instructions;

namespace XmlSharp.Types;

public class InstructionTree
{
    private static Dictionary<XName, Action<XElement, StringBuilder, string>> tree = new()
    {
        ["field"] = FieldOrVariable,
        ["var"] = FieldOrVariable,
        ["property"] = Property,
        ["class"] = Type,
        ["struct"] = Type,
        ["record"] = Type,
        ["interface"] = Interface,
        ["indexer"] = Indexer,
        ["attribute"] = Attribute,
        ["comment"] = Comment
    };
    
}   