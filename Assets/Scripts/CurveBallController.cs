using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBallController : MonoBehaviour
{
    public float Timing;//ボールの飛距離と飛ぶ角度が決まる
    public float BallSpeed;
    public float CurveSpeed;
    // Start is called before the first frame update
    // ボールの速度の決定
    void Start()
    {
        BallSpeed = Random.Range(-0.05f, -0.1f);
        CurveSpeed = Random.Range(-0.08f, 0.08f);
    }

    // Update is called once per frame
    // よくわからん
    void Update()
    {
        transform.position += new Vector3(0, BallSpeed, 0);
        transform.position += new Vector3(CurveSpeed, 0, 0);
        Timing += 5;
        Destroy(this, 5);
    }
}
