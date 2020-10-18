using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public Text HomerunText;
    public Text RemainingBallText;

    public static float BallFlyingDistance = 0;
    public static int remainingBall = 11;

    void Start()
    {
        BallFlyingDistance += Mathf.Ceil(Ball_Hit.Distance2);
        BallFlyingDistance += Mathf.Ceil(Ball_Hit2.Distance2);
        BallFlyingDistance += Mathf.Ceil(Ball_Hit3.Distance2);
        remainingBall -= 1;

    }

    void Update()
    {
        if (GameSystem.Stage1)
        {
            HomerunText.text = BallFlyingDistance.ToString() + "/300";
            RemainingBallText.text = remainingBall.ToString() + "/10";
        }
        if (GameSystem2.Stage2)
        {
            HomerunText.text = BallFlyingDistance.ToString() + "/400";
            RemainingBallText.text = remainingBall.ToString() + "/10";
        }
        if (GameSystem3.Stage3)
        {
            HomerunText.text = BallFlyingDistance.ToString() + "/500";
            RemainingBallText.text = remainingBall.ToString() + "/10";
        }
    }

    void AddPoint(int point)
    {
        BallFlyingDistance = BallFlyingDistance + point; 
    }

}
