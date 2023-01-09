using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] Behaviour[] switchOnDeath;
    [SerializeField] bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(float amount)
    {
        if (dead)
            return;
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    void Die()
    {
        dead = true;
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 4f);

        foreach (Behaviour b in switchOnDeath)
            b.enabled = !b.enabled;

        try
        {
            GetComponent<Animator>().SetTrigger("Dead");
        }
        catch
        {
            Debug.Log("No Animator found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
