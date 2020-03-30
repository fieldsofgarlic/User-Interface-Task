using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoice : MonoBehaviour
{
    private Slider control;
    private GameObject characterContainer;
    private List<Transform> characters = new List<Transform>();
    private CanvasGroup canvasGroup;
    private Text characterName;

    // Start is called before the first frame update
    void Awake()
    {
        control = GetComponent<Slider>();
        characterContainer = GameObject.Find("Characters");
        canvasGroup = GetComponent<CanvasGroup>();
        characterName = GameObject.Find("Character Name Text").GetComponent<Text>();
        foreach (Transform child in characterContainer.transform)
        {
            characters.Add(child);
        }
        HideCharacters();
    }

    public void Show(bool show)
    {
        canvasGroup.alpha = System.Convert.ToSingle(show);
        canvasGroup.blocksRaycasts = show;
        if (!show)
        {
            HideCharacters();
        }
        else
        {
            ShowCharacter();
        }
    }

    public void ShowCharacter()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (i == control.value)
            {
                characterName.text = characters[i].gameObject.name;
                ChangeLayersRecursively(characters[i], "HUD");
            }
            else
            {
                ChangeLayersRecursively(characters[i], "Default");
            }
        }
    }
    
    void HideCharacters()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            ChangeLayersRecursively(characters[i], "Default");
        }
    }

    void OnDisable ()
    {
        HideCharacters();
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
