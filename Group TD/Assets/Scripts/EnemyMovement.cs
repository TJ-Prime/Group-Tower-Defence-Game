using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    GameObject Path;
    LineRenderer PathLine;
    int pointIndex = 0;
    Vector3 target = new Vector3(0, 0, 0);

    void Start()
    {
        Path = GameObject.Find("AttackPath");
        if (Path != null)
        {
            PathLine = Path.GetComponent<LineRenderer>();
            transform.position = PathLine.GetPosition(pointIndex);
            pointIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveUnit();
    }

    void MoveUnit()
    {
        target = PathLine.GetPosition(pointIndex);
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.001f && pointIndex < PathLine.positionCount - 1)
        {
            pointIndex++;
        }
        else if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            Debug.Log("Attacked defender");
            Destroy(gameObject);
        }
    }
}
