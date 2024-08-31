using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject audioSource;

    private GameObject panel;
    private Button pauseButton;
    private Button resumeButton;
    private Button endButton;
    private Button musicButton;
    private MusicHandler musicHandler;

    // Start is called before the first frame update
    void Start()
    {
        musicHandler = audioSource.GetComponent<MusicHandler>();
        panel = transform.Find("PausePanel").gameObject;
        pauseButton = transform.Find("PauseButton").GetComponent<Button>();
        resumeButton = panel.transform.Find("ContinueButton").GetComponent<Button>();
        endButton = panel.transform.Find("EndButton").GetComponent<Button>();
        musicButton = panel.transform.Find("MusicToggle").GetComponent<Button>();
        pauseButton.onClick.AddListener(() =>
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        });
        resumeButton.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            Time.timeScale = 1f;
            pauseButton.gameObject.SetActive(true);
        });
        endButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Title");
        });
        musicButton.onClick.AddListener(() =>
        {
            Image image = musicButton.GetComponent<Image>();
            image.color = new Color(image.color.g, image.color.r, image.color.b);
            musicHandler.ToggleMusic();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
