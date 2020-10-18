using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour
{
    public Vector3 position;

    [SerializeField] Bounds bounds;//バッターの打つ範囲を指定

    [SerializeField, Range(0f, 1f)] private float followStrength;

    public float Timing;//ボールを打つタイミングをカウントする変数
    public GameObject Ball;//ボールのオブジェクト

    public static float Time;//この秒数でボールの飛距離が確定する
    public static float DistanceX; //毎フレームX軸の距離(DistanceX)進む
    public static float DistanceY; //毎フレームY軸の距離(DistanceY)進む
    public Animator Battinganimator;

    // Start is called before the first frame update
    void Start()
    {

    }
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;//バッターの打つ範囲を指定
    }

    // Update is called once per frame
    void Update()
    {
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.x = Mathf.Clamp(position.x, bounds.xMin, bounds.xMax);
        position.y = Mathf.Clamp(position.y, bounds.yMin, bounds.yMax);

        position.z = 0f;

        transform.position = Vector3.Lerp(transform.position, position, followStrength);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Battinganimator.SetBool("BattingBool", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Battinganimator.SetBool("BattingBool", false);
        }

    }

    void OnTriggerStay2D(Collider2D Ball)
    {
        if (Ball.gameObject.tag == "Ball")
        {
            Timing = Ball.GetComponent<BallControll>().Timing;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Battinganimator.SetBool("BattingBool", true);
                if (Timing >= 0 && Timing <= 100)
                {
                    //左に飛ぶ
                    Debug.Log("fast");
                    Time = Random.Range(50.0f, 200.0f);
                    DistanceX = Random.Range(-0.3f, -0.1f);
                    DistanceY = Random.Range(0.01f, 0.5f);
                    SceneManager.LoadScene("Stage2_Ingame2");
                    Debug.Log("Time = " + Time);
                    Debug.Log("DistanceX = " + DistanceX);
                    Debug.Log("DistanceY = " + DistanceY);
                }
                else if (Timing >= 90 && Timing <= 95)
                {
                    Debug.Log("fastmeet");
                    Time = Random.Range(100.0f, 200.0f);
                    DistanceX = Random.Range(-0.3f, -0.1f);
                    DistanceY = Random.Range(2.0f, 4.0f);
                    SceneManager.LoadScene("Stage2_Ingame2");
                }
                else if (Timing > 100 && Timing <= 120)
                {
                    //真ん中に飛ぶ
                    Debug.Log("nomal");
                    Time = Random.Range(50.0f, 200.0f);
                    DistanceX = Random.Range(-0.1f, 0.1f);
                    DistanceY = Random.Range(0.01f, 0.5f);
                    SceneManager.LoadScene("Stage2_Ingame2");

                }
                else if (Timing >= 110 && Timing <= 115)
                {
                    Debug.Log("normalmeet");
                    Time = Random.Range(100.0f, 200.0f);
                    DistanceX = Random.Range(-0.1f, 0.3f);
                    DistanceY = Random.Range(0.01f, 0.5f);
                    SceneManager.LoadScene("Stage2_Ingame2");
                }
                else if (Timing > 120)
                {
                    //右に飛ぶ
                    Debug.Log("late");
                    Time = Random.Range(50.0f, 200.0f);
                    DistanceX = Random.Range(0.2f, 0.5f);
                    DistanceY = Random.Range(0.01f, 0.5f);
                    SceneManager.LoadScene("Stage2_Ingame2");
                }
                else if (Timing >= 130 && Timing <= 135)
                {
                    Debug.Log("latemeet");
                    Time = Random.Range(100.0f, 200.0f);
                    DistanceX = Random.Range(0.5f, 1f);
                    DistanceY = Random.Range(0.01f, 0.5f);
                    SceneManager.LoadScene("Stage2_Ingame2");
                }
            }
        }
    }
}
