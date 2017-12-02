using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    // trigger: OnTriggerExit - called when other collider is no longer touching the trigger
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
