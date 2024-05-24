using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace UI
{
    public class Render : MonoBehaviour
    {
        [SerializeField] private TMP_Text render;
        
        [SerializeField] private Button button1;
        [SerializeField] private Button button2;
        [SerializeField] private Button button3;
        [SerializeField] private Button button4;
        [SerializeField] private Button button5;

        private List<Button> _buttons = new List<Button>();
        private void Awake()
        {
            Assert.IsNotNull(render);
            
            Assert.IsNotNull(button1);
            Assert.IsNotNull(button2);
            Assert.IsNotNull(button3);
            Assert.IsNotNull(button4);
            Assert.IsNotNull(button5);
            
            _buttons.Add(button1);
            _buttons.Add(button2);
            _buttons.Add(button3);
            _buttons.Add(button4);
            _buttons.Add(button5);
            
            DeactivateAllButtons();
            
        }
        
        public void DeactivateAllButtons()
        {
            foreach (Button button in _buttons)
            {
                button.enabled = false;
                button.gameObject.SetActive(false);
            }
        }
        
        public void ActivateButton(int index, string text)
        {
            _buttons[index].gameObject.SetActive(true);
            _buttons[index].enabled = true;
            _buttons[index].GetComponentInChildren<TMP_Text>().text = text;
        }
        
        public void HideRender()
        {
            gameObject.SetActive(false);
            ClearRender();
        }
        
        public void ShowRender()
        {
            gameObject.SetActive(true);
        }
        
        public List<Button> GetListOfButtons()
        {
            return _buttons;
        }

        public void DrawText(string str)
        {
            render.text = str;
        }

        public void ClearRender()
        {
            render.text = "";
        }
    }
    
    

}