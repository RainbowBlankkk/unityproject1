using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public MicInput micInput;

    public AudioClip testClip;

    public TextMeshProUGUI modeText;

    // 播放测试音频
    public void PlayTestAudio()
    {
        micInput.PlayClip(testClip);

        modeText.text = "当前模式：离线音频";
    }
    //停止播放
    public void StopTestAudio()
    {
        micInput.StopAudio();

        modeText.text = "当前模式：停止离线音频";
    }

    // 开始麦克风
    public void StartMic()
    {
        micInput.StartMic();

        modeText.text = "当前模式：实时交互";
    }

    // 停止
    public void StopAll()
    {
        micInput.StopMic();

        modeText.text = "当前模式：已停止";
    }
}