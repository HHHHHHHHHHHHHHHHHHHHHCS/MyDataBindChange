using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BindPropertyChangedEvent
{
    public object from;
    public object to;
    public string propertyName;
}
