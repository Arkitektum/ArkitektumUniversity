using System;

namespace StrategyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Strategy!");


            // Randomly get one of the enum values
            var incomingAltinnData = (SupportedProcessingPathForAltinnForms) new Random().Next(Enum.GetNames(typeof(SupportedProcessingPathForAltinnForms)).Length);
            Console.WriteLine($"We are processing an Altinn request of type {incomingAltinnData}");

            // Select processing strategy
            IProcessAltinnDownloadQueueItemStrategy processStrategy;

            switch (incomingAltinnData)
            {
                case SupportedProcessingPathForAltinnForms.Ship:
                    processStrategy = new ProcessSendToKommune();
                    break;

                case SupportedProcessingPathForAltinnForms.Distribute:
                    processStrategy = new ProcessDistribution();
                    break;
                
                case SupportedProcessingPathForAltinnForms.Notification:
                    processStrategy = new ProcessSendToApplicant();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Run the strategy
            processStrategy.ProcessData();
        }
    }


    public enum SupportedProcessingPathForAltinnForms
    {
        Ship, // Send to kommune
        Distribute, // Distribute nabovarsel, ansvarrett, Kos
        Notification // Send data back to the requester 
    };




    // INTERFACE
    internal interface IProcessAltinnDownloadQueueItemStrategy
    {
        void ProcessData();
    }


    // STRATEGY 1
    internal class ProcessDistribution : IProcessAltinnDownloadQueueItemStrategy
    {
        public void ProcessData()
        {
            Console.WriteLine("The Altinn Archive Reference is being processed for distribution");
        }
    }


    // STRATEGY 2
    internal class ProcessSendToKommune : IProcessAltinnDownloadQueueItemStrategy
    {
        public void ProcessData()
        {
            Console.WriteLine("The Altinn Archive Reference is being sent to kommune through KS FIKS  SvarUt");
        }
    }


    // STRATEGY 2
    internal class ProcessSendToApplicant : IProcessAltinnDownloadQueueItemStrategy
    {
        public void ProcessData()
        {
            Console.WriteLine("The Altinn Archive Reference is being sent to Ansvarlig Sokers inbox in Altinn");
        }
    }
}
