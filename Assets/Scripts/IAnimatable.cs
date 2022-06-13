using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public interface IAnimatable
{
    Task Show();
    Task Hide();
}
