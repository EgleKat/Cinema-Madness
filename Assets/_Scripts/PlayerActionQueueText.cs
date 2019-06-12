using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerActionQueueText : MonoBehaviour
{

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(ServiceStation nextTarget, Queue<ServiceStation> actionQueue)
    {

        string newText = "";

        if (nextTarget != null)
        {
            newText = nextTarget.gameObject.tag + "\n";
        }
        
        foreach (ServiceStation s in actionQueue)
        {
            newText += s.gameObject.tag + "\n";
        }
        text.text = newText;
    }
}
