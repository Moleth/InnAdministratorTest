using InnAdministrator.Controllers;
using InnAdministrator.Data.Context;
using InnAdministrator.Services;
using InnAdministrator.Services.Interfaces;
using SimpleInjector;

namespace GildedRose.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            Container container = InitializeContainer();

            InnAdministratorController gildedRoseController = container.GetInstance<InnAdministratorController>();
            
            gildedRoseController.UpdateQuality();

            System.Console.ReadKey();

        }

        private static Container InitializeContainer()
        {
            Container container = new Container();

            /*I am using a transient instance here for all classes since it is a simple example.
            In reality this would depend amongst other thigns on the type of application we are creating.
            Also at least for the context it is generally a good practice to be creating a new instance 
            with each request.*/
            Lifestyle lifestyle = Lifestyle.Transient;

            container.Register<InnAdministratorContext, InnAdministratorContext>(lifestyle);
            container.Register<IInnAdministratorDataService, GildedRoseDataService>(lifestyle);
            container.Register<IInnAdministrator, GildedRoseAdministrator>(lifestyle);

            return container;
        }
    }
}
