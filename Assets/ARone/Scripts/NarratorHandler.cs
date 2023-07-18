using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Utilities;
using WareHouseDemo.Scripts.Audio;

namespace Ui.Narrator
{
    public class NarratorHandler : MonoBehaviour
    {
        private static readonly int AnimIdleMale = Animator.StringToHash("CharIdle");
        private static readonly int AnimTalkingMale = Animator.StringToHash("CharTalk");
        private static readonly int AnimIdleFemale = Animator.StringToHash("Idle");
        private static readonly int AnimTalkingFemale = Animator.StringToHash("Talking");
        private static Action _onClickCrossButton , _onCompleteNarrator;
        [SerializeField] private Animator _animatorMale;
        [SerializeField] private Animator _animatorFemale;
        private string _narratorText;
        private const float narratorOutDelay = 0.2f;
        private const float audioFinishDelay = 0.5f;

        void Start()
        {
            //_animatorMale.SetTrigger(AnimIdleMale);
            //_animatorFemale.SetTrigger(AnimIdleFemale);
            _animatorMale.Play("CharIdle");
            _animatorFemale.Play("Idle");
        }

        internal void BringInNarrator(string narratorText,NarratorName narratorName= NarratorName.NotSet, float delay = 1f, AudioName audioName = AudioName.NotSet,
               Action onCompleteNarrator = null)
        {
            if(narratorName == NarratorName.A)
            {
                //_animatorMale.SetTrigger(AnimTalkingMale);
                // _animatorFemale.SetTrigger(AnimIdleFemale);
                _animatorMale.Play("CharTalk");
                _animatorFemale.Play("Idle");
            }
            else if (narratorName == NarratorName.B)
            {
                //_animatorMale.SetTrigger(AnimIdleMale);
                //_animatorFemale.SetTrigger(AnimTalkingFemale);
                _animatorMale.Play("CharIdle");
                _animatorFemale.Play("Talking");
            }
            _narratorText = narratorText;

            _onCompleteNarrator = onCompleteNarrator;
            BringOnNarratorComplete(audioName);
            Debug.Log(narratorName.ToString());
        }

        private void BringOnNarratorComplete(AudioName audioName)
        {
            GenericAudioManager.Instance.PlaySound(audioName);
            if (_onCompleteNarrator != null)
            {
                Invoke(nameof(CallOnCompleteNarrator), GenericAudioManager.Instance.GetAudioLength(audioName) + audioFinishDelay);
            }
        }

        private void CallOnCompleteNarrator()
        {
                 BringOutNarrator(narratorOutDelay);            
        }

        internal void BringOutNarrator(float delay = 1f)
        {
            _onCompleteNarrator();
        }

    }
}

public enum NarratorName
{
    NotSet = -1,
    A = 0,
    B = 1,
}