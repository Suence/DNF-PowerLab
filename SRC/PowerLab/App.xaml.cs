using System;
using System.Threading;
using System.Windows;
using PowerLab.Core.Native.Win32;
using PowerLab.Core.Tools;
using PowerLab.Modules.ModuleName;
using PowerLab.Services;
using PowerLab.Services.Interfaces;
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
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }

        /// <summary>
        /// 程序入口函数
        /// </summary>
        [STAThread] static void Main()
        {
            if (CheckAppIsRunning()) return;

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        /// <summary>
        /// 检查程序是否已经运行
        /// </summary>
        /// <returns>True: </returns>
        private static bool CheckAppIsRunning()
        {
            using var mutex = new Mutex(true, "E2A4C483-C59D-4856-BE14-F9B4AF07042C");
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                IntPtr mainWindowHandle = Win32Helper.FindWindow(null, ApplicationResources.GetString("AppName"));

                if (mainWindowHandle != IntPtr.Zero)
                {
                    Win32Helper.SetForegroundWindow(mainWindowHandle);
                }

                return true;
            }

            return false;
        }
    }
}
