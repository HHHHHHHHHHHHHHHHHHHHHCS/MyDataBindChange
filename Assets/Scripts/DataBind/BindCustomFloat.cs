using System.Collections;
using System.Collections.Generic;
using DataBindChange;
using UnityEngine;

public class BindCustomFloat : BindProperty
{
    private float _val;

    public float Val
    {
        get => GetProperty(ref _val);
        set => SetProperty(ref _val, value);
    }

    public BindCustomFloat(float input = 0)
    {
        _val = input;
    }
}
