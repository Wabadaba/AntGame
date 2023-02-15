using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private Animator animator;
    bool loadSceneFlag;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(StartTransition(1));
        }
    }
    public void SetSceneLoadFlag()
    {
        loadSceneFlag = true;
    }

    private IEnumerator StartTransition(int sceneNum)
    {
        animator.SetBool(0, false);
        while (!loadSceneFlag)
        {
            yield return new WaitForEndOfFrame();
            Debug.Log(loadSceneFlag);
        }
        SceneManager.LoadScene(sceneNum);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool(0, true);
        loadSceneFlag = false;
    }
}
