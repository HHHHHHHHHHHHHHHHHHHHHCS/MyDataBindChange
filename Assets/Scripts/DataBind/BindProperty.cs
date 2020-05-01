using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DataBindChange
{
    public class BindProperty
    {
        public Action<BindPropertyChangedEvent> propertyChangedAct;
        public bool disableEvent = false;

        protected T GetProperty<T>(ref T property, [CallerMemberName] string propertyName = null)
        {
            if (BindHandler.Instance != null)
            {
                BindHandler.Instance.AddTarget(this, propertyName);
            }

            return property;
        }

        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(property, value))
                return;

            property = value;
            TriggerPropertyChange(this, propertyName);
        }

        public void TriggerPropertyChange(object target, string propertyName = null)
        {
            if (!disableEvent)
                propertyChangedAct?.Invoke(new BindPropertyChangedEvent()
                    {from = this, to = target, propertyName = propertyName});
        }
    }
}