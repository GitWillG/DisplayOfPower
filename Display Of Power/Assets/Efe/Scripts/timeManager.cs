using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



[System.Serializable]
public class DayColors
{
    public Color SkyColor;
    public Color EquatorColor;
    public Color GroundColor;

}
public class timeManager : MonoBehaviour
{

    // TIME
    [Range(0, 365)]
    [Tooltip("Current day since game start.")]
    public float curDay = 0f;
    private float counter30DAY = 0;
    [Range(0, 24)]
    [Tooltip("Current hour since game start.")]
    public float curHour = 0f;
    private float counter1SEC = 0f;
    [Range(0, 12)]
    [Tooltip("Current month since game start.")]
    public float curMonth = 0f;
    private float counter365DAY;
    [Range(0, 1000)]
    [Tooltip("Current year since game start.")]
    public float curYear = 0f;

    [Range(0f, 30f)]
    [Tooltip("How fast time moves. Default is 1.")]
    public float timeSpeed = 1f;

    public Light sun;
    [Range(0, 5f)]
    private float rateIntensityChange = 0;
   
    [Header("Colors")]
    [Space(10)]
    public DayColors dawnColors;
    public DayColors nightColors;

    // GUI
    [Header("Must-fill")]
    public TextMeshProUGUI hourText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI monthText;
    public TextMeshProUGUI yearText;

    // WEATHER
    public enum weather { Snow, Sunny, Rain };
    public int fogLevel = 0;

    // Start is called before the first frame update
    void Start()
    {

        sun.intensity = 0.65f;


    }

    // Update is called once per frame
    void Update()
    {
        processTime();
        weatherManager();

        Time.timeScale = timeSpeed;
       
    }
    void processTime()
    {
        counter1SEC += Time.deltaTime;
        if(counter1SEC > 1)
        {
            curHour++;
            curHour = Mathf.Clamp(curHour, 0, 24);
            // hourText.text = curHour.ToString();
            counter1SEC = 0;

            if (curHour == 24)
                {
                    counter30DAY++;
                    curDay++;
                    curDay = Mathf.Clamp(curDay, 0, 30);
                    // dayText.text = curDay.ToString();
                    curHour = 0;

                        if(counter30DAY == 30)
                        {
                            curMonth++;
                            counter30DAY = 0;
                        }
                }
        }

        rateIntensityChange += Time.deltaTime;

        if(rateIntensityChange > 0.2)
        {
            sun.intensity = Mathf.Clamp(sun.intensity, 0.35f, 1.5f);
            if (curHour > 12)
            {
                sun.intensity -= 0.01f;
            }
            else
            {
                sun.intensity += 0.01f;
            }
            rateIntensityChange = 0;
        }
    }

    void weatherManager()
    {
        if(curHour > 20 && curHour < 6)
        {
            RenderSettings.ambientSkyColor = nightColors.SkyColor;
            RenderSettings.ambientGroundColor = nightColors.GroundColor;
            RenderSettings.ambientEquatorColor = nightColors.EquatorColor;
        }
        else if(curHour > 6 && curHour < 20)
        {
            RenderSettings.ambientSkyColor = dawnColors.SkyColor;
            RenderSettings.ambientGroundColor = dawnColors.GroundColor;
            RenderSettings.ambientEquatorColor = dawnColors.EquatorColor;
        }
    }
}
