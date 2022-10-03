using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    public GameObject hitBoxController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
    }

    void Attack()
    {
        GameObject hitBox = Instantiate(hitBoxController, transform.position + new Vector3(1,0,0) ,Quaternion.identity);
        HitBoxController hitbox = hitBox.GetComponent<HitBoxController>();
        hitbox.MakeHit();
    }
}
