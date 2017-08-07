using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Android
{
    private static AndroidJavaObject _ca;
    private static AndroidJavaObject _co;

    public static AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity =>
        _ca ?? (_ca = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"));
    public static AndroidJavaObject context =>
        _co ?? (_co = currentActivity.Call<AndroidJavaObject>("getApplicationContext"));

    public class Toast
    {
        private const string packageName = "android.widget.Toast";
        private static AndroidJavaClass package = new AndroidJavaClass(packageName);
        public static int LENGTH_LONG => package.GetStatic<int>(nameof(LENGTH_LONG));
        public static int LENGTH_SHORT => package.GetStatic<int>(nameof(LENGTH_SHORT));

        private AndroidJavaObject self;
        private Toast() { }
        public Toast(AndroidJavaObject context)
        {
            self = new AndroidJavaObject(packageName, context);
        }
        public static Toast makeText(AndroidJavaObject context, string text, int duration) => new Toast()
        {
            self = package.CallStatic<AndroidJavaObject>(nameof(makeText), context, text, duration)
        };
       
        public void setText(string s) => self.Call(nameof(setText), s);
        public void setDuration(int duration) => self.Call(nameof(setDuration), duration);
        public void show() => self.Call(nameof(show));
        public void cancel() => self.Call(nameof(cancel));
    }
    public static class AudioManager
    {
        public const int STREAM_MUSIC = 3;
        private static AndroidJavaObject _am;
        private static AndroidJavaObject package =>
            _am ?? (_am = currentActivity.Call<AndroidJavaObject>("getSystemService", "audio"));

        public static int getStreamMaxVolume(int streamType) => package.Call<int>(nameof(getStreamMaxVolume), streamType);
        public static int getStreamVolume(int streamType) => package.Call<int>(nameof(getStreamVolume), streamType);
    }
}