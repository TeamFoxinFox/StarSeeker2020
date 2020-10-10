using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Starseeker
{
    public class PauseButton : MonoBehaviour
    {
        public GameObject PauseUI;

        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => OnClickButton());
        }

        private void OnClickButton()
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}