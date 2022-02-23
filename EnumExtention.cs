using System.ComponentModel;
using System.Reflection;

namespace CSVHelperSample
{
    /// <summary>
    /// Enum拡張。当サンプルの本筋外。
    /// </summary>
    internal static partial class EnumExtention
    {
        /// <summary>
        /// Description属性の取得
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        /// <exception cref="CustomAttributeFormatException"></exception>
        internal static string GetEnumDescription(this Enum e)
        {
            FieldInfo? fieldInfo = e.GetType().GetField(e.ToString());
            if (fieldInfo is null)
            {
                throw new InvalidEnumArgumentException();
            };
            Attribute? attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
            if (attr is null)
            {
                throw new CustomAttributeFormatException("Descriptionが未定義");
            }
            return ((DescriptionAttribute)attr).Description;
        }
    }


}
