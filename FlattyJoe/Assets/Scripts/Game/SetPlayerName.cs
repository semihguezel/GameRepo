using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

namespace Game
{
    public class SetPlayerName : Singleton<SetPlayerName>
    {
        private string _playerName;
        [SerializeField] GameObject inputField;
    
        public void StoreName()
        {
            var playerName = inputField.GetComponent<Text>().text;
            if (!string.IsNullOrWhiteSpace(playerName))
            {
                if (playerName.All(Char.IsLetter))
                {
                    _playerName = playerName;
                    SceneManager.LoadScene("MainMenu");

                }
            
            }
            else
            {
                EditorUtility.DisplayDialog("Blank space error has been occured", " Input field can not be leave as empty","ok", "");
            }

        }

        public string GetPlayerName()
        {
            return _playerName;
        }
    
    }
}