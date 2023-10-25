using GuruFirstCase.Interfaces;
using GuruFirstCase.Presenters;
using UnityEngine;

namespace GuruFirstCase
{
    public class Launcher : MonoBehaviour
    {
        Locator _locator;

        IGridManager _gridManager;
        IViewManager _viewManager;
        
        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            _locator = new Locator();

            RegisterManagers();
            
            _viewManager.LoadView(new LoadViewParams<MainMenuPresenter>()
            {
                viewName = "MainMenuView"
            });
        }

        void RegisterManagers()
        {
            _gridManager = new GridManager();
            _locator.Register<IGridManager>(_gridManager);

            _viewManager = new ViewManager();
            _locator.Register<IViewManager>(_viewManager);
        }
    }
}