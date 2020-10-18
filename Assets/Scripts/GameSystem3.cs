using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem3 : MonoBehaviour
{
    public float Interval;
    public float Curve;
    public GameObject Ball;
    public GameObject CurveBall;
    public GameObject SpeedBall;
    public GameObject Pitcher;
    public static bool canCurve;
    public static bool canSpeed;
    public static bool Stage3;
    // Start is called before the first frame update
    void Start()
    {
        Stage3 = true;
    }

    // Update is called once per frame
    void Update()
    {
        Interval += Time.deltaTime;
        if (Interval >= 10)
        {
            Interval = 0;
            Curve = Random.Range(1, 4);
            if (Curve == 1)//カーブしない
            {
                canCurve = false;
                canSpeed = false;
                Instantiate(Ball, Pitcher.transform.position, Quaternion.identity);
            }
            if (Curve == 2)//カーブする
            {
                canCurve = true;
                canSpeed = false;
                Instantiate(CurveBall, Pitcher.transform.position, Quaternion.identity);
            }
            if (Curve == 3)
            {
                canCurve = false;
                canSpeed = true;
                Instantiate(SpeedBall, Pitcher.transform.position, Quaternion.identity);
            }
        }
        if (Score.remainingBall == 0)
        {
            //スコアが条件超えて残り級数が0になったら勝利エンド
            if (Score.BallFlyingDistance >= 500)
            {
                SceneManager.LoadScene("Vic_End_Homerun_Derby");
                HiScoreSystem.SCORE = Score.BallFlyingDistance;
                Stage3 = false;
            }
            //スコアが条件超えなくて残り級数が0になったら勝利エンド
            if (Score.BallFlyingDistance < 500)
            {
                SceneManager.LoadScene("Def_End_Homerun_Derby");
                HiScoreSystem.SCORE = Score.BallFlyingDistance;
                Stage3 = false;
            }
        }
    }
}
