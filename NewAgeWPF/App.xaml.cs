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
using System.Windows.Documents;

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

            // Kills All Running World Of Warcraft Processes, to Prevent Patch Read Issues

            foreach (var process_wow1 in Process.GetProcessesByName("wow_mod"))
            {
                process_wow1.Kill();
            }

            foreach (var process_wow2 in Process.GetProcessesByName("wow"))
            {
                process_wow2.Kill();
            }


            if (Settings.Default.UpdatePostPoned == true)
            {
                Settings.Default.UpdatePostPoned = false;
                Settings.Default.Save();
            }


            // /* Use This Tag for DEBUGGING or in A ZIP Format
            if (Settings.Default.CheckforUpdateTag == true && Settings.Default.UpdatePGShow == true)
            {
                if (Settings.Default.UpdateChannel == "Release")
                {
                    using (var updater = await UpdateManager.GitHubUpdateManager("https://github.com/CDAGaming/NewAge-Launcher_WPF", null, null, null, false, null))
                    {
                        var updatecheck = await updater.CheckForUpdate();

                        if (updatecheck.ReleasesToApply.Any())
                        {
                            List<ReleaseEntry> updatedownloads = updatecheck.ReleasesToApply;
                            string FutureVersion = updatecheck.FutureReleaseEntry.Version.ToString();
                            Version FutureVer = Version.Parse(FutureVersion);
                            Settings.Default.FutureVersion = FutureVersion;
                            Settings.Default.Save();

                            if (CurrentVersion < FutureVer)
                            {
                                if (Settings.Default.CurrentChannel != "Release")
                                {
                                    string UpdateMSG = "An Update is Available: " + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " > " + FutureVersion + " - " + "Release" + " ) ";
                                    Settings.Default.UpdateMessage = UpdateMSG;
                                    Settings.Default.UpdateAvailable = true;
                                    Settings.Default.Save();
                                }
                                else if (Settings.Default.CurrentChannel == "Release")
                                {
                                    string UpdateMSG = "An Update is Available: " + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " > " + FutureVersion + " - " + Settings.Default.CurrentChannel + " ) ";
                                    Settings.Default.UpdateMessage = UpdateMSG;
                                    Settings.Default.UpdateAvailable = true;
                                    Settings.Default.Save();
                                }

                                if (Settings.Default.UpdateAccepted == true && Settings.Default.UpdatePostPoned == false)
                                {
                                    await updater.DownloadReleases(updatedownloads);
                                    await updater.ApplyReleases(updatecheck);

                                    Settings.Default.UpdateAccepted = false;
                                    Settings.Default.UpdateAvailable = false;
                                    Settings.Default.CurrentChannel = "Release";
                                    Settings.Default.Save();

                                    MessageBoxResult updateresult = MessageBox.Show("Update Complete, Please Relaunch Launcher to Start New Version, or Exit the Prompt to Exit at your Own Time.", "Update Completed!", MessageBoxButton.OK, MessageBoxImage.Information);

                                    if (updateresult == MessageBoxResult.OK)
                                    {
                                        Application.Current.Shutdown();
                                    }
                                }
                                else if (Settings.Default.UpdateAccepted == false && Settings.Default.UpdatePostPoned == true)
                                {
                                    MessageBox.Show("Update Has been Postponed Until Next Restart.");
                                }
                            }
                            else if (CurrentVersion >= FutureVer)
                            {
                                string UpdateMSG = "Already Up-To-Date :D" + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " ) ";
                                Settings.Default.UpdateMessage = UpdateMSG;
                                Settings.Default.UpdateAvailable = false;
                                Settings.Default.Save();
                            }
                        }
                        else
                        {
                            string UpdateMSG = "Already Up-To-Date :D" + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " ) ";
                            Settings.Default.UpdateMessage = UpdateMSG;
                            Settings.Default.UpdateAvailable = false;
                            Settings.Default.Save();
                        }
                    }
                }
                else if (Settings.Default.UpdateChannel == "Beta")
                {
                    using (var updater = await UpdateManager.GitHubUpdateManager("https://github.com/CDAGaming/NewAge-Launcher_WPF", null, null, null, true, null))
                    {
                        var updatecheck = await updater.CheckForUpdate();

                        if (updatecheck.ReleasesToApply.Any())
                        {
                            List<ReleaseEntry> updatedownloads = updatecheck.ReleasesToApply;
                            string FutureVersion = updatecheck.FutureReleaseEntry.Version.ToString();
                            Version FutureVer = Version.Parse(FutureVersion);
                            Settings.Default.FutureVersion = FutureVersion;
                            Settings.Default.Save();

                            if (CurrentVersion < FutureVer)
                            {
                                if (Settings.Default.CurrentChannel != "Beta")
                                {
                                    string UpdateMSG = "An Update is Available: " + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " > " + FutureVersion + " - " + "PreRelease" + " ) ";
                                    Settings.Default.UpdateMessage = UpdateMSG;
                                    Settings.Default.UpdateAvailable = true;
                                    Settings.Default.Save();
                                }
                                else if (Settings.Default.CurrentChannel == "Beta")
                                {
                                    string UpdateMSG = "An Update is Available: " + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " > " + FutureVersion + " - " + Settings.Default.CurrentChannel + " ) ";
                                    Settings.Default.UpdateMessage = UpdateMSG;
                                    Settings.Default.UpdateAvailable = true;
                                    Settings.Default.Save();
                                }

                                if (Settings.Default.UpdateAccepted == true && Settings.Default.UpdatePostPoned == false)
                                {
                                    await updater.DownloadReleases(updatedownloads);
                                    await updater.ApplyReleases(updatecheck);

                                    Settings.Default.UpdateAccepted = false;
                                    Settings.Default.UpdateAvailable = false;
                                    Settings.Default.CurrentChannel = "Beta";
                                    Settings.Default.Save();

                                    MessageBoxResult updateresult = MessageBox.Show("Update Complete, Please Relaunch Launcher to Start New Version, or Exit the Prompt to Exit at your Own Time.", "Update Completed!", MessageBoxButton.OK, MessageBoxImage.Information);

                                    if (updateresult == MessageBoxResult.OK)
                                    {
                                        Application.Current.Shutdown();
                                    }
                                }
                                else if (Settings.Default.UpdateAccepted == false && Settings.Default.UpdatePostPoned == true)
                                {
                                    MessageBox.Show("Update Has been Postponed Until Next Restart.");
                                }
                            }
                            else if (CurrentVersion >= FutureVer)
                            {
                                string UpdateMSG = "Already Up-To-Date :D" + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " ) ";
                                Settings.Default.UpdateMessage = UpdateMSG;
                                Settings.Default.UpdateAvailable = false;
                                Settings.Default.Save();
                            }
                        }
                        else
                        {
                            string UpdateMSG = "Already Up-To-Date :D" + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " ) ";
                            UpdateMSG.Replace(",", ".");
                            Settings.Default.UpdateMessage = UpdateMSG;
                            Settings.Default.UpdateAvailable = false;
                            Settings.Default.Save();
                        }
                    }
                }

                UpdatesPage updatepg = new UpdatesPage();
                updatepg.ShowDialog();
            }
            else if (Settings.Default.CheckforUpdateTag == false && Settings.Default.UpdatePGShow == false)
            {
                // N/A
            }
            else if (Settings.Default.CheckforUpdateTag == true && Settings.Default.UpdatePGShow == false)
            {
                if (Settings.Default.UpdateChannel == "Release")
                {
                    using (var updater = await UpdateManager.GitHubUpdateManager("https://github.com/CDAGaming/NewAge-Launcher_WPF", null, null, null, false, null))
                    {
                        var updatecheck = await updater.CheckForUpdate();

                        if (updatecheck.ReleasesToApply.Any())
                        {
                            List<ReleaseEntry> updatedownloads = updatecheck.ReleasesToApply;
                            string FutureVersion = updatecheck.FutureReleaseEntry.Version.ToString();
                            Version FutureVer = Version.Parse(FutureVersion);
                            Settings.Default.FutureVersion = FutureVersion;
                            Settings.Default.Save();

                            if (CurrentVersion < FutureVer)
                            {
                                if (Settings.Default.CurrentChannel != "Release")
                                {
                                    MessageBoxResult msgresult = MessageBox.Show("An Update is Available: " + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " > " + FutureVersion + " - " + "Release" + " ) " + ", Do you Wish to Update?", "New Update Available!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                                    if (msgresult == MessageBoxResult.Yes)
                                    {
                                        await updater.DownloadReleases(updatedownloads);
                                        await updater.ApplyReleases(updatecheck);

                                        Settings.Default.UpdateAccepted = false;
                                        Settings.Default.UpdatePostPoned = false;
                                        Settings.Default.Save();

                                        MessageBoxResult updateresult = MessageBox.Show("Update Complete, Please Relaunch Launcher to Start New Version, or Exit the Prompt to Exit at your Own Time.", "Update Completed!", MessageBoxButton.OK, MessageBoxImage.Information);

                                        if (updateresult == MessageBoxResult.OK)
                                        {
                                            Application.Current.Shutdown();
                                        }
                                    }
                                    else if (msgresult == MessageBoxResult.No)
                                    {
                                        MessageBox.Show("Update Postponed Until Next Restart");
                                    }
                                }
                                else if (Settings.Default.CurrentChannel == "Release")
                                {
                                    MessageBoxResult msgresult = MessageBox.Show("An Update is Available: " + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " > " + FutureVersion + Settings.Default.CurrentChannel + " ) " + ", Do you Wish to Update?", "New Update Available!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                                    if (msgresult == MessageBoxResult.Yes)
                                    {
                                        await updater.DownloadReleases(updatedownloads);
                                        await updater.ApplyReleases(updatecheck);

                                        Settings.Default.UpdateAccepted = false;
                                        Settings.Default.UpdatePostPoned = false;
                                        Settings.Default.CurrentChannel = "Release";
                                        Settings.Default.Save();

                                        MessageBoxResult updateresult = MessageBox.Show("Update Complete, Please Relaunch Launcher to Start New Version, or Exit the Prompt to Exit at your Own Time.", "Update Completed!", MessageBoxButton.OK, MessageBoxImage.Information);

                                        if (updateresult == MessageBoxResult.OK)
                                        {
                                            Application.Current.Shutdown();
                                        }
                                    }
                                    else if (msgresult == MessageBoxResult.No)
                                    {
                                        MessageBox.Show("Update Postponed Until Next Restart");
                                    }
                                }
                            }
                            else if (CurrentVersion >= FutureVer)
                            {
                                MessageBox.Show("You Are Already Up-To-Date :D" + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " ) ");
                            }
                        }
                    }
                }

                else if (Settings.Default.UpdateChannel == "Beta")
                {
                    using (var updater = await UpdateManager.GitHubUpdateManager("https://github.com/CDAGaming/NewAge-Launcher_WPF", null, null, null, true, null))
                    {
                        var updatecheck = await updater.CheckForUpdate();

                        if (updatecheck.ReleasesToApply.Any())
                        {
                            List<ReleaseEntry> updatedownloads = updatecheck.ReleasesToApply;
                            string FutureVersion = updatecheck.FutureReleaseEntry.Version.ToString();
                            Version FutureVer = Version.Parse(FutureVersion);
                            Settings.Default.FutureVersion = FutureVersion;
                            Settings.Default.Save();

                            if (CurrentVersion < FutureVer)
                            {
                                if (Settings.Default.CurrentChannel != "Beta")
                                {
                                    MessageBoxResult msgresult = MessageBox.Show("An Update is Available: " + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " > " + FutureVersion + " - " + "PreRelease" + " ) " + ", Do you Wish to Update?", "New Update Available!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                                    if (msgresult == MessageBoxResult.Yes)
                                    {
                                        await updater.DownloadReleases(updatedownloads);
                                        await updater.ApplyReleases(updatecheck);

                                        Settings.Default.UpdateAccepted = false;
                                        Settings.Default.UpdatePostPoned = false;
                                        Settings.Default.CurrentChannel = "Beta";
                                        Settings.Default.Save();

                                        MessageBoxResult updateresult = MessageBox.Show("Update Complete, Please Relaunch Launcher to Start New Version, or Exit the Prompt to Exit at your Own Time.", "Update Completed!", MessageBoxButton.OK, MessageBoxImage.Information);

                                        if (updateresult == MessageBoxResult.OK)
                                        {
                                            Application.Current.Shutdown();
                                        }
                                    }
                                    else if (msgresult == MessageBoxResult.No)
                                    {
                                        MessageBox.Show("Update Postponed Until Next Restart");
                                    }
                                }
                                else if (Settings.Default.CurrentChannel == "Beta")
                                {
                                    MessageBoxResult msgresult = MessageBox.Show("An Update is Available: " + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " > " + FutureVersion + Settings.Default.CurrentChannel + " ) " + ", Do you Wish to Update?", "New Update Available!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                                    if (msgresult == MessageBoxResult.Yes)
                                    {
                                        await updater.DownloadReleases(updatedownloads);
                                        await updater.ApplyReleases(updatecheck);

                                        Settings.Default.UpdateAccepted = false;
                                        Settings.Default.UpdatePostPoned = false;
                                        Settings.Default.CurrentChannel = "Beta";
                                        Settings.Default.Save();

                                        MessageBoxResult updateresult = MessageBox.Show("Update Complete, Please Relaunch Launcher to Start New Version, or Exit the Prompt to Exit at your Own Time.", "Update Completed!", MessageBoxButton.OK, MessageBoxImage.Information);

                                        if (updateresult == MessageBoxResult.OK)
                                        {
                                            Application.Current.Shutdown();
                                        }
                                    }
                                    else if (msgresult == MessageBoxResult.No)
                                    {
                                        MessageBox.Show("Update Postponed Until Next Restart");
                                    }
                                }
                            }
                            else if (CurrentVersion >= FutureVer)
                            {
                                MessageBox.Show("You Are Already Up-To-Date :D" + " ( " + CurrentVersion + " - " + Settings.Default.CurrentChannel + " ) ");
                            }
                        }
                    }
                }
            }
            else if (Settings.Default.CheckforUpdateTag == false && Settings.Default.UpdatePGShow == true)
            {
                UpdatesPage updatePG = new UpdatesPage();
                updatePG.ShowDialog();
            }
            // */

            base.OnStartup(e);

        }
    }
}
