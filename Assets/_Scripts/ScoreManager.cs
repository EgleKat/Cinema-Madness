using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;
    private ScoreText scoreText;

    private Dictionary<PaidItem, int> pricelist = new Dictionary<PaidItem, int>
    {
        {PaidItem.Popcorn, 10}
    };

    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreText>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScoreByObject(PaidItem item)
    {
        int itemValue;
        if (pricelist.TryGetValue(item, out itemValue))
        {
            score += pricelist[item];
            scoreText.SetText(score.ToString());
        }
        else
        {
            Debug.LogError("No paid value for item: " + item);
        }
    }

}
