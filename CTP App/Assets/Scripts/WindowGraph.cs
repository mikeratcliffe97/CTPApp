using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
      
        List<int> valueList = new List<int>() { 5, 10, 19, 22, 40, 66, 70,  };
        ShowGraph(valueList);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(3, 3);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return gameObject;
    }

    private void ShowGraph(List<int> valueList)
    {
        float xSize = 10f;
        float yMax = 100f;
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;


        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = (i * xSize) + xSize;
            float yPosition = (valueList[i] / yMax) * graphHeight;
          GameObject circleGameObject =  CreateCircle(new Vector2(xPosition, yPosition));

            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);

            }
            lastCircleGameObject = circleGameObject;
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);


        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);

        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(50, 3f);
        rectTransform.anchoredPosition = dotPositionA;

        rectTransform.localEulerAngles = new Vector3(0, 0, 0);//work out angle);


    } 
}
