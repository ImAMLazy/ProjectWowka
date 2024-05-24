using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

enum Loops
{ 
    One = 1,
    Two = 2,
    Three = 3,
    Last
}

public interface ISpeechComponent
{
    public bool End();
}

public class Choose : ISpeechComponent
{
    private Dictionary<string, Speech> answers = new Dictionary<string, Speech>();
    public void AddAnswer(string text, Speech speech)
    {
        answers.Add(text, speech);
    }

    public bool End()
    {
        return false;
    }

    public List<string> GetAnswers()
    {
        List<string> result = new List<string>();

        foreach (var key in answers.Keys)
        {
            result.Add(key);
        }
        
        return result;
    }

    public Speech GetAnswerByKey(string key)
    {
        return answers[key];
    }
}

public class Speech : ISpeechComponent
{
    private ISpeechComponent? NextNode;
    private string Text;
    private Action PreAction;
    private Action PostAction;

    public void AddSpeech(string text)
    {
        Text = text;
    }

    public void AddNextNode(ISpeechComponent choose)
    {
        NextNode = choose;
    }

    public bool End()
    {
        if (NextNode == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlayPreAction()
    {
        if (PreAction != null)
        {
            PreAction.Invoke();
        }

        
    }

    public void PlayPostAction()
    {
        if (PostAction != null)
        {
            PostAction.Invoke();
        }
    }

    public string GetText()
    {
        return Text;
    }

    [CanBeNull]
    public ISpeechComponent Next()
    {
        return NextNode;
    }
}


/*
public class Choose : SpeechComponent
{
    Dictionary<string, Speech> answers = new Dictionary<string, Speech>();
    public void AddAnswer(string text, Speech speech)
    {
        answers.Add(text, speech);
    }
}

public class Speech : SpeechComponent
{
    Choose choose;
    List<string> speeches = new List<string>();
    public void AddSpeech(string text)
    {
        speeches.Add(text);
    }

    public void AddChoose(Choose choose)
    {
        this.choose = choose;
    }
}
*/





