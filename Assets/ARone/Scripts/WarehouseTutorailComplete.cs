using System;
using TMPro;
using UnityEngine;
using Utilities;
using WareHouseDemo.Scripts.Audio;

namespace WareHouseDemo.Scripts.UI
{
    public class WarehouseTutorailComplete : MonoSingleton<WarehouseTutorailComplete>
    {
        private static Action _onComplete;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextMeshProUGUI gameCompleteTMP;
        private float _fadeDuration = 0.2f;

        void Start()
        {
            canvasGroup.UpdateState(false, 0);
        }
        internal void BringPanel(string gameCompleteText = null ,Action onComplete=null, AudioName audioName = AudioName.NotSet)
        {
            _onComplete = onComplete;
            gameCompleteTMP.text = gameCompleteText.ToString();
            canvasGroup.UpdateState(true, _fadeDuration,()=> {
                if(audioName!= AudioName.NotSet)
                    GenericAudioManager.Instance.PlaySound(audioName);
            });
        }


    }
}
