using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG_Project
{
    public class GameManager : MonoBehaviour
    {
        public event Action OnMenu;

        public static GameManager instance = null;

        public StateID currentState;

        [field: SerializeField] public PartyController Player { get; set; }

        [field: SerializeField] public CombatDatabase CombatData { get; private set; }
        [field: SerializeField] public CharacterDatabase CharData { get; private set; }

        public UIManager Ui { get; private set; }

        public TimeManager TimeManager { get; private set; }
        public AreaManager Area { get; private set; }

        readonly List<int> loadedSceneIndexes = new List<int>();

        public readonly StateMachine sm = new StateMachine();

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            Ui = FindObjectOfType<UIManager>();

            TimeManager = GetComponent<TimeManager>();
            Area = GetComponent<AreaManager>();

            CombatData.BuildDatabase();
            CharData.BuildDatabase();
        }

        private void Start()
        {
            InitSM();
        }

        private void Update()
        {
            if (Input.GetKeyDown("space")) GameOver();
        }

        void InitSM()
        {
            sm.AddState(StateID.GameMainMenu, new GameMainMenuState(this));
            sm.AddState(StateID.GameLoading, new GameLoadingState(this));
            sm.AddState(StateID.GameWorld, new GameWorldState(this));
            sm.AddState(StateID.GameOver, new GameOverState(this));

            sm.ChangeState(StateID.GameMainMenu);
        }

        public void LoadScene(int index, bool resetTimer)
        {
            StartCoroutine(LoadSceneCo(index, resetTimer));
        }

        public void GameOver()
        {
            StartCoroutine(GameOverCo());
        }

        #region Coroutines
        IEnumerator LoadSceneCo(int index, bool resetTimer)
        {
            yield return StartCoroutine(Ui.FadingScreen.FadeTo(1f, Color.black));

            sm.ChangeState(StateID.GameLoading);

            yield return StartCoroutine(Ui.FadingScreen.FadeTo(0f, Color.black));

            var async = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

            yield return new WaitUntil(() => async.isDone);

            if (resetTimer) TimeManager.ResetLevelTime();

            loadedSceneIndexes.Add(index);

            yield return Area.InitAreaCo();

            yield return StartCoroutine(Ui.FadingScreen.FadeTo(1f, Color.black));

            sm.ChangeState(StateID.GameWorld);

            yield return StartCoroutine(Ui.FadingScreen.FadeTo(0f, Color.black));

            Ui.AreaName.DisplayText(Area.AreaName, 3f);
        }

        IEnumerator GameOverCo()
        {
            yield return StartCoroutine(Ui.FadingScreen.FadeTo(1f, Color.black));

            sm.ChangeState(StateID.GameOver);

            foreach (var index in loadedSceneIndexes)
                if (SceneManager.GetSceneByBuildIndex(index).isLoaded)
                    SceneManager.UnloadSceneAsync(index);

            Player?.DestroySelf();

            Player = null;

            yield return StartCoroutine(Ui.FadingScreen.FadeTo(0f, Color.black));
        }
        #endregion
    }
}