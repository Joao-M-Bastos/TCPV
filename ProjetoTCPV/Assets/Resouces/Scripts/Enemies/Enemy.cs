using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{
    public void GotHit(float value);

    public void SetTarget(Transform value);
}
