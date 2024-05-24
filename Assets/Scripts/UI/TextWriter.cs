using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using TMPro;
using UI;
using Unity.VisualScripting;

public class TextWriter
{
    //[SerializeField]
    //GameObject render;

    string buffer = "";
    Render render;

    string text = "123456789123456789012345678901234567890";
    float delayTime = 0.08f;
    float lastTime = 0;
    float currentTime = 0;
    int currentIndex = 0;

    bool run = false;

    public TextWriter(Render Render)
    {
        render = Render;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!run)
        {
            return;
        }

        currentTime += Time.realtimeSinceStartup - lastTime;
        lastTime = Time.realtimeSinceStartup;

        //UnityEngine.Debug.Log(Time.realtimeSinceStartup);
        //UnityEngine.Debug.Log(delayTime);

        if (currentTime > delayTime)
        {
            currentTime = 0;
            currentIndex++;
            WriteText();

            // TODO: Here can be error, mb needs lenght +- 1 or smthng like this
            if (currentIndex == text.Length)
            {
                currentIndex = 0;
                run = false;
            }
        }
    }

    public void StartWriteText(string txt) // TODO: mb set text to write
    {
        text = txt;
        run = true;
    }

    public void EndWriteText()
    {
        // TODO
    }

    public void Clear()
    {
        render.ClearRender(); 
        text = "";
        currentIndex = 0;
        run = false;
    }

    private void WriteText()
    {
        if (currentIndex > text.Length)
        {
            Clear();
            return;
        }

        buffer = text.Substring(0, currentIndex);


        //render.text = buffer;


        //UnityEngine.Debug.Log(buffer);
        render.DrawText(buffer);
        buffer = "";
    }
}
