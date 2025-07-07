using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProtncColabo.Languages
{
    public class LanguageManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static LanguageManager _instance = new LanguageManager();
        public static LanguageManager Instance => _instance;

        private ResourceManager _resourceManager = Resources.ResourceManager;

        public string this[string key] => _resourceManager.GetString(key);

        public void ChangeCulture(string cultureCode)
        {
            CultureInfo culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = culture;
            //Thread.CurrentThread.CurrentCulture = culture; // 숫자/날짜 포맷 같은 지역 문화 적용

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}
