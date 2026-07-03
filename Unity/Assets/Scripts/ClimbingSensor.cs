using System.Collections.Generic;
using UnityEngine;

public class ClimbingSensor : MonoBehaviour
{
    public bool InContact => contacts.Count > 0;

    HashSet<Collider> contacts = new HashSet<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if ((LayerMask.NameToLayer("Ground") & other.gameObject.layer) > 0)
        {
            contacts.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((LayerMask.NameToLayer("Ground") & other.gameObject.layer) > 0)
        {
            contacts.Remove(other);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = InContact ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, .25f);
    }
}
