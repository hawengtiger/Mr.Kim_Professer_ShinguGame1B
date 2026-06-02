using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Toggle bgmToggle;
    public Toggle sfxToggle;

    public Slider bgmSlider;
    public Slider sfxSlider;

    public Button openButton;
    public Button exitButton;

    public GameObject optionPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgmToggle.onValueChanged.AddListener(SoundManager.instance.OnOffBGM);
        sfxToggle.onValueChanged.AddListener(SoundManager.instance.OnOffSFX);

        bgmSlider.onValueChanged.AddListener(SoundManager.instance.ChangeBGMVolume);
        sfxSlider.onValueChanged.AddListener(SoundManager.instance.ChangeSFXVolume);

        openButton.onClick.AddListener(OpenPanel);
        exitButton.onClick.AddListener(ClosePanel);
    }

    private void OpenPanel()
    {
        optionPanel.SetActive(true);
    }

    private void ClosePanel()
    {
        optionPanel.SetActive(false);
    }
}
