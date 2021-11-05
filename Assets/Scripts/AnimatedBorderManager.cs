using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedBorderManager : MonoBehaviour
{
    GameObject border;
    Canvas borderCanvas;
    CanvasScaler canvasScaler;
    GameObject borderElement;
    public Sprite borderSprite;
    int ratio;

    void Awake()
    {
        GenerateCanvas();
    }
    // Start is called before the first frame update
    void Start()
    {
        ratio = GetRatio();
        GenerateBorder(ratio);
    }

    // Update is called once per frame
    void Update()
    {
        if (ratio != GetRatio())
        {
            Destroy(border);
            GenerateCanvas();
            ratio = GetRatio();
            GenerateBorder(ratio);
        }
    }

    public int GetRatio()
    {
        if (Camera.main.aspect > 2.1) {
            return 7;
        }

        else if (Camera.main.aspect > 1.7) {
            return 9;
        }

        return 12;
    }

    private void GenerateCanvas()
    {
        border = new GameObject();
        border.name = "Border";
        borderCanvas = border.AddComponent<Canvas>();
        borderCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        borderCanvas.sortingOrder = 1;
        canvasScaler = border.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(1000, 800);
    }

    private GameObject GenerateBorderSprite(int number, string position)
    {
        //borderElement = Instantiate(sprite);
        borderElement = new GameObject();
        borderElement.name = "Border" + position + number;
        Image borderImage = borderElement.AddComponent<Image>();
        borderImage.sprite = borderSprite;
        Animator borderAnimator = borderElement.AddComponent<Animator>();
        borderAnimator.runtimeAnimatorController = Resources.Load("Border") as RuntimeAnimatorController;
        return borderElement;
    }
    private void GenerateBottom()
    {
        GameObject[] elements = new GameObject[16];
        RectTransform elementTransform;
        Vector2 position = new Vector2(20, 20);
        Vector2 anchor = new Vector2(0, 0);
        Vector2 size = new Vector2(40, 40);
        for (int i = 0; i < 16; i++) {
            elements[i] = GenerateBorderSprite(i, "BL");
            elements[i].transform.SetParent(border.transform);
            elementTransform = elements[i].GetComponent<Image>().GetComponent<RectTransform>();
            elementTransform.anchoredPosition = position;
            elementTransform.anchorMin = anchor;
            elementTransform.anchorMax = anchor;
            elementTransform.sizeDelta = size;
            position += new Vector2(60, 0);
        }
    }
    private void GenerateTop()
    {
        GameObject[] elements = new GameObject[16];
        RectTransform elementTransform;
        Vector2 position = new Vector2(-20, -20);
        Vector2 anchor = new Vector2(1, 1);
        Vector2 size = new Vector2(40, 40);
        for (int i = 0; i < 16; i++) {
            elements[i] = GenerateBorderSprite(i, "BL");
            elements[i].transform.SetParent(border.transform);
            elementTransform = elements[i].GetComponent<Image>().GetComponent<RectTransform>();
            elementTransform.anchoredPosition = position;
            elementTransform.anchorMin = anchor;
            elementTransform.anchorMax = anchor;
            elementTransform.sizeDelta = size;
            position -= new Vector2(60, 0);
        }
    }
    private void GenerateLeft(int ratio)
    {
        GameObject[] elements = new GameObject[ratio];
        RectTransform elementTransform;
        Vector2 position = new Vector2(20, -20);
        Vector2 anchor = new Vector2(0, 1);
        Vector2 size = new Vector2(40, 40);
        for (int i = 0; i < ratio; i++) {
            elements[i] = GenerateBorderSprite(i, "BL");
            elements[i].transform.SetParent(border.transform);
            elementTransform = elements[i].GetComponent<Image>().GetComponent<RectTransform>();
            elementTransform.anchoredPosition = position;
            elementTransform.anchorMin = anchor;
            elementTransform.anchorMax = anchor;
            elementTransform.sizeDelta = size;
            position -= new Vector2(0, 60);
        }
    }

    private void GenerateRight(int ratio)
    {
        GameObject[] elements = new GameObject[ratio];
        RectTransform elementTransform;
        Vector2 position = new Vector2(-20, 20);
        Vector2 anchor = new Vector2(1, 0);
        Vector2 size = new Vector2(40, 40);
        for (int i = 0; i < ratio; i++) {
            elements[i] = GenerateBorderSprite(i, "BL");
            elements[i].transform.SetParent(border.transform);
            elementTransform = elements[i].GetComponent<Image>().GetComponent<RectTransform>();
            elementTransform.anchoredPosition = position;
            elementTransform.anchorMin = anchor;
            elementTransform.anchorMax = anchor;
            elementTransform.sizeDelta = size;
            position += new Vector2(0, 60);
        }
    }

    private void GenerateBorder(int ratio)
    {
        GenerateBottom();
        GenerateTop();
        GenerateLeft(ratio);
        GenerateRight(ratio);
    }
}
