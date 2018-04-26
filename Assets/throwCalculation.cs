using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwCalculation : MonoBehaviour {

    float distance = 0;
    float distanceChanged = 0;
    GameObject horseshoe1;
    GameObject stake;
    int currentHighScore;
    TextMesh highScore;
    TextMesh currentScore;

    // Use this for initialization
    void Start () {
        horseshoe1 = GameObject.FindGameObjectWithTag("Horseshoe");
        stake = GameObject.FindGameObjectWithTag("Stake");
        highScore = GameObject.Find("HighScoretext").GetComponent<TextMesh>();
        currentScore = GameObject.Find("CurrentScoretext").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update () {
        currentScore.text = ((int)distance).ToString();
        //highScore.text = currentHighScore.ToString();
        if (distanceChanged == 0)
        {
            distanceChanged = distance;
            currentHighScore = (int)distance;
            highScore.text = ((int)distance).ToString();
        }else if ((int)distance < currentHighScore) {
            highScore.text = ((int)distance).ToString();
            currentHighScore = (int)distance;
        }
    }

    void OnCollisionEnter(Collision col) {

        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Horseshoe")
        {
            distance = Vector3.Distance(horseshoe1.transform.position, stake.transform.position);
            Debug.Log(distance);
        }
    }
}
