using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public string MainSceneToLoad;
    public GameObject MainMenuUI;
    public GameObject SettingsUI;
    public GameObject AboutUI;

    public void PlayGame()
    {
        SceneManager.LoadScene(MainSceneToLoad);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void About()
    {
        MainMenuUI.SetActive(false);
        AboutUI.SetActive(true);
    }
    public void AboutBackButton()
    {
        MainMenuUI.SetActive(true);
        AboutUI.SetActive(false);
    }
    public void SettingButton()
    {
        MainMenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }
    public void SettingsBackButton()
    {
        MainMenuUI.SetActive(true);
        SettingsUI.SetActive(false);
    }
}
