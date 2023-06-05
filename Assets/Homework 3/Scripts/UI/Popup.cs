using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class Popup : MonoBehaviour
    {
        private ICallback callback;

        public void Show(ICallback callback = null)
        {
            this.callback = callback;
            this.OnShow();
        }

        public void Hide()
        {
            this.OnHide();
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }

        public void RequestClose()
        {
            this.callback?.OnClose(this);
        }

        public interface ICallback
        {
            void OnClose(Popup popup);
        }
    }
}