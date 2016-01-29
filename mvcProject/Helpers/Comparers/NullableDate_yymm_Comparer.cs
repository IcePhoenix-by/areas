using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Helpers
{
    class NullableDate_yymm_Comparer : IComparer<DateTime?>
    {
        public int Compare(DateTime? left, DateTime? right)
        {
            if (left == null && right == null)
                return 0;

            if (left == null)
                return -1;

            if (right == null)
                return 1;

            if (left.Value.Year == right.Value.Year)
            {
                if (left.Value.Month == right.Value.Month)
                    return 0;

                if (left.Value.Month < right.Value.Month)
                    return -1;

                return 1;
            }

            if (left.Value.Year < right.Value.Year)
                return -1;

            return 1;
        }
    }
}