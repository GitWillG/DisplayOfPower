using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 using efe;
 using TMPro;

namespace efe
{

    /// <summary>
    /// This script calculate the current fps and show it to a text ui.
    /// </summary>
    public class framerateCounter : MonoBehaviour
    {
        public TextMeshProUGUI txtFps;

        private float _hudRefreshRate = 2;

        private float _timer;

        private void Update()
        {
            if (Time.unscaledTime > _timer)
            {
                int fps = (int)(1f / Time.unscaledDeltaTime);
                txtFps.text = "FPS: " + fps;
                fps += 10;
                _timer = Time.unscaledTime + _hudRefreshRate;
            }
        }
    }
}