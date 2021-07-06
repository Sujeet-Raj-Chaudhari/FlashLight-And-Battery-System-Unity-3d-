using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    public GameObject batteryLabel;
    public AudioClip reloadBatteriesSound;
    public KeyCode batteryReloadKey = KeyCode.R;

    public float batteries;
    private float minBatteries = 0.0f;
    private float maxBatteries = 0.05f;
    private float batteryDeduct = 1.0f;

    private Transform myTransform;

    public bool enableBattery;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(batteryReloadKey) && batteries > 0 && batteries <= 0.05f)
        {
            FlashLight flashLightComponent = this.GetComponent<FlashLight>();

            if(flashLightComponent.batteryPercentage < 90.0f)
            {
                flashLightComponent.batteryPercentage = 100;
                batteries -= batteryDeduct * 0.01f;

                if(reloadBatteriesSound)
                {
                    AudioSource.PlayClipAtPoint(reloadBatteriesSound, myTransform.position, 0.75f);
                }
            }
        }

        Text battery = batteryLabel.GetComponent<Text>();
        batteries = Mathf.Clamp(batteries, 0.0f, 0.05f);

        if(batteries <= minBatteries)
        {
            batteries = minBatteries;
            battery.text = "0 / 5";

            enableBattery = true;
        }

        else if(batteries <= 0.01f && batteries > 0)
        {
            battery.text = "1 / 5";
            enableBattery = true;
        }

        else if (batteries <= 0.02f && batteries > 0.01f)
		{
			battery.text = "2 / 5";
			enableBattery = true;
		}				
		
	    else if (batteries <= 0.03f && batteries > 0.02f)
		{
			battery.text = "3 / 5";
			enableBattery = true;
		}				
		
	    else if (batteries <= 0.04f && batteries > 0.03f)
		{
			battery.text = "4 / 5";
			enableBattery = true;
		}				
		
	    else if (batteries <= 0.05f && batteries > 0.04f)
		{
			battery.text = "5 / 5";
			enableBattery = false;
		}
			
			//Setting for a max batteries
	    else if(batteries > 0.05f)
		{
            batteries = maxBatteries;
		    enableBattery = false;
        }   
    }
}
