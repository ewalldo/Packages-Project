using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitExtras
{
    [UxmlElement]
    public partial class SpriteSheetImage : Image
	{
        private SpriteSheetAnimationContainer animationFrames;
        [UxmlAttribute]
        public SpriteSheetAnimationContainer AnimationFrames
        {
            get => animationFrames;
            set
            {
                if (animationFrames == value)
                    return;

                animationFrames = value;

                if (panel != null && IsPlaying)
                {
                    StopAnimationLogic();
                    if (AutoStart)
                        PlayAnimationLogic();
                }
                else if (panel != null && AutoStart && animationFrames != null && animationFrames.Length > 0)
                {
                    PlayAnimationLogic();
                }
                else if (animationFrames == null || animationFrames.Length == 0)
                {
                    StopAnimationLogic();
                }
            }
        }

        private float framesPerSecond = 60f;
        [UxmlAttribute]
        public float FramesPerSecond
        {
            get => framesPerSecond;
            set
            {
                if (Mathf.Approximately(framesPerSecond, value))
                    return;

                framesPerSecond = value > 0 ? value : 60f;

                if (panel != null && IsPlaying)
                {
                    StopAnimationLogic();
                    if (AutoStart)
                        PlayAnimationLogic();
                }
            }
        }

        [UxmlAttribute]
        public bool Loop { get; set; } = true;

        [UxmlAttribute]
        public bool AutoStart = true;

        private bool previewOnEditor = false;
        [UxmlAttribute]
        public bool PreviewOnEditor
        {
            get => previewOnEditor;
            set
            {
                if (previewOnEditor == value)
                    return;
                previewOnEditor = value;

                if (panel != null)
                {
                    StopAnimationLogic();
                    if (value)
                        PlayAnimationLogic();
                }
            }
        }

        private IVisualElementScheduledItem animationTask;
        private int currentFrame = 0;
        private bool isAttached = false;

        public SpriteSheetImage()
            : base()
        {
            RegisterCallback<AttachToPanelEvent>(OnAttachToPanel);
            RegisterCallback<DetachFromPanelEvent>(OnDetachFromPanel);
        }

        public void Play()
        {
            if (!isAttached)
                return;

            AutoStart = true;
            PlayAnimationLogic();
        }

        public void Pause()
        {
            animationTask?.Pause();
        }

        public void Resume()
        {
            if (animationTask != null && !animationTask.isActive)
            {
                animationTask.Resume();
            }
            else if (IsReadyToPlay() && (animationTask == null || !animationTask.isActive))
            {
                Play();
            }
        }

        public void Stop()
        {
            StopAnimationLogic();

            currentFrame = 0;

            if (animationFrames != null && animationFrames.Length > 0)
                base.sprite = animationFrames.GetSprite(currentFrame);
        }

        public bool IsPlaying => animationTask != null && animationTask.isActive;

        private void OnAttachToPanel(AttachToPanelEvent evt)
        {
            isAttached = true;
            if (AutoStart)
                PlayAnimationLogic();
        }

        private void OnDetachFromPanel(DetachFromPanelEvent evt)
        {
            isAttached = false;
            StopAnimationLogic();
        }

        private bool IsReadyToPlay()
        {
            return animationFrames != null && animationFrames.Sprites != null && animationFrames.Length > 0 && framesPerSecond > 0;
        }

        private void PlayAnimationLogic()
        {
            if (!isAttached)
                return;

#if UNITY_EDITOR
            if (!PreviewOnEditor && !Application.isPlaying)
            {
                StopAnimationLogic();
                return;
            }
#endif

            StopAnimationLogic();

            if (!IsReadyToPlay())
                return;

            if (currentFrame >= animationFrames.Length || currentFrame < 0)
                currentFrame = 0;

            Sprite initialSprite = animationFrames.GetSprite(currentFrame);
            if (initialSprite != null)
                base.sprite = initialSprite;
            else
            {
                Debug.LogError($"Initial sprite at index {currentFrame} is null in {name}.");
                return;
            }

            if (animationFrames.Length <= 1 && !Loop)
            {
                animationTask = null; // No animation needed for single frame
                return;
            }

            long delayMs = (long)(1000f / framesPerSecond);
            if (delayMs <= 0)
                delayMs = (long)1000f / 60;

            animationTask = schedule.Execute(UpdateFrame).Every(delayMs);
        }

        private void StopAnimationLogic()
        {
            animationTask?.Pause();
            animationTask = null;
        }

        private void UpdateFrame()
        {
            if (!IsReadyToPlay())
            {
                StopAnimationLogic();
                return;
            }

            currentFrame++;

            if (currentFrame >= animationFrames.Length)
            {
                if (Loop)
                    currentFrame = 0;
                else
                {
                    currentFrame = animationFrames.Length - 1; // Stay on the last frame
                    StopAnimationLogic();
                }
            }

            Sprite nextSprite = animationFrames.GetSprite(currentFrame);
            if (nextSprite != null)
                base.sprite = nextSprite;
            else
            {
                Debug.LogError($"Sprite at index {currentFrame} is null in {name}. Stopping animation");
                StopAnimationLogic();
            }
        }
    }
}