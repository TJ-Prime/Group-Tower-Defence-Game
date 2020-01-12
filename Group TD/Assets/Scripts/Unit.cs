using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    float Health = 100;
    float maxHealth = 100;

    GameObject HealthBarBackground;
    GameObject HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        HealthBarBackground = transform.Find("HealthBar").gameObject;
        HealthBar = HealthBarBackground.transform.Find("Health").gameObject;

        Damage(0);
    }

    public void Damage(float damage)
    {
        Health -= damage;

        float newScale = Health / maxHealth;
        HealthBar.transform.localScale = new Vector3(newScale, 1, 1);

        float newPosition = (1 - newScale) / 2;
        HealthBar.transform.localPosition = new Vector3(-newPosition, 0, -0.1f);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
