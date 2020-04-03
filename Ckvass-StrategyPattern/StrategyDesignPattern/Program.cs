using System;

namespace StrategyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }





    internal interface IProcessAltinnDownloadQueueItemStrategy
    {
        void ProcessData(string archiveReference);
    }

    internal class ProcessDistribution : IProcessAltinnDownloadQueueItemStrategy
    {
        public void ProcessData(string archiveReference)
        {
            Console.WriteLine($"{archiveReference} is being processed for distribution");
        }
    }

    internal class ProcessSendToKommune : IProcessAltinnDownloadQueueItemStrategy
    {
        public void ProcessData(string archiveReference)
        {
            Console.WriteLine($"{archiveReference} is being sent to kommune through KS FIKS  SvarUt");
        }
    }

    internal class ProcessSendToApplicant : IProcessAltinnDownloadQueueItemStrategy
    {
        public void ProcessData(string archiveReference)
        {
            Console.WriteLine($"{archiveReference} is being sent to Ansvarlig Sokers inbox in Altinn");
        }
    }




}
