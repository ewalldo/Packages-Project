using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChronoTools
{
    public class ChronoToolsSample : MonoBehaviour
	{
        [Header("Countdown")]
        [SerializeField] private float countdownSeconds = 15f;
        [SerializeField] private TextMeshProUGUI countdownText;
        [SerializeField] private TextMeshProUGUI countdownMessage;
        [SerializeField] private Image countdownImage;
        [SerializeField] private Button countdownStart;
        [SerializeField] private Button countdownStop;
        [SerializeField] private Button countdownPause;
        [SerializeField] private Button countdownResume;

        [Header("Periodic")]
        [SerializeField] private float periodSeconds = 10f;
        [SerializeField] private TextMeshProUGUI periodText;
        [SerializeField] private TextMeshProUGUI periodMessage;
        [SerializeField] private Image periodImage;
        [SerializeField] private Button periodStart;
        [SerializeField] private Button periodStop;
        [SerializeField] private Button periodPause;
        [SerializeField] private Button periodResume;

        [Header("Stopwatch")]
		[SerializeField] private TextMeshProUGUI stopwatchText;
		[SerializeField] private Button stopwatchStart;
		[SerializeField] private Button stopwatchStop;
		[SerializeField] private Button stopwatchPause;
		[SerializeField] private Button stopwatchResume;

        private CountdownTimer countdownTimer;
        private PeriodicTimer periodicTimer;
		private StopwatchTimer stopwatchTimer;

        private CountdownTimer deactivateMessageTimer;

        private void Awake()
        {
            countdownTimer = new CountdownTimer(countdownSeconds);
            countdownTimer.OnTimerStart += () => StartButtonLogic(countdownStart, countdownStop, countdownPause, countdownResume);
            countdownTimer.OnTimerStart += () => countdownMessage.gameObject.SetActive(false);
            countdownTimer.OnTimerStop += () => StopButtonLogic(countdownStart, countdownStop, countdownPause, countdownResume);
            countdownTimer.OnTimerPaused += () => PauseButtonLogic(countdownStart, countdownStop, countdownPause, countdownResume);
            countdownTimer.OnTimerResumed += () => ResumeButtonLogic(countdownStart, countdownStop, countdownPause, countdownResume);
            countdownTimer.OnCountdownEnd += () => countdownMessage.gameObject.SetActive(true);
            countdownStart.onClick.AddListener(countdownTimer.Start);
            countdownStop.onClick.AddListener(countdownTimer.Stop);
            countdownPause.onClick.AddListener(countdownTimer.Pause);
            countdownResume.onClick.AddListener(countdownTimer.Resume);

            periodicTimer = new PeriodicTimer(periodSeconds);
            periodicTimer.OnTimerStart += () => StartButtonLogic(periodStart, periodStop, periodPause, periodResume);
            periodicTimer.OnTimerStop += () => StopButtonLogic(periodStart, periodStop, periodPause, periodResume);
            periodicTimer.OnTimerPaused += () => PauseButtonLogic(periodStart, periodStop, periodPause, periodResume);
            periodicTimer.OnTimerResumed += () => ResumeButtonLogic(periodStart, periodStop, periodPause, periodResume);
            periodicTimer.OnPeriodEnd += () => periodMessage.gameObject.SetActive(true);
            periodicTimer.OnPeriodEnd += () => deactivateMessageTimer.Start();
            periodStart.onClick.AddListener(periodicTimer.Start);
            periodStop.onClick.AddListener(periodicTimer.Stop);
            periodPause.onClick.AddListener(periodicTimer.Pause);
            periodResume.onClick.AddListener(periodicTimer.Resume);

            stopwatchTimer = new StopwatchTimer();
            stopwatchTimer.OnTimerStart += () => StartButtonLogic(stopwatchStart, stopwatchStop, stopwatchPause, stopwatchResume);
            stopwatchTimer.OnTimerStop += () => StopButtonLogic(stopwatchStart, stopwatchStop, stopwatchPause, stopwatchResume);
            stopwatchTimer.OnTimerPaused += () => PauseButtonLogic(stopwatchStart, stopwatchStop, stopwatchPause, stopwatchResume);
            stopwatchTimer.OnTimerResumed += () => ResumeButtonLogic(stopwatchStart, stopwatchStop, stopwatchPause, stopwatchResume);
            stopwatchStart.onClick.AddListener(stopwatchTimer.Start);
            stopwatchStop.onClick.AddListener(stopwatchTimer.Stop);
            stopwatchPause.onClick.AddListener(stopwatchTimer.Pause);
            stopwatchResume.onClick.AddListener(stopwatchTimer.Resume);

            deactivateMessageTimer = new CountdownTimer(3f);
            deactivateMessageTimer.OnCountdownEnd += () => periodMessage.gameObject.SetActive(false);
        }

        private void Update()
        {
            UpdateCountdown();
            UpdatePeriod();
            UpdateStopwatch();
        }

        private void UpdateCountdown()
        {
            countdownTimer.Tick();
            TimeSpan time = TimeSpan.FromSeconds(countdownTimer.CurrentTime);
            countdownText.text = time.ToString(@"mm\:ss");
            countdownImage.fillAmount = countdownTimer.Progress;

            deactivateMessageTimer.Tick();
        }

        private void UpdatePeriod()
        {
            periodicTimer.Tick();
            TimeSpan time = TimeSpan.FromSeconds(periodicTimer.CurrentTime);
            periodText.text = time.ToString(@"mm\:ss");
            periodImage.fillAmount = periodicTimer.Progress;
        }

        private void UpdateStopwatch()
        {
            stopwatchTimer.Tick();
            TimeSpan time = TimeSpan.FromSeconds(stopwatchTimer.CurrentTime);
            stopwatchText.text = time.ToString(@"mm\:ss\:fff");
        }

        private void StartButtonLogic(Button start, Button stop, Button pause, Button resume)
        {
            start.interactable = false;
            stop.interactable = true;
            pause.interactable = true;
            resume.interactable = false;
        }

        private void PauseButtonLogic(Button start, Button stop, Button pause, Button resume)
        {
            start.interactable = false;
            stop.interactable = false;
            pause.interactable = false;
            resume.interactable = true;
        }

        private void ResumeButtonLogic(Button start, Button stop, Button pause, Button resume)
        {
            start.interactable = false;
            stop.interactable = true;
            pause.interactable = true;
            resume.interactable = false;
        }

        private void StopButtonLogic(Button start, Button stop, Button pause, Button resume)
        {
            start.interactable = true;
            stop.interactable = false;
            pause.interactable = false;
            resume.interactable = false;
        }
    }
}