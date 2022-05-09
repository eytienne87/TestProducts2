using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace XUnitTests.TestsHelper
{
    internal class RoutesHelper
    {
        public static string TestServerName = "http://localhost:5001/api";

        public static async Task<T> GetTestJsonObject<T>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();  
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}
