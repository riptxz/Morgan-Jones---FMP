using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class InGamemenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject amenu;
    public GameObject cmenu;

    InputAction MenuAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
        MenuAction = InputSystem.actions.FindAction("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuAction.IsPressed() && amenu.activeInHierarchy == false && cmenu.activeInHierarchy == false) // If escape is pressed and audio and controls menu is false
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
