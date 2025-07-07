using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProtncColabo.Languages;

namespace ProtncColabo
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 이현배 첫커밋 retry

            // 한석영 첫 커밋 retry

            // 신재성 첫 커밋
            int i = 0;

        }

        private void LanguageSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedItem = e.AddedItems[0] as ComboBoxItem;
                var cultureCode = selectedItem?.Tag as string;
                if (!string.IsNullOrEmpty(cultureCode))
                {
                    LanguageManager.Instance.ChangeCulture(cultureCode);
                }
            }
        }
    }
}
