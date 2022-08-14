using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class PlayerNew : MonoBehaviour
    {
        [SerializeField]
        float jumpForce = 10f;
        public float pitch;
        public float score;
        private bool _isGrounded = true;
        private bool _isAlive = true;

        private string _groundTag = "Ground";
        private string _obstacleTag = "Obstacle";
        private string _playerName;
    
        private Scene _scene;

        private Rigidbody2D _myBody;

        public TMP_Text scoreText;
        public GameObject playerNamePanel;

        // Start is called before the first frame update

        private void Awake()
        {
            _myBody = GetComponent<Rigidbody2D>();
            GetComponent<SpriteRenderer>();
            score = 0;
            _scene = SceneManager.GetActiveScene();
            playerNamePanel.SetActive(false);
        }
        void Start()
        {
            if (SystemInfo.supportsGyroscope)
            {
                Input.gyro.enabled = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (SystemInfo.supportsGyroscope)
            {
                // _gyro = GyroToUnity(Input.gyro.attitude);
                pitch = Input.gyro.attitude.y;
            }
            PlayerJump(pitch);

            if (_scene.name != "Tutorial")
            {
                score += Time.deltaTime * 4;
                scoreText.text = "Score : " + score.ToString("F");
            }
        
            if (!_isAlive)
            {
                Time.timeScale = 0;
                playerNamePanel.SetActive(true);
                _playerName = SetPlayerName.Instance.GetPlayerName();
            }
        
        } 

        void PlayerJump(float pitchAmount)
        {
            if (pitchAmount >= 0.1 || _isGrounded)
            {
                _myBody.AddForce(new Vector2(0f, Math.Abs(pitchAmount) * jumpForce), ForceMode2D.Impulse);
                _isGrounded = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_groundTag))
            {
                _isGrounded = true;
            }

            if (collision.gameObject.CompareTag(_obstacleTag))
            {
                _isAlive = false;
            }
        }
    }
}