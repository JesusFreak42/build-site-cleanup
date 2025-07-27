using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandler : MonoBehaviour
{

    [SerializeField] private GameObject inGameMenuBtn;
    [SerializeField] private GameObject menuObj;
    [SerializeField] private GameObject startBtns;
    [SerializeField] private GameObject inGameBtns;
    [SerializeField] private TMP_Text message;
    [TextAreaAttribute(3,5)] [SerializeField] private string startMessage;
    [TextAreaAttribute(3,5)] [SerializeField] private string winMessage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; //confine the cursor to the game window

        if (Application.isMobilePlatform)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep; //no sleep for this mobile device
            inGameMenuBtn.SetActive(true);
        }
        else
        {
            inGameMenuBtn.SetActive(false);
        }

        startBtns.SetActive(true);
        inGameBtns.SetActive(false);
        message.SetText(startMessage);
        SetMenuActive(true);
    }

    public bool MenuOpen()
    {
        return menuObj.active;
    }

    public void ToggleMenu()
    {
        if (menuObj.active)
        {
            SetMenuActive(false);
        }
        else
        {
            SetMenuActive(true);
        }
    }

    public void SetMenuActive(bool active)
    {
        menuObj.SetActive(active);
        Cursor.visible = active;
    }

    public void StartGame()
    {
        SetMenuActive(false);
        startBtns.SetActive(false);
        inGameBtns.SetActive(true);
    }

    public void ResumeGame()
    {
        SetMenuActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        message.SetText(winMessage);
        SetMenuActive(true);
    }

}
