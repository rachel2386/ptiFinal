using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFood : MonoBehaviour
{
    private Camera myCam;
    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
