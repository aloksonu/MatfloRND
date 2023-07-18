using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WareHouseDemo.Scripts.Audio;

public class MatfloNarratorHandler : MonoBehaviour
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
        _animatorMale.Play("CharIdle");
        _animatorFemale.Play("Idle");
    }

    internal void BringInNarrator(string narratorText, NarratorName narratorName = NarratorName.NotSet, float delay = 1f, AudioName audioName = AudioName.NotSet,
          Action onCompleteNarrator = null)
    {
        if (narratorName == NarratorName.A)
        {
            _animatorMale.Play("CharTalk");
            _animatorFemale.Play("Idle");
        }
        else if (narratorName == NarratorName.B)
        {

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
