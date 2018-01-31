﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class PredictionParametersButtonHandler : MonoBehaviour
    {
        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            SceneManager.LoadScene("PredictionScene");
        }
    }
}