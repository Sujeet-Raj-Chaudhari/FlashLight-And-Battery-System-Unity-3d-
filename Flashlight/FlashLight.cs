using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BatterySpriteClass{
    public Sprite Battery_0_red;
	public Sprite Battery_5;
	public Sprite Battery_10;
	public Sprite Battery_15;
	public Sprite Battery_20;
	public Sprite Battery_25;
	public Sprite Battery_30;
	public Sprite Battery_35;
	public Sprite Battery_40;
	public Sprite Battery_45;
	public Sprite Battery_50;
	public Sprite Battery_55;
	public Sprite Battery_60;
	public Sprite Battery_65;
	public Sprite Battery_70;
	public Sprite Battery_75;
	public Sprite Battery_80;
	public Sprite Battery_85;
	public Sprite Battery_90;
	public Sprite Battery_95;
	public Sprite Battery_100;
}

public class FlashLight : MonoBehaviour
{
    public Light linkedLight;

    public bool is_on = false;
    public float speed = 5.0f;

    public BatterySpriteClass BatterySprites = new BatterySpriteClass();
    public float batteryLifeInSec = 300f;
    public float batteryPercentage = 100;
    public GameObject FlashLightSprite;
    public bool pickedFlashLight = false;
    public bool on;
    private float timer;

    private Transform  myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Image BatterySprite = FlashLightSprite.GetComponent<Image>();
        timer += Time.deltaTime;
		
		if(pickedFlashLight)
		{
			if(Input.GetKeyDown(KeyCode.P) && timer >= 0.3f && batteryPercentage > 0)
			{
				on = !on;
				timer = 0;
			}
		}

		if(on)
		{
			linkedLight.enabled = true;
			batteryPercentage -= 4 * Time.deltaTime * (100 / batteryLifeInSec);
		}
		else{
			linkedLight.enabled = false;
		}


        batteryPercentage = Mathf.Clamp(batteryPercentage, 0, 100);

        if (batteryPercentage > 95.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_100;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 3, Time.deltaTime);
			}
        else if (batteryPercentage <= 95.0f && batteryPercentage > 90.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_95;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 2.8f, Time.deltaTime);
			}
			else if (batteryPercentage <= 90.0f && batteryPercentage > 85.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_90;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 2.6f, Time.deltaTime);
			}
			else if (batteryPercentage <= 85.0f && batteryPercentage > 80.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_85;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 2.4f, Time.deltaTime);
			}
			else if (batteryPercentage <= 80.0f && batteryPercentage > 75.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_80;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 2.2f, Time.deltaTime);
			}
			else if (batteryPercentage <= 75.0f && batteryPercentage > 70.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_75;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 2, Time.deltaTime);
			}
			else if (batteryPercentage <= 70.0f && batteryPercentage > 65.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_70;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 1.8f, Time.deltaTime);
			}
			else if (batteryPercentage <= 65.0f && batteryPercentage > 60.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_65;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 1.6f, Time.deltaTime);
			}
			else if (batteryPercentage <= 60.0f && batteryPercentage > 55.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_60;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 1.4f, Time.deltaTime);
			}
			else if (batteryPercentage <= 55.0f && batteryPercentage > 50.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_55;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 1.2f, Time.deltaTime);
			}
			else if (batteryPercentage <= 50.0f && batteryPercentage > 45.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_50;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 1f, Time.deltaTime);
			}
			else if (batteryPercentage <= 45.0f && batteryPercentage > 40.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_45;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0.9f, Time.deltaTime);
			}		
			else if (batteryPercentage <= 40.0f && batteryPercentage > 35.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_40;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0.8f, Time.deltaTime);
			}	
			else if (batteryPercentage <= 35.0f && batteryPercentage > 30.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_35;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0.7f, Time.deltaTime);
			}	
			else if (batteryPercentage <= 30.0f && batteryPercentage > 25.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_30;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0.6f, Time.deltaTime);
			}			
			else if (batteryPercentage <= 25.0f && batteryPercentage > 20.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_25;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0.5f, Time.deltaTime);
			}
			else if (batteryPercentage <= 20.0f && batteryPercentage > 15.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_20;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0.4f, Time.deltaTime);
			}
			else if (batteryPercentage <= 15.0f && batteryPercentage > 10.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_15;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0.3f, Time.deltaTime);
			}
			else if (batteryPercentage <= 10.0f && batteryPercentage > 5.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_10;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0.2f, Time.deltaTime);
			}
			else if (batteryPercentage <= 5.0f && batteryPercentage > 1.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_5;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0.1f, Time.deltaTime);
			}
			else if (batteryPercentage <= 1.0f)
			{
				BatterySprite.sprite = BatterySprites.Battery_0_red;
				linkedLight.intensity = Mathf.Lerp(linkedLight.intensity, 0, Time.deltaTime * 2);
			}
    }

	/*function OnGUI () {
        GUI.Label (Rect(70, Screen.height - 75,150,60), "Battery:   " + currentPower.ToString("F0") + "%");
    }
	*/
}
