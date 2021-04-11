using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicNavigation : MonoBehaviour
{
	[SerializeField] private int playingID;
	private AudioSource audiosource;
	public AudioClip[] musicList;

	[Space(10)]

	public Text musicName;

	void Start ()
	{
		playingID = 0;
		audiosource = GetComponent<AudioSource>();
		audiosource.clip = musicList[0];
		audiosource.Play();
		musicName.text = audiosource.clip.name;
	}

	public void ChangeMusic(bool next)
	{
		print(musicList.Length);
		print(playingID);

		audiosource.Stop();

		if (next)
		{
			if(playingID == musicList.Length - 1)
				playingID = 0;
			else
				playingID += 1;
			
		}
		else //previous
		{
			if (playingID == 0)
				playingID = musicList.Length -1;
			else
				playingID -= 1;
		}

		audiosource.clip = musicList[playingID];
		audiosource.Play();

		musicName.text = audiosource.clip.name;
	}
}
