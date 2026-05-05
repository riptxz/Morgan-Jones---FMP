using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class WinGame : MonoBehaviour
{

    public string rank;
    public GameObject rankmenu1;
    public GameObject rankmenu2;
    public GameObject rankmenu3;
    public GameObject rankmenu4;
    public GameObject rankmenu5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.time == 100f)
        {
            rank = ("S");
            print(rank);
            rankmenu1.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Timer.time == 150f)
        {
            rank = ("A");
            print(rank);
            rankmenu2.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Timer.time == 200f)
        {
            rank = ("B");
            print(rank);
            rankmenu3.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Timer.time == 250f)
        {
            rank = ("C");
            print(rank);
            rankmenu4.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Timer.time == 300f)
        {
            rank = ("F");
            print(rank);
            rankmenu5.SetActive(true);
            Time.timeScale = 0f;
        }


    }
}
