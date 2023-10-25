using GuruFirstCase.Interfaces;
using GuruFirstCase.Presenters;
using UnityEngine;

namespace GuruFirstCase.Model
{
    public class GameplayModel
    {
        readonly IGridManager _gridManager;
        readonly IViewManager _viewManager;

        public GameplayModel()
        {
            _gridManager = Locator.Instance.Resolve<IGridManager>();
            _viewManager = Locator.Instance.Resolve<IViewManager>();
        }
        
        public void CreateGrid(GameObject cellPrefab, int gridSize)
        {
            _gridManager.CreateGrid(cellPrefab, gridSize);
        }

        public void ReturnToMainMenu()
        {
            _gridManager.ResetGrid();
            _viewManager.LoadView(new LoadViewParams<MainMenuPresenter>()
            {
                viewName = "MainMenuView"
            });
        }
    }
}