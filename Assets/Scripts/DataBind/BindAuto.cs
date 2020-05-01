using System.Collections;
using System.Collections.Generic;
using DataBindChange;
using UnityEngine;

public class BindAuto<T> : BindProperty
{
    private T _val;

    public T Val
    {
        get => GetProperty(ref _val);
        set => SetProperty(ref _val, value);
    }

    public BindAuto(T input = default(T))
    {
        _val = input;
    }
}