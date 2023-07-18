using DG.Tweening;
using Ui.Narrator;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using WareHouseDemo.Scripts.Audio;
using WareHouseDemo.Scripts.UI;
//using WareHouseDemo.Scripts.UI;

namespace WareHouseDemo.Scripts
{
    public class MatfloGameManager : MonoSingleton<MatfloGameManager>
    {
        // P1 A   Answer  >>>> man
        // P2 B   Question  >>> girl

        private const string NBoy1 = "Hi there! How are you doing today?";
        private const string NGirl1 = "I�m good, How was you�re weekend?";
        private const string NBoy2 = "Great! Thanks for asking. Hope you had a great weekend too!";
        private const string NGirl2 = "So, what are you working on nowadays?";
        private const string NBoy3 = "Oh! It�s just a new project that was assigned to me. Can you help me?";
        private const string NBoy4 = "what�s that?";
        private const string NBoy5 = "They are into Warehouse Automation";
        private const string NBoy6 = "Is that so? Don�t worry then, I�ll help you out";
        private const string NBoy7 = "So, Let�s start with the basics what�s a warehouse? What�re they�re types? Can you explain them to me?"; //Audio
        private const string NBoy8 = "Sure, warehouse is an inventory storage management facility, where inbound goods are received , tracked &" +
                                     " temporarily stored or future demands. Warehouse also manage the outbound shipments based on current market demands and replenishment orders." +
                                   " Warehouses usually have loading docks to load and unload goods from desired mode of transport.";
        private const string NGirl13 = "In the warehouses, the Stored goods can include any raw materials, packing materials, spare parts, components, or finished goods" +
                                     " associated with agriculture, manufacturing, and production. As for warehouse types there are many types of warehouses. Let me explain.";

        private const string NBoy9 = "Public warehouse operators lease out their storage space to other companies in exchange for a fee." +
                                     " These are a bit cheaper and hence good for start-ups and other small scale operators.";

        private const string NGameComplete = "Thank You For This Information";


        [SerializeField] NarratorHandler _narratorHandeler;
        [SerializeField] private Button btnPlay;
        private const float timeToHoldMAx = 6f;
        private const float delayBetweenTwoNarrator = 0.2f;

        void Start()
        {
            btnPlay.onClick.AddListener(BringCharacterInView);
        }

        public void UpdatePlayButton(bool b)
        {
            btnPlay.gameObject.SetActive(b);
        }

        private void BringCharacterInView()
        {
            UpdatePlayButton(false);
            Invoke(nameof(CallBoy1), 0.2f);
        }

        private void CallBoy1()
        {
            _narratorHandeler.BringInNarrator(NBoy1, NarratorName.A, delayBetweenTwoNarrator, AudioName.AN01, CallGirl1);
        }


        private void CallGirl1()
        {
            _narratorHandeler.BringInNarrator(NGirl1, NarratorName.B, delayBetweenTwoNarrator, AudioName.BN02, CallBoy2);
        }


        private void CallBoy2()
        {
            _narratorHandeler.BringInNarrator(NBoy2, NarratorName.A, delayBetweenTwoNarrator, AudioName.AN03, CallGirl2);
        }

        private void CallGirl2()
        {
            _narratorHandeler.BringInNarrator(NGirl2, NarratorName.B, delayBetweenTwoNarrator, AudioName.BN04, CallBoy3);
        }


        private void CallBoy3()
        {
            _narratorHandeler.BringInNarrator(NBoy3, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA05, CallBoy4);
        }


        private void CallBoy4()
        {
            _narratorHandeler.BringInNarrator(NBoy4, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA07, CallBoy5);
        }
        private void CallBoy5()
        {
            _narratorHandeler.BringInNarrator(NBoy5, NarratorName.A, delayBetweenTwoNarrator, AudioName.AN09, CallBoy6);
        }

        private void CallBoy6()
        {
            _narratorHandeler.BringInNarrator(NBoy6, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA11, CallBoy7);
        }

        private void CallBoy7()
        {
            _narratorHandeler.BringInNarrator(NBoy7, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA13, CallBoy8);
        }

        private void CallBoy8()
        {
            _narratorHandeler.BringInNarrator(NBoy8, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA15, CallGirl3);
        }

        private void CallGirl3()
        {
            _narratorHandeler.BringInNarrator(NGirl13, NarratorName.B, delayBetweenTwoNarrator, AudioName.BN06, CallBoy9);
        }
        private void CallBoy9()
        {
            _narratorHandeler.BringInNarrator(NBoy9, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA17, BringWarehouseCompletePanel);
        }


 
        private void BringWarehouseCompletePanel()
        {
            //WarehouseTutorailComplete.Instance.BringPanel(NGameComplete, null, AudioName.NGameComplete);
            Application.Quit();
        }

    }
}
