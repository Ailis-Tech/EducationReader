// Copyright (c) 2025 Ailis-Tech
// SPDX-License-Identifier: MIT

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
    private static System.Media.SoundPlayer _player;
    private static MemoryStream _playerStream;

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
        try
        {
            // リソースからストリーム取得
            Stream stream = EducationReader.Properties.Resources.ResourceManager.GetStream(voiceName);
            if (stream == null)
            {
                System.Diagnostics.Debug.WriteLine($"Resource not found: {voiceName}");
                return;
            }

            // 既存の再生を止めてストリーム破棄
            _player?.Stop();
            _playerStream?.Dispose();

            // ストリームを MemoryStream にコピーして保持（Seek可能にするため）
            _playerStream = new MemoryStream();
            stream.CopyTo(_playerStream);
            _playerStream.Position = 0;

            _player = new System.Media.SoundPlayer(_playerStream);
            _player.Play(); // 非同期再生。オブジェクトを保持することで GC による停止を防ぐ
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("playVoice error: " + ex);
        }
    }
}