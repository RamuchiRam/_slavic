using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform player;
    private Vector3 pos;

    [SerializeField]
    float leftLimit = 12;
    [SerializeField]
    float rightLimit = 91;
    [SerializeField]
    float bottomLimit = 5.1f;
    [SerializeField]
    float upperLimit;

    private void Awake()
    {
        if (!player) {
            player = FindObjectOfType<Hero>().transform;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        pos = player.position;
        pos.z = -10f;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z
            );
    }
}
