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
            var renderer = new RazorPageRenderer();
            Assert.Equal("Render Test", renderer.Render());
        }    
    }
}
