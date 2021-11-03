using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Button button;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            button = GameObject.FindWithTag("ExitButton").GetComponent<Button>();
            button.onClick.AddListener(ExitLevel);
        }
    }

    public void ExitLevel()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
