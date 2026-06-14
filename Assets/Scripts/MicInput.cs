//using System.Diagnostics;
//using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
//public class MicInput : MonoBehaviour
//{
//    private AudioSource audioSource;
//    private string micName;

//    void Start()
//    {
//        audioSource = GetComponent<AudioSource>();

//        if (Microphone.devices.Length == 0)
//        {
//            UnityEngine.Debug.LogError("No microphone found!");
//            return;
//        }

//        micName = Microphone.devices[0];

//        UnityEngine.Debug.Log("Using mic: " + micName);

//        audioSource.clip = Microphone.Start(
//            micName,
//            true,
//            10,
//            44100
//        );

//        audioSource.loop = true;

//        while (Microphone.GetPosition(micName) <= 0)
//        {
//        }

//        // 关键
//        audioSource.mute = false;

//        // 关键
//        audioSource.volume = 1.0f;

//        audioSource.Play();
//    }
//}

//搭配UI
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicInput : MonoBehaviour
{
    private AudioSource audioSource;
    private string micName;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 开始麦克风
    public void StartMic()
    {
        StopMic();

        if (Microphone.devices.Length == 0)
        {
            UnityEngine.Debug.LogError("No microphone found!");
            return;
        }

        micName = Microphone.devices[0];

        audioSource.clip = Microphone.Start(
            micName,
            true,
            10,
            44100
        );

        audioSource.loop = true;

        while (Microphone.GetPosition(micName) <= 0)
        {
        }

        audioSource.Play();

        UnityEngine.Debug.Log("Mic Started");
    }

    // 停止麦克风
    public void StopMic()
    {
        if (Microphone.devices.Length > 0)
        {
            Microphone.End(null);
        }

        audioSource.Stop();
        audioSource.clip = null;

        UnityEngine.Debug.Log("Mic Stopped");
    }

    // 播放测试音频
    public void PlayClip(AudioClip clip)
    {
        StopMic();

        audioSource.clip = clip;
        audioSource.loop = false;

        audioSource.Play();

        UnityEngine.Debug.Log("Playing Test Audio");
    }
    //
    public void StopAudio()
    {
        audioSource.Stop();
        audioSource.clip = null;

        UnityEngine.Debug.Log("Audio Stopped");
    }
}