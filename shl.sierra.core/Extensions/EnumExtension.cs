using System;

namespace shl.sierra.core.Extensions
{

    /// <summary> Enum Extension Methods </summary>
    /// <typeparam name="T"> type of Enum </typeparam>
    public class Enum<T> where T : struct, IConvertible
    {
        public static T[] GetEnumArray()
        {
            T[] array = (T[])Enum.GetValues(typeof(T));
            return array;
        }
    }

}
