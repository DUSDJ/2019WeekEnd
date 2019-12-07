//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Assets.Main.Scripts;

//public interface IHasEvent
//{
//    void Do(ICharacter hero);

//    bool CheckCondition(ICharacter hero);

//    string GetFlavorText();
//}

//public enum EventParameter
//{
//    Stress
//}

//public enum EventConditionType
//{
//    StressUp,
//    StressDown,
//    StressCompanionUp,
//}

//public enum EventType
//{
//    Counceil,
//    Report
//}

//namespace MyEvent
//{
//    [System.Serializable]
//    public class Event : IHasEvent
//    {
//        public int id;

//        public EventParameter EventChangeParameter;
//        public float ChangeValue;

//        public EventConditionType EventCondition;
//        public float ConditionValue;

//        public string Text;

//        public void Do(ICharacter hero)
//        {
//            switch (EventChangeParameter)
//            {
//                case EventParameter.Stress:
//                    hero.Stress += (int)ChangeValue;
//                    break;
//            }
//        }

//        public string GetFlavorText()
//        {
//            return Text;
//        }

//        public bool CheckCondition(ICharacter hero)
//        {
//            switch (EventCondition)
//            {
//                case EventConditionType.StressUp:
//                    return hero.Stress >= ConditionValue;
                    
//                case EventConditionType.StressDown:
//                    return hero.Stress <= ConditionValue;

//                default:
//                    return false;
//            }
//        }
//    }
//}

//public class EventManager : Singleton<EventManager>, IEventInfo
//{
//    public List<string> eventFlavorTexts;

//    public void CheckEvents(IDungeonInfo info)
//    {
//        ICharacter[] hero = info.GetCharacters();
//        for (int ix = 0; ix < hero.Length; ix++)
//        {
//            // 1 랜덤 발동
//            int ratio = Random.Range(0, 100);
//            if(ratio < 5f)
//            {
//                info.AddEvent(hero[ix], 1);
//                continue;
//            }

//            // 2 성격 파탄
//            if(hero[ix].Stress > 50)
//            {
//                info.AddEvent(hero[ix], 2);
//                continue;
//            }

//            // 3 좌절
//            for (int iy = 0; iy < hero.Length; iy++)
//            {
//                if (hero[iy].Stress >= 75)
//                {
//                    info.AddEvent(hero[ix], 3);
//                    break;
//                }
//            }

//            // 4 투지
//            ratio = Random.Range(0, 100);
//            if (ratio < 2f)
//            {
//                info.AddEvent(hero[ix], 4);
//                return;
//            }
//        }
//    }

//    public void ActiveEvent(IDungeonInfo info)
//    {
//        Dictionary<ICharacter, int> events = info.GetEvents();

//        float gainStress = info.GetLootStress();
//        foreach (var item in events)
//        {
//            switch (item.Value)
//            {
//                case 1:
//                    item.Key.Stress -= 10;
//                    break;

//                case 2:
//                    gainStress *= 0.1f;
//                    item.Key.Stress += (int)gainStress;
//                    break;

//                case 3:
//                    gainStress *= 0.1f;
//                    item.Key.Stress += (int)gainStress;
//                    break;

//                case 4:
//                    item.Key.Stress -= 10;
//                    break;

//                default:
//                    break;
//            }
//        }
//    }

//    public string GetFlavorText(int eventId)
//    {
//        return eventFlavorTexts[eventId];
//    }
//}

//public interface IEventInfo
//{
//    string GetFlavorText(int eventId);
//}

//public interface IDungeonInfo
//{
//    void GetInfo();
//    float GetLootStress();
//    float GetLoot();
//    ICharacter[] GetCharacters();

//    void AddEvent(ICharacter hero, int eventId);
//    Dictionary<ICharacter, int> GetEvents();
//}