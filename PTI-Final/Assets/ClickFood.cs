using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFood : MonoBehaviour
{
    private Camera myCam;

    public List<GameObject> foodList;
    public List<string> keyList;

    public GameObject Course2;
    public GameObject Course1;

    public CanvasGroup like;
    private bool DoLike;
    
    private List<bool> toogle = new List<bool>();

    public GameObject chat;
    
    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;

        for (int i = 0; i < foodList.Count; i++)
        {
            toogle.Add(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            Course2.SetActive(true);
            Course1.SetActive(false);
        }
        
        if (Input.GetKeyDown("9"))
                {
                    chat.transform.position += new Vector3(0, 68, 0);
                }

        if (Input.GetKeyDown("space"))
        {
            like.alpha = 1;
            DoLike = true;
        }

        if (DoLike)
        {
            like.alpha -= Time.deltaTime;

            if (like.alpha < 0)
            {
                DoLike = false;
            }
            
        }
        
        //using mouse
       if(Input.GetMouseButtonDown(0))
       {
           Ray myRay = myCam.ScreenPointToRay(Input.mousePosition);
           RaycastHit hitInfo = new RaycastHit();
           
          if(Physics.Raycast(myRay, out hitInfo))
              if (hitInfo.collider != null)
              {
                  if (hitInfo.collider.CompareTag("food"))
                  {
                      GameObject foodClicked = hitInfo.collider.gameObject;
                      foodClicked.SetActive(false);
                  }
              }
       }

       //using keyboard
       for (int i = 0; i < foodList.Count; i++)
       {
           if (Input.GetKeyDown(keyList[i]))
           {
               
               foodList[i].SetActive(toogle[i]);
               toogle[i] = !toogle[i];
           }
        
       }
       
       
    }
}
