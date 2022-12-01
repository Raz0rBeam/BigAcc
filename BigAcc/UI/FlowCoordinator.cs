using HMUI;
using Zenject;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using BigAcc.Configuration;

namespace BigAcc.UI
{
    public class BAFlowCoordinator : FlowCoordinator
    {
        private MainFlowCoordinator mainFlowCoordinator = null!;
        private MainView mainView = null!;

        [Inject]
        private void Construct(MainFlowCoordinator _mainFlowCoordinator, MainView _mainView)
        {
            mainFlowCoordinator = _mainFlowCoordinator;
            mainView = _mainView;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            SetTitle(nameof(BigAcc));
            showBackButton = true;

            ProvideInitialViewControllers(mainView);
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}
