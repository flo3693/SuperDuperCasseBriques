using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] GameObject[] lives;
    [SerializeField] Text score;

    int _index;

    private void Start() {
        InitializeNewGameUI();
    }

    public void InitializeNewGameUI() {
        _index = 0;
        score.text = "0";
        foreach (var live in lives) {
            live.SetActive(true);
        }
    }

    public void RemoveLife() {
        lives[_index].SetActive(false);
        _index++;
    }

    public void UpdateScore(int newScore) {
        score.text = newScore.ToString();
    }
}
