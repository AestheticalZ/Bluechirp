using Bluechirp.Library.Constants;
using Bluechirp.Library.Enums;
using Bluechirp.Library.Models;
using Bluechirp.Library.Services.Environment;
using Bluechirp.Library.Services.Interface;
using Bluechirp.Library.Services.Security;
using Bluechirp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media.Animation;
using System.Threading.Tasks;
using WinUIEx;

namespace Bluechirp
{
    public sealed partial class MainWindow : WindowEx
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.MinWidth = 380;
            this.MinHeight = 570;

            AppWindow.Title = "Bluechirp";
            AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;
            AppWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            AppWindow.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        /// <summary>
        /// Checks if there are credentials stored in the disk.
        /// If none are found, the content frame will navigate to <see cref="LoginPage"/>.
        /// Otherwise, it will navigate to <see cref="ShellView"/>.
        /// </summary>
        public async Task CheckLoginAndNavigateAsync()
        {
            ISettingsService settingsService = App.ServiceProvider.GetRequiredService<ISettingsService>();
            ICredentialService credentialService = App.ServiceProvider.GetRequiredService<ICredentialService>();
            IAuthService authService = App.ServiceProvider.GetRequiredService<IAuthService>();
            INavigationService navService = App.ServiceProvider.GetRequiredService<INavigationService>();

            string lastProfile = settingsService.Get<string>(SettingsConstants.LAST_PROFILE_KEY);

            await credentialService.LoadProfileDataAsync();
            navService.TargetFrame = ContentFrame;

            if(lastProfile != string.Empty)
            {
                ProfileCredentials credentials = credentialService.GetProfileData(lastProfile);
                authService.LoadClientFromCredentials(credentials);

                navService.Navigate(PageType.Shell, null, new DrillInNavigationTransitionInfo());
            }
            else
            {
                navService.Navigate(PageType.Login, null, new DrillInNavigationTransitionInfo());
            }
        }

        /// <summary>
        /// Shows the splash screen.
        /// </summary>
        public void ShowSplash()
        {
            ContentFrame.Navigate(typeof(SplashScreenPage));
        }
    }
}
