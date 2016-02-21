using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using soji.Helpers;
using System.Windows;
using soji.Core;
using System.IO;
using Reactive.Bindings;
using System.Reactive.Linq;

namespace soji.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        //public RelayCommand RenderCommand { get; set; }
        public ReactiveCommand RenderCommand { get; set; }

        public MainWindowViewModel()
        {
            //RenderCommand = new RelayCommand(RenderPage);
            this.ReactiveOutputFilePath = new ReactiveProperty<string>("");
            this.RenderCommand = this.ReactiveOutputFilePath
                .Select(x => !string.IsNullOrWhiteSpace(x)) // ReactiveOutputFilePathが空でない
                .ToReactiveCommand(); 
            this.RenderCommand.Subscribe(_ => this.ReactiveOutputFilePath.Value = "");
        }

        void RenderPage(object selectedItem)
        {
            var json = File.ReadAllText(_ConfigFilePath);
            ModelConfigurator configurator = new ModelConfigurator(json);
            var model = configurator.Run();
           
            var template = File.ReadAllText(_TemplateFilePath);
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

        public ReactiveProperty<string> ReactiveOutputFilePath { get; private set; }

        string _TemplateFilePath;
        public string TemplateFilePath
        {
            get
            {
                return _TemplateFilePath;
            }
            set
            {
                if (_TemplateFilePath != value)
                {
                    _TemplateFilePath = value;
                    RaisePropertyChanged("TemplateFilePath");
                }
            }
        }

        string _ConfigFilePath;
        public string ConfigFilePath
        {
            get
            {
                return _ConfigFilePath;
            }
            set
            {
                if (_ConfigFilePath != value)
                {
                    _ConfigFilePath = value;
                    RaisePropertyChanged("ConfigFilePath");
                }
            }
        }
    }
}
