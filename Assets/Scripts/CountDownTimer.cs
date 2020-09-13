using System;

public class CountDownTimer
{
    private class TimerSetting
    {
        public readonly float TimeStamp;
        public readonly float CountDownTime;

        public TimerSetting(float timeStamp, float countDownTime)
        {
            TimeStamp = timeStamp;
            CountDownTime = countDownTime;
        }
    }

    private readonly Func<float> timeStampGetter = null;
    private TimerSetting timerSetting = null;

    /// <summary>
    /// Creates a new countdown timer with the provided timestamp getter.
    /// </summary>
    /// <param name="timeStampGetter">Calls this function to get a timestamp, at which 'StartTimer' was called. This can be, for instance: Time.time.</param>
    public CountDownTimer(Func<float> timeStampGetter)
    {
        this.timeStampGetter = timeStampGetter;
    }

    /// <param name="countDownTime">The countdown time in seconds.</param>
    public void StartTimer(float countDownTime)
    {
        timerSetting = new TimerSetting(timeStampGetter(), countDownTime);
    }

    public bool IsRunning()
    {
        if (timerSetting == null)
        {
            return false;
        }
        else
        {
            float timePassed = timeStampGetter() - timerSetting.TimeStamp;
            if (timePassed > timerSetting.CountDownTime)
            {
                // More time has passed than the countdown time, so we can can reset it now.
                timerSetting = null;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
