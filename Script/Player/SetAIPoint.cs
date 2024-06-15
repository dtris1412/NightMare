using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAIPoint : MonoBehaviour
{
    public Transform AIPoint;
    public LayerMask setUpMask;
    public Vector3 Direction { get; set; }
    private GameObject setAIPoint;
    private void Awake()
    {
        Collider2D SetUpPoint = Physics2D.OverlapCircle(transform.position + Direction, 10f, setUpMask);
        if (setAIPoint)
        {
            setAIPoint = SetUpPoint.gameObject;
            setAIPoint.transform.position = AIPoint.position;
            setAIPoint.transform.parent = transform;
            if (setAIPoint.GetComponent<Rigidbody2D>())
                setAIPoint.GetComponent<Rigidbody2D>().simulated = false;

        }
    }
}
