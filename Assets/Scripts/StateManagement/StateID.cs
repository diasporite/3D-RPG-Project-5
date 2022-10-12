namespace RPG_Project
{
    public enum StateID
    {
        Empty = 0,

        GameOverworld = 1,
        GameMenu = 2,

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

        EnemyAIIdle = 31,
        EnemyAIChase = 32,
        EnemyAIStrafe = 33,
    }
}