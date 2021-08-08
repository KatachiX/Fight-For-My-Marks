using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenu : MonoBehaviour
{
    public GameObject storyMenu;
    public GameObject lvlText;
    public GameObject lvlOptions;
    public static bool readStory;
    // Start is called before the first frame update
    void Start()
    {
        if(readStory){
            storyMenu.SetActive(false);
            lvlText.SetActive(true);
            lvlOptions.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(readStory){
            storyMenu.SetActive(false);
            lvlText.SetActive(true);
            lvlOptions.SetActive(true);
        }
        else{
            storyMenu.SetActive(true);
            lvlText.SetActive(false);
            lvlOptions.SetActive(false);
        }
    }

    public void ContinueButton(){
        readStory = true;
    }

    public void ViewStory(){
        readStory = false;
    }
}
