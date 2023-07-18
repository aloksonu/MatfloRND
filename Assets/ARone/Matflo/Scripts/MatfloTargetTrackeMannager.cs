using UnityEngine;
using WareHouseDemo.Scripts;

public class MatfloTargetTrackeMannager : MonoBehaviour
{
    private bool isTrackStarted;
    void Start()
    {
        isTrackStarted = false;
        MatfloGameManager.Instance.UpdatePlayButton(false);
    }
    public void OnTargetFound()
    {
        //AudioListener.pause = false;
        if (isTrackStarted == false)
        {
            MatfloGameManager.Instance.UpdatePlayButton(true);
            isTrackStarted = true;
        }
    }
    public void OnTargetLost()
    {
        //AudioListener.pause = true;
    }

}
