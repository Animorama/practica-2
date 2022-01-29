using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeePatrol : MonoBehaviour
{
    [SerializeField] float Speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if WallDetected() then Flip()
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(1,0,0) * Time.deltaTime * Speed;
    }

    private void Flip()
    {
        int angle = Random.Range(90, 271); // 271 is exclusive
        transform.Rotate(new Vector3(0, angle, 0));
    }
}
