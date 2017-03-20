using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    //AudioSourceが埋め込まれる空のゲームオブジェクト
    private GameObject soundObject;
    //AudioSourceコンポーネント
    public AudioSource audioSource;

    public Sound() {
        //soundObjectを生成します。
        soundObject = new GameObject("EmptySound");
        audioSource = soundObject.AddComponent<AudioSource>();
        soundObject.AddComponent<SoundDestroyer>();
    }
    public Sound(Vector3 pos) {
        //soundObjectを座標posへ生成します。
        soundObject = new GameObject("EmptySound");
        audioSource = soundObject.AddComponent<AudioSource>();
        soundObject.AddComponent<SoundDestroyer>();
        soundObject.transform.position = pos;
    }
    public Sound(Vector3 pos,SE se) {
        //soundObjectを座標posへ生成し、再生させるSEを設定します
        soundObject = new GameObject("EmptySound");
        audioSource = soundObject.AddComponent<AudioSource>();
        soundObject.AddComponent<SoundDestroyer>();
        soundObject.transform.position = pos;
        SetSound(se);
    }
    public Sound(Vector3 pos,BGM bgm) {
        //soundObjectを座標posへ生成し、再生させるBGMを設定します
        soundObject = new GameObject("EmptySoundObject");
        audioSource = soundObject.AddComponent<AudioSource>();
        soundObject.AddComponent<SoundDestroyer>();
        soundObject.transform.position = pos;
        SetSound(bgm);
    }
    public void SetSound(SE se) {
        //再生させるSEを設定する
        audioSource.clip = Resources.Load<AudioClip>("Audio/SE/" + se.ToString());
        soundObject.name = se.ToString();
    }
    public void SetSound(BGM bgm) {
        //再生させるBGMを設定する
        audioSource.clip = Resources.Load<AudioClip>("Audio/BGM/" + bgm.ToString());
        audioSource.loop = true;
        soundObject.name = bgm.ToString();
    }
    public void SetParent(GameObject parent) {
        soundObject.transform.parent = parent.transform;
    }
    public void SetPosition(Vector3 position) {
        soundObject.transform.position = position;
    }
    public Vector3 GetPosition() {
        return soundObject.transform.position;
    }
    
}
