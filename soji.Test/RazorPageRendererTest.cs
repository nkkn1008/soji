using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using soji.Core;

namespace soji.Test
{
    public class RazorPageRendererTest : IDisposable
    {
        private RazorModel model;
        public RazorPageRendererTest()
        {
            Series series = new Series();
            Target target1 = new Target { Name = "TargetA" };
            Target target2 = new Target { Name = "TargetB" };
            List<Target> targets = new List<Target>();
            targets.Add(target1);
            targets.Add(target2);

            model = new RazorModel();
            model.Series = series;
            model.Targets = targets;
        }
        [Fact]
        public void RenderTest()
        {
            string template = @"Series code is @Model.Series.Code";
            model.Series.Code = "37";
            var renderer = new RazorPageRenderer(template, model);
            Assert.Equal("Series code is 37", renderer.Render());
        }

        [Fact]
        public void RenderTargetsTest()
        {
            string template = @"@foreach(var target in Model.Targets){
@:@target.Name
}";
            var renderer = new RazorPageRenderer(template, model);
            Assert.Equal("TargetA\r\nTargetB\r\n", renderer.Render());
        }

        public void Dispose() { }
    }
}
