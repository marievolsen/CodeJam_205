using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleControls : MonoBehaviour
{
    //Based on "BoxScript" and "Respawn", made by Victor Hej� during HTX at ZBC Ringsted.
    [SerializeField] private GameObject player;
    [SerializeField] private int nextLevelIndex;
    public AudioClip _clip;

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Checkpoint")
        {
            player.GetComponent<AccelerometerController>().SetSpawnPosition(transform.position);
            Destroy(gameObject);
            player.GetComponent<AccelerometerController>().checkpoint = true;
        }

        if (gameObject.tag == "Collectible")
        {
            Destroy(gameObject);
            AccelerometerController.collectibleCount++;

            //Based on https://www.youtube.com/watch?v=tEsuLTpz_DU
            SoundManager.Instance.PlaySound(_clip);
        }

        if (gameObject.tag == "Opponent")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(gameObject.tag == "NextLevel")
        {
            SceneManager.LoadScene(nextLevelIndex);
        }


    }
}
