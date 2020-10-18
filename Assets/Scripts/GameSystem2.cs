using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem2 : MonoBehaviour
{
    public float Interval;
    public float Curve;
    public GameObject Ball;
    public GameObject CurveBall;
    public GameObject Pitcher;
    public static bool canCurve;
    public static bool Stage2;
    // Start is called before the first frame update
    void Start()
    {
        Stage2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        Interval += Time.deltaTime;
        if (Interval >= 10)
        {
            Interval = 0;
            Curve = Random.Range(1, 3);
            if (Curve == 1)//カーブしない
            {
                canCurve = false;
                Instantiate(Ball, Pitcher.transform.position, Quaternion.identity);
            }
            if (Curve == 2)//カーブする
            {
                canCurve = true;
                Instantiate(CurveBall, Pitcher.transform.position, Quaternion.identity);
            }
        }
        if (Score.remainingBall == 0)
        {
            //スコアが条件超えて残り級数が0になったら勝利エンド
            if (Score.BallFlyingDistance >= 400)
            {
                SceneManager.LoadScene("Vic_End_Homerun_Derby");
                HiScoreSystem.SCORE = Score.BallFlyingDistance;
                Stage2 = false;
            }
            //スコアが条件超えなくて残り級数が0になったら勝利エンド
            if (Score.BallFlyingDistance < 400)
            {
                SceneManager.LoadScene("Def_End_Homerun_Derby");
                HiScoreSystem.SCORE = Score.BallFlyingDistance;
                Stage2 = false;
            }
        }
    }
}
