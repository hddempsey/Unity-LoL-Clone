using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private static Image healthBarImage;
    // Start is called before the first frame update
    void Start()
    {
        healthBarImage = GetComponent<Image>();
    }

    public static void SetHealthBarValue(float value)
    {
        healthBarImage.fillAmount = value;
        if (healthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (healthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public static float GetHealthBarValue()
    {
        return healthBarImage.fillAmount;
    }

    public static void SetHealthBarColor(Color healthColor)
    {
        healthBarImage.color = healthColor;
    }


}
