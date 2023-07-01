using UnityEngine;

namespace ObjectiveManagerandQuestEngine
{
    public class ObjectiveChecker : MonoBehaviour
    {
        public string Name;
        public ObjectiveType ObjectiveType;

        [ShowWhen("ObjectiveType", ObjectiveType.Count)]
        public CountType countType;

        private float LastTimeCheck = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (ObjectiveType == ObjectiveType.Go)
                {
                    ObjectiveManager.instance.CheckObjectiveStatus(Name, ObjectiveType.Go);
                }
                else if (ObjectiveType == ObjectiveType.Count && countType == CountType.Collected)
                {
                    Collected();
                }
            }

            if (other.CompareTag("mentor"))
            {
                if (ObjectiveType == ObjectiveType.Count && countType == CountType.Collected)
                {
                    Collected();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (ObjectiveType == ObjectiveType.Go)
                {
                    ObjectiveManager.instance.CheckObjectiveStatus(Name, ObjectiveType.Go);
                }
                else if (ObjectiveType == ObjectiveType.Count && countType == CountType.Collected)
                {
                    Collected();
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (ObjectiveType == ObjectiveType.Speak)
                {
                    if (Input.GetKey(KeyCode.E) && Time.time > LastTimeCheck + 1)
                    {
                        ObjectiveManager.instance.CheckObjectiveStatus(Name, ObjectiveType.Speak);
                        LastTimeCheck = Time.time;
                    }
                }
                else if (ObjectiveType == ObjectiveType.Time && Time.time > LastTimeCheck + 1)
                {
                    LastTimeCheck = Time.time;
                    ObjectiveManager.instance.CheckObjectiveStatus(Name, ObjectiveType.Time);
                }
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (ObjectiveType == ObjectiveType.Speak)
                {
                    ObjectiveManager.instance.CheckObjectiveStatus(Name, ObjectiveType.Speak);
                }
                else if (ObjectiveType == ObjectiveType.Time && Time.time > LastTimeCheck + 1)
                {
                    LastTimeCheck = Time.time;
                    ObjectiveManager.instance.CheckObjectiveStatus(Name, ObjectiveType.Time);
                }
            }
        }

        public void Collected()
        {
            var result = ObjectiveManager.instance.CheckObjectiveStatus(Name, ObjectiveType.Count);
            if(result) Destroy(gameObject);
        }
    }
}