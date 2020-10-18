using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public float Interval;
    public GameObject Ball;
    public GameObject Pitcher;
    public static bool Stage1;
    public AudioSource Pitch;
    public AudioClip Throwing;
    // Start is called before the first frame update
    void Start()
    {
        Stage1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        Interval += Time.deltaTime;
        if(Interval >= 10)
        {
            Interval = 0;
            Instantiate(Ball, Pitcher.transform.position, Quaternion.identity);
            Pitch.PlayOneShot(Throwing);
        }
        if(Score.remainingBall == 0)
        {
            //スコアが条件超えて残り級数が0になったら勝利エンド
            if (Score.BallFlyingDistance >= 300)
            {
                SceneManager.LoadScene("Vic_End_Homerun_Derby");
                HiScoreSystem.SCORE = Score.BallFlyingDistance;
                Stage1 = false;
            }
            //スコアが条件超えなくて残り級数が0になったら勝利エンド
            if (Score.BallFlyingDistance < 300)
            {
                SceneManager.LoadScene("Def_End_Homerun_Derby");
                HiScoreSystem.SCORE = Score.BallFlyingDistance;
                Stage1 = false;
            }
        }
    }
}
