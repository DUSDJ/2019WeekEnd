//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class DungeonUi : MonoBehaviour
//{
//    public GameObject dungeonInfoPanel;
//    public Dungeon dungeon;
//    private Dungeon visualDungeon;

//    [System.Serializable]
//    public struct DungeonStruct
//    {
//        public Image torsoImage;
//        public Text dungeonName;

//        public Text Hardness;

//        public Text reward;
//        public Text stress;
//        public Text time;

//    }
//    public DungeonStruct dungeonStruct;

//    public void Show(Dungeon dg)
//    {
//        dungeon = dg;
//        dungeonInfoPanel.SetActive(true);
//        SetDungeonUI();
//    }

//    public void DeepCopyDungeon()
//    {
//        visualDungeon = new Dungeon();
//        visualDungeon.DungeonSprite = dungeon.DungeonSprite;
//        visualDungeon.TorsoImage = dungeon.TorsoImage;
//        visualDungeon.dungeonName = dungeon.dungeonName;
//        visualDungeon.hardness = dungeon.hardness;
//        visualDungeon.rewardRange = dungeon.rewardRange;
//        visualDungeon.stressRange = dungeon.stressRange;
//        visualDungeon.timeRange = dungeon.timeRange;
//    }

//    public void SetDungeonUI()
//    {
//        dungeonStruct.dungeonName.text = visualDungeon.dungeonName;
//        dungeonStruct.torsoImage.sprite = visualDungeon.TorsoImage;

//        string hardness = "보통";
//        switch (visualDungeon.hardness)
//        {
//            case 0:
//                hardness = "쉬움";
//                break;
//            case 1:
//                hardness = "보통";
//                break;
//            case 2:
//                hardness = "어려움";
//                break;

//            default:
//                break;
//        }

//        dungeonStruct.Hardness.text = hardness;
//        dungeonStruct.reward.text = visualDungeon.rewardRange[0] + " ~ " + visualDungeon.rewardRange[1];
//        dungeonStruct.stress.text = visualDungeon.stressRange[0] + " ~ " + visualDungeon.stressRange[1];
//        dungeonStruct.time.text = visualDungeon.timeRange[0] + " ~ " + visualDungeon.timeRange[1];
//    }

//    public void Hide()
//    {
//        dungeonInfoPanel.SetActive(false);

//    }
//}
