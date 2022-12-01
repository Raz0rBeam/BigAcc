using BigAcc.UI;
using Zenject;
using BigAcc.Managers;

namespace BigAcc.Installers
{
    internal class BAUIInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<BAFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<MainView>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesTo<MenuButtonManager>().AsSingle();
        }
    }
}
