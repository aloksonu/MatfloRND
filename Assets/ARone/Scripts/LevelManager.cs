using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadTargerAR()
    {
        SceneManager.LoadSceneAsync("ArTargetOne");
    }
    public void LoadPlaneAR()
    {
        SceneManager.LoadSceneAsync("ARone");
    }
}
