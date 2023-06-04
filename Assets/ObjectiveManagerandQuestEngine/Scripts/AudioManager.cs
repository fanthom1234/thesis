using UnityEngine;

namespace ObjectiveManagerandQuestEngine
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public AudioSource audioSource;
        public AudioClip audioClip_CoinUpdate;
        public AudioClip audioClip_ObjectiveCompleted;
        public AudioClip audioClip_ObjectiveNew;

        private void Awake()
        {
            instance = this;
        }

        public void Play_Coin()
        {
            audioSource.PlayOneShot(audioClip_CoinUpdate);
        }

        public void Play_ObjectiveCompleted()
        {
            audioSource.PlayOneShot(audioClip_ObjectiveCompleted);
        }

        public void Play_ObjectiveNew()
        {
            audioSource.PlayOneShot(audioClip_ObjectiveNew);
        }
    }
}