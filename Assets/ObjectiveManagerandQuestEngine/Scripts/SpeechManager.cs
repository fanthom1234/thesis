using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ObjectiveManagerandQuestEngine
{
    public class SpeechManager : MonoBehaviour
    {
        public GameObject Panel_Speech;
        public Text Text_Speaker;
        public Text Text_SpeechText;
        public static SpeechManager instance;
        private void Awake()
        {
            instance = this;
        }
        Coroutine lastRoutine = null;

        public void Show_Speach(string speech, string speaker)
        {
            Text_Speaker.text = speaker;
            Text_SpeechText.text = "";
            if (lastRoutine != null)
            {
                StopCoroutine(lastRoutine);
            }
            lastRoutine = StartCoroutine(ShowText(speech));
            Panel_Speech.SetActive(true);
            if (hideSpeech != null)
            {
                StopCoroutine(hideSpeech);
            }
            hideSpeech = HidetheSpeech();
            LastSpeakingTime = Time.time;
            StartCoroutine(hideSpeech);
        }

        private IEnumerator hideSpeech;

        IEnumerator ShowText(String speech)
        {
            for (int i = 0; i < speech.Length; i++)
            {
                yield return new WaitForSeconds(0.02f);
                Text_SpeechText.text += speech[i];
            }
        }

        IEnumerator HidetheSpeech()
        {
            yield return new WaitForSeconds(8);
            Panel_Speech.SetActive(false);
        }

        [HideInInspector]
        public float LastSpeakingTime = 0;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                LastSpeakingTime = Time.time-4;
            }
        }
    }
}