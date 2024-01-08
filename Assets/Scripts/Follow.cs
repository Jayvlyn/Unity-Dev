using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject player;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if(dist > 4)
            {
                Debug.Log(dist);
                Vector3 dir = player.transform.position - transform.position;

                dir.Normalize();

                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }
        }
    }
}
