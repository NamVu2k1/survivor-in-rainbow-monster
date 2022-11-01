using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    public static Ground _instance;
    public SpriteRenderer ground;
    Color ColorGround;
    private void Awake()
    {
        _instance = this;
        ColorGround = ground.color;

    }
  
    public void RedGround()
    {
        ground.DOColor(new Color(1, 0.57f, 0.43f,1),0.5f).SetEase(Ease.OutQuart);
    }
    public void GreenGround()
    {
        ground.color = new Color(0.74f, 1, 0.53f, 1);
        ground.DOColor(ColorGround, 1.5f).SetEase(Ease.OutQuad);
        
    }
}
