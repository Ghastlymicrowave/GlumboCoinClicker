using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneScroll : PhoneElement
{
    [SerializeField] Vector2 inputMultiplier;
    Vector2 targetOffset = Vector2.zero;
    Vector2 currentOffset = Vector2.zero;
    [SerializeField] Transform imageContainer;

    void Start(){
        targetOffset = imageContainer.transform.position;
        currentOffset = imageContainer.transform.position;
    }
    public override void OnDrag(Vector2 relativeOffset)
    {
        targetOffset += relativeOffset * inputMultiplier;
    }

    void UpdateOffset(){
        imageContainer.transform.position = new Vector3(currentOffset.x,currentOffset.y,imageContainer.transform.position.z);
    }

    void Update(){
        currentOffset = Vector2.Lerp(currentOffset,targetOffset,0.1f);
        if(Vector2.Distance(currentOffset,targetOffset)<0.01f && currentOffset!=targetOffset){
            currentOffset = targetOffset;
            UpdateOffset();
        }else{
            UpdateOffset();
        }
    }
}
