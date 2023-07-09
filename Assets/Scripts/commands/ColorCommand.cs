using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCommand : Command
{
    Color newColor;

    void Init(Color newColor)
    { 
        this.newColor = newColor;
    }

    public static ColorCommand New(Color newColor, float actionTime)
    {
        ColorCommand instance = ScriptableObject.CreateInstance<ColorCommand>();
        instance.Init(newColor);
        instance.actionTime = actionTime;
        return instance;
    }

    public override IEnumerator Execute(Robot r)
    {
        float currentFade = 0;
        Material m = r.gameObject.GetComponent<MeshRenderer>().material;
        Color currentColor = m.color;
        if(m.color == newColor)
            yield break;
        while (currentFade < actionTime)
        {
           // Debug.Log("color: " + currentFade);
            currentFade += Time.deltaTime ;
            m.color = Color.Lerp(currentColor, newColor, currentFade/actionTime);
            yield return null;
        }
    }
}
