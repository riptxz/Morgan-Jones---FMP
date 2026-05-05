using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public static float time;
    public TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = Mathf.Floor(time).ToString();
    }
}
