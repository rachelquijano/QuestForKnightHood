using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextAdventure : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] Text storyText;
    [SerializeField] Text choiceText1;
    [SerializeField] Text choiceText2;
    [SerializeField] Button choiceButton1;
    [SerializeField] Button choiceButton2;
    private State state;
    [Header("Gameplay Settings")]
    [Range(0.0f, 0.1f)]
    [SerializeField] float typeDelay = 0.025f;
    [Range(0.0f, 0.1f)]
    [SerializeField] float fadeDelay = 0.5f;
    [Header("Miscellaneous")]
    [SerializeField] State startingState;
    [SerializeField] SoundManager soundM;


    void Start()
    {
        state = startingState;
        soundM.voiceLine.clip = state.getVoiceClip();
        soundM.voiceLine.Play();
        StartCoroutine(TypeText(typeDelay));
        choiceText1.text = state.GetChoiceTexts()[0];

    }

    public void ChoiceButton(int button)
    {
        ManageStates(button);
        soundM.clickSound.Play();        
    }

    private void ManageStates(int index)
    {
        var nextStates = state.GetNextStates();               
        state = nextStates[index];
        soundM.voiceLine.clip = state.getVoiceClip();
        soundM.voiceLine.Play();
        StartCoroutine(TypeText(typeDelay));
        
    }

    IEnumerator TypeText(float delay)
    {

        storyText.text = "";
        soundM.writeSound.Play();
        foreach (char letter in state.GetStateStory().ToCharArray())
        {
            storyText.text += letter;
            yield return new WaitForSeconds(delay);
        }
        soundM.writeSound.Stop();
        EnableButton(choiceButton1, choiceText1, 0);


        if (state.GetNextStates().Length > 1)
        {
            EnableButton(choiceButton2, choiceText2, 1);
        }

    }

    public void EnableButton(Button button, Text text, int choice)
    {
        button.gameObject.SetActive(true);
        button.image.DOFade(1f, fadeDelay);
        text.DOFade(1f, 0.5f);
        text.text = state.GetChoiceTexts()[choice];
    }
    public void DisableButton(Button button)
    {     
        button.image.DOFade(0f, fadeDelay);        
        button.gameObject.SetActive(false);

    }
    public void DisableButtonText(Text text)
    {
        text.DOFade(0f, 0.5f);
    }

}
