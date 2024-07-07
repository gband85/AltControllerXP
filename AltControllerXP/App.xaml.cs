using AltControllerXP.Interfaces;
using AltControllerXP.Services;
using AltControllerXP.ViewModels;
using AltControllerXP.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AltControllerXP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IDialogService dialogService = new DialogService(MainWindow);

            dialogService.Register<DialogViewModel, DialogWindow>();
            dialogService.Register<HelpAboutWindowViewModel, HelpAboutWindow>();

            var viewModel = new MainWindowViewModel(dialogService);
            var view = new MainWindow { DataContext = viewModel };

            view.ShowDialog();
        }
    }
}
