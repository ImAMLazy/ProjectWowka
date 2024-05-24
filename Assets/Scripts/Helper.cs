using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Helper
{
    [CanBeNull]
    public static GameController GetGC()
    {
        //Scene CurrentScene = SceneManager.GetActiveScene();
        Object gameObject = GameObject.Find("GameController");
        GameController gameController = gameObject.GetComponent<GameController>();
        return gameController;
    }

    [CanBeNull]
    public static Speech GetSpeechByKey(string Key)
    {
        Speech speech = new Speech();
        return speech;
    }

    public static void Log(string Str)
    {
        UnityEngine.Debug.Log(Str);
    }
}
