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

    public void NextOption() // changes the option value to the next one within the list
    {
        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }
        BodyPartCheck();
    }

    public void PreviousOption() // changes the option value to the previous one within the list
    {
        currentOption--;
        if (currentOption < 0)
        {
            currentOption = options.Count - 1;
        }
        BodyPartCheck();
    }

    private void BodyPartCheck() // checks for the correct body part to be displayed
    {
        bodyPart.sprite = options[currentOption];

        if (otherBodyPart != null) // in case that there is more than on sprite being changed (arms, legs and shoulders)
        {
            otherBodyPart.sprite = otherOptions[currentOption];
        }
        
        if(bodyPart.sprite != null) // updates the body part text
        {
            outfitTxt.text = bodyPart.sprite.name;
        }
        else // for parts that are optional to use (capes)
        {
            outfitTxt.text = "None";
        }

    }
}
