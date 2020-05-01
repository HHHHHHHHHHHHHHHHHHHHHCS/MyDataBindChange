using System;
using System.Collections;
using System.Collections.Generic;
using DataBindChange;
using UnityEngine;

public struct BindTarget
{
    public BindProperty target;
    public Action<BindPropertyChangedEvent> action;

    public void Bind()
    {
        target.propertyChangedAct += action;
    }

    public void UnBind()
    {
        if (action != null)
            target.propertyChangedAct -= action;
    }
}