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
            if (field.Contains("id"))
            {
                requete = Expression.Lambda<Func<T, bool>>(Expression.Equal(fieldSearch, Expression.Constant(int.Parse(param))), parameter);
            }
            else
            {
                requete = Expression.Lambda<Func<T, bool>>(Expression.Equal(fieldSearch, Expression.Constant(param)), parameter);
            }

            return requete;
        }
    }
}
