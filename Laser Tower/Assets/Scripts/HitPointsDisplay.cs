using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitPointsDisplay : MonoBehaviour
{

    TextMeshProUGUI HPText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        HPText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = player.GetHealth().ToString();
    }
}
