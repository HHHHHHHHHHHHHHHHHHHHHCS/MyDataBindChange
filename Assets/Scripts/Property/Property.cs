using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property<T>
{
    private event Action<T> actEvent;
    private T _val;

    public bool IsForces { get; set; }

    public T Val
    {
        get => _val;
        set
        {
            if (_val != null && value != null)
            {
                if (!_val.Equals(value))
                {
                    _val = value;
                    actEvent?.Invoke(Val);
                }
                else if (IsForces)
                {
                    actEvent?.Invoke(Val);
                }
            }
            else if (_val == null && value == null)
            {
                if (IsForces)
                {
                    actEvent?.Invoke(Val);
                }
            }
            else
            {
                _val = value;
                actEvent?.Invoke(Val);
            }
        }
    }

    public Property(T val = default(T), Action<T> act = null, bool _isForces = false)
    {
        _val = val;
        Add(act);
        IsForces = _isForces;
    }

    public void Add(Action<T> act)
    {
        if (act != null)
        {
            actEvent += act;
        }
    }

    public void Remove(Action<T> act)
    {
        if (act != null)
        {
            actEvent -= act;
        }
    }

    public void Set(Action<T> act)
    {
        actEvent = act;
    }

    public void Clear()
    {
        actEvent = null;
    }

    public static implicit operator T(Property<T> p)
    {
        return p._val;
    }
}