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
        public ReactiveCommand RenderCommand { get; set; }
        public MainWindowViewModel()
        {
            RenderCommand = Observable.CombineLatest(OutputFilePath, TemplateFilePath, ConfigFilePath,
                (output, template, config) => !string.IsNullOrEmpty(output) && !string.IsNullOrEmpty(template) && !string.IsNullOrEmpty(config))
                .ToReactiveCommand();
            this.RenderCommand.Subscribe(_ => RenderPage());
        }

        void RenderPage()
        {
            var json = File.ReadAllText(ConfigFilePath.Value);
            ModelConfigurator configurator = new ModelConfigurator(json);
            var model = configurator.Run();
           
            var template = File.ReadAllText(TemplateFilePath.Value);
            var renderer = new RazorPageRenderer(template, model);
            string result;
            try
            {
                result = renderer.Render();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            try
            {
                using (var writer = new StreamWriter(OutputFilePath.Value, false, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine(result);
                }
            }
            catch
            {
                MessageBox.Show("Write file error !! Please set file path");
            }
        }

        public ReactiveProperty<string> OutputFilePath { get; private set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> TemplateFilePath { get; private set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> ConfigFilePath { get; private set; } = new ReactiveProperty<string>();

    }
}
