using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    void Start()
    {
        Cursor.visible =false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            if(!pauseMenu.activeSelf){
                Time.timeScale =0f;
                pauseMenu.SetActive(true);
                Cursor.visible=true;

            }   else {
                Time.timeScale =1f;
                pauseMenu.SetActive(false);
                Cursor.visible=false;
                
            }
        }
    }
    public void resume(){
           Time.timeScale =1f;
                pauseMenu.SetActive(false);
                Cursor.visible=false;
    }
      public void quit(){
           Time.timeScale =1f;
                pauseMenu.SetActive(false);
                Cursor.visible=false;
    }
}
