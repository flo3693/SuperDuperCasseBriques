using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour {
    [Header("Managers")]
    [SerializeField] UIManager uiManager;

    [Header("Level")]
    [SerializeField] Transform leftWall;
    [SerializeField] Transform rightWall;
    [SerializeField] Transform topWall;

    int _numberOfBricks;

    int lives = 3;
    int score = 0;
    int scoreMultiplier = 0;

    GameObject _paddle;

    private void OnEnable() {
        Deadzone.OnBallDead += onBallDead;
        Brick.OnBrickDestroyed += onBrickDestroyed;
        Paddle.OnBallBounceOnPaddle += resetScoreMultiplier;
    }

    private void OnDisable() {
        Deadzone.OnBallDead -= onBallDead;
        Brick.OnBrickDestroyed -= onBrickDestroyed;
        Paddle.OnBallBounceOnPaddle -= resetScoreMultiplier;
    }

    void Start() {
        _paddle = Instantiate(Resources.Load<GameObject>("Prefabs/Paddle2"), Vector3.zero, Quaternion.identity);
        _paddle.GetComponent<Paddle>().Initialize(rightWall);

        _numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    void onBallDead() {
        lives--;
        if (lives > 0) {
            uiManager.RemoveLife();
            _paddle.GetComponent<Paddle>().Initialize(rightWall);
            resetScoreMultiplier();
        } else {
            uiManager.Defeat();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void onBrickDestroyed() {
        scoreMultiplier++;
        score += 10 * scoreMultiplier;
        uiManager.UpdateScore(score);
        _numberOfBricks--;
        if(_numberOfBricks <= 0){
            uiManager.Victory();
        }
    }

    void resetScoreMultiplier() {
        scoreMultiplier = 0;
    }
}
