using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOnclick : MonoBehaviour
{
    [SerializeField] protected Sprite SpriteOn;
    [SerializeField] protected Sprite SpriteOff;
    public GameObject obj;
    public GameObject Currentobj;
    void Update()
    {
        ClickMouse();
    }
    public void ClickMouse()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.CompareTag("answer") && GameManager.instance.text_Handle.CanReloadQues == false) 
            {
                obj = GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
                obj.GetComponent<Button>().image.sprite = SpriteOn;
                if (Currentobj.name != obj.name)
                {
                    Currentobj.GetComponent<Button>().image.sprite = SpriteOff;
                    Currentobj = obj;
                }
                Debug.Log("name" + EventSystem.current.currentSelectedGameObject.name);
            }          
        }
       
    } 
}
