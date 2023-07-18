using UnityEngine;
using WareHouseDemo.Scripts;

public class TargetTrackeMannager : MonoBehaviour
{
    private bool isTrackStarted;
    void Start()
    {
        isTrackStarted = false;
        GameManager.Instance.UpdatePlayButton(false);
    }
   public void OnTargetFound()
    {
        //AudioListener.pause = false;
        if(isTrackStarted == false) { 
        GameManager.Instance.UpdatePlayButton(true);
        isTrackStarted = true;
        }
    }
    public void OnTargetLost()
    {
        //AudioListener.pause = true;
    }
}
