using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public List<Sprite> avatars;
    public SpriteRenderer sRenderer;
    public CharacterData data;

    private int index = 0;

    // Start is called before the first frame update
    void Start() {
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.sprite = avatars[0];
    }

    // Update is called once per frame
    void Update() {

        if(Input.GetKeyDown(KeyCode.X)) {
            sRenderer.sprite = avatars[(++index) % avatars.Count];
        }
        Debug.Log("Stresslevel: " + data.stressLevel);
        sRenderer.sprite = data.GetExprByStressLvl(data.stressLevel);

    }
}
