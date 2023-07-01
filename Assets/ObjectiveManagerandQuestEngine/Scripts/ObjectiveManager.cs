using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.Events;

namespace ObjectiveManagerandQuestEngine
{
    public class ObjectiveManager : MonoBehaviour
    {
        [Header("GENERAL DETAILS:")]
        [HideInInspector]
        public int CurrentObjectiveIndex = 0;
        public List<ObjectiveItem> Objectives;
        [HideInInspector]
        public static ObjectiveManager instance;
        public bool ResetObjectiveIndexOnStart = true;
        public bool AssignObjectivesOnStart = true;
        public UnityEvent TriggerEventWhenAllObjectivesAreDone;

        [Header("UI ELEMENTS:")]
        public GameObject ObjectivePanel;
        public Text Text_Description;
        public Image Image_Icon;

        [Header("OBJECTIVE DONE UI ELEMENTS:")]
        public GameObject Panel_ObjectiveDone;
        public Text Text_ObjectiveDoneCoin;
        public GameObject Image_ObjectiveDoneCoin;
        public Text Text_ObjectiveCountDown;
        public GameObject Panel_ObjectiveCountDown;

        [HideInInspector]
        public ObjectiveItem Objective_Current
        {
            get
            {
                if (CurrentObjectiveIndex >= Objectives.Count)
                {
                    return null;
                }
                else
                {
                    return Objectives[CurrentObjectiveIndex];
                }

            }
        }

        [Header("RESOURCES:")]
        public Sprite SpriteWhenAnObjectiveIsDone;

        void Awake()
        {
            for (int i = 0; i < Objectives.Count; i++)
            {
                Objectives[i].isDone = false;
                Objectives[i].SpeecIndex = Objectives[i].ResetSpeechIndex;
                Objectives[i].ObjectiveAmount = Objectives[i].ResetObjectiveAmount;

            }
            CurrentObjectiveIndex = ResetObjectiveIndexOnStart ? 0 : PlayerPrefs.GetInt("Objective", 0);
            instance = this;
        }

        private void Start()
        {
            if (AssignObjectivesOnStart)
            {
                CallLastActions_FromLastObjective_OnStartingGame();
                AssignObjective();
            }
        }

        public void Refresh_Objective_Text()
        {
            if (CurrentObjectiveIndex >= Objectives.Count)
            {
                return;
            }

            ObjectiveItem currentObjective = Objectives[CurrentObjectiveIndex];
            Text_Description.text = currentObjective.Description.ToString();
        }

        public void CallLastActions_FromLastObjective_OnStartingGame()
        {
            if (CurrentObjectiveIndex >= Objectives.Count)
            {
                return;
            }
            ObjectiveItem currentObjective = Objectives[CurrentObjectiveIndex];
            if (!currentObjective.isDone && CurrentObjectiveIndex > 0)
            {
                ObjectiveItem previousObjective = Objectives[CurrentObjectiveIndex - 1];
                if (!string.IsNullOrEmpty(previousObjective.ObjectNameForTrigger) && !string.IsNullOrEmpty(previousObjective.EventNameForTrigger))
                {
                    GameObject findObject = GameObject.Find(previousObjective.ObjectNameForTrigger);
                    if (findObject != null)
                    {
                        findObject.SendMessage(previousObjective.EventNameForTrigger);
                    }
                }
                else if (!string.IsNullOrEmpty(previousObjective.ObjectTagForTrigger) && !string.IsNullOrEmpty(previousObjective.EventNameForTrigger))
                {
                    GameObject[] findObjects = GameObject.FindGameObjectsWithTag(previousObjective.ObjectTagForTrigger);
                    if (findObjects != null)
                    {
                        for (int i = 0; i < findObjects.Length; i++)
                        {
                            findObjects[i].SendMessage(previousObjective.EventNameForTrigger);
                        }
                    }
                }
            }
        }

        public void AssignTarget(GameObject assign)
        {
            if (assign != null)
            {
                TargetPointer.Instance.enabled = true;
                TargetPointer.Instance.PointedTarget = assign;
            }
        }

        public void RemoveTarget()
        {
            TargetPointer.Instance.enabled = false;
        }

        public void AssignObjective()
        {
            ObjectiveItem currentObjective = Objectives[CurrentObjectiveIndex];
            if (!currentObjective.isDone)
            {
                if (currentObjective.Speeches.Count > 0 && currentObjective.SpeecIndex < currentObjective.Speeches.Count && !String.IsNullOrEmpty(currentObjective.Speecher) && !currentObjective.Speecher.Equals("You") && CurrentObjectiveIndex > 0)
                {
                    AssignTarget(GameObject.Find(currentObjective.Speecher));
                }

                Text_Description.text = currentObjective.Description.ToString();
                Text_Description.color = Color.white;
                Image_Icon.sprite = currentObjective.Icon;

                Text_ObjectiveCountDown.text = "";
                Panel_ObjectiveCountDown.SetActive(false);
                if (currentObjective.Type == ObjectiveType.Count || currentObjective.Type == ObjectiveType.Time)
                {
                    if (currentObjective.ObjectiveAmount > 0)
                    {
                        Text_ObjectiveCountDown.text = currentObjective.ObjectiveAmount.ToString();
                        Panel_ObjectiveCountDown.SetActive(true);
                    }
                }
                if (currentObjective.ShowWaypoint)
                {
                    var targetObject = GameObject.FindObjectsOfType<ObjectiveChecker>().Where(x => x.Name == currentObjective.ObjectiveActorName).FirstOrDefault();
                    if (targetObject != null)
                    {
                        AssignTarget(targetObject.gameObject);
                    }
                }
                ObjectivePanel.SetActive(true);
                AudioManager.instance.Play_ObjectiveNew();
            }
        }

