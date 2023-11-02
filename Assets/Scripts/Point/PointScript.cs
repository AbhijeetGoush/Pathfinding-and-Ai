using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public GameObject pointObj;
    public GameObject playerObj;
    PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            player.points += 1;
            Destroy(pointObj);
        }
    }
}
