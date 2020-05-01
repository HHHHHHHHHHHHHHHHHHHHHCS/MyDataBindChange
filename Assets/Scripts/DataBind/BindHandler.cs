using System;
using System.Collections;
using System.Collections.Generic;
using DataBindChange;
using UnityEngine;

public class BindHandler
{
    public static BindHandler Instance;

    private HashSet<BindTarget> bindTargets = new HashSet<BindTarget>();

    public Action<BindPropertyChangedEvent> changeAction;


    //添加一个绑定目标
    public BindHandler AddTarget(BindProperty property, string propertyName = null)
    {
        var bindTarget = new BindTarget()
        {
            target =  property,
            action = e =>
            {
                if (propertyName == null || propertyName == e.propertyName)
                {
                    changeAction?.Invoke(e);
                }
            }
        };

        bindTarget.Bind();
        bindTargets.Add(bindTarget);

        return this;
    }

    //根据表达式添加绑定目标，如 () => obj1.a + obj2.b
    public BindHandler AddTarget<T>(Func<T> expression)
    {
        AddExpressionListener(expression);
        return this;
    }

    //指定绑定后执行的回调，必须配合AddTarget使用
    public BindHandler BindAction(Action<BindPropertyChangedEvent> action)
    {
        this.changeAction = action;
        return this;
    }

    //属性绑定，setter设置值，getter获得绑定源
    //例子：BindProperty(v => obj2.a = v, () => obj1.a)，表示obj2.a永远等于obj1.a
    public BindHandler BindProperty<T>(Action<T> setter, Func<T> getter)
    {
        BindAction(e => setter(getter()));
        setter(AddExpressionListener(getter));
        return this;
    }

    //属性绑定,setter是从绑定源复制数据到目标的代码
    //例子：BindProperty(() => obj2.a = obj1.a)，表示obj2.a永远等于obj1.a
    //必须保证obj2是一个局部变量而不是属性
    public BindHandler BindProperty(Action setter)
    {
        BindAction(e => setter());
        Instance = this;
        setter.Invoke();
        Instance = null;
        return this;
    }

    private T AddExpressionListener<T>(Func<T> expression)
    {
        Instance = this;
        var result = expression.Invoke();
        Instance = null;
        return result;
    }

    //移除绑定
    public void UnBind()
    {
        foreach (var item in bindTargets)
        {
            item.UnBind();
        }
        bindTargets.Clear();
    }
}
