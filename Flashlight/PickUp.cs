using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public bool guiShow = false;
    public float rayLength = 0.5f;
    public bool useLightPickUpSound;
    public AudioClip lightPickUpSound;
    public GameObject flashLightPlayer;

    private GameObject lightMessageLabel;
    public GameObject lightUIPanel;
    public bool lightPickUpMessage;
    public string lightPickUpText = "You picked up a FlashLight";

    public Color lightPickUpTextColor = Color.white;
    
    //BATTERY VARIABLES
    private Transform myTransform;
    public bool useBatteryPickUpSound = false;
    private GameObject batteryMessageLabel;
    private GameObject batteryUIScript;

    private GameObject batteryLabel;

    public bool batteryEnableMessageMax = true;

    public bool Enabled;
    public float batteryAdd = 0.01f;
    public AudioClip batteryPickUpSound;
    public string maxBatteryText = "You have maximum pair of batteries";
    public Color maxBatterytextColor = Color.white;
    public bool batteryPickUpMessage;
    public string batteryPickUptext = "Battery pair +1";
    public Color batteryPickUpTextColor = Color.white;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CrossHairGUI reticle = this.GetComponent<CrossHairGUI>();
        

        guiShow = false;

        guiShow = lightPickUp();
        guiShow = batteryPickUp();
         

        if(guiShow == true)
        {
            reticle.m_UseReticle = true;
            reticle.m_DefaultReticle = false;
        }
        if(guiShow ==  false)
        {
            reticle.m_UseReticle = false;
            reticle.m_DefaultReticle = true;
        }

    }

    bool lightPickUp()
    {
        FlashLight flashLightScript = flashLightPlayer.GetComponent<FlashLight>();
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            if(hit.collider.gameObject.tag == "FlashLight")
            {
                guiShow = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    flashLightScript.enabled = true;
                    hit.collider.gameObject.SetActive(false);
                    lightUIPanel.SetActive(true);

                    flashLightScript.pickedFlashLight = true;

                    if(lightPickUpMessage)
                    {
                        StartCoroutine(sendLightPickUpMessage());
                    }

                    guiShow = false;
                }
            }
        }

        return guiShow;
    }

    bool batteryPickUp()
    {
        batteryUIScript = GameObject.Find("FlashLight");
        BatteryUI batteryComponent = batteryUIScript.GetComponent<BatteryUI>();
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(batteryComponent.enableBattery == true)
        {
            Enabled = true;
        }
        if(Physics.Raycast(transform.position, fwd, out hit, rayLength))
            {
                if(hit.collider.gameObject.tag == "Batteries")
                {
                    guiShow = true;
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        if(batteryComponent.enableBattery == false)
                        {
                            Enabled = false;
                            StartCoroutine(maxBatteries());
                        }
                        else
                        {
                            StartCoroutine(sendBatteryPickUpMessage());
                            batteryComponent.batteries += batteryAdd;
                            hit.collider.gameObject.SetActive(false);
                        }
                        guiShow = false;
                    }
                }
            }

        return guiShow;
    }

    public IEnumerator sendLightPickUpMessage()
    {
        lightMessageLabel = GameObject.Find("UI_MessageLabel");
        Text message = lightMessageLabel.GetComponent<Text>();

        message.enabled = true;
        message.color = lightPickUpTextColor;
        message.text = lightPickUpText;

        yield return new WaitForSeconds(1);
        message.CrossFadeAlpha(0, 0.2f, false);

        yield return new WaitForSeconds(1);
        message.enabled = false;
    }

    public IEnumerator sendBatteryPickUpMessage()
    {
        batteryMessageLabel = GameObject.Find("UI_MessageLabel");
        Text message = batteryMessageLabel.GetComponent<Text>();

        batteryEnableMessageMax = false;
        message.enabled = true;

        message.color = batteryPickUpTextColor;
        message.text = batteryPickUptext;

        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);

        message.enabled = false;
        batteryEnableMessageMax = true;
    }

    public IEnumerator maxBatteries()
    {
        batteryMessageLabel = GameObject.Find("UI_MessageLabel");
        Text message = batteryMessageLabel.GetComponent<Text>();

        if(!Enabled)
        {
            batteryEnableMessageMax = false;
            message.enabled = true;

            message.color = maxBatterytextColor;
            message.text = maxBatteryText;

            yield return new WaitForSeconds(2);
            message.CrossFadeAlpha(0f, 0.2f, false);
            yield return new WaitForSeconds(1);

            message.enabled = false;
            batteryEnableMessageMax = true;
        }
    }
}
