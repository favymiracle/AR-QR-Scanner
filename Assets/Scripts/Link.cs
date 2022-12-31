using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Link : MonoBehaviour
{
    public Camera Main;

    [DllImport("__Internal")]
    private static extern void OpenNewTab(string url);

    public void openIt(string url)
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            OpenNewTab(url);
        #endif
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                bool hit = Physics.Raycast(Main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hitInfo.transform.tag == "LinkIcon")
                {
                    //openIt("www." + hitInfo.transform.name + ".com");
                    Application.OpenURL("http://" + hitInfo.transform.name + ".com");
                }
            }
        }
    }
}
