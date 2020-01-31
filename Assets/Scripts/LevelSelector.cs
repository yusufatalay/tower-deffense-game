using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);//use PlayerPrefs wwhenever you want to get or set a value in 
                                                                //this case i am getting a value
                                                                //i wrote 1 as a default level player have reached
                                                                //so if game is 'just' started it will start from first level
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i+1>levelReached)  //if the button that links to the higher level from the player ever reached,this code will disable that button
            {
            levelButtons[i].interactable = false;
            }
        }    
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);

    }
}
