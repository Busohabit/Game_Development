using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class UIButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private TextMeshProUGUI buttonText;
    private Color originalColor;
    public Color hoverColor = Color.red;
    public float hoverOffset = 5f;
    public float lerpSpeed = 5f;

    private Vector3 originalPosition;
    private Vector3 hoveredPosition;

    private bool isHovered = false;
    public bool canHover = false;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        button = GetComponent<Button>();
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

        originalColor = buttonText.color;

        originalPosition = transform.localPosition;
        hoveredPosition = originalPosition + new Vector3(hoverOffset, 0f, 0f);
    }

    private void OnDisable()
    {
        DisableHover();
    }

    void Update()
    {
        if (isHovered && canHover)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, hoveredPosition, lerpSpeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, lerpSpeed * Time.deltaTime);
        }

        if (IsController())
        {
            if (EventSystem.current.currentSelectedGameObject == gameObject && canHover)
            {
                EnableHover();
            }
            else
            {
                DisableHover();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EnableHover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DisableHover();
    }

    private bool IsController()
    {
        bool usingController = false;

        foreach (var device in InputSystem.devices)
        {
            if (device is Gamepad || device is Joystick)
            {
                usingController = true;
                break;
            }
        }

        return usingController;
    }

    private void EnableHover()
    {
        isHovered = true;
        buttonText.color = hoverColor;
        audioSource.Play();
    }

    private void DisableHover()
    {
        isHovered = false;
        buttonText.color = originalColor;
    }
}
