using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheCancerProject.Core.Utilities
{
    public class Utilities
    {        
        public static List<object> GetEnumNames(string enumStringType)
        {
            List<object> result = new List<object>();
            Type enumType = Type.GetType(enumStringType);
            foreach (object enumValue in Enum.GetValues(enumType))
            {
                string enumName = Enum.GetName(enumType, enumValue);
                var data = new
                {
                    Name = SpaceWords(enumName),
                    Value = enumValue
                };
                result.Add(data);
            }
            return result;
        }        

        private static string SpaceWords(string words)
        {
            StringBuilder result = new StringBuilder();
            foreach (char letter in words.ToCharArray())
            {
                if (char.IsUpper(letter))
                {
                    result.Append(' ');
                }
                result.Append(letter);
            }
            return result.Replace('_', ' ').ToString();
        }
        public static string SplitAtCapitalLetters(string stringToSplit)
        {
            string str = Regex.Replace(stringToSplit, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
            if (str.Length == 0)
            {
                return str;
            }
            str = string.Format("{0}{1}", str.Substring(0, 1).ToUpper(), str.Substring(1, str.Length - 1));
            StringBuilder builder = new StringBuilder();
            string[] strArray = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length == 1)
            {
                return str;
            }
            builder.Append(strArray[0].Trim());
            bool flag = strArray[0].Trim().Length > 1;
            for (int i = 1; i < strArray.Length; i++)
            {
                if (strArray[i].Trim().Length == 1)
                {
                    builder.AppendFormat("{0}{1}", (flag && (i == 1)) ? " " : "", strArray[i].Trim());
                }
                else
                {
                    builder.AppendFormat(" {0}", strArray[i].Trim());
                }
            }
            return builder.ToString();
        }
    }
}
