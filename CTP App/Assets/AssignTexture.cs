using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AssignTexture : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]
    private AvatarManager mainAvatar;


    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
        this.GetComponent<RawImage>().texture = mainAvatar.GetComponent<RawImage>().texture;
        
    }
}
