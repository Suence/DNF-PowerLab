using System.Windows;
using System.Windows.Markup;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None,            //where theme specific resource dictionaries are located
                                                //(used if a resource is not found in the page,
                                                // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly   //where the generic resource dictionary is located
                                                //(used if a resource is not found in the page,
                                                // app, or any theme specific resource dictionaries)
)]

[assembly: XmlnsDefinition("http://ui.powerlab.com/", "PowerLab.UI.Core.Converters")]
[assembly: XmlnsDefinition("http://ui.powerlab.com/", "PowerLab.UI.Core.Behaviors")]
[assembly: XmlnsDefinition("http://ui.powerlab.com/", "PowerLab.UI.Core.AttachedProperties")]
[assembly: XmlnsDefinition("http://ui.powerlab.com/", "PowerLab.UI.Core.Tools")]
[assembly: XmlnsDefinition("http://ui.powerlab.com/", "PowerLab.UI.Core.MarkupExtensions")]
[assembly: XmlnsDefinition("http://ui.powerlab.com/", "PowerLab.UI.Core.Selectors")]