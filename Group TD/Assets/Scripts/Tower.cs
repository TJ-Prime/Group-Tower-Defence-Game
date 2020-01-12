using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float Range = 3; //How many tiles an enemy has to be before defending
    [SerializeField] float Damage = 1;
    [SerializeField] float FireRate = 1;

    float timeSinceFiring = 0;

    // Update is called once per frame
    void Update()
    {
        float RangeSize = (Range * 2) + 1;
        GetComponent<CapsuleCollider>().radius = RangeSize / 2;
        transform.Find("Range").transform.localScale = new Vector3(RangeSize, RangeSize, 1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || true)
        {
            Attack(other.gameObject);
        }
    }

    void Attack(GameObject unit)
    {
        if (timeSinceFiring >= FireRate)
        {
            timeSinceFiring = 0;
            unit.GetComponent<Unit>().Damage(Damage);
        }
        else
        {
            timeSinceFiring += Time.deltaTime;
        }
    }
}
