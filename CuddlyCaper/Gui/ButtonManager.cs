using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioSource Music, Sound;

    public Image MImage, SImage;
    public Sprite MSpriteOn, MSpriteOff, SSpriteOn, SSpriteOff;

    public bool music = true, sound;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Music != null)
        {
            if (music && Input.GetKeyDown(KeyCode.M))
            {
                Music.mute = true;
                music = false;
                if (MImage != null) { MImage.sprite = MSpriteOff; }

            }
            else if (!music && Input.GetKeyDown(KeyCode.M))
            {
                Music.mute = false;
                music = true;
                if (MImage != null) { MImage.sprite = MSpriteOn; }

            }
            
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Parents()
    {
        SceneManager.LoadScene(2);
    }
    public void Bear()
    {
        SceneManager.LoadScene(3);
    }
    public void MuteMusic()
    {
        if (music)
        {
            music = false;

        }
        else if (!music)
        {
            music = true;
        }

    }
    public void MuteSound()
    {
        if (sound)
        {
            sound = false;

        }
        else if (!sound)
        {
            sound = true;
        }
    }
}
