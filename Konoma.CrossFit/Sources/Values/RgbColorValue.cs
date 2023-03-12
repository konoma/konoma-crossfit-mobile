using System.Globalization;

namespace Konoma.CrossFit
{
    /// <summary>
    /// A platform agnostic way to represent an RGB color value with an alpha component.
    /// </summary>
    public struct RgbColorValue
    {
        /// <summary>
        /// Creates a RgbColorValue from an integer in the ARGB format.
        /// </summary>
        /// <remarks>
        /// If alpha is 0x00 this is interpreted as 0xFF instead. Use the
        /// <see cref="RgbColorValue(byte, byte, byte, byte)"/> constructor
        /// to create a color value with an explicit 0x00 alpha value.
        /// </remarks>
        /// <param name="argb">The argb value to parse.</param>
        /// <returns></returns>
        public static RgbColorValue FromArgb(int argb)
        {
            var a = (byte)(argb >> 24);
            var r = (byte)(argb >> 16);
            var g = (byte)(argb >> 8);
            var b = (byte)(argb >> 0);

            if (a == 0x00)
            {
                a = 0xFF;
            }

            return new RgbColorValue(red: r, green: g, blue: b, alpha: a);
        }

        /// <summary>
        /// Parse a string in the format <c>#xxxxxx</c> or <c>xxxxxx</c> where <c>x</c> is a hex digit.
        /// </summary>
        /// <remarks>
        /// Alpha values are not supported.
        /// </remarks>
        /// <param name="hexString">A hex string that represents an RGB color.</param>
        /// <returns></returns>
        public static RgbColorValue ParseString(string hexString) => TryParseString(hexString, out var result)
            ? result
            : throw new ArgumentException(
                message: "Hex string must be in the format #xxxxxx or xxxxxx where x is a hex digit",
                paramName: nameof(hexString));

        public static bool TryParseString(string hexString, out RgbColorValue result)
        {
            if (hexString.StartsWith("#"))
            {
                hexString = hexString.Substring(1);
            }

            if (hexString.Length != 6)
            {
                result = default;
                return false;
            }

            if (!int.TryParse(hexString, NumberStyles.HexNumber, null, out var rgbInt))
            {
                result = default;
                return false;
            }

            result = FromArgb(rgbInt);
            return true;
        }

        public RgbColorValue(byte red, byte green, byte blue, byte alpha)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Alpha = alpha;
        }

        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }

        public byte Alpha { get; }
    }
}
