using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class ButtonControl : MonoBehaviour
{
    public GameObject slider;
    private CharacterChoice cp;
    private bool buttonState = false;
    private Text text;
    public Camera cam;
    private DepthOfField dof;
    private Bloom bloom;

    void Start()
    {
        cp = slider.GetComponent<CharacterChoice>();
        text = transform.GetChild(0).gameObject.GetComponent<Text>();
        dof = cam.GetComponent<DepthOfField>();
        bloom = cam.GetComponent<Bloom>();
    }
    public void ClickMe()
    {
        buttonState = !buttonState;
        dof.aperture = System.Convert.ToSingle(buttonState);
        cp.Show(buttonState);
        if (buttonState)
        {
            bloom.bloomThreshold = .3f;
            text.text = "Return to Game";
        }
        else
        {
            bloom.bloomThreshold = .5f;
            text.text = "Choose Character";
        }
    }
}
