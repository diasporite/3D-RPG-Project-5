using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG_Project
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;

        public StateID currentState;

        [field: SerializeField] public PartyController Player { get; set; }

        [field: SerializeField] public CombatDatabase Combat { get; private set; }
        [field: SerializeField] public CharacterDatabase CharData { get; private set; }

        public UIManager Ui { get; private set; }
        public AreaManager Area { get; private set; }

        public readonly StateMachine sm = new StateMachine();

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            Ui = FindObjectOfType<UIManager>();
            Area = GetComponent<AreaManager>();

            CharData.BuildDatabase();
        }

        private void Start()
        {
            InitSM();
        }

        void InitSM()
        {
            sm.AddState(StateID.GameMainMenu, new GameMainMenuState(this));
            sm.AddState(StateID.GameLoading, new GameLoadingState(this));
            sm.AddState(StateID.GameWorld, new GameWorldState(this));

            sm.ChangeState(StateID.GameMainMenu);
        }

        public IEnumerator LoadScene(int index)
        {
            yield return StartCoroutine(Ui.FadingScreen.FadeTo(1f, Color.black));

            sm.ChangeState(StateID.GameLoading);

            yield return StartCoroutine(Ui.FadingScreen.FadeTo(0f, Color.black));

            var async = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

            yield return new WaitUntil(() => async.isDone);

            yield return Area.InitAreaCo();

            yield return StartCoroutine(Ui.FadingScreen.FadeTo(1f, Color.black));

            sm.ChangeState(StateID.GameWorld);

            yield return StartCoroutine(Ui.FadingScreen.FadeTo(0f, Color.black));

            Ui.AreaName.DisplayText(Area.AreaName, 3f);
        }
    }
}