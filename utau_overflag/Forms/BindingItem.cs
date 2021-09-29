﻿using System;
namespace utau_overflags.Forms
{
    public class BindingItem<T> : IEquatable<BindingItem<T>>
    {
        public BindingItem(T item)
        {
            Item = item;
        }
        public T Item;

        public override string ToString()
        {
            return Item.ToString();
        }

        public bool Equals(BindingItem<T> other)
        {
            if (other == null) return false;

            return (this.Item.Equals(other.Item));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            return this.Equals((BindingItem<T>)obj);
        }

        public override int GetHashCode()
        {
            return this.Item.GetHashCode();
        }
    }
}
