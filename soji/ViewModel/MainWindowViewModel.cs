using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using soji.Helpers;
using System.Windows;
using soji.Core;
using System.IO;

namespace soji.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public RelayCommand RenderCommand { get; set; }
        
        public MainWindowViewModel()
        {
            RenderCommand = new RelayCommand(RenderPage);
        }

        void RenderPage(object selectedItem)
        {
            Series series = new Series();
            Target target1 = new Target { Name = "TargetA" };            
            List<Target> targets = new List<Target>();
            targets.Add(target1);

            RazorModel model = new RazorModel();
            model.Series = series;
            model.Targets = targets;

            string template = @"Series code is @Model.Series.Code";
            model.Series.Code = "37";
            var renderer = new RazorPageRenderer(template, model);
            string result = renderer.Render();
            try
            {
                using (var writer = new StreamWriter(_OutputFilePath, false, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine(result);
                }
            }
            catch
            {
                MessageBox.Show("Write file error !! Please set file path");
            }
        }

        string _OutputFilePath;
        public string OutputFilePath
        {
            get
            {
                return _OutputFilePath;
            }
            set
            {
                if (_OutputFilePath != value)
                {
                    _OutputFilePath = value;
                    RaisePropertyChanged("OutputFilePath");
                }
            }
        }
    }
}
