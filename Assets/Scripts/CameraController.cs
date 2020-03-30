using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CameraController : MonoBehaviour
{
    //private DepthOfField blur;
    public List<Component> components;
    private DepthOfField dof;

    void Start ()
    {
        //blur = GetComponent<DepthOfField>();
        components = new List<Component>();
        foreach (Component component in GetComponents<Component>())
        {
            Debug.Log(component);
        }
    }
    // Update is called once per frame
    public void ToggleBlur()
    {
    }
}
