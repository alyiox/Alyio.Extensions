﻿using System;
using System.Globalization;

namespace Alyio.Extensions
{
    /// <summary>
    /// Extension methods for converting a <see cref="Boolean"/> type to another base data type.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Converts the value of a specified object to an equivalent <see cref="Boolean"/> value.
        /// </summary>
        /// <param name="value">The object to convert.</param>
        /// <param name="provider">An <see cref="System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information. Default is <see cref="CultureInfo.InvariantCulture"/></param>
        /// <returns>
        /// <see cref="System.Object"/>: true or false, which reflects the value returned by invoking the <see cref="IConvertible.ToBoolean"/> method for the underlying type of value. If value is null, the method returns false. 
        /// <see cref="System.String"/>: true if value equals <see cref="Boolean.TrueString"/>, or false if value equals <see cref="Boolean.FalseString"/> or null.
        /// <see cref="System.Double"/>: true if value is not zero; otherwise, false.
        /// </returns>
        public static bool ToBoolean(this object? value, IFormatProvider? provider = null)
        {
            if (value == null)
            {
                return false;
            }

            if (typeof(bool).Equals(value.GetType()))
            {
                return (bool)value;
            }

            if (value is IConvertible converter)
            {
                try
                {
                    return converter.ToBoolean(provider ?? CultureInfo.InvariantCulture);
                }
                catch
                {
                    var d = value.ToDouble();
                    if (d != null)
                    {
                        return d != 0D;
                    }
                    else
                    {
                        var s = value.ToString();
                        return s.ToBoolean();
                    }
                }
            }
            else
            {
                var d = value.ToDouble();
                if (d != null)
                {
                    return d != 0D;
                }
                else
                {
                    var s = value.ToString();
                    return s.ToBoolean();
                }
            }
        }

        /// <summary>
        /// Converts the specified string representation of a logical value to its <see cref="System.Boolean"/> equivalent.
        /// </summary>
        /// <param name="s">A string containing the value to convert.</param>
        /// <returns>true if value is equal to <see cref="System.Boolean.TrueString"/> or false if value is equal to <see cref="System.Boolean.FalseString"/>, otherwise false.</returns>
        public static bool ToBoolean(this string? s)
        {
            return bool.TryParse(s, out bool result) && result;
        }
    }
}
