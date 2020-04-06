using System;

namespace StrategyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Strategy!");

            // Randomly get one of the enum values
            var incomingAltinnData = (SupportedProcessingPathForAltinnForms)new Random().Next(Enum.GetNames(typeof(SupportedProcessingPathForAltinnForms)).Length);
            Console.WriteLine($"We are processing an Altinn request of type {incomingAltinnData}");

            // Call "form strategy factory" to get desired form-processor
            var formDataProcessor = GetFormDataProcessor(incomingAltinnData);

            // Process the form data
            formDataProcessor.ProcessFormData();
        }

        // Form processor strategy "factory"
        private static FormDataProcessor GetFormDataProcessor(SupportedProcessingPathForAltinnForms incomingAltinnData)
        {
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

            return new FormDataProcessor(processStrategy);
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

    // 
    internal class FormDataProcessor
    {
        private readonly IProcessAltinnDownloadQueueItemStrategy _prosessingStrategy;

        public FormDataProcessor(IProcessAltinnDownloadQueueItemStrategy prosessingStrategy)
        {
            _prosessingStrategy = prosessingStrategy;
        }

        public void ProcessFormData()
        {
            DoSomeDefaultStuffFirst();
            _prosessingStrategy.ProcessData();
            DoSomeDefaultStuffAtTheEnd();
        }

        private void DoSomeDefaultStuffFirst()
        {
            Console.WriteLine("*** Does some default processing stuff first.. ***");
        }

        private void DoSomeDefaultStuffAtTheEnd()
        {
            Console.WriteLine("*** And then the processor does some other stuff at the end of the form processing.. ***");
        }

    }
}
