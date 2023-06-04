using UnityEngine;

namespace ObjectiveManagerandQuestEngine
{
    public class DummyTrainingScript : MonoBehaviour
    {
        public int Health = 100;

        public void GetDamage(int damage)
        {
            Health = Health - damage;
            GetComponent<Animation>().Play();
            if (Health <= 0)
            {
                ObjectiveManager.instance.CheckObjectiveStatus(GetComponent<ObjectiveChecker>().Name, GetComponent<ObjectiveChecker>().ObjectiveType);
                Destroy(gameObject, 1);
            }
        }
    }
}
