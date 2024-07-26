﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace PowerLab.UI.Core.MarkupExtensions
{
    public class BindingWithDesignSupport : MarkupExtension
    {
        public BindingWithDesignSupport() { }

        public BindingWithDesignSupport(BindingBase binding)
        {
            Binding = binding;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DesignerProperties.GetIsInDesignMode(new DependencyObject()) ? DesignTimeValue : Binding.ProvideValue(serviceProvider);
        }

        public BindingBase Binding { get; set; }

        public object DesignTimeValue { get; set; }
    }
}
