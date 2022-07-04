using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scroll_List_Handler : MonoBehaviour
{
    // Start is called before the first frame update
    public int rotationSpeed = 5;
    public GameObject plr_Model;
    public GameObject plr_ModelClothes;
    public Material[] arr_materials;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plr_Model.transform.Rotate(0,rotationSpeed * Time.deltaTime,0);
    }
    public void onCostumeButtonClick()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "Green_Costume")
        {
            plr_ModelClothes.GetComponent<SkinnedMeshRenderer>().material = arr_materials[0];
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Red_Costume")
        {
            plr_ModelClothes.GetComponent<SkinnedMeshRenderer>().material = arr_materials[1];
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Blue_Costume")
        {
            plr_ModelClothes.GetComponent<SkinnedMeshRenderer>().material = arr_materials[2];
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Black_Costume")
        {
            plr_ModelClothes.GetComponent<SkinnedMeshRenderer>().material = arr_materials[3];
        }
    }
}
