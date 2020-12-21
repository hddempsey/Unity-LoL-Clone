using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp = 1.0f;
    public Healthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        Healthbar.SetHealthBarValue(hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Return the new health
     */
    public float UpdateHealth(float change)
    {
        hp += change;
        Healthbar.SetHealthBarValue(hp);
        return hp;
    }
}
