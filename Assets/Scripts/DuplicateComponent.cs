using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DuplicateComponent
{
    public static T Duplicate<T>(T origin) where T : Component
    {
        var type = origin.GetType();
        var dst = new GameObject().AddComponent(type) as T;
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            if (field.IsStatic) continue;
            field.SetValue(dst, field.GetValue(origin));
        }
        var props = type.GetProperties();
        foreach (var prop in props)
        {
            if (!prop.CanWrite || !prop.CanWrite || prop.Name == "name") continue;
            prop.SetValue(dst, prop.GetValue(origin, null), null);
        }
        return dst;
    }
}
