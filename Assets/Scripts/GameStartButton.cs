using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Starseeker
{
    public class GameStartButton : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => OnClickButton());
        }

        private void OnClickButton()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}