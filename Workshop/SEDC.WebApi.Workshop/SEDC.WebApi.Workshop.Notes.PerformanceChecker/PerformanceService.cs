using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.PerformanceChecker
{
    public class PerformanceService
    {
        private string _url = null;

        public void SetUrl(string url) => _url = url;

        public PerformanceService()
        {

        }

        public void CheckPerformance()
        {
            using HttpClient client = new();
            var limit = 100;

            using HttpResponseMessage response = client.GetAsync(_url).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            if(int.Parse(responseBody) > limit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"Performance: {responseBody} [Limit: {limit}]");
        }
    }
}
