using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace RPG_Project
{
    public class EnemyAIController : MonoBehaviour
    {
        [field: SerializeField] public EnemyAIPattern Pattern { get; private set; }

        [SerializeField] float minDelay = 5f;

        [SerializeField] StateID currentState;

        public PartyController Player { get; private set; }
        [field: SerializeField] public Transform Follow { get; private set; }

        public PartyController Party { get; private set; }
        public EnemyInputReader Ir { get; private set; }

        [field: SerializeField] public Cooldown Timer { get; private set; }

        public readonly StateMachine sm = new StateMachine();

        public Vector3 RelativeDirToPlayer => 
            transform.rotation * (Follow.position - transform.position);

        private void Awake()
        {
            Party = GetComponent<PartyController>();
            Ir = GetComponent<EnemyInputReader>();

            Timer = new Cooldown(minDelay, 1f, 0f);
        }

        private void OnEnable()
        {
            Party.OnCharacterChange += UpdateCharacter;

            SceneManager.sceneLoaded += FindPlayer;
        }

        private void OnDisable()
        {
            Party.OnCharacterChange -= UpdateCharacter;

            SceneManager.sceneLoaded -= FindPlayer;
        }

        private void Update()
        {
            sm.Update();

            currentState = sm.CurrentStateKey;
        }

        void FindPlayer(Scene scene, LoadSceneMode mode)
        {
            if (Player == null)
            {
                var gos = SceneManager.GetSceneByName("PersistentObjects").GetRootGameObjects();

                foreach(var go in gos)
                {
                    var p = go.GetComponent<PartyController>();

                    if (p == null) continue;

                    if (p.IsPlayer)
                    {
                        Player = p;
                        Follow = Player.transform;

                        InitSM();

                        sm.ChangeState(StateID.EnemyAIIdle);

                        break;
                    }
                }
            }
        }

        void UpdateCharacter()
        {
            Pattern = Party.CurrentController.Character.EnemyAi;

            Timer = new Cooldown(Pattern.MinDelay, 1f, 0f);
        }

        void InitSM()
        {
            sm.AddState(StateID.EnemyAIIdle, new EnemyAIIdleState(this));
            sm.AddState(StateID.EnemyAIChase, new EnemyAIChaseState(this));
            sm.AddState(StateID.EnemyAIStrafe, new EnemyAIStrafeState(this));
        }
    }
}