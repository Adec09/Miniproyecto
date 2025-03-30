using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagere : MonoBehaviour
{
    public GameObject loaderScreen;

    public string programScene = "Program";
    public string[] levels;
    public string[] wantedLevels;
    

    string escenaActiva;
    public static SceneManagere Singleton { get; private set; }
    internal static event Action OnSingletonReady;

    private void OnEnable()
    {
        if (Singleton == null)
        {
            SetSingleton();
        }
    }
    public void SetSingleton()
    {
        Singleton = this;
        OnSingletonReady?.Invoke();
    }

    private void Start()
    {
        LoadLevel(levels[4]);
    }
    public void LoadLevel(string levelLoad)
    {
        if (!IsSceneLoaded(levelLoad))
        {
            SceneManager.LoadScene(levelLoad, LoadSceneMode.Additive);
            escenaActiva = levelLoad;
        }

        wantedLevels = new[] { levelLoad };
        StartCoroutine(RemoveUnwantedScenes(wantedLevels));
    }

    private IEnumerator RemoveUnwantedScenes(string[] wantedScenes)
    {
        Debug.Log("Removing Scenes");
        yield return null; //Needs at least 1 frame to ensure that the scene is loaded in the editor.

        List<string> unwantedScenes = new List<string>();

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            bool removeScene = true;

            for (int j = 0; j < wantedScenes.Length; j++)
            {
                if (SceneManager.GetSceneAt(i).name == wantedScenes[j])
                {
                    removeScene = false;
                }
            }
            if (removeScene)
            {
                unwantedScenes.Add(SceneManager.GetSceneAt(i).name);
                removeScene = false;
            }
        }

        loaderScreen.gameObject.SetActive(true);

        foreach (var VARIABLE in unwantedScenes)
        {
            Debug.Log(VARIABLE);
        }

        for (int i = 0; i < unwantedScenes.Count; i++)
        {
            if (SceneManager.GetSceneAt(i).name != programScene)
            {
                //The static scene will be ignored always, not possible to unload it. -> Debug.LogFormat("Removing Scene <color=orange>" + SceneManager.GetSceneAt(i).name + "</color>");
                SceneManager.UnloadSceneAsync(unwantedScenes[i]);
            }
        }

        loaderScreen.gameObject.SetActive(false);

    }

    public bool IsSceneLoaded(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (sceneName == SceneManager.GetSceneAt(i).name)
            {
                return true;
            }
        }
        return false;
    }
}
