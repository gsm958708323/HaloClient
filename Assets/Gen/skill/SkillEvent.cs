//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace cfg.skill
{

public abstract class SkillEvent :  Bright.Config.BeanBase 
{
    public SkillEvent(JSONNode _json) 
    {
    }

    public SkillEvent() 
    {
    }

    public static SkillEvent DeserializeSkillEvent(JSONNode _json)
    {
        string type = _json["__type__"];
        switch (type)
        {
            case "TestEvent": return new skill.TestEvent(_json);
            case "TestEvent2": return new skill.TestEvent2(_json);
            default: throw new SerializationException();
        }
    }



    public virtual void Resolve(Dictionary<string, object> _tables)
    {
    }

    public virtual void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "}";
    }
    }
}