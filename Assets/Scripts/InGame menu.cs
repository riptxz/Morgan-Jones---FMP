using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamemenu : MonoBehaviour
{
    public GameObject menu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
        }

        if(Input.GetKey(KeyCode.Tab))
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Front End");
    }
}
