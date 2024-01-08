using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour, IAgent, IDamageable
{
    public GameObject GameObject { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public void Init(){
        GameObject = this.gameObject;
        Agent = GetComponent<NavMeshAgent>();

        if (Agent == null) { Debug.LogError(GameObject.name + " Doesn't contain a NavMeshAgent"); }
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0){
            Die();
        }
    }

    public void Die()
    {
        NPCManager.Instance.RemoveNPC(this);
    }

    protected virtual void SetTarget(){
        
    }
}
