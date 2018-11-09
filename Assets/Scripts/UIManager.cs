using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] GameObject[] lives;
    [SerializeField] Text score;
    [SerializeField] GameObject victory;
    [SerializeField] AudioClip victorySound;
    [SerializeField] GameObject defeat;
    [SerializeField] AudioClip defeatSound;

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
        //victory.SetActive(false);
        defeat.SetActive(false);
    }

    public void RemoveLife() {
        lives[_index].SetActive(false);
        _index++;
    }

    public void UpdateScore(int newScore) {
        score.text = newScore.ToString();
    }

    public void Victory(){
        victory.SetActive(true);
        SoundManager.instance.PlaySingle(victorySound);
    }

    public void Defeat(){
        defeat.SetActive(true);
        SoundManager.instance.PlaySingle(defeatSound);
    }
}
