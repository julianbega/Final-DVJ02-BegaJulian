using UnityEngine.SceneManagement;
using UnityEngine;

public class MyScenelManager : MonoBehaviour
{
    public static MyScenelManager instanceSceneManager;

    public static MyScenelManager Instance { get { return instanceSceneManager; } }

    private void Awake()
    {
        if (instanceSceneManager != null && instanceSceneManager != this)
        {
            Destroy(FindObjectOfType<MyScenelManager>().gameObject);
        }
        else
        {
            instanceSceneManager = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnDisable()
    {
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    public void OnClickQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
