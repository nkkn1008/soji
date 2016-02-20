using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using soji.Core;

namespace soji.Test
{
    public class ModelConfiguratorTest
    {
        [Fact]
        public void LoadSeriesInfoToRazorModel()
        {
            string json = @"{
  'Targets':
  [
      {
         'Name': 'Target-A'
      }
       ,
      {
          'Name': 'Target-B'
      }
  ],
  'Series': 
  {                
    'Code': '9999'
  }
        }";
            ModelConfigurator configurator = new ModelConfigurator(json);
            RazorModel model = configurator.Run();
            Assert.Equal("9999", model.Series.Code);
        }

        [Fact]
        public void LoadTargetInfoToRazorModel()
        {
            string json = @"{
  'Targets':
  [
      {
         'Name': 'Target-A'
      }
       ,
      {
          'Name': 'Target-B'
      }
  ],
  'Series': 
  {                
    'Code': '9999'
  }
        }";
            ModelConfigurator configurator = new ModelConfigurator(json);
            RazorModel model = configurator.Run();
            Assert.Equal("Target-A", model.Targets[0].Name);
        }
    }
}

