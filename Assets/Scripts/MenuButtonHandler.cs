using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject playButtonObj;
    [SerializeField]
    private GameObject endButtonObj;

    private Button playButton;
    private Button endButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton = playButtonObj.GetComponent<Button>();
        endButton = endButtonObj.GetComponent<Button>();

        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });

        endButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
