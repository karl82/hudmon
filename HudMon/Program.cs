using System;

namespace HudMon
{
    class Program
    {
        static void Main(string[] args)
        {
            HudsonFactory jobFactory = new JsonHudsonFactory("http://endor/hudson/");
            Hudson.Job job = jobFactory.RetrieveJob("CallREC");
            Console.WriteLine(job);
        }
    }
}
