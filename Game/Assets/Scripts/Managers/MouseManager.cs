using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager>
{ 
    [SerializeField] Texture2D texture2D;

    void Start()
    {
        if (texture2D == null)
        {
            Debug.LogError("Cursor texture is missing! Assign a texture in the Inspector.");
            return;
        }

        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }



    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void State(int state)
    {
        switch(state)
        {
            case 0:
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            break;
            case 1:
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        State(scene.buildIndex);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
    {
        
    }
}
