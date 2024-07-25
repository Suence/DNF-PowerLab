using System.Windows;
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
    }
}
