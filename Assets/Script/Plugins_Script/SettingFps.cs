using UnityEngine;

public class SettingFps : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
