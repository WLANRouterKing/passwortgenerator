using System;
using System.Windows;
using AutoUpdaterDotNET;
using Sodium;
using PasswortGenerator.Classes;
using System.Text;

namespace PasswortGenerator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Object containing the settings
        /// </summary>
        Settings settings;

        /// <summary>
        /// nothing to say
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            settings = new Settings();
            Init();
            AutoUpdater.AppTitle = "Passwort Generator";
            AutoUpdater.Start(Encoding.UTF8.GetString(Convert.FromBase64String(settings.GetUpdateUrl())));
        }

        /// <summary>
        /// Initialize the settings
        /// </summary>
        private void Init()
        {
            if (settings.GetUseLowercase() == true)
            {
                LowercaseCheckbox.IsChecked = true;
            }

            if (settings.GetUseUppercase() == true)
            {
                UppercaseCheckbox.IsChecked = true;
            }

            if (settings.GetUseNumbers() == true)
            {
                NumberCheckbox.IsChecked = true;
            }

            if (settings.GetUseSpecialchars() == true)
            {
                SpecialcharsCheckbox.IsChecked = true;
            }

            DefaultPasswordlengthTextbox.Text = Convert.ToString(settings.GetDefaultPasswordlength());
            AllowedSpecialcharsTextbox.Text = settings.GetAllowedSpecialchars();
        }

        private void GeneratePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string characters = "";
            string password = "";

            if(settings.GetUseLowercase() == true)
            {
                characters += "abcdefghijklmnopqrstuvwxyz";
            }

            if(settings.GetUseUppercase() == true)
            {
                characters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            if(settings.GetUseNumbers() == true)
            {
                characters += "0123456789";
            }

            if(settings.GetUseSpecialchars() == true)
            {
                characters += settings.GetAllowedSpecialchars();
            }

            for(int i = 0; i < settings.GetDefaultPasswordlength(); i++)
            {
                int random = SodiumCore.GetRandomNumber(characters.Length);
                char c = characters[random];

                password += c;
            }

            GeneratedPasswordTextbox.Text = password;
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool uselowercase = LowercaseCheckbox.IsChecked == true ? true : false;
                bool useuppercase = UppercaseCheckbox.IsChecked == true ? true : false;
                bool usenumbers = NumberCheckbox.IsChecked == true ? true : false;
                bool usespecialchars = SpecialcharsCheckbox.IsChecked == true ? true : false;
                int defaultpasswordlength = Convert.ToInt32(DefaultPasswordlengthTextbox.Text);
                string allowedspecialchars = AllowedSpecialcharsTextbox.Text;

                settings.SetUseLowercase(uselowercase);
                settings.SetUseUppercase(useuppercase);
                settings.SetUseNumbers(usenumbers);
                settings.SetUseSpecialchars(usespecialchars);
                settings.SetDefaultPasswordlength(defaultpasswordlength);
                settings.SetAllowedSpecialchars(allowedspecialchars);
                settings.Save();
                SettingsResponseLabel.Content = "Einstellungen gespeichert";
            }
            catch(Exception ex)
            {
                SettingsResponseLabel.Content = ex.Message;
            }
        }

        private void ResetSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                settings.Reset();
                Init();
                SettingsResponseLabel.Content = "Einstellungen erfolgreich zurück gesetzt";
            }
            catch(Exception ex)
            {
                SettingsResponseLabel.Content = ex.Message;
            }
        }
    }
}
