using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public Player player;
    public LayerMask layerMask;

    public GameObject f;

    public bool isOnStart;

    private void Update()
    {
        isOnStart = Physics2D.CapsuleCast(player.capsuleCollider2D.bounds.center, player.capsuleCollider2D.size, player.capsuleCollider2D.direction, 0, Vector2.down, player.playerData.GrounderDistance, layerMask);
        f.SetActive(isOnStart);


    }


    public void enterGame()
    {
        if (isOnStart)
        {
            SceneManager.LoadSceneAsync("Level", LoadSceneMode.Single);
        }
    }
}
