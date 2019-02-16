namespace PasswortGenerator.Classes
{
    class Settings
    {
        /// <summary>
        /// use lowercase ?
        /// </summary>
        private bool UseLowercase { get;  set; }

        /// <summary>
        /// use uppercase ?
        /// </summary>
        private bool UseUppercase { get;  set; }

        /// <summary>
        /// use numbers ?
        /// </summary>
        private bool UseNumbers { get;  set; }

        /// <summary>
        /// use specialchars ?
        /// </summary>
        private bool UseSpecialchars { get;  set; }

        /// <summary>
        /// the default password length for generating passwords
        /// </summary>
        private int DefaultPasswordlength { get;  set; }

        /// <summary>
        /// allowed special characters for the password
        /// </summary>
        private string AllowedSpecialchars { get;  set; }

        /// <summary>
        /// the url from where updates getting pulled
        /// </summary>
        private string UpdateUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Settings()
        {
            SetUseLowercase(Properties.Settings.Default.UseLowercase);
            SetUseUppercase(Properties.Settings.Default.UseUppercase);
            SetUseNumbers(Properties.Settings.Default.UseNumbers);
            SetUseSpecialchars(Properties.Settings.Default.UseSpecialchars);
            SetDefaultPasswordlength(Properties.Settings.Default.DefaultPasswordlength);
            SetAllowedSpecialchars(Properties.Settings.Default.AllowedSpecialchars);
            SetUpdateUrl(Properties.Settings.Default.UpdateUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void SetUpdateUrl(string value)
        {
            UpdateUrl = value;
        }

        /// <summary>
        /// Setter Lowercase Setting
        /// </summary>
        /// <param name="value"></param>
        public void SetUseLowercase(bool value)
        {
            UseLowercase = value;
        }

        /// <summary>
        /// Setter Uppercase Setting
        /// </summary>
        /// <param name="value"></param>
        public void SetUseUppercase(bool value)
        {
            UseUppercase = value;
        }


        /// <summary>
        /// Setter Number Setting
        /// </summary>
        /// <param name="value"></param>
        public void SetUseNumbers(bool value)
        {
            UseNumbers = value;
        }

        /// <summary>
        /// Setter Specialchars Setting
        /// </summary>
        /// <param name="value"></param>
        public void SetUseSpecialchars(bool value)
        {
            UseSpecialchars = value;
        }

        /// <summary>
        /// Setter Defaultpasswordlength Setting
        /// </summary>
        /// <param name="value"></param>
        public void SetDefaultPasswordlength(int value)
        {
            DefaultPasswordlength = value;
        }

        /// <summary>
        /// Setter Allowedspecialchars Setting
        /// </summary>
        /// <param name="value"></param>
        public void SetAllowedSpecialchars(string value)
        {
            AllowedSpecialchars = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetUseUppercase()
        {
            return UseUppercase;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetUseNumbers()
        {
            return UseNumbers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetUseSpecialchars()
        {
            return UseSpecialchars;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetDefaultPasswordlength()
        {
            return DefaultPasswordlength;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetAllowedSpecialchars()
        {
            return AllowedSpecialchars;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetUseLowercase()
        {
            return UseLowercase;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetUpdateUrl()
        {
            return UpdateUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            SetUseLowercase(true);
            SetUseUppercase(true);
            SetUseNumbers(true);
            SetUseSpecialchars(true);
            SetDefaultPasswordlength(16);
            SetAllowedSpecialchars(@"+-=_@#$%^&;:,.<>/~\[](){}?!|*");
            Properties.Settings.Default.Reset();
            Save();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            Properties.Settings.Default.UseLowercase = GetUseLowercase();
            Properties.Settings.Default.UseUppercase = GetUseUppercase();
            Properties.Settings.Default.UseNumbers = GetUseNumbers();
            Properties.Settings.Default.UseSpecialchars = GetUseSpecialchars();
            Properties.Settings.Default.DefaultPasswordlength = GetDefaultPasswordlength();
            Properties.Settings.Default.AllowedSpecialchars = GetAllowedSpecialchars();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }
    }
}
