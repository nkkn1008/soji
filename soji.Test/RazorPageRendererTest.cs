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
            Target target = new Target();
            List<Target> targets = new List<Target>();
            targets.Add(target);

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

        public void Dispose() { }
    }
}
