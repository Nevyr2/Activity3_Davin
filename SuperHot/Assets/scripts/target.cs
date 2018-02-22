
using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (GameObject.Find("NPC"))
            GameObject.Find("NPC").GetComponent<gun>().dead = true;
        if (GameObject.Find("NPC(Clone)"))
            GameObject.Find("NPC(Clone)").GetComponent<gun>().dead = true;
        Destroy(gameObject);
    }

}
