using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = this.transform.position;
        player.transform.rotation = this.transform.rotation;
    }
}
