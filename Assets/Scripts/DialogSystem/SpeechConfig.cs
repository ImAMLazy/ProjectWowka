using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using JetBrains.Annotations;
using UnityEngine;



// This is a config with text values
public static class SpeechConfig
{
    private static Dictionary<string, Speech> _encounters = new Dictionary<string, Speech>();
    public static void Init()
    {

        /*
         Struct
        
        E - Encounter
        L - Loop
        S - Speech
        
        E1L1S1


         
         */



        Dictionary<string, Speech> Encounters = new Dictionary<string, Speech>();

        Speech FirstDialogC0S0 = new Speech();
        FirstDialogC0S0.AddSpeech("Hello");

        Speech FirstDialogC0S1 = new Speech();
        FirstDialogC0S1.AddSpeech("Are You Friendly&");
        FirstDialogC0S0.AddNextNode(FirstDialogC0S1);

        Choose FirstDialogC0C0 = new Choose();

        Speech FirstDialogC0C0S0 = new Speech();
        FirstDialogC0C0S0.AddSpeech("Sadly");

        FirstDialogC0C0.AddAnswer("No", FirstDialogC0C0S0);

        Speech FirstDialogC0C1S0 = new Speech();
        FirstDialogC0C1S0.AddSpeech("Hurray");

        Speech FirstDialogC0C1S1 = new Speech();
        FirstDialogC0C1S1.AddSpeech("Lets drink for this");
        FirstDialogC0C1S0.AddNextNode(FirstDialogC0C1S1);

        FirstDialogC0C0.AddAnswer("Yes", FirstDialogC0C1S0);

        FirstDialogC0S1.AddNextNode(FirstDialogC0C0);

        Speech FirstDialog = FirstDialogC0S0;

        Encounters.Add("FirstDialog", FirstDialog);
        // End of Encounter FirstDialog



        _encounters = Encounters;
    }

    [CanBeNull]
    public static Speech GetSpeechByKey(string key)
    {
        if (_encounters.ContainsKey(key))
        {
            return _encounters[key];
        }
        else
        {
            throw new Exception("Speech key does not exists");
        }
    }

   
}
