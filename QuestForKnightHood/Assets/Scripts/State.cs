using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State: ScriptableObject
{
    [TextArea(14,10)]
    [SerializeField] string storyText;
    [TextArea(2, 10)]
    [SerializeField] string[] choiceTexts;
    [SerializeField] State[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }
    public State[] GetNextStates()
    {
        return nextStates;
    }
    public string[] GetChoiceTexts()
    {
        return choiceTexts;
    }
}
