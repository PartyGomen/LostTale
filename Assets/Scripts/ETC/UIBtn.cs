using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBtn : MonoBehaviour
{
    Button[] btns = new Button[4];

    public GameObject inventory;
	public GameObject InventoryShadow;
	public GameObject MobileControl;
    public GameObject exitPanel;

	public GameObject Control;
    public AudioSource clickSound;

	void Start ()
    {
        btns = GetComponentsInChildren<Button>(true);
       
        btns[0].onClick.AddListener(() => Click());
        btns[1].onClick.AddListener(() => Click2());
        btns[2].onClick.AddListener(() => Click3());
        btns[3].onClick.AddListener(() => Click4());
    }

    void Click()
    {
        InventoryShadow.SetActive(true);
        inventory.SetActive(true);
		MobileControl.SetActive (false);
        SoundPlay();
		//Inventory.CheckInventory ();
    }

    void Click2()
    {
        AudioListener.volume = 0.0f;
        SoundPlay();
        btns[1].gameObject.SetActive(false);
        btns[2].gameObject.SetActive(true);
    }

    void Click3()
    {
        AudioListener.volume = 1.0f;
        SoundPlay();
        btns[1].gameObject.SetActive(true);
        btns[2].gameObject.SetActive(false);
    }

    void Click4()
    {
        SoundPlay();
        exitPanel.SetActive(true);
		Control.SetActive (false);
    }

    public void BackToTitleScene()
    {
        SoundPlay();
        SceneManager.LoadScene(3);
    }

    public void SoundPlay()
    {
        clickSound.Play();
    }

	public void HideControl(){
		Control.SetActive (true);
	}
}
