using System.Collections.Generic;
using UnityEngine;

public abstract class Registry<T> : ScriptableObject where T : SerializableScriptableObject
{
    [SerializeField] protected List<T> _descriptors = new List<T>();

    public List<T> Descriptors => _descriptors;

    public T FindByUuid(string guid)
    {
        foreach (var desc in _descriptors)
        {
            if (desc.Guid == guid)
            {
                return desc;
            }
        }

        return null;
    }
}