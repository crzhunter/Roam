using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapBindPerson : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position =new Vector3(player.position.x,transform.position.y,player.position.z);
        this.transform.eulerAngles = new Vector3(transform.eulerAngles.x,player.eulerAngles.y, transform.eulerAngles.z);
    }
}
