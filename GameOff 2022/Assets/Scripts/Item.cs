using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public virtual void PickUp()
    {
        Debug.Log(name + " picked up");
        Destroy(this.gameObject);
    }
}
