using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using soji.Helpers;
using System.Windows;

namespace soji.ViewModel
{
    public class MainWindowViewModel
    {
        public RelayCommand RenderCommand { get; set; }

        public MainWindowViewModel()
        {
            RenderCommand = new RelayCommand(RenderPage);
        }

        void RenderPage(object selectedItem)
        {
            MessageBox.Show("hoge");
        }
    }
}
