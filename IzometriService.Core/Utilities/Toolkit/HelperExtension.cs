using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IzometriService.Core.Utilities.Toolkit
{
    public static class HelperExtension
    {
        public static IQueryable<T> CustomOrderBy<T>(this IQueryable<T> query, string orderBy)
        {
            if (String.IsNullOrEmpty(orderBy))
                return query;
            var arry = orderBy.Split(",");

            if (arry.Length > 0)
            {
                var propertyAndDirectionArry = arry[0].Split(":");
                if (propertyAndDirectionArry[1] == "desc")
                    query = query.CustomOrderByDescending(propertyAndDirectionArry[0]);
                else
                    query = query.CustomOrderByAscending(propertyAndDirectionArry[0]);

                if (arry.Length > 1)
                {
                    for (int i = 1; i < arry.Length; i++)
                    {
                        var propertyAndDirectionArryInner = arry[i].Split(":");
                        if (propertyAndDirectionArryInner[1] == "desc")
                            query = ((IOrderedQueryable<T>)query).CustomThenByDescending(propertyAndDirectionArryInner[0]);
                        else
                            query = ((IOrderedQueryable<T>)query).CustomThenByAscending(propertyAndDirectionArryInner[0]);
                    }
                }
            }

            return query;
        }
    }
}
