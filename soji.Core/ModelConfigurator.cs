using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soji.Core
{
    public class ModelConfigurator
    {
        private string _JsonString;
        public ModelConfigurator(string jsonString)
        {
            this._JsonString = jsonString;
        }

        public RazorModel Run()
        {
            var deserialized = JsonConvert.DeserializeObject<RazorModel>(_JsonString);
            return deserialized;
        }
    }
}
