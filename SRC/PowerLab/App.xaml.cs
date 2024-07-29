﻿using System;
using System.Threading;
using System.Windows;
using DryIoc;
using PowerLab.Core.Attributes;
using PowerLab.Core.Contracts;
using PowerLab.Core.Native.Win32;
using PowerLab.Core.Tools;
using PowerLab.Modules.ModuleName;
using PowerLab.Services;
using PowerLab.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace PowerLab
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            LoggingAttribute.Logger = Container.Resolve<ILogger>();
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILogger, SerilogService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        /// <summary>
        /// 程序入口函数
        /// </summary>
        [STAThread]
        static void Main()
        {
            var logger = new SerilogService();

            logger.Debug("程序已启动");

            using var mutex = new Mutex(true, "E2A4C483-C59D-4856-BE14-F9B4AF07042C");
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                IntPtr mainWindowHandle = Win32Helper.FindWindow(null, ApplicationResources.GetString("AppName"));
                if (mainWindowHandle != IntPtr.Zero)
                    Win32Helper.SetForegroundWindow(mainWindowHandle);

                logger.Debug("已有实例正在运行，正在退出程序。");
                return;
            }
            logger = null;

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