        public bool CheckObjectiveStatus(string objectName, ObjectiveType type)
        {
            if (CurrentObjectiveIndex >= Objectives.Count)
            {
                return false;
            }

            ObjectiveItem currentObjective = Objectives[CurrentObjectiveIndex];

            if (currentObjective.Speecher == objectName)
            {
                RemoveTarget();
            }

            if (!currentObjective.isDone && currentObjective.ObjectiveAmount > 0 && currentObjective.Type == type)
            {
                if (currentObjective.Type == ObjectiveType.Speak)
                {
                    Speak(currentObjective.ObjectiveActorName);
                    return true;
                }
                if (currentObjective.ObjectiveActorName.Equals(objectName))
                {
                    currentObjective.ObjectiveAmount--;
                    if (currentObjective.ShowWaypoint)
                    {
                        RemoveTarget();
                    }
                    Text_ObjectiveCountDown.text = currentObjective.ObjectiveAmount.ToString();
                    if (currentObjective.ObjectiveAmount <= 0)
                    {
                        currentObjective.isDone = true;
                        StartCoroutine(ObjectiveDone(currentObjective));
                    }
                    return true;
                }
            }
            return false;
        }

        IEnumerator ObjectiveDone(ObjectiveItem currentObjective)
        {
            yield return new WaitForSeconds(0.5f);
            Image_Icon.sprite = SpriteWhenAnObjectiveIsDone;
            Text_ObjectiveCountDown.text = "";
            Panel_ObjectiveCountDown.SetActive(false);
            Text_Description.color = Color.green;

            yield return new WaitForSeconds(1);
            if (currentObjective.Reward > 0)
            {
                Image_ObjectiveDoneCoin.SetActive(true);
                Text_ObjectiveDoneCoin.text = currentObjective.Reward.ToString();
            }
            else
            {
                Image_ObjectiveDoneCoin.SetActive(false);
                Text_ObjectiveDoneCoin.text = "";
            }
            ObjectivePanel.SetActive(false);
            Panel_ObjectiveDone.SetActive(true);
            AudioManager.instance.Play_ObjectiveCompleted();
            yield return new WaitForSeconds(3);
            Panel_ObjectiveDone.transform.localScale = Vector3.zero;
            Panel_ObjectiveDone.SetActive(false);
            CurrentObjectiveIndex++;
            PlayerPrefs.SetInt("Objective", CurrentObjectiveIndex);
            RemoveTarget();

            if (!string.IsNullOrEmpty(currentObjective.ObjectNameForTrigger) && !string.IsNullOrEmpty(currentObjective.EventNameForTrigger))
            {
                GameObject findObject = GameObject.Find(currentObjective.ObjectNameForTrigger);
                if (findObject != null)
                {
                    findObject.SendMessage(currentObjective.EventNameForTrigger);
                }
            }
            else if (!string.IsNullOrEmpty(currentObjective.ObjectTagForTrigger) && !string.IsNullOrEmpty(currentObjective.EventNameForTrigger))
            {
                GameObject[] findObjects = GameObject.FindGameObjectsWithTag(currentObjective.ObjectTagForTrigger);
                if (findObjects != null)
                {
                    for (int i = 0; i < findObjects.Length; i++)
                    {
                        findObjects[i].SendMessage(currentObjective.EventNameForTrigger);
                    }
                }
            }



            if (CurrentObjectiveIndex < Objectives.Count)
            {
                ObjectiveItem newCurrentObjective = Objectives[CurrentObjectiveIndex];
                AssignObjective();
                if (!String.IsNullOrEmpty(newCurrentObjective.Speecher))
                {
                    AssignTarget(GameObject.Find(newCurrentObjective.Speecher));
                }
            }
            else
            {
                // All Objectives are Done! Let's Trigger the Final Event!
                if (TriggerEventWhenAllObjectivesAreDone != null)
                {
                    TriggerEventWhenAllObjectivesAreDone.Invoke();
                }
            }
        }

        public void Speak(string Name)
        {
            // if (Input.GetKeyDown(KeyCode.E))
            // if (Time.time > SpeechManager.instance.LastSpeakingTime + 20 || Input.GetKeyUp(KeyCode.E))
            // {
                SpeechManager.instance.LastSpeakingTime = Time.time;
                if (CurrentObjectiveIndex >= Objectives.Count)
                {
                    return;
                }

                ObjectiveItem currentObjective = Objectives[CurrentObjectiveIndex];
                if (currentObjective.Speecher.Equals(Name))
                {
                    if (currentObjective.SpeecIndex < currentObjective.Speeches.Count)
                    {
                        try
                        {
                            string speech = currentObjective.Speeches[currentObjective.SpeecIndex].ToString();
                            SpeechManager.instance.Show_Speach(speech, currentObjective.Speecher);
                        }
                        catch
                        {
                            SpeechManager.instance.Show_Speach(currentObjective.Speeches[currentObjective.SpeecIndex], currentObjective.Speecher);
                        }

                    }
                    currentObjective.SpeecIndex++;
                    if (currentObjective.SpeecIndex == currentObjective.Speeches.Count + 1)
                    {
                        // currentObjective.SpeecIndex++;
                        if (currentObjective.Type == ObjectiveType.Speak)
                        {
                            currentObjective.isDone = true;
                            StartCoroutine(ObjectiveDone(currentObjective));
                        }
                        else
                        {
                            AssignObjective();
                        }
                    }

                    if (currentObjective.SpeecIndex > currentObjective.Speeches.Count)
                    {
                        SpeechManager.instance.Panel_Speech.SetActive(false);
                    }
                // }
            }
        }
    }
}