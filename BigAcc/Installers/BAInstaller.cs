using System;
using Zenject;

namespace BigAcc.Installers
{
    class BAInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BigAccController>().AsSingle();
        }
    }
}
