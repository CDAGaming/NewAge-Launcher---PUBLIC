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
using NewAgeWPF.Properties;

namespace NewAgeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            string CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Settings.Default.CurrentVersion = CurrentVersion;
            Settings.Default.Save();

            
            if (Settings.Default.CheckforUpdateTag == true)
            {
                using (var updater = await UpdateManager.GitHubUpdateManager("https://github.com/CDAGaming/NewAge-Launcher---PUBLIC"))
                {

                    if (Settings.Default.UpdatePGShow == false && Settings.Default.CheckforUpdateTag == true)
                    {
                        var UpdateCheck = await updater.CheckForUpdate();

                        if (UpdateCheck.ReleasesToApply.Any())
                        {
                            Settings.Default.UpdatePGShow = true;
                        }
                    }
                    else if (Settings.Default.UpdatePGShow == true && Settings.Default.CheckforUpdateTag == true)
                    {
                        var UpdateCheck = await updater.CheckForUpdate();

                        if (UpdateCheck.ReleasesToApply.Any())
                        {
                            string FutureVersion = UpdateCheck.FutureReleaseEntry.Version.ToString();
                            string UpdateMSG = "Current Version:" + Settings.Default.CurrentVersion + "---" + "Update Available" + " ( " + FutureVersion + ")";
                            Settings.Default.UpdateMessage = UpdateMSG;
                            Settings.Default.Save();

                            UpdatesPage updatePG = new UpdatesPage();
                            updatePG.ShowDialog();

                            if (Settings.Default.UpdateAccepted == true && Settings.Default.UpdatePostPoned == false)
                            {
                                await updater.ApplyReleases(UpdateCheck);

                                Process.Start(ResourceAssembly.Location);
                                Application.Current.Shutdown();
                            }
                            else if (Settings.Default.UpdateAccepted == false && Settings.Default.UpdatePostPoned == true)
                            {
                                MessageBox.Show("You Will be Reminded On Next Reboot of Launcher");
                            }

                        }
                    }
                    else if (Settings.Default.UpdatePGShow == false && Settings.Default.CheckforUpdateTag == false)
                    {
                        // Do Nothing in Startup Event
                    }
                    else if (Settings.Default.UpdatePGShow == true && Settings.Default.CheckforUpdateTag == false)
                    {
                        UpdatesPage UpdatePG = new UpdatesPage();
                        UpdatePG.ShowDialog();
                    }
                }

            }

        }
    }
}
