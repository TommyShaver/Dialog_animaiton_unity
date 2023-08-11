using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialog : MonoBehaviour
{
    public TextMeshProUGUI _textComponent;
    public string[] _linesOfSpeech;
    public float _textSpeed;


    // Controls the dialog _linesOfSpeech cue;
    private int _index;
    private void Start()
    {
        _textComponent.text = string.Empty;
        StartDialogueBoxOne();
    }
    void StartDialogueBoxOne()
    {
        _index = 0;
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine()
    {
        foreach (char c in _linesOfSpeech[_index].ToCharArray())
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }


   // this is to adavnce the text boo that once finished. 
   void NextLine()
    {
        _index++;
        StartCoroutine(TypeLine());
    }


    //this is for the user to skip animation of the box. 
    void UserInputNextLine()
    {
        if (_textComponent.text == _linesOfSpeech[_index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            _textComponent.text = _linesOfSpeech[_index];
        }
    }
}
