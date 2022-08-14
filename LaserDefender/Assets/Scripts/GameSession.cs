using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
   public int score = 0;
   private void Awake()
   {
      AddSingleTon();
   }

   private void AddSingleTon()
   {
      int numberGameSessions = FindObjectsOfType<GameSession>().Length;
      if (numberGameSessions >1)
      {
         gameObject.SetActive(false);
         Destroy(gameObject);
        
      }
      else
      {
         DontDestroyOnLoad(gameObject);
      }
   }
   
   public void AddScore(int addToScore)
   {
      score += addToScore;
   }

   public int GetScore()
   {
      return score;
   }

   public void ResetScore()
   {
     Destroy(gameObject);
   }
   
}
