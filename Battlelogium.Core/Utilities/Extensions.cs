using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System;

namespace Battlelogium.Core.Utilities
{
    public static class Extensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue ret;
            // Ignore return value
            dictionary.TryGetValue(key, out ret);
            return ret;
        }
    }
}
