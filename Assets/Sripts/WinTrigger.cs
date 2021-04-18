using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent winGame;

    private void OnTriggerEnter(Collider other)
    {
        winGame.Raise();
    }
}
