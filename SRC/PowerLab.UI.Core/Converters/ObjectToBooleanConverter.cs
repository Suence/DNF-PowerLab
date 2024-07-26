﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PowerLab.UI.Core.Converters
{
    [ValueConversion(typeof(object), typeof(bool))]
    public class ObjectToBooleanConverter : DependencyObject, IValueConverter
    {
        /// <summary>
        /// 标识 TrueValue 依赖属性。
        /// </summary>
        public static readonly DependencyProperty TrueValueProperty =
            DependencyProperty.Register(
                nameof(TrueValue),
                typeof(object),
                typeof(ObjectToBooleanConverter),
                new PropertyMetadata());

        /// <summary>
        /// 标识 FalseValue 依赖属性。
        /// </summary>
        public static readonly DependencyProperty FalseValueProperty =
            DependencyProperty.Register(
                nameof(FalseValue),
                typeof(object),
                typeof(ObjectToBooleanConverter),
                new PropertyMetadata());

        /// <summary>
        /// 获取或设置TrueValue的值
        /// </summary>
        public object TrueValue
        {
            get => GetValue(TrueValueProperty);
            set => SetValue(TrueValueProperty, value);
        }

        /// <summary>
        /// 获取或设置FalseValue的值
        /// </summary>
        public object FalseValue
        {
            get => GetValue(FalseValueProperty);
            set => SetValue(FalseValueProperty, value);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
            => value.Equals(TrueValue);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = value is bool b && b;

            return boolValue ? TrueValue : FalseValue;
        }
    }
}
