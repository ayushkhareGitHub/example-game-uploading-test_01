using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController_01 : MonoBehaviour
{
    public Text gameText;
    public GameObject orbContainer;

    private OrbController_01[] orbs;

    private int orbsToDestroy;

    private float gameTimer;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        orbs = orbContainer.GetComponentsInChildren<OrbController_01>();
        orbsToDestroy = orbs.Length;

        foreach(OrbController_01 orb in orbs)
        {
            orb.onOrbDestroyed = () =>
            {
                OnOrbDestroyed();
            };
        }
    }

    void OnOrbDestroyed()
    {
        orbsToDestroy--;

        if(orbsToDestroy == 0)
        {
            isGameOver = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (!isGameOver)
        {
            gameText.text = "Shoot the orbs!\nTime : " + Mathf.Floor(gameTimer);
            gameTimer += Time.deltaTime;
        }
        else
        {
            gameText.text = "You won!\nTime" + Mathf.Floor(gameTimer);
        }
    }
}
