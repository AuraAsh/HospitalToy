using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseM;
   
    public void ClickPause()
    {
        pauseM.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClickContinue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
