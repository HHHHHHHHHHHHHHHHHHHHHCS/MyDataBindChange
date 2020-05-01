using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBindChange
{
    public class BindProperty<T>
    {
        private T _val;

        private readonly HashSet<BindProperty<T>> listernSet = new HashSet<BindProperty<T>>();

        public T Val
        {
            get => _val;
            set
            {
                if (EqualityComparer<T>.Default.Equals(_val, value))
                    return;

                _val = value;
                DispatchChange(_val);
            }
        }

        public BindProperty(T input = default(T))
        {
            _val = input;
        }

        public void Add(BindProperty<T> bp)
        {
            listernSet.Add(bp);
        }

        public void Remove(BindProperty<T> bp)
        {
            listernSet.Remove(bp);
        }

        public void DispatchChange(T v)
        {
            foreach (var item in listernSet)
            {
                item.Val = v;
            }
        }

        public static BindProperty<T> operator +(BindProperty<T> bp0, BindProperty<T> bp1)
        {
            bp0.Add(bp1);
            return bp0;
        }

        public static BindProperty<T> operator -(BindProperty<T> bp0, BindProperty<T> bp1)
        {
            bp0.Remove(bp1);
            return bp0;
        }

        public static BindProperty<T> operator *(BindProperty<T> bp0, BindProperty<T> bp1)
        {
            bp0.Add(bp1);
            bp1.Add(bp0);

            return bp0;
        }

        public static BindProperty<T> operator /(BindProperty<T> bp0, BindProperty<T> bp1)
        {
            bp0.Remove(bp1);
            bp1.Remove(bp0);

            return bp0;
        }

        public static bool operator ==(BindProperty<T> bp0, BindProperty<T> bp1)
        {
            return EqualityComparer<T>.Default.Equals(bp0._val, bp1._val);
        }

        public static bool operator !=(BindProperty<T> bp0, BindProperty<T> bp1)
        {
            return !EqualityComparer<T>.Default.Equals(bp0._val, bp1._val);
        }

        public static implicit operator T(BindProperty<T> p)
        {
            return p._val;
        }

        public override string ToString()
        {
            return _val.ToString();
        }
    }
}