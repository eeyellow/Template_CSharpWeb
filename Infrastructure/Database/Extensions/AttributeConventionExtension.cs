﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace LC.Infrastructure.Database.Extensions
{
    /// <summary> SqlDefaultValueAttributeConvention </summary>
    public static class SqlDefaultValueAttributeConvention
    {
        /// <summary> Apply </summary>
        public static void Apply(ModelBuilder builder)
        {
            ConventionBehaviors
                .SetSqlValueForPropertiesWithAttribute<SqlDefaultValueAttribute>(builder, x => x.DefaultValue);
        }
    }

    /// <summary> DecimalPrecisionAttributeConvention </summary>
    public static class DecimalPrecisionAttributeConvention
    {
        /// <summary> Apply </summary>
        public static void Apply(ModelBuilder builder)
        {
            ConventionBehaviors
                .SetTypeForPropertiesWithAttribute<DecimalPrecisionAttribute>(builder,
                    x => $"decimal({x.Precision}, {x.Scale})");
        }
    }

    /// <summary> CustomDataTypeAttributeConvention </summary>
    public class CustomDataTypeAttributeConvention
    {
        /// <summary> Apply </summary>
        public static void Apply(ModelBuilder builder)
        {
            ConventionBehaviors
                .SetTypeForPropertiesWithAttribute<DataTypeAttribute>(builder,
                    x => x.CustomDataType);
        }
    }

    /// <summary> ConventionBehaviors </summary>
    public static class ConventionBehaviors
    {
        /// <summary> SetTypeForPropertiesWithAttribute </summary>
        public static void SetTypeForPropertiesWithAttribute<TAttribute>(ModelBuilder builder, Func<TAttribute, string> lambda) where TAttribute : class
        {
            SetPropertyValue<TAttribute>(builder).ForEach((x) =>
            {
                x.Item1.SetColumnType(lambda(x.Item2));
            });
        }

        /// <summary> SetSqlValueForPropertiesWithAttribute </summary>
        public static void SetSqlValueForPropertiesWithAttribute<TAttribute>(ModelBuilder builder, Func<TAttribute, string> lambda) where TAttribute : class
        {
            SetPropertyValue<TAttribute>(builder).ForEach((x) =>
            {
                x.Item1.SetDefaultValueSql(lambda(x.Item2));
            });
        }

        private static List<Tuple<IMutableProperty, TAttribute>> SetPropertyValue<TAttribute>(ModelBuilder builder) where TAttribute : class
        {
            var propsToModify = new List<Tuple<IMutableProperty, TAttribute>>();
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties();
                foreach (var property in properties)
                {
                    var attribute = property.PropertyInfo
                        .GetCustomAttributes(typeof(TAttribute), false)
                        .FirstOrDefault() as TAttribute;
                    if (attribute != null)
                    {
                        propsToModify.Add(new Tuple<IMutableProperty, TAttribute>(property, attribute));
                    }
                }
            }
            return propsToModify;
        }
    }

    /// <summary>
    /// Set a default value defined on the sql server
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class SqlDefaultValueAttribute : Attribute
    {
        /// <summary>
        /// Default value to apply
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Set a default value defined on the sql server
        /// </summary>
        /// <param name="value">Default value to apply</param>
        public SqlDefaultValueAttribute(string value)
        {
            DefaultValue = value;
        }
    }

    /// <summary>
    /// Set the decimal precision of a decimal sql data type
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DecimalPrecisionAttribute : Attribute
    {
        /// <summary>
        /// Specify the precision - the number of digits both left and right of the decimal
        /// </summary>
        public int Precision { get; set; }

        /// <summary>
        /// Specify the scale - the number of digits to the right of the decimal
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// Set the decimal precision of a decimal sql data type
        /// </summary>
        /// <param name="precision">Specify the precision - the number of digits both left and right of the decimal</param>
        /// <param name="scale">Specify the scale - the number of digits to the right of the decimal</param>
        public DecimalPrecisionAttribute(int precision, int scale)
        {
            Precision = precision;
            Scale = scale;
        }

        /// <summary> DecimalPrecisionAttribute </summary>
        public DecimalPrecisionAttribute(int[] values)
        {
            Precision = values[0];
            Scale = values[1];
        }
    }
}
