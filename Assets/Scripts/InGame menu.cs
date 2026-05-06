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
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Front End");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
}
