using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using soji.Core;

namespace soji.Test
{
    public class RazorPageRendererTest
    {
        [Fact]
        public void RenderTest()
        {
            string template = @"Series code is @Model.Series.Code";
            Series series = new Series { Code = "37" };
            Target target = new Target { Name = "TestName" };
            List<Target> targets = new List<Target>();
            targets.Add(target);

            RazorModel model = new RazorModel();
            model.Series = series;
            model.Targets = targets;
            var renderer = new RazorPageRenderer(template, model);
            Assert.Equal("Series code is 37", renderer.Render());
        }    
    }
}
