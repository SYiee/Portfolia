using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleColorPicker : MonoBehaviour
{
    public Image circlePalette;
    public Image picker;
    public Color selectedColor;
    public GameObject linkedObject;

    private Vector2 sizeOfPalette;
    private CircleCollider2D paletteCollider;

    private static CircleColorPicker instance = null;
    public static CircleColorPicker Instance
    {
        get
        {
            if (null == instance) instance = FindObjectOfType<CircleColorPicker>();
            return instance;
        }
    }

    private void Awake()
    {
        if (null == instance) instance = this;
    }

    void Start()
    {
        this.gameObject.SetActive(false);

        paletteCollider = circlePalette.GetComponent<CircleCollider2D>();

        sizeOfPalette = new Vector2(
            circlePalette.GetComponent<RectTransform>().rect.width,
            circlePalette.GetComponent<RectTransform>().rect.height);
    }

    public void mousePointerDown()
    {
        selectColor();
    }

    public void mouseDrag()
    {
        selectColor();
    }




    private Color getColor()
    {
        Vector2 circlePalettePosition = circlePalette.transform.position;
        Vector2 pickerPosition = picker.transform.position;

        Vector2 position = pickerPosition - circlePalettePosition + sizeOfPalette * 0.5f;
        Vector2 normalized = new Vector2(
            (position.x / (circlePalette.GetComponent<RectTransform>().rect.width)),
            (position.y / (circlePalette.GetComponent<RectTransform>().rect.height)));

        Texture2D texture = circlePalette.mainTexture as Texture2D;
        Color circularSelectedColor = texture.GetPixelBilinear(normalized.x, normalized.y);

        return circularSelectedColor;
    }
    private float speed = 3f;
    private void selectColor()
    {
        Vector3 offset = Input.mousePosition - transform.position;
        Vector3 diff = Vector3.ClampMagnitude(offset, paletteCollider.radius);

        picker.transform.position = transform.position + diff;

            selectedColor = getColor();
            MeshRenderer[] mesh = linkedObject.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer child in mesh)
            {
            if (offset.magnitude <= paletteCollider.radius)
            {
                child.materials[0].color = selectedColor;
                transform.gameObject.SetActive(false);
                linkedObject = null;
                ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
                MoveBehaviour.Instance.can_move = true;
            }
            }
    
    }


    void Update()
    {
        Vector3 offset = Input.mousePosition - transform.position;
        Vector3 diff = Vector3.ClampMagnitude(offset, paletteCollider.radius);

        if (offset.magnitude > paletteCollider.radius&& Input.GetMouseButton(0))
        {
            linkedObject.GetComponent<Transform>().Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
            //linkedObject.GetComponent<Transform>().Rotate(-Input.GetAxis("Mouse Y") * speed, 0f, 0f);
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            linkedObject.GetComponent<Transform>().position = objPosition;
        }
    }
}