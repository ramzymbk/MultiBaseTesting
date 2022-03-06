using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xpert.Common.Base.Helper;

namespace Xpert.Common.Base.Persistent
{
    public static class XpertQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Session"></param>
        /// <param name="PredicateExpression"></param>
        /// <returns></returns>
        public static T SelectObject<T>(Session Session, Expression<Func<T, bool>> PredicateExpression) 
        {
            var result = Session.Query<T>().Where(PredicateExpression).FirstOrDefault();
            if (XpertHelper.IsNotNullAndNotEmpty(result))
            {
                Session.Reload(result);
                return result;
            }
            return default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Session"></param>
        /// <param name="PredicateExpression"></param>
        /// <returns></returns>
        public static XPCollection<T> SelectListObjects<T>(Session Session, Expression<Func<T, bool>> PredicateExpression)
        {
            var result = Session.Query<T>().Where(PredicateExpression).ToList();
            if (XpertHelper.IsNotNullAndNotEmpty(result))
            {
                XPCollection<T> collection = new XPCollection<T>(Session);
                foreach (var item in result)
                {
                    Session.Reload(item);
                }
                try
                {
                    collection.AddRange(result);
                }
                catch (Exception)
                {

                    throw;
                }

                return collection;
            }
            return default(XPCollection<T>);
        }





        /// <summary>    
        /// Creates a predicate that evaluates to true.    
        /// </summary>    
        public static Expression<Func<T, bool>> True<T>() { return param => true; }

        /// <summary>    
        /// Creates a predicate that evaluates to false.    
        /// </summary>    
        public static Expression<Func<T, bool>> False<T>() { return param => false; }

        /// <summary>    
        /// Creates a predicate expression from the specified lambda expression.    
        /// </summary>    
        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate) { return predicate; }

        /// <summary>    
        /// Combines the first predicate with the second using the logical "and".    
        /// </summary>    
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>    
        /// Combines the first predicate with the second using the logical "or".    
        /// </summary>    
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        /// <summary>    
        /// Negates the predicate.    
        /// </summary>    
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }

        /// <summary>    
        /// Combines the first expression with the second using the specified merge function.    
        /// </summary>    
        static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)    
            var map = first.Parameters
                .Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first    
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // create a merged lambda expression with parameters from the first expression    
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        class ParameterRebinder : ExpressionVisitor
        {
            readonly Dictionary<ParameterExpression, ParameterExpression> map;

            ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;

                if (map.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }
    }
}
