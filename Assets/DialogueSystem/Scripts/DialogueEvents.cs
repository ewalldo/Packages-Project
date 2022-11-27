namespace DialoguePackage
{
    public enum DialogueTimelineEvents
    {
        PlayTimelineSync,
        PlayTimelineAsync,
        PauseTimeline,
        RestartTimeline,
        JumpToTimeline,
    }

    public enum DialogueEvents
    {
        PauseDialogue,
    }

    public enum DialogueSoundEvents
    {
        PlayBGM,
        PlaySE,
    }

    public enum DialogueGameObjectEvents
    {
        ActivateDeactivate,
        //Translate,
        //Rotate,...
    }
}
