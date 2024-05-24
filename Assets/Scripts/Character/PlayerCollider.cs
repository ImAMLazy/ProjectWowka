using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    const float MaxDistance = 5f;
    Collider2D lastCollider;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Collision Trigger Event
    void OnTriggerEnter2D(Collider2D col)
    {
        
        lastCollider = col;
        //UnityEngine.Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other == lastCollider)
        {
            //Helper.Log("Break Dialog");
            GameController gc = Helper.GetGC();
            gc.BreakDialog();
        }
    }

    public bool IsColliding(Vector3 vec)
    {
        if (lastCollider == null)
        {
            UnityEngine.Debug.Log("Null");
            return false;
        }

        

        //float distance = (lastCollider.attachedRigidbody.transform.position - vec).magnitude;
        float distance = (lastCollider.transform.position - vec).magnitude;
        //float distance = (lastCollider.transform.parent.transform.position - vec).magnitude;
        //UnityEngine.Debug.Log(distance);
        bool result = distance < MaxDistance;

        //UnityEngine.Debug.Log(result);
        return result;
    }

    [CanBeNull]
    public Character GetLastCollidedCharacter()
    {
        if (lastCollider is not null)
        {
            return lastCollider.gameObject.GetComponent<Character>();
        }
        else
        {
            return null;
        }
    }

}