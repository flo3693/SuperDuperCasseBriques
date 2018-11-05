using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deadzone : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ball")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
