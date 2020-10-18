using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Stg_Sel_Homerun_Derby");
    }

    public void OnClickStartButtonStage1()
    {
        SceneManager.LoadScene("Stage1_Ingame1");
    }

    public void OnClickStartButtonStage2()
    {
        SceneManager.LoadScene("Stage2_Ingame1");
    }

    public void OnClickStartButtonStage3()
    {
        SceneManager.LoadScene("Stage3_Ingame1");
    }

    public void OnClickStartButtonTitle()
    {
        Score.remainingBall = 11;
        Ball_Hit.Distance2 = 0;
        Score.BallFlyingDistance = 0;

        SceneManager.LoadScene("Title_Homerun_Derby");
    }

}
