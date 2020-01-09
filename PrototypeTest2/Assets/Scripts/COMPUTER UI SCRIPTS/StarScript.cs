using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image _Image;

    [SerializeField]
    private Sprite _StarOffSprite;

    [SerializeField]
    private Sprite _StarOnSprite;

    [SerializeField]
    private AudioSource _StarAudioSourceOn;

    [SerializeField]
    private AudioSource _StarAudioSourceOff;

    private bool _StarIsOn=false;

    private void Start()
    {
        _Image.sprite = _StarOffSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_StarIsOn)
        {
            _StarIsOn = true;
            _Image.sprite = _StarOnSprite;
            _StarAudioSourceOn.Play();
        }
        else
        {
            _StarIsOn = false;
            _Image.sprite = _StarOffSprite;
            _StarAudioSourceOff.Play();
        }
        
    }
}
