using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameNinja.Desktop.Services;

namespace TheGameNinja.Desktop
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container;
        static ContainerHelper()
        {
            _container = new UnityContainer();

            _container.RegisterType<IAccoladesRepository, AccoladesRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IGenresRepository, GenresRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IMediaTypesRepository, MediaTypesRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IPlatformsRepository, PlatformsRepository>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IVideoGamesRepository, VideoGamesRepository>(new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }
}
