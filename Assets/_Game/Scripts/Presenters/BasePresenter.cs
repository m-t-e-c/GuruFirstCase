using GuruFirstCase.Interfaces;
using UnityEngine;

namespace GuruFirstCase.Presenters
{
    public abstract class BasePresenter<T> : MonoBehaviour
    {
        IViewManager _viewManager;

        protected virtual void Start()
        {
            _viewManager = Locator.Instance.Resolve<IViewManager>();
        }

        protected void Close()
        {
            _viewManager?.DestroyView<T>();
        }
    }
}