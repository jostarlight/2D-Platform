using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{

    public static Launcher instance;
    public Camera MainCamera;
    public Camera UICamera;
    public GameObject eventSystem;
    public GameObject Canvas;


    private void Awake()
    {

        instance = this;

        DontDestroyOnLoad(Canvas);
        DontDestroyOnLoad(eventSystem);
        DontDestroyOnLoad(UICamera);
        DontDestroyOnLoad(MainCamera);
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
