using System;
using System.Collections.Generic;
using System.Text;

namespace Walle.Components.Extensions
{
    public static class DateExt
    {
        public static bool InRange(this DateTime dt, DateTime dtBegin, DateTime dtEnd)
        {
            if (dtBegin <= dt && dt <= dtEnd)
            {
                return true;
            }
            return false;
        }
    }
}
