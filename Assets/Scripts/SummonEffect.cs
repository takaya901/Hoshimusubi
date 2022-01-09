using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 星座が完成したら画面全体を光らせる
/// </summary>
//http://nn-hokuson.hatenablog.com/entry/2017/01/11/215346
public class SummonEffect : MonoBehaviour
{
    Image _img;
	AudioSource _se;
    bool _isFlushStart;

	void Start ()
	{
		_img = GetComponent<Image>();
		_img.color = Color.clear;
		_se = GetComponent<AudioSource>();
	}

	public void Update() 
	{
		if (_isFlushStart){
			_img.color = Color.white;
			_isFlushStart = false;
		}
		else{
			_img.color = Color.Lerp(_img.color, Color.clear, Time.deltaTime / 2f);
		}
	}
	
	public void Play()
	{
		_isFlushStart = true;
		_se.Play();
	}
}