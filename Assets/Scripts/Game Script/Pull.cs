﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : Gravity
{

    public override Vector3 Calculate(Vector3 direction, float force)
    {
        return (-1 * direction.normalized) * force;
    }

}
