using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.PerformanceChecker
{
    public class PChecker :  IPChecker, ICheckPerformance
    {
        private string _url = null;

        public PChecker SetUrl(string url) 
        {
            _url = url;
            return this;
        } 

        public PChecker()
        {

        }

        public void CheckPerformance()
        {
            using HttpClient client = new();
            var limit = 100;

            using HttpResponseMessage response = client.GetAsync(_url).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            if (int.Parse(responseBody) > limit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"Performance: {responseBody} [Limit: {limit}]");
        }

        ICheckPerformance IPChecker.SetUrl(string url)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPChecker
    {
        ICheckPerformance SetUrl(string url);
    }

    public interface IPCheckerSetUrl 
    {
        ICheckPerformance SetUrl(string url);
    }

    public interface ICheckPerformance
    {
        void CheckPerformance();
    }

    public class Test
    {
        private readonly IPChecker _performanceChecker;

        public Test(IPChecker performanceChecker)
        {
            _performanceChecker = performanceChecker;
        }
        
    }
}

