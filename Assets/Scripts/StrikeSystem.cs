using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeSystem : MonoBehaviour
{
    public GameObject StrikeText;//ストライク表示のテキスト
    public float Interval;
    public bool Count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Count)
        {
            Interval += Time.deltaTime;
        }
        if(Interval >= 3 )
        {
            Count = false;
            Interval = 0;
            StrikeText.SetActive(false);

        }
    }
    void OnTriggerEnter2D(Collider2D Ball)
    {
        if (Ball.gameObject.tag == "Ball")
        {
            Count = true;
            StrikeText.SetActive(true);
            Score.remainingBall -= 1;
        }
    }
}
