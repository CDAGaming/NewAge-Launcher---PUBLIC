using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Squirrel;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace NewAgeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {


            if (NewAgeWPF.Properties.Settings.Default.CheckforUpdateTag == true)
            {
                using (var updater = UpdateManager.GitHubUpdateManager("https://github.com/CDAGaming/NewAge-Launcher---PUBLIC"))
                {
                    //var UpdateCheck = await updater.CheckForUpdate();

                    if (NewAgeWPF.Properties.Settings.Default.UpdatePGShow == false)
                    {
                        try
                        {
                            await updater.Result.UpdateApp();

                            MessageBox.Show("The Launcher has been Updated to a New Version, Please Restart The Launcher to Apply Update", "Update Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception)
                        {
                            //
                        }
                    }
                    else
                    {
                        await updater.Result.UpdateApp();


                        UpdatesPage updatePG = new UpdatesPage();
                        updatePG.ShowDialog();
                    }
                }

            }
            base.OnStartup(e);
        }
    }
}
