using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] public Render _render;
    private TextWriter _textWriter;
    
    [CanBeNull] private ISpeechComponent currentSpeechNode;
    private bool isDialogRunning = false;
    private bool isAfterDialogEnd = false;
    private bool isAfterDialogEndSecondTime = false;

    private int cachedChooseItem = -1;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        Assert.IsNotNull(_render);
        
        _textWriter = new TextWriter(_render);
        
        SpeechConfig.Init();
        
        //Helper.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        _textWriter.Update();
    }
   
    public void CallDialog(Character character)
    {
        if (isAfterDialogEndSecondTime)
        {
            isAfterDialogEndSecondTime = false;
            _render.HideRender();
            ClearRender();
            return;
        }

        if (!isDialogRunning || isAfterDialogEnd)
        {
            Speech speech = character.GetSpeech();
            currentSpeechNode = speech;
            isDialogRunning = true;
            isAfterDialogEnd = false;
            cachedChooseItem = -1;
            _render.ShowRender();
        }

        if (currentSpeechNode.GetType() == typeof(Speech))
        {
            Speech castedSpeech = (Speech)currentSpeechNode;
            castedSpeech.PlayPreAction();

            string text = castedSpeech.GetText();
            
            //Helper.Log("Called Dialog");
            //Helper.Log(text);

            PrintToRender(text);
            
            castedSpeech.PlayPostAction();

            currentSpeechNode = castedSpeech.Next();

            if (currentSpeechNode != null)
            {
                // Call answers for UI and for remove double click
                if (currentSpeechNode.GetType() == typeof(Choose))
                {
                    // Call Options for answer
                    
                    Choose castedChoose = (Choose)currentSpeechNode;

                    List<string> answers = castedChoose.GetAnswers();
                    List<Button> buttons = _render.GetListOfButtons();

                    for (int i = 0; i < answers.Count; i++)
                    {
                        buttons[i].onClick.RemoveAllListeners();
                        var i1 = i;
                        buttons[i].onClick.AddListener(delegate
                        {
                            int num = i1;
                            SetChoose(num);
                        });
                        
                        _render.ActivateButton(i, answers[i]);
                    }

                }
            }
            else
            {
                isAfterDialogEnd = true;
                isAfterDialogEndSecondTime = true;
            }

            

        }
        else if (currentSpeechNode.GetType() == typeof(Choose))
        {
            Helper.Log(cachedChooseItem.ToString());
            if (cachedChooseItem == -1)
            {
                return;
            }

            // Here we select choose (new speech)
            Choose castedChoose = (Choose)currentSpeechNode;

            List<string> answers = castedChoose.GetAnswers();
            
            //
            currentSpeechNode = castedChoose.GetAnswerByKey(answers[cachedChooseItem]);
            cachedChooseItem = -1;
            _render.DeactivateAllButtons();
            CallDialog(null);
        }
        else
        {
            throw new Exception("Speech / Choose cast error");
        }
    }

    public void SetChoose(int itemNum)
    {
        cachedChooseItem = itemNum;
        CallDialog(null);
    }

    public void BreakDialog()
    {
        isDialogRunning = false;
        currentSpeechNode = null;
        cachedChooseItem = -1;
        isAfterDialogEndSecondTime = false;
        _render.DeactivateAllButtons();
    }

    private void PrintToRender(string str)
    {
        _textWriter.StartWriteText(str);
    }

    private void EndWriteText()
    {
        _textWriter.EndWriteText();
    }

    private void ClearRender()
    {
        _textWriter.Clear();
    }
}
