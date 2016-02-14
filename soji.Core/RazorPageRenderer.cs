using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Templating;

namespace soji.Core
{
    public class RazorPageRenderer
    {
        private string template;
        private RazorModel model;

        public RazorPageRenderer(string template, RazorModel model)
        {
            this.template = template;
            this.model = model;
        }

        public string Render()
        {                                               
            return Engine.Razor.RunCompile(this.template, "templatekey", null, this.model);
        }
    }

    public class RazorModel
    {
        public Series Series { get; set; }
        public List<Target> Targets { get; set; }
    }

    public class Target
    {
        public string Name { get; set; }           
    }

    public class Series
    {
        public string Code { get; set; }
    }
}
