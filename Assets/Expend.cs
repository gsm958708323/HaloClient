using System.Collections;
using System.Collections.Generic;

public static class Expend
{
    public static TValue TryGet<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
    {
        TValue value;
        if (!dict.ContainsKey(key))
        {
            return default(TValue);
        }
        else
        {
            dict.TryGetValue(key, out value);
            return value;
        }
    }
}
