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
        public string Render()
        {
            var template = @"Hello @Model.Name!!";
            var model = new { Name = "RazorEngine" };        
                        
            return Engine.Razor.RunCompile(template, "templatekey", null, model);
        }
    }
}
