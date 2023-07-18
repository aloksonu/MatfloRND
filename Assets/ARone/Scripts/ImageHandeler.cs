using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace WareHouseDemo.Scripts
{
    public class ImageHandeler : MonoSingleton<ImageHandeler>
    {
        private static Action _onComplete;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Image img;
        private const float imageInOutDelay = 0.2f;

        void Start()
        {
            canvasGroup.UpdateState(false, 0);
        }

        private void OnDestroy()
        {

            canvasGroup.UpdateState(false, 0);
        }

        internal void BringPanel(Sprite spr , Action onComplete = null)
        {
            img.sprite = spr;
            _onComplete = onComplete;
            canvasGroup.UpdateState(true, imageInOutDelay);
            Invoke(nameof(BringOutPanel), 5);
        }

        internal void BringOutPanel()
        {
            canvasGroup.UpdateState(false, imageInOutDelay, ()=> {
            
                if(_onComplete != null) { 
                    _onComplete();
                    _onComplete = null;
                }
            });
        }
    }
}
