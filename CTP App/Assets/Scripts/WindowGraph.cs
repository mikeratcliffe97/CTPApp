using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WindowGraph : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    private RectTransform XLabel;
    private RectTransform YLabel;

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
       XLabel = graphContainer.Find("XAxisLabel").GetComponent<RectTransform>();
       YLabel = graphContainer.Find("YAxisLabel").GetComponent<RectTransform>(); 
        List<int> valueList = new List<int>() { 5, 10, 7, 16, 4, 3, 12,  };
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
        rectTransform.sizeDelta = new Vector2(2, 2);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        
        return gameObject;
    }

    private void ShowGraph(List<int> valueList)
    {
        float xSize = 12.5f;
        float yMax = 16f;
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;


        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {

            float xPosition = (i * xSize) + 6;

            if (i == 0)
            {
                xPosition = 5;
            }

            float yPosition = (valueList[i] / yMax) * graphHeight;

            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));

            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);

            }
            lastCircleGameObject = circleGameObject;


            RectTransform labelX = Instantiate(XLabel);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -5f);
           



            switch (i)
            {
                case 0:

                    labelX.GetComponent<TMPro.TMP_Text>().text = "Monday";
                   // labelX.localScale.Set(0.05f, 0.07f, 0.0f);
                    break;
                case 1:
                    labelX.GetComponent<TMPro.TMP_Text>().text = "Tuesday";
                   // labelX.localScale.Set(0.05f, 0.07f, 0.0f);
                    break;

                case 2:
                    labelX.GetComponent<TMPro.TMP_Text>().text = "Wednesday";
                  //  labelX.localScale.Set(0.05f, 0.07f, 0.0f);
                    break;

                case 3:
                    labelX.GetComponent<TMPro.TMP_Text>().text = "Thursday";
                  //  labelX.localScale.Set(0.05f, 0.07f, 0.0f);
                    break;

                case 4:
                    labelX.GetComponent<TMPro.TMP_Text>().text = "Friday";
                 //   labelX.localScale.Set(0.05f, 0.07f, 0.0f);
                    break;

                case 5:
                    labelX.GetComponent<TMPro.TMP_Text>().text = "Saturday";
                 //   labelX.localScale.Set(0.05f, 0.07f, 0.0f);
                    break;

                case 6:
                    labelX.GetComponent<TMPro.TMP_Text>().text = "Sunday";
                  //  labelX.localScale.Set(0.05f, 0.07f, 0.0f);
                    break;
            }


          //  labelX.GetComponent<TMPro.TMP_Text>().fontSize = 40;
        }
            int separatorCount = 10;
            for (int i = 0; i <= separatorCount; i++)
            {
            RectTransform labelY = Instantiate(YLabel);

            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            
            float normalisedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-5f, normalisedValue * graphHeight);
            labelY.GetComponent<TMPro.TMP_Text>().text = Mathf.RoundToInt(normalisedValue * yMax).ToString();
            }
    }
    

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);


        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);

        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;

        dir = dir.normalized;
        float slope = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (slope < 0) slope += 360;



        rectTransform.localEulerAngles = new Vector3(0, 0, slope);

    } 
}
