using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace BindingDemo
{
    internal static class BindingHelper
    {
        public static Binding BindTo<TControl, TDataSource>(
            this TControl control,
            TDataSource dataSource,
            Expression<Func<TControl, object>> controlProperty,
            Expression<Func<TDataSource, object>> dataSourceProperty,
            ControlUpdateMode controlUpdateMode = ControlUpdateMode.OnPropertyChanged,
            DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged)
            where TDataSource : class
            where TControl : IBindableComponent
        {
            Binding binding = control.DataBindings.Add(controlProperty.GetPropertyName(), dataSource, dataSourceProperty.GetPropertyName());

            // viewmodel (data source) gets updated like set in provided parameter
            binding.DataSourceUpdateMode = dataSourceUpdateMode;

            // control gets updated on viewmodel changes
            binding.ControlUpdateMode = controlUpdateMode;

            return binding;
        }

        public static string GetPropertyName<T>(this Expression<Func<T, object>> func)
        {
            return func.GetProperty().Name;
        }

        public static MemberInfo GetProperty<T, TE>(this Expression<Func<T, TE>> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }

            MemberExpression memberExpression;
            var body = func.Body as UnaryExpression;
            if (body != null)
            {
                memberExpression = body.Operand as MemberExpression;
            }
            else
            {
                memberExpression = func.Body as MemberExpression;
            }

            if (memberExpression == null)
            {
                throw new ArgumentException("func must be valid lambda expression");
            }

            return memberExpression.Member;
        }
    }
}