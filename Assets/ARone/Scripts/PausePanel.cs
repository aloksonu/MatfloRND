using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;
using WareHouseDemo.Scripts.Audio;

namespace WareHouseDemo.Scripts
{
    public class PausePanel : MonoSingleton<PausePanel>
    {
        private static Action _onComplete;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button btnResume,btnRetry;
        private float _fadeDuration = 0.1f;
        void Start()
        {
            btnResume.onClick.AddListener(() => StartCoroutine(OnClickResumeButton()));
            btnRetry.onClick.AddListener(() => StartCoroutine(OnClickRetryButton()));
            _canvasGroup.UpdateState(false, 0);
        }

        private void OnDestroy()
        {
            btnResume.onClick.RemoveAllListeners();
            btnRetry.onClick.RemoveAllListeners();
        }

        internal void OnClickPauseButton()
        {
            StartCoroutine(_OnClickPauseButton());
        }

        private IEnumerator _OnClickPauseButton()
        {
            AudioListener.pause = true;
            // GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            yield return new WaitForSeconds(0.0f);
            if (Time.timeScale == 1)
            {
                _canvasGroup.UpdateState(true, _fadeDuration,()=> {

                    Time.timeScale = 0;
                });
            }

        }
        private IEnumerator OnClickResumeButton()
        {
            Time.timeScale = 1;
            //GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            yield return new WaitForSeconds(0.0f);
            _canvasGroup.UpdateState(false, _fadeDuration,()=> {
                AudioListener.pause = false;
            });
        }

        private IEnumerator OnClickRetryButton()
        {
            //GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            yield return new WaitForSeconds(0);
            Time.timeScale = 1;
            GenericAudioManager.Instance.StopAllSounds();
            SceneManager.LoadSceneAsync("WareHouse");
            AudioListener.pause = false;
            // _canvasGroup.UpdateState(false, 0);
        }
    }
}
