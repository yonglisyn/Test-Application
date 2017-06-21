using System;
using System.Collections.Generic;

namespace BlackJack.Extensions
{
    public static class ListExtension
    {
        public static void Shuffle<T>(this IList<T> list, Random rnd)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var j = rnd.Next(i, list.Count);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
