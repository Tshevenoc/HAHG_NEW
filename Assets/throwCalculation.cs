using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwCalculation : MonoBehaviour {

    private float distance = 0;
    GameObject horseshoe1;
    GameObject stake;
    private bool firstThrow = true;
    private float currentHighScore = 0;
    TextMesh highScore;
    TextMesh currentScore;

    // Use this for initialization
    void Start () {
        horseshoe1 = GameObject.FindGameObjectWithTag("Horseshoe");
        stake = GameObject.FindGameObjectWithTag("Stake");
        highScore = TextMesh.Find("HighScoretext").GetComponent<TextMesh>();
        currentScore = TextMesh.Find("CurrentScoretext").GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update () {
        currentScore.text = distance;

        if (firstThrow == true) {
            highScore.text = distance;
            firstThrow = false;
            currentHighScore = distance;
        } else if (distance < currentHighScore) {
            highScore.text = distance;
            currentHighScore = distance;
        }else
        {
            highScore.text = currentHighScore;
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
