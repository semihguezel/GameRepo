using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerHealth;
    private PLAYER _player;
    // Start is called before the first frame update
    void Start()
    {
        _player= FindObjectOfType<PLAYER>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = _player.PlayerHealthCounter().ToString();
    }
}
