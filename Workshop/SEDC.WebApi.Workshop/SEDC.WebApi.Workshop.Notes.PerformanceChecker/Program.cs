namespace SEDC.WebApi.Workshop.Notes.PerformanceChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var url = @"http://localhost:5070/api/v1/performance/notes";

            Console.WriteLine("Performance check started");
            Console.WriteLine("===============================");
            var service = new PerformanceService();
            service.SetUrl(url);
            service.CheckPerformance();

            IPChecker a = new PChecker();
            var b = a.SetUrl(url);
            b.CheckPerformance();

            Console.ReadLine();
        }
    }
}