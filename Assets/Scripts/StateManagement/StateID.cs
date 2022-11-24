namespace RPG_Project
{
    public enum StateID
    {
        Empty = 0,

        GameMainMenu = 1,
        GameLoading = 2,
        GameMenu = 3,
        GameWorld = 4,
        GameOverworld = 5,
        GameOver = 6,

        ControllerMove = 11,
        ControllerRun = 12,
        ControllerStrafe = 13,
        ControllerAction = 14,
        ControllerFall = 15,
        ControllerDeath = 16,
        ControllerStagger = 17,
        ControllerKnockback = 18,
        ControllerDodge = 19,
        ControllerGuard = 20,
        ControllerJump = 21,
        ControllerStandby = 22,
        ControllerInactive = 23,

        EnemyAIIdle = 31,
        EnemyAIChase = 32,
        EnemyAIStrafe = 33,
        EnemyAIStandby = 34,

        MainMenuHome = 41,
        MainMenuOptions = 42,

        MenuHome = 51,
    }
}