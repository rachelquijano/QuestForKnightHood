using UnityEngine;
using UnityEngine.UI;

public class TextAdventure : MonoBehaviour
{
    [SerializeField] Text storyTextComponent;
    [SerializeField] Text choiceTextComponent1;
    [SerializeField] Text choiceTextComponent2;
    [SerializeField] Button choiceButton1;
    [SerializeField] Button choiceButton2;
    [SerializeField] State startingState;
    [SerializeField] AudioSource soundManager;
    State state;

    void Start()
    {
        state = startingState;
        storyTextComponent.text = state.GetStateStory();
        choiceTextComponent1.text = state.GetChoiceTexts()[0];
        choiceTextComponent2.text = state.GetChoiceTexts()[1];

    }

    public void ChoiceButton(int button)
    {
        ManageStates(button);
        soundManager.Play();
    }

    private void ManageStates(int index)
    {
        var nextStates = state.GetNextStates();               
        state = nextStates[index];
        storyTextComponent.text = state.GetStateStory();
        choiceTextComponent1.text = state.GetChoiceTexts()[0];

        if (state.GetNextStates().Length > 1)
        {
            choiceButton2.gameObject.SetActive(true);
            choiceTextComponent2.text = state.GetChoiceTexts()[1];
        }
        else
        {
            choiceButton2.gameObject.SetActive(false);
        }
    }
}
