using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class BlackBoard : Resource
{
    [Export]
    private Dictionary<String, Dictionary> blackboard = new Dictionary<String, Dictionary> { {"default", new Dictionary() } };

    public static Variant EMPTY = "";

    public void Set(Variant key, Variant value, String blackboardName = "default")
    {
        if (!blackboard.ContainsKey(blackboardName))
        {
            blackboard[blackboardName] = new Dictionary();
        }

        blackboard[blackboardName][key] = value;
    }

    public Variant Get(String key, Variant defaultValue, String blackboardName = "default")
    {
        if(Has(key, blackboardName)){
            return blackboard[blackboardName][key];
        }
        return defaultValue;
    }

    public Variant Get(String key, String blackboardName = "default")
    {
        if (Has(key, blackboardName))
        {
            return blackboard[blackboardName][key];
        }
        return EMPTY;
    }

    public void Erase(String key, String blackboardName = "default")
    {
        if (blackboard.ContainsKey(blackboardName))
        {
            blackboard[blackboardName].Remove(key);
        }
    }

    public bool Has(String key, String blackboardName = "default")
    {
        return blackboard.ContainsKey(blackboardName) && blackboard[blackboardName].ContainsKey(key);
    }
}
