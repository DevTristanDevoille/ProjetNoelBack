using System.Linq.Expressions;

namespace ProjetNoelAPI.Services.Commons
{
    public class RequestExpression<T>
    {
        public static Expression<Func<T, bool>> CreateRequetWithOneParam(string field,string param)
        {
            Type type = typeof(T);
            ParameterExpression parameter = Expression.Parameter(type, "param");
            MemberExpression fieldSearch = Expression.PropertyOrField(parameter, field);
            Expression<Func<T, bool>> requete;
            if (field.ToLower().Contains("id"))
            {
                requete = Expression.Lambda<Func<T, bool>>(Expression.Equal(fieldSearch, Expression.Constant(int.Parse(param))), parameter);
            }
            else
            {
                requete = Expression.Lambda<Func<T, bool>>(Expression.Equal(fieldSearch, Expression.Constant(param)), parameter);
            }

            return requete;
        }

        public static Expression<Func<T, bool>> CreateRequetWithTwoParam(string field1, string param1, string field2, string param2)
        {
            Type type = typeof(T);
            ParameterExpression parameter = Expression.Parameter(type, "param");
            MemberExpression fieldSearch1 = Expression.PropertyOrField(parameter, field1);
            MemberExpression fieldSearch2 = Expression.PropertyOrField(parameter, field2);
            Expression<Func<T, bool>> requete;
            if (field1.ToLower().Contains("id") || field2.Contains("id"))
            {
                requete = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(
                    Expression.Equal(fieldSearch1, Expression.Constant(int.Parse(param1))),
                    Expression.Equal(fieldSearch2,Expression.Constant(int.Parse(param2)))),
                    parameter);
            }
            else
            {
                requete = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(
                    Expression.Equal(fieldSearch1, Expression.Constant(param1)),
                    Expression.Equal(fieldSearch2, Expression.Constant(param2))),
                    parameter);
            }

            return requete;
        }
    }
}
