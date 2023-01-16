using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Scripts.Infrustructure.States
{
    public class SceneLoader
    {
        private ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            if(SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (waitNextScene.isDone == false)
                yield return new WaitForSeconds(1);

            onLoaded?.Invoke();
        }


    }
}