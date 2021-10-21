using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite Body Part")]
    public SpriteRenderer bodyPart = new SpriteRenderer();
    public SpriteRenderer otherBodyPart = new SpriteRenderer();

    [Header("Sprite Options")]
    public List<Sprite> options = new List<Sprite>();
    public List<Sprite> otherOptions = new List<Sprite>();

    [Header("Outfit Text")]
    public Text outfitTxt;

    [Header("String Body Part and Outfit Index")]
    public string bodyPartString;
    public int currentOption;

    void Start()
    {
        BodyPartCheck();
    }

    public void NextOption()
    {
        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }
        BodyPartCheck();
    }

    public void PreviousOption()
    {
        currentOption--;
        if (currentOption < 0)
        {
            currentOption = options.Count - 1;
        }
        BodyPartCheck();
    }

    private void BodyPartCheck()
    {
        bodyPart.sprite = options[currentOption];

        if (otherBodyPart != null)
        {
            otherBodyPart.sprite = otherOptions[currentOption];
        }
        
        if(bodyPart.sprite != null)
        {
            outfitTxt.text = bodyPart.sprite.name;
        }
        else
        {
            outfitTxt.text = "None";
        }

    }
}
