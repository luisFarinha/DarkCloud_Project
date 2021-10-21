using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private PlayerOutfit playerOutfit;

    private OutfitChanger[] outfitChangerScripts;

    void Awake()
    {
        //playerOutfit = new PlayerOutfit();
        //SaveData();
        
        outfitChangerScripts = GameObject.FindWithTag("PlayerOutfitsPanel").GetComponentsInChildren<OutfitChanger>();
        LoadData();
    }

    public void LoadData()
    {
        playerOutfit = JsonHandler.ReadPlayerOutfitData();
        
        if(playerOutfit != null)
        {
            foreach(OutfitChanger outfitChanger in outfitChangerScripts)
            {
                switch (outfitChanger.bodyPartString)
                {
                    case "head": outfitChanger.currentOption = playerOutfit.head; break;
                    case "shoulders": outfitChanger.currentOption = playerOutfit.shoulders; break;
                    case "torso": outfitChanger.currentOption = playerOutfit.torso; break;
                    case "arms": outfitChanger.currentOption = playerOutfit.arms; break;
                    case "legs": outfitChanger.currentOption = playerOutfit.legs; break;
                    case "cape": outfitChanger.currentOption = playerOutfit.cape; break;
                    case "sword": outfitChanger.currentOption = playerOutfit.sword; break;
                }
            }
        }
        else
        {
            Debug.Log("data is null");
        }

    }

    public void SaveData()
    {
        if (playerOutfit != null)
        {
            foreach (OutfitChanger outfitChanger in outfitChangerScripts)
            {
                switch (outfitChanger.bodyPartString)
                {
                    case "head": playerOutfit.head = outfitChanger.currentOption; break;
                    case "shoulders": playerOutfit.shoulders = outfitChanger.currentOption; break;
                    case "torso": playerOutfit.torso = outfitChanger.currentOption; break;
                    case "arms": playerOutfit.arms = outfitChanger.currentOption; break;
                    case "legs": playerOutfit.legs = outfitChanger.currentOption; break;
                    case "cape": playerOutfit.cape = outfitChanger.currentOption; break;
                    case "sword": playerOutfit.sword = outfitChanger.currentOption; break;
                }
            }
        }
        else
        {
            Debug.Log("data is null");
        }

        JsonHandler.WritePlayerOutfitData(playerOutfit);
    }
}
