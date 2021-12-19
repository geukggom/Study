using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class Version_Manager : MonoBehaviour
{
    private static bool AutoIncrease = true;
    private const string AutoIncreaseMenuName = "Build/Auto Increase Build Version";

        [PostProcessBuild(1)] // PostProcessBuild - 빌드 후 실행되는 콜백 함수
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (AutoIncrease) EditVersion(0, 0, 1);
    }

    /// <summary>
    /// 자동으로 버전업
    /// </summary>
    [MenuItem(AutoIncreaseMenuName, false, 1)]
    private static void SetAutoIncrease()
    {
        AutoIncrease = !AutoIncrease;
        EditorPrefs.SetBool(AutoIncreaseMenuName, AutoIncrease);
        Debug.Log("Auto Increase : " + AutoIncrease);
    }

    [MenuItem(AutoIncreaseMenuName, true)]
    private static bool SetAutoIncreaseValidate()
    {
        Menu.SetChecked(AutoIncreaseMenuName, AutoIncrease);
        return true;
    }

    /// <summary>
    /// 버전 수정(버전업)
    /// </summary>
    static void EditVersion(int majorIncr, int minorIncr, int buildIncr)
    {
        string[] lines = PlayerSettings.bundleVersion.Split('.');

        int MajorVersion = int.Parse(lines[0]) + majorIncr;
        int MinorVersion = int.Parse(lines[1]) + minorIncr;
        int Build = int.Parse(lines[2]) + buildIncr;

        PlayerSettings.bundleVersion = MajorVersion.ToString("0") + "." +
                                       MinorVersion.ToString("0") + "." +
                                       Build.ToString("0");
        PlayerSettings.Android.bundleVersionCode =
             MajorVersion * 10000 + MinorVersion * 1000 + Build;
        CheckCurrentVersion();
    }

    //현재 버전 체크
    [MenuItem("Build/Check Current Version", false, 2)]
    private static void CheckCurrentVersion()
    {
        Debug.Log("Build v" + PlayerSettings.bundleVersion +
             " (" + PlayerSettings.Android.bundleVersionCode + ")"); //현재 버전 표시
    }

    //Major 버전 업
    [MenuItem("Build/Increase Major Version", false, 51)]
    private static void IncreaseMajor()
    {
        string[] lines = PlayerSettings.bundleVersion.Split('.');
        EditVersion(1, -int.Parse(lines[1]), -int.Parse(lines[2]));
    }

    //Minor 버전 업
    [MenuItem("Build/Increase Minor Version", false, 52)]
    private static void IncreaseMinor()
    {
        string[] lines = PlayerSettings.bundleVersion.Split('.');
        EditVersion(0, 1, -int.Parse(lines[2]));
    }
}
