using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEditor;
using UnityEngine.Assertions;
using static System.Net.Mime.MediaTypeNames;

public class Player : Character
{
    //Animator animator;

    [SerializeField]
    public float speed = 0.1f;

    private Rigidbody2D rb;

    private bool MoveUp;
    private bool MoveDown;
    private bool MoveRight;
    private bool MoveLeft;
    private Vector2 moveIpnut;

    private Vector2 Go;

    [SerializeField]
    private GameObject collider;
    private PlayerCollider colliderComponent;

    //[SerializeField]
    //private TMP_Text render;

    //[SerializeField]
    //public GameObject buttonPrefab;

    //private TextWriter textWriter;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(collider);
        
        //animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        colliderComponent = collider.GetComponent<PlayerCollider>();
        //textWriter = GetComponent<TextWriter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))//(Input.GetKeyDown(KeyCode.Space))
        {
            bool isCollidingWithCharacter = colliderComponent.IsColliding(transform.position);
            if (isCollidingWithCharacter)
            {
                //Helper.Log("Click");

                GameController gameController = Helper.GetGC();
                if (gameController is not null)
                {
                    Character lastCollidedCharacter = colliderComponent.GetLastCollidedCharacter();
                    if (lastCollidedCharacter is not null)
                    {
                        gameController.CallDialog(lastCollidedCharacter);
                    }
                }
                else
                {
                    //Helper.Log("FAIL");
                }
            }
        }
        
        /*
        if (false)
        {
            // Create a new button
            Button newButton = CreateButton("Click me!", new Vector2(100, 180), Vector2.one * 30f);

            // Add a click event handler to the button
            newButton.onClick.AddListener(ButtonClick);
        }
        */




        moveIpnut.x = Input.GetAxisRaw("Horizontal");
        moveIpnut.y = Input.GetAxisRaw("Vertical");

        // speed2 = Random.Range(-2000f, 4000f);




    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveIpnut.normalized * speed * Time.deltaTime);
    }

    //private void Move(Vector2 vec)
    //{
    //transform.position += vec * speed;

    //rb.velocity += vec * speed;

    //rb.MovePosition(rb.position + vec * speed * Time.deltaTime);

    // }


/*
    // Button

    void MyAwesomeCreator()
    {
        //GameObject go = Instantiate(buttonPrefab);
        var button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() => FooOnClick());
    }

    void FooOnClick()
    {
        UnityEngine.Debug.Log("Ta-Da!");
    }

    ///
    
     
    Button CreateButton(string buttonText, Vector2 position, Vector2 size)
    {
        // Create a new GameObject for the button
        GameObject buttonGameObject = new GameObject("DynamicButton");
        buttonGameObject.transform.SetParent(transform);

        // Add a RectTransform component to handle position and size
        RectTransform rectTransform = buttonGameObject.AddComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = size;

        // Add a CanvasRenderer component
        CanvasRenderer canvasRenderer = buttonGameObject.AddComponent<CanvasRenderer>();

        // Add a Canvas component
        Canvas canvas = buttonGameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace; // Adjust based on your scene's requirements

        // Add a Button component to handle the button functionality
        Button button = buttonGameObject.AddComponent<Button>();

        // Add a Text component to display the button text
        UnityEngine.UI.Text buttonTextComponent = buttonGameObject.AddComponent<UnityEngine.UI.Text>();
        buttonTextComponent.text = buttonText;

        // Set up the button text properties
        buttonTextComponent.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf"); // Use LegacyRuntime.ttf
        buttonTextComponent.fontSize = 24;
        buttonTextComponent.alignment = TextAnchor.MiddleCenter;

        return button;
    }

    // Event handler for the button click
    void ButtonClick()
    {
        UnityEngine.Debug.Log("Button Clicked!");
    }
*/
}
