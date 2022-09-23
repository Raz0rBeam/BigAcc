using System;
using Zenject;

namespace BigAcc
{
    class BAInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BigAccController>().AsSingle();
        }
    }
}
