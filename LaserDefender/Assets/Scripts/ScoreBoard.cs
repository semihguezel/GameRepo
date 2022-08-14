using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;


    //cached parameters
    private GameSession _myGameSession;
 
    
    // Start is called before the first frame update
    void Start()
    {
        _myGameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = _myGameSession.GetScore().ToString();
      
    }
}
