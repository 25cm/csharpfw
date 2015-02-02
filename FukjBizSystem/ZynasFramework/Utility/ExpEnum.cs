using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Utility
{
    /// <summary>
    /// enumにラベルを付与するための属性定義
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class LabeledEnumAttribute : Attribute
    {
        /// <summary>
        /// ラベル文字列
        /// </summary>
        private String label;
        public LabeledEnumAttribute(String value)
        {
            this.label = value;
        }
        /// <summary>
        /// 属性で指定されたラベル文字列を取得する。
        /// </summary>
        /// <param name="value">ラベル付きフィールド</param>
        /// <returns>ラベル文字列</returns>
        public static string GetLabel(Enum value)
        {
            Type enumType = value.GetType();
            string name = Enum.GetName(enumType, value);
            LabeledEnumAttribute[] attrs =
                (LabeledEnumAttribute[])enumType.GetField(name)
                .GetCustomAttributes(typeof(LabeledEnumAttribute), false);
            if (attrs.Length == 0) return "";
            return attrs[0].label;
        }
    }

    /// <summary>
    /// enumに付与されたラベルを取得するための拡張メソッド
    /// </summary>
    public static class LabeledEnum
    {
        public static String GetLabel(this Enum e)
        {
            return LabeledEnumAttribute.GetLabel(e);
        }
    }
}
