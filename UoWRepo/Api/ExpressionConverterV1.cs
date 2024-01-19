using System;
using System.Linq.Expressions;

namespace UoWRepo.Api;

public static class ExpressionConverterV1
{
    public static Expression<Func<TDestination, bool>> Convert<TSource, TDestination>(
        Expression<Func<TSource, bool>> sourcePredicate)
    {
        var replaceParam = Expression.Parameter(typeof(TDestination), "p");
        var visitor = new Visitor<TSource, TDestination>(replaceParam);
        var destinationBody = visitor.Visit(sourcePredicate.Body);
        return Expression.Lambda<Func<TDestination, bool>>(destinationBody, replaceParam);
    }

    private class Visitor<TSource, TDestination> : ExpressionVisitor
    {
        private readonly ParameterExpression _replaceParam;

        public Visitor(ParameterExpression replaceParam)
        {
            _replaceParam = replaceParam;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof(TSource))
                return _replaceParam;
            return base.VisitParameter(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TSource))
            {
                var member = typeof(TDestination).GetMember(node.Member.Name)[0];
                var visit =Visit(node.Expression);
                return Expression.MakeMemberAccess(visit, member);
            }
            return base.VisitMember(node);
        }
    }
}