﻿using UnityEngine;
using UnityEngine.UI;

namespace CutTheSheep
{
    public class ScissorsCursor : MonoBehaviour
    {
        [SerializeField] private Scissors scissors = null;
        [SerializeField] private RectTransform rect = null;
        [SerializeField] private Image image = null;
        
        private Vector2 cursorPosition;

        private void Start()
        {
            Application.targetFrameRate = 300;
            Cursor.visible = false;

            scissors.onHoverFeedback += ChangeCursorColor;
        }

        private void Update()
        {
            PlaceCursor();

            scissors.CheckInput();
        }

        private void PlaceCursor()
        {
            cursorPosition = Input.mousePosition;
            cursorPosition.x -= Screen.width / 2f;
            cursorPosition.y -= Screen.height / 2f;

            rect.anchoredPosition = cursorPosition;

            cursorPosition = Input.mousePosition;
        }

        /// <summary>
        /// FUTURE: make the scissorcs sprite different / opening closing the scissors,
        /// and you could also have an indication in the scissors when ur not allowed to cut ( the bear for example ).
        /// </summary>
        private void ChangeCursorColor(bool hoveringOverSomething) 
        {
            image.color = hoveringOverSomething ? Color.gray : Color.black;
        }

        public Vector2 GetCursorPosition() { return cursorPosition; }
    }
}