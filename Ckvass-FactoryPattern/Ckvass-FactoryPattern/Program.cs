using System;

namespace Ckvass_FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Factory!");

            // Kommune,
            var ship = MyFactory.Build(HowDoWeSendThis.Kommune);
            Console.WriteLine(ship.MyOwnSelf());
            

            // AnsvarligSoker,
            var notification = MyFactory.Build(HowDoWeSendThis.AnsvarligSoker);
            Console.WriteLine(notification.MyOwnSelf());

            // DistribusjonTilGodtfolkIAltinn,
            var distribution = MyFactory.Build(HowDoWeSendThis.DistribusjonTilGodtfolkIAltinn);
            Console.WriteLine(distribution.MyOwnSelf());

            // NokoHeiltNyttMeIkkjeEinGongHarTenktPaa
            var altinnTreNull = MyFactory.Build(HowDoWeSendThis.NokoHeiltNyttMeIkkjeEinGongHarTenktPaa);
            Console.WriteLine(altinnTreNull.MyOwnSelf());

        }
    }

    public enum HowDoWeSendThis
    {
        Kommune,
        AnsvarligSoker,
        DistribusjonTilGodtfolkIAltinn,
        NokoHeiltNyttMeIkkjeEinGongHarTenktPaa
    }


    public static class MyFactory
    {
        public static IHowToPassStuffThroughFTB Build(HowDoWeSendThis howDoWeSendThis)
        {
            switch (howDoWeSendThis)
            {
                case HowDoWeSendThis.Kommune:
                    return new SendToAKommune();

                case HowDoWeSendThis.AnsvarligSoker:
                    return new SendBackToThePeopleInChargeOfTheBuilding();

                case HowDoWeSendThis.DistribusjonTilGodtfolkIAltinn:
                    return new SendForDistributionToAListOfFinePeople();

                case HowDoWeSendThis.NokoHeiltNyttMeIkkjeEinGongHarTenktPaa:
                default:
                    return new SendInANewAndWonderousWayWeHaveNotEvenThoughtOfYet(); 
            }
        }
    }







    public interface IHowToPassStuffThroughFTB
    {
        string MyOwnSelf();
    }

    public class SendToAKommune : IHowToPassStuffThroughFTB
    {
        public string MyOwnSelf()
        {
            return this.GetType().Name;
        }
    }

    public class SendBackToThePeopleInChargeOfTheBuilding : IHowToPassStuffThroughFTB
    {
        public string MyOwnSelf()
        {
            return this.GetType().Name;
        }

    }

    public class SendForDistributionToAListOfFinePeople : IHowToPassStuffThroughFTB
    {
        public string MyOwnSelf()
        {
            return this.GetType().Name;
        }
    }

    public class SendInANewAndWonderousWayWeHaveNotEvenThoughtOfYet : IHowToPassStuffThroughFTB
    {
        public string MyOwnSelf()
        {
            return this.GetType().Name;
        }
    }


 
}
