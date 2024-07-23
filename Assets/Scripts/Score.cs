using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score: MonoBehaviour
{
public Transform player;
public Text scoreText;

int currentScore;

private void Update()
{
currentScore = Mathf.FloorToInt(player.position.z); 
scoreText.text = currentScore.ToString();
}
}