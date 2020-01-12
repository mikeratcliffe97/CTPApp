using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WindowGraph : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Sprite dotSprite;
    private RectTransform graphContainer;
    //public PopulateGraph filler;
    private RectTransform XLabel;
    private RectTransform YLabel;
    public bool bar = false;
    private List<GameObject> gameObjectList;
    private Button BarButton;
    private Button LineButton;


    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        XLabel = graphContainer.Find("XAxisLabel").GetComponent<RectTransform>();
        YLabel = graphContainer.Find("YAxisLabel").GetComponent<RectTransform>();

        BarButton = GameObject.Find("BarButton").GetComponent<Button>();
        BarButton.onClick.AddListener(delegate { bar = true; });

        LineButton = GameObject.Find("LineButton").GetComponent<Button>();
        LineButton.onClick.AddListener(delegate { bar = false; }) ;

        gameObjectList = new List<GameObject>();
        //  List<int> valueList = new List<int>() { 5, 10, 7, 16, 4, 3, 12,  };
        // ShowGraph(valueList);

    }


    private GameObject CreateDot(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("dot", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = dotSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(2, 2);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);


        return gameObject;
    }

    public void ShowGraph(List<int> valueList)
    {

        float xSize = 12.5f;
        float yMax = 16f;
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;

        foreach (GameObject gameObject in gameObjectList)
        {
            Destroy(gameObject);
        }
        gameObjectList.Clear();
          GameObject lastDotGameObject = null;

        for (int i = 0; i < valueList.Count; i++)
        {

            float xPosition = (i * xSize) + 6;

            if (i == 0)
            {
                xPosition = 5;
            }

            float yPosition = (valueList[i] / yMax) * graphHeight;
            if (bar)
            {
                GameObject barGameObject = CreateBar(new Vector2(xPosition, yPosition), xSize * 0.9f);
                gameObjectList.Add(barGameObject);

            }

            else
            {
                GameObject dotGameObject = CreateDot(new Vector2(xPosition, yPosition));
                gameObjectList.Add(dotGameObject);
                if (lastDotGameObject != null)
                {
                    GameObject dotConnectionGameObject = CreateDotConnection(lastDotGameObject.GetComponent<RectTransform>().anchoredPosition, dotGameObject.GetComponent<RectTransform>().anchoredPosition);
                    gameObjectList.Add(dotConnectionGameObject);
                }
                lastDotGameObject = dotGameObject;
            }   

            RectTransform labelX = Instantiate(XLabel);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -2f);
                gameObjectList.Add(labelX.gameObject);

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
            labelY.anchoredPosition = new Vector2(-2f, normalisedValue * graphHeight);
            labelY.GetComponent<TMPro.TMP_Text>().text = Mathf.RoundToInt(normalisedValue * yMax).ToString();
                gameObjectList.Add(labelY.gameObject);
        }

           
            Debug.Log(gameObjectList.ToString());
    


    }


    private GameObject CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
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
        return gameObject;
    }


    private GameObject CreateBar(Vector2 graphPosition, float barWidth)
   
    {

        GameObject gameObject = new GameObject("bar", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = dotSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(graphPosition.x + 2f, 0f);
       
        rectTransform.sizeDelta = new Vector2(barWidth, graphPosition.y);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(.5f, 0f);


        return gameObject;


    }




}