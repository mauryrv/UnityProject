using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LimitsController : MonoBehaviour {

   

	void OnCollisionEnter2D (Collision2D collision) {
        
		if (collision.collider.tag.Equals("Asteroid")) {
			SceneManager.LoadScene(3);
		}
	}

   

}
