using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    AudioSource source;
    [SerializeField]
    List<AudioClip> clips = new List<AudioClip>();
    [SerializeField]
    List<float> musicLenghts = new List<float>();
    int musicAmount;

    void Start()
    {
        source = GetComponent<AudioSource>();

        AudioClip clip;
        bool result = true;
        int count = 0;
        while(result)
        {
            ++count;
            clip = Resources.Load<AudioClip>("Sounds/" + count.ToString());
            if(clip == null) break;
            clips.Add(clip);
            musicLenghts.Add(clip.length);
        }
        musicAmount = clips.Count;  
        
        fillBar.fillMethod = Image.FillMethod.Horizontal;
        fillBar.fillAmount = 0;

        SetMusic(0);
    }
    IEnumerator PlayMusic()
    {
        while(source.isPlaying)
        {
            MusicPlayBarUpdate();
            yield return new WaitForSeconds(0.05f);
        }
    }

    int _current = 0;
    int currentMusicNumber
    {
        get { return _current; }
        set
        {
            if (isSuffle)
            {
                int rand = _current;
                while(rand == _current)     //현재와 다른음악이 나올 때까지 셔플함
                {
                    rand = Random.Range(0, musicAmount);
                }
                _current = rand;
            }
            else _current = value;
            
            if (_current < 0)
            {
                _current = 0;
            }
            if (_current >= musicAmount)
            {
                _current %= musicAmount;
            }
            source.clip = clips[_current];

            if (isPause) return;

            Play();
        }
    }
    public void SetMusic(int number)
    {
        currentMusicNumber = number;
    }

    public void Play()
    {
        source.Play();
        playButtonImage.sprite = pauseSprite;
        StartCoroutine(PlayMusic());
    }

    [SerializeField]
    Sprite playSprite;
    [SerializeField]
    Sprite pauseSprite;

    [SerializeField]
    Image playButtonImage;

    [SerializeField]
    bool isPause = true;
  
    public void DoPause()
    {
        isPause = !isPause;

        if (isPause) Pause();
        else Play();
    }

    public void Pause()
    {
        source.Pause();
        playButtonImage.sprite = playSprite;
    }
    public void SetLoop()
    {
        source.loop = !source.loop;
    }

    [SerializeField]
    bool isSuffle = false;
    public void SetShuffle()
    {
        isSuffle = !isSuffle;
    }

    public void PrevMusic()
    {
        --currentMusicNumber;
    }
    public void NextMusic()
    {
        ++currentMusicNumber;
    }

    [SerializeField]
    Image fillBar;
    [SerializeField]
    Scrollbar playScrollBar;
    void MusicPlayBarUpdate()
    {
        float value = source.time / musicLenghts[currentMusicNumber];
        if(value >= 1f)
        {
            NextMusic();
            return;
        }

        fillBar.fillAmount = value;
        playScrollBar.value = value;
    }
}
