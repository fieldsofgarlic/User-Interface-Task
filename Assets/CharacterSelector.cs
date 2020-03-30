using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPicker : MonoBehaviour
{
    private Slider control;
    private GameObject characterContainer;
    private List<Transform> characters = new List<Transform>();

    // Start is called before the first frame update
    void Awake()
    {
        control = GetComponent<Slider>();
        characterContainer = GameObject.Find("Characters");
        characterContainer.SetActive(true);
        foreach (Transform child in characterContainer.transform)
        {
            characters.Add(child);
        }
        ShowCharacter();
    }

    public void ShowCharacter()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (i == control.value)
            {
                ChangeLayersRecursively(characters[i], "HUD");
            }
            else
            {
                ChangeLayersRecursively(characters[i], "Default");
            }
        }
    }

    void OnDisable ()
    {
        characterContainer.SetActive(false);
    }

    void ChangeLayersRecursively(Transform trans, string name)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, name);
        }
    }
}
