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
    public class GameManager : MonoSingleton<GameManager>
    {
        // P1 A   Answer  >>>> man
        // P2 B   Question  >>> girl

        private const string AN01 = "Hi, how�re you?";
        private const string BN02 = "I�m good, How was you�re weekend?";
        private const string AN03 = "Great! Thanks for asking. Hope you had a great weekend too!";
        private const string AN09 = "So, what are you working on nowadays?";
        //private const string BN10 = "Oh! It�s just a new project that was assigned to me, but I�ve no idea about it. " +
        //    "I�m hoping to find someone who knows about the field, my client is into.";
        private const string BN10 = "Oh! It�s just a new project that was assigned to me. Can you help me?";
        private const string AN11 = "what�s that?";
        private const string BN12 = "They are into Warehouse Automation";
        private const string AN13 = "Is that so? Don�t worry then, I�ll help you out";

        //private const string BN14 = "You serious? You�ve idea about this field? It�d be really helpful if you can guide me.";
        //private const string AN15 = "Yes I can. I�ve been working in the similar field for over a decade now. So ask me and I will try my best to explain.";
        //private const string BN18 = "Thanks again for the offer. Let me just get my notepad as I�ve somethings I need answers for." +
        //    " If it works for you I can ask them one by one.";
        //private const string AN19 = "Yeah no worries";

        //private const string BN18 = "Thanks again for the offer."; // if require add later
        private const string BN20 = "So, Let�s start with the basics what�s a warehouse? What�re they�re types? Can you explain them to me?"; //Audio


        // defination for warehouse

        private const string AN211 = "Sure, warehouse is an inventory storage management facility, where inbound goods are received , tracked &" +
                                     " temporarily stored or future demands. Warehouse also manage the outbound shipments based on current market demands and replenishment orders." +
                                     " Warehouses usually have loading docks to load and unload goods from desired mode of transport.";

        private const string AN212 = "In the warehouses, the Stored goods can include any raw materials, packing materials, spare parts, components, or finished goods" +
                                     " associated with agriculture, manufacturing, and production. As for warehouse types there are many types of warehouses. Let me explain.";

        private const string AN213 = "Public warehouse operators lease out their storage space to other companies in exchange for a fee." +
                                     " These are a bit cheaper and hence good for start-ups and other small scale operators.";

        private const string AN214 = "Another type is Private warehouse, also called a proprietary warehouse. Private warehouses are owned by" +
                                     " the same companies that produce the goods they store";

        private const string AN215 = "Another kind is semi-automated warehouses that take advantage of both human labour, along with technology.";

        private const string AN216 = "Then we have smart warehouses. They rely on heavy use of automated technology machines. Some of these technologies include" +
                                     " Automated Storage and Retrieval systems, Automated Guided Vehicles, Collaborative Robots etc. etc.";

        private const string AN217 = "Also there are Distribution Centres where Warehouses store the goods for longer period. Distribution centres are" +
                                     " used for storing them temporarily while they�re being prepped for their next destination or delivery.";

        private const string AN218 = "There is also Climate-Controlled warehouses. Goods that are stored in these types of warehouses require specific" +
                                     " temperature or moisture range. Here the items stored are some agriculture related goods, grains, chemicals etc.";

        // private const string AN21 = "Yes, Sure, warehouse is a building where large quantities of goods are stored before being sent to shops";// after this show pic>>warehouse
        private const string BN22 = "Now I do have some terminologies that I didn�t understand here, can you explain them to me";
        private const string AN23 = "Yeah";
        private const string BN24 = "So there�s something written over here like Inbound, Whats that";
        private const string AN25 = "You mean Inbound logistics, so its basically the way materials and other goods are brought into a company";// after this show pic >>Inbound
        private const string BN26 = "So what are steps are there related with this Inbound logistics";
        private const string AN27 = "Usually This process includes the steps to order, receive, store, transport and manage incoming supplies";


        //>>Receiving
        private const string BN41 = "Please can you tell me about warehouse receiving";
        private const string AN42 = "Look this picture"; // after this show pic >> receiving
        private const string AN43 = "So the warehouse receiving process steps include delivery of the products, unloading from the delivery trunk, and inventory storage";

        //>>Putaway
        private const string BN28 = "Oh that sounds good";
        private const string AN29 = "Now what are you curios about next";
        private const string BN30 = "Yes, So can you tell me more about Putaway";
        private const string AN31 = "So put-away is actually one of the key components in terms of warehouse management." +
                                    " Its basically process of storing goods in a warehouse. Here we take items from inventory and them put them on the different pallet or shelves.";
        // private const string BN32 = "Ok so what does it mean";
        //  private const string AN33 = "Its basically process of storing goods in a warehouse. Here we take items from inventory and them put them on the different pallet or shelves";
        private const string BN34 = "So what are the activities involved in this put-away process";
        private const string AN35 = "the main activities involved in this are warehouse receiving, transportation, and ensuring that inventory is stored" +
                                    " in the right locations";
        // here show pic >>Putaway

        //>>Storage
        private const string BStorage1 = "Oh can you help me to explain Storage";
        private const string AStorage2 = "Yeah So this term involves keeping the goods in a safe, secure, and organized manner until they are needed for distribution";
        // here show pic >>Storage

        private const string BN36 = "Alright. That sounds really important. Now can you tell me a bit about outbound logistics"; // after this show pic>>outbound
        private const string AN37 = "Yeah So this term is generally used for storing, transporting and distributing goods to customer";
        //private const string BN38 = "Ok";
        private const string AN39 = "So it basically starts with customer sales order, moves on to warehouse packing and ends with product deliver";
        private const string BN40 = "Cool!";

        //..........
        private const string BN44 = "Now can you tell me more about this picking process";
        private const string AN45 = "Yeah! So what happens is Voice, labels, or lights direct operators to pick all cases required for a batch of orders " +
                                    "within a specific pick module.Operators make the picks";
        //private const string BN46 = "Ok then";
        private const string AN47 = "After that, All the picks are placed on each case on the outbound conveyor.The conveyor transports and merges cases from" +
                                    " various pick modules and then sorts them to individual shipping lanes based on order requirements";
        // after this show pic >> picking
        private const string BN48 = "Now what�s the case picking pallet then";
        private const string AN49 = "So we help our operators with the help of computer instructions or voice commands so that they can understand which goods to pick out" +
                                    " and where to send them";
        private const string BN50 = "I believe most of these picking methods are automated right";
        private const string AN51 = "Yeah right";
        private const string BN52 = "Now can you explain me about the transportation system";   // after this show pic >> transport
        private const string AN53 = "The transport system in warehouse includes transport of goods and cargos from their receiving location to the warehouse" +
                                    " where they're stored along with sending them to desired delivery locations";


        private const string NGameComplete = "Thank You For This Information";

        [SerializeField] Sprite whareHouseSPR;
        [SerializeField] Sprite ReceivingSPR;
        [SerializeField] Sprite InboundSPR;
        [SerializeField] Sprite OutboundSPR;
        [SerializeField] Sprite PutawaySPR;
        [SerializeField] Sprite PickingSPR;
        [SerializeField] Sprite TransportSPR;
        //[SerializeField] GameObject characterBoy;
        //[SerializeField] GameObject characterGirl;

        [SerializeField] NarratorHandler _narratorHandeler;
        [SerializeField] private Button btnPlay;
        private const float timeToHoldMAx = 6f;
        private const float delayBetweenTwoNarrator = 0.2f;

        void Start()
        {
            btnPlay.onClick.AddListener(BringCharacterInView);
            //BringCharacterInView();
        }

        public void UpdatePlayButton(bool b)
        {
            btnPlay.gameObject.SetActive(b);
        }

        private void BringCharacterInView()
        {
            //btnPlay.gameObject.SetActive(false);
            UpdatePlayButton(false);
            //characterBoy.GetComponent<Transform>().DOMoveX(-4.25f, 2f);
            //characterGirl.GetComponent<Transform>().DOMoveX(4.25f, 2f);
            Invoke(nameof(CallA01), 0.2f);
            //Invoke(nameof(CallA53), 2.2f);
        }

        private void CallA01()
        {
            _narratorHandeler.BringInNarrator(AN01,NarratorName.A, delayBetweenTwoNarrator, AudioName.AN01, CallB02);
        }


        private void CallB02()
        {
            _narratorHandeler.BringInNarrator(BN02, NarratorName.B, delayBetweenTwoNarrator, AudioName.BN02, CallA03);
        }


        private void CallA03()
        {
            _narratorHandeler.BringInNarrator(AN03, NarratorName.A, delayBetweenTwoNarrator, AudioName.AN03, CallA09);
        }

        private void CallA09()
        {
            _narratorHandeler.BringInNarrator(AN09, NarratorName.A, delayBetweenTwoNarrator, AudioName.AN09, CallB10);
        }


        private void CallB10()
        {
            _narratorHandeler.BringInNarrator(BN10, NarratorName.B, delayBetweenTwoNarrator, AudioName.BN10, CallA11);
        }


        private void CallA11()
        {
            _narratorHandeler.BringInNarrator(AN11, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA11, CallB12);
        }
        private void CallB12()
        {
            _narratorHandeler.BringInNarrator(BN12, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB12, CallA13);
        }

        private void CallA13()
        {
            _narratorHandeler.BringInNarrator(AN13, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA13, CallB20);
        }


        //private void CallB14()
        //{
        //    _narratorHandeler.BringInNarrator(BN14, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB14, CallA15);
        //}


        //private void CallA15()
        //{
        //    _narratorHandeler.BringInNarrator(AN15, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA15, CallB18);
        //}

        //private void CallB18()
        //{
        //    _narratorHandeler.BringInNarrator(BN18, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB18, CallA19);
        //}


        //private void CallA19()
        //{
        //    _narratorHandeler.BringInNarrator(AN19, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA19, CallB20);
        //}
        private void CallB20()
        {
            _narratorHandeler.BringInNarrator(BN20, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB20, CallA211);
        }

        private void CallA211()
        {
            _narratorHandeler.BringInNarrator(AN211, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA211, CallA212);
        }

        private void CallA212()
        {
            _narratorHandeler.BringInNarrator(AN212, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA212, CallA213);
        }
        private void CallA213()
        {
            _narratorHandeler.BringInNarrator(AN213, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA213, CallA214);
        }
        private void CallA214()
        {
            _narratorHandeler.BringInNarrator(AN214, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA214, CallA215);
        }
        private void CallA215()
        {
            _narratorHandeler.BringInNarrator(AN215, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA215, CallA216);
        }
        private void CallA216()
        {
            _narratorHandeler.BringInNarrator(AN216, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA216, CallA217);
        }
        private void CallA217()
        {
            _narratorHandeler.BringInNarrator(AN217, NarratorName.A, delayBetweenTwoNarrator, AudioName.AN217, CallA218);
        }
        private void CallA218()
        {
            _narratorHandeler.BringInNarrator(AN218, NarratorName.A, delayBetweenTwoNarrator, AudioName.AN218, CallImageForWharehouse);
        }
        private void CallImageForWharehouse()
        {
            ImageHandeler.Instance.BringPanel(whareHouseSPR, CallB22);
        }

        private void CallB22()
        {
            _narratorHandeler.BringInNarrator(BN22, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB22, CallA23);
        }


        private void CallA23()
        {
            _narratorHandeler.BringInNarrator(AN23, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA23, CallB24);
        }
        private void CallB24()
        {
            _narratorHandeler.BringInNarrator(BN24, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB24, CallA25);
        }

        private void CallA25()
        {
            _narratorHandeler.BringInNarrator(AN25, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA25, CallImageForInbound);
        }

        private void CallImageForInbound()
        {
            ImageHandeler.Instance.BringPanel(InboundSPR, CallB26);
        }
        private void CallB26()
        {
            _narratorHandeler.BringInNarrator(BN26, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB26, CallA27);
        }

        private void CallA27()
        {
            _narratorHandeler.BringInNarrator(AN27, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA27, CallB41);
        }

        private void CallB41()
        {
            _narratorHandeler.BringInNarrator(BN41, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB41, CallA42);
        }
        private void CallA42()
        {
            _narratorHandeler.BringInNarrator(AN42, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA42, CallImageForWharehouseReceving);
        }
        private void CallImageForWharehouseReceving()
        {
            ImageHandeler.Instance.BringPanel(ReceivingSPR, CallA43);
        }
        private void CallA43()
        {
            _narratorHandeler.BringInNarrator(AN43, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA43, CallB28);
        }
        private void CallB28()
        {
            _narratorHandeler.BringInNarrator(BN28, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB28, CallA29);
        }

        private void CallA29()
        {
            _narratorHandeler.BringInNarrator(AN29, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA29, CallB30);
        }

        private void CallB30()
        {
            _narratorHandeler.BringInNarrator(BN30, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB30, CallA31);
        }

        private void CallA31()
        {
            _narratorHandeler.BringInNarrator(AN31, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA31, CallB34);
        }
        private void CallB34()
        {
            _narratorHandeler.BringInNarrator(BN34, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB34, CallA35);
        }

        private void CallA35()
        {
            _narratorHandeler.BringInNarrator(AN35, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA35, CallImageForPutAway);
        }
        private void CallImageForPutAway()
        {
            ImageHandeler.Instance.BringPanel(PutawaySPR, CallBStorage1);
        }
        private void CallBStorage1()
        {
            _narratorHandeler.BringInNarrator(BStorage1, NarratorName.B, delayBetweenTwoNarrator, AudioName.BStorage1, CallAStorage2);
        }
        private void CallAStorage2()
        {
            _narratorHandeler.BringInNarrator(AStorage2, NarratorName.A, delayBetweenTwoNarrator, AudioName.AStorage2, CallB36);
        }
        private void CallB36()
        {
            _narratorHandeler.BringInNarrator(BN36, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB36, CallA37);
        }
        private void CallA37()
        {
            _narratorHandeler.BringInNarrator(AN37, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA37, CallImageForOutbound);
        }

        private void CallImageForOutbound()
        {
            ImageHandeler.Instance.BringPanel(OutboundSPR, CallA39);
        }
        //private void CallB38()
        //{
        //    _narratorHandeler.BringInNarrator(BN38, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB38, CallA39);
        //}

        private void CallA39()
        {
            _narratorHandeler.BringInNarrator(AN39, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA39, CallB40);
        }
        private void CallB40()
        {
            _narratorHandeler.BringInNarrator(BN40, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB40, CallB44);//CallB41 to skip receiving process
        }
        private void CallB44()
        {
            _narratorHandeler.BringInNarrator(BN44, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB44, CallA45);
        }
        private void CallA45()
        {
            _narratorHandeler.BringInNarrator(AN45, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA45, CallA47);
        }
        //private void CallB46()
        //{
        //    _narratorHandeler.BringInNarrator(BN46, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB46, CallA47);
        //}
        private void CallA47()
        {
            _narratorHandeler.BringInNarrator(AN47, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA47, CallImageForPicking);
        }

        private void CallImageForPicking()
        {
            ImageHandeler.Instance.BringPanel(PickingSPR, CallB48);
        }
        private void CallB48()
        {
            _narratorHandeler.BringInNarrator(BN48, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB48, CallA49);
        }
        private void CallA49()
        {
            _narratorHandeler.BringInNarrator(AN49, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA49, CallB50);
        }
        private void CallB50()
        {
            _narratorHandeler.BringInNarrator(BN50, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB50, CallA51);
        }
        private void CallA51()
        {
            _narratorHandeler.BringInNarrator(AN51, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA51, CallB52);
        }
        private void CallB52()
        {
            _narratorHandeler.BringInNarrator(BN52, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB52, callLookImage);
        }

        private void callLookImage()
        {
            _narratorHandeler.BringInNarrator(AN42, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA42, callimageforwharehouseTransport);
        }
        private void callimageforwharehouseTransport()
        {
            ImageHandeler.Instance.BringPanel(TransportSPR, CallA53);
        }
        private void CallA53()
        {
            _narratorHandeler.BringInNarrator(AN53, NarratorName.A, delayBetweenTwoNarrator, AudioName.NA53, BringWarehouseCompletePanel);
        }
        //private void CallB54()
        //{
        //    _narratorHandeler.BringInNarrator(BN38, NarratorName.B, delayBetweenTwoNarrator, AudioName.NB38, BringWarehouseCompletePanel);
        //}
        private void BringWarehouseCompletePanel()
        {
            WarehouseTutorailComplete.Instance.BringPanel(NGameComplete,null,AudioName.NGameComplete);
        }

    }
}
