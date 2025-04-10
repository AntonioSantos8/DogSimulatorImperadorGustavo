using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System;

class NDKEnvSetup : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        string ndkPath = @"C:\Program Files\Unity\Hub\Editor\2021.3.17f1\Editor\Data\PlaybackEngines\AndroidPlayer\NDK";
        Environment.SetEnvironmentVariable("ANDROID_NDK_ROOT", ndkPath);
        UnityEngine.Debug.Log("ANDROID_NDK_ROOT set to: " + ndkPath);
    }
}
