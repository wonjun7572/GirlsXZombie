using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ToggleSwitch : MonoBehaviour , IPointerDownHandler
{
    [SerializeField]
    private bool _isOn = true;

    private bool OnOff = true;

    /// <summary>
    /// 다른 스크립트에서도 변경없이 사용할수 있게끔 함
    /// </summary>
    public bool isOn
    {
        get
        {
            return _isOn;
        }
    }

    [SerializeField]
    private RectTransform toggleIndicator;
    [SerializeField]
    private Image backgroundImage;

    [SerializeField]
    private Color onColor;
    [SerializeField]
    private Color offColor;
    private float onX;
    private float offX;
    [SerializeField]
    private float tweenTime = 0.25f;

    private AudioSource audioSource;

    public delegate void ValueChanged(bool value);
    public event ValueChanged valueChanged;

    // Start is called before the first frame update
    void Start()
    {
        onX = toggleIndicator.anchoredPosition.x;
        offX = backgroundImage.rectTransform.rect.width - toggleIndicator.rect.width + toggleIndicator.anchoredPosition.x;
        audioSource = this.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Toggle(isOn);
        Debug.Log("처음 상태");
    }

    private void Toggle(bool value, bool playSFX = true)
    {
        if(value != isOn)
        {
            _isOn = value;

            ToggleColor(isOn);
            MoveIndicator(isOn);

            if (playSFX)
                audioSource.Play();

            if (valueChanged != null)
                valueChanged(isOn);

            //Debug.Log("2");
        }
    }

    private void ToggleColor(bool value)
    {
        if (value)
            backgroundImage.DOColor(onColor, tweenTime);
        else
            backgroundImage.DOColor(offColor, tweenTime);
    }

    private void MoveIndicator(bool value)
    {
        if (value)
            toggleIndicator.DOAnchorPosX(onX, tweenTime);
        else
            toggleIndicator.DOAnchorPosX(offX, tweenTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Toggle(!isOn);

        if (OnOff == true)
        {
            Debug.Log("오프 상태로 변경");
            TileBehavior.instance.mergePossible = false;
            OnOff = false;
        }
        
        else
        {
            Debug.Log("온 상태로 변경");
            TileBehavior.instance.mergePossible = true;
            OnOff = true;
        }
        
    }
}
