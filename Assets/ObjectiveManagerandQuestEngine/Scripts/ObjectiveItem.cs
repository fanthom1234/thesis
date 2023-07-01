using System.Collections.Generic;
using UnityEngine;

namespace ObjectiveManagerandQuestEngine
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectiveItem", order = 1)]
    public class ObjectiveItem : ScriptableObject
    {
        [Header("GENERAL DETAILS:")]
        public string Title;
        public string Description;
        public Sprite Icon;
        [HideInInspector]
        public bool isDone;
        public int Reward;
        public ObjectiveType Type;
        [ShowWhen("Type", ObjectiveType.Count)]
        public CountType countType;

        [Header("OBJECTIVE DETAILS:")]
        [ShowWhen("Type", ObjectiveType.Speak)]
        [TextArea(4,15)]
        public List<string> Speeches;

        [ShowWhen("Type", ObjectiveType.Speak)]
        public int SpeecIndex;

        [ShowWhen("Type", ObjectiveType.Speak)]
        public string Speecher;

        public string ObjectiveActorName;
        public int ObjectiveAmount;
        public bool ShowWaypoint = false;

        [Header("TRIGGER DETAILS:")]
        public bool TriggerAnEventIfObjectiveIsDone = false;

        [ShowWhen("TriggerAnEventIfObjectiveIsDone", true)]
        public string ObjectNameForTrigger;
        [ShowWhen("TriggerAnEventIfObjectiveIsDone", true)]
        public string ObjectTagForTrigger;
        [ShowWhen("TriggerAnEventIfObjectiveIsDone", true)]
        public string EventNameForTrigger;

        [Header("RESET DETAILS:")]
        public int ResetObjectiveAmount;
        [ShowWhen("Type", ObjectiveType.Speak)]
        public int ResetSpeechIndex;
    }

    public enum ObjectiveType
    {
        Time,
        Count,
        Go,
        Speak
    }

    public enum CountType
    {
        Killed,
        Collected
    }
}