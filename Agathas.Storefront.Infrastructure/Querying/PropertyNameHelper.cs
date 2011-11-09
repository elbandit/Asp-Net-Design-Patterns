using System;
using System.Linq.Expressions;

namespace Agathas.Storefront.Infrastructure.Querying
{
    public static class PropertyNameHelper
    {
        public static string ResolvePropertyName<T>(Expression<Func<T, object>> expression)
        {
            var expr = expression.Body as MemberExpression;
            if (expr == null)
            {
                var u = expression.Body as UnaryExpression;
                expr = u.Operand as MemberExpression;
            }
            return expr.ToString().Substring(expr.ToString().IndexOf(".") + 1);
        } 
    }
}
