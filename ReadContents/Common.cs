using System;
using System.IO;

public class CommonConst
{
    public readonly int BTN_HEIGHT = 100;
    public readonly int BTN_WIDTH = 100;
    public readonly int BTN_SPACE = 10;
    public readonly int PICT_HEIGHT = 80;
    public readonly int PICT_WIDTH = 80;
    public readonly float TXT_SIZE = 35f;
}
public class Common
{
    public static string getMediaDirectory(string dirName)
    {
        string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // 親ディレクトリ（存在しない場合は null になる）
        string parentDirectory = Directory.GetParent(executableDirectory)?.FullName;

        // さらに親（存在しない場合は null）
        string grandParentDirectory = Directory.GetParent(parentDirectory ?? string.Empty)?.FullName;

        // さらに親（存在しない場合は null）
        string greatGrandParentDirectory = Directory.GetParent(grandParentDirectory ?? string.Empty)?.FullName;

        // 最終的なメディアディレクトリ。存在しない親はフォールバックする
        string mediaDirectory = Path.Combine(
            greatGrandParentDirectory ?? grandParentDirectory ?? parentDirectory ?? executableDirectory,
            dirName
        );

        return mediaDirectory;
    }

    public static void playVoice(string voiceName)
    {
        // リソースから音声ストリームを取得
        Stream stream = ReadContents.Properties.Resources.ResourceManager.GetStream(voiceName);

        // サウンドプレイヤーで再生
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(stream);
        player?.Play();
    }
}