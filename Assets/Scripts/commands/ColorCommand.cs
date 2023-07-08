using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCommand : Command
{
    Color newColor;

    public ColorCommand(Color newColor, float actionTime): base(actionTime)
    { 
        this.newColor = newColor;
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
