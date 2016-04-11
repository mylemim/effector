using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    protected int value;
    public virtual int Value
    {
        get
        {
            return this.value;
        }

        set
        {
            this.value += value;
        }
    }

    // Use this for initialization
    protected virtual void Start()
    {
        value = 0;
    }
}
