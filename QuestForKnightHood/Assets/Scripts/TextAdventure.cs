using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextAdventure : MonoBehaviour
{
    [SerializeField] Text storyTextComponent;
    [SerializeField] Text choiceTextComponent1;
    [SerializeField] Text choiceTextComponent2;
    [SerializeField] Button choiceButton1;
    [SerializeField] Button choiceButton2;
    [SerializeField] State startingState;
    [SerializeField] AudioSource soundManager;
    [Range(0.0f, 0.1f)]
    [SerializeField] float delay;
    State state;

    void Start()
    {
        int test;
        state = startingState;
        StartCoroutine(TypeText(delay));
        choiceTextComponent1.text = state.GetChoiceTexts()[0];

    }

    public void ChoiceButton(int button)
    {
        Debug.Log("Text");
        ManageStates(button);
        soundManager.Play();        
        
    }

    private void ManageStates(int index)
    {
        var nextStates = state.GetNextStates();               
        state = nextStates[index];
        StartCoroutine(TypeText(delay));
        
    }

    IEnumerator TypeText(float delay)
    {

        storyTextComponent.text = "";
        foreach (char letter in state.GetStateStory().ToCharArray())
        {
            storyTextComponent.text += letter;
            yield return new WaitForSeconds(delay);
        }

        EnableButton(choiceButton1, choiceTextComponent1, 0);


        if (state.GetNextStates().Length > 1)
        {
            EnableButton(choiceButton2, choiceTextComponent2, 1);
        }

    }

    public void EnableButton(Button button, Text text, int choice)
    {
        button.gameObject.SetActive(true);
        button.image.DOFade(1f, 0.5f);
        text.DOFade(1f, 0.5f);
        text.text = state.GetChoiceTexts()[choice];
    }
    public void DisableButton(Button button)
    {     
        button.image.DOFade(0f, 0.5f);        
        button.gameObject.SetActive(false);

    }
    public void DisableButtonText(Text text)
    {
        text.DOFade(0f, 0.5f);
    }

}
