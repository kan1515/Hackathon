using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////////////////////////
// ボールの飛距離、角度、速度の設定 //
///////////////////////////////////

public class BallControll : MonoBehaviour

{
    public float Timing;//ボールの飛距離と飛ぶ角度が決まる
    public float BallSpeed;
    public float CurveSpeed;
    public float SpeedTiming;
    // Start is called before the first frame update
    // ボールの速度の決定
    void Start()
    {
        BallSpeed = Random.Range(-0.05f, -0.1f);
        CurveSpeed = Random.Range(-0.03f, 0.03f);
    }

    // Update is called once per frame
    // よくわからん
    void Update()
    {
        transform.position += new Vector3(0, BallSpeed, 0);
        Timing += 5;
        Destroy(this, 5);
        if(GameSystem2.canCurve)
        {
            transform.position += new Vector3(CurveSpeed, 0, 0);
        }
        if (GameSystem3.canCurve)
        {
            transform.position += new Vector3(CurveSpeed, 0, 0);
        }
        if (GameSystem3.canSpeed)
        {
            SpeedTiming += Time.deltaTime;
            if(SpeedTiming >= 0.5)
            transform.position += new Vector3(0, -0.05f, 0);
        }
    }
}
