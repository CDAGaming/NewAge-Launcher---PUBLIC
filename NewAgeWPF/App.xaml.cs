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
            //Sets Current Version and Resets Future Version
            Version CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            //string CurrentVersion_string = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //Settings.Default.CurrentVersion = CurrentVersion_string;
            //Settings.Default.FutureVersion = "";
            //Settings.Default.Save();

            

            if (Settings.Default.UpdatePostPoned == true)
            {
                Settings.Default.UpdatePostPoned = false;
                Settings.Default.Save();
            }
            if (Settings.Default.UpdateAccepted == true)
            {
                Settings.Default.UpdateAccepted = false;
                Settings.Default.Save();
            }

            
            // /* Use This Tag for DEBUGGING or in A ZIP Format
            if (Settings.Default.CheckforUpdateTag == true && Settings.Default.UpdatePGShow == true)
            {
                
                using (var updater = await UpdateManager.GitHubUpdateManager("https://github.com/CDAGaming/NewAge-Launcher_WPF"))
                {
                    var updatecheck = await updater.CheckForUpdate();
                    
                    if (updatecheck.ReleasesToApply.Any())
                    {
                       string FutureVersion = updatecheck.FutureReleaseEntry.Version.ToString();
                       Version FutureVer = Version.Parse(FutureVersion);
                       Settings.Default.FutureVersion = FutureVersion;
                       Settings.Default.Save();

                        if (CurrentVersion < FutureVer)
                        {
                            string UpdateMSG = "An Update is Available: " + " ( " + CurrentVersion + " > " + FutureVersion + " ) ";
                            UpdateMSG.Replace(",", ".");
                            Settings.Default.UpdateMessage = UpdateMSG;
                            Settings.Default.UpdateAvailable = true;
                            Settings.Default.Save();

                            if (Settings.Default.UpdateAccepted == true && Settings.Default.UpdatePostPoned == false)
                            {
                                await updater.ApplyReleases(updatecheck);

                                Process.Start(ResourceAssembly.Location);
                                Application.Current.Shutdown();
                            }
                            else if (Settings.Default.UpdateAccepted == false && Settings.Default.UpdatePostPoned == true)
                            {

                            }
                        }
                        else if (CurrentVersion == FutureVer)
                        {
                            string UpdateMSG = "Already Up-To-Date :D" + " ( " + CurrentVersion + " ) ";
                            UpdateMSG.Replace(",", ".");
                            Settings.Default.UpdateMessage = UpdateMSG;
                            Settings.Default.UpdateAvailable = false;
                            Settings.Default.Save();
                        }
                        else if (CurrentVersion > FutureVer)
                        {
                            string UpdateMSG = "Already Up-To-Date :D" + " ( " + CurrentVersion + " ) ";
                            UpdateMSG.Replace(",", ".");
                            Settings.Default.UpdateMessage = UpdateMSG;
                            Settings.Default.UpdateAvailable = false;
                            Settings.Default.Save();
                        }
                        
                    }
                    else
                    {
                        string UpdateMSG = "Already Up-To-Date :D" + " ( " + CurrentVersion + " ) ";
                        UpdateMSG.Replace(",", ".");
                        Settings.Default.UpdateMessage = UpdateMSG;
                        Settings.Default.UpdateAvailable = false;
                        Settings.Default.Save();
                    }
                }
                UpdatesPage updatepg = new NewAgeWPF.UpdatesPage();
                updatepg.ShowDialog();
            }
            else if (Settings.Default.CheckforUpdateTag == false && Settings.Default.UpdatePGShow == false)
            {
                // N/A
            }
            else if (Settings.Default.CheckforUpdateTag == true && Settings.Default.UpdatePGShow == false)
            {

            }
            else if (Settings.Default.CheckforUpdateTag == false && Settings.Default.UpdatePGShow == true)
            {
                UpdatesPage updatePG = new NewAgeWPF.UpdatesPage();
                updatePG.ShowDialog();
            }
            // */
            base.OnStartup(e);
        }

    }
}
