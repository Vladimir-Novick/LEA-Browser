using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEA.Lib
{
    public static class LEAExtentions
    {
        public static string ToKey<T>(this List<T> list)
        {
            if (list.Count == 0) return "";
            StringBuilder buider = new StringBuilder();

            for (int i = 0; i< list.Count-1;i++)
            {
                buider.Append(list[i].ToString());
                buider.Append(" , ");
            }
            buider.Append(list[list.Count-1].ToString());
            return buider.ToString();
        }
    }
}
