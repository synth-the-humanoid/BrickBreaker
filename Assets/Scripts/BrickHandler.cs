using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BrickHandler : MonoBehaviour
{
    [SerializeField]
    public BrickType BrickType;
    private int health;
    private Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        health = (int)BrickType + 1;
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        r.material = GetMaterial();
    }

    void OnCollisionEnter(Collision collision)
    {
        health -= 1;
        switch (health)
        {
            case 2:
                BrickType = BrickType.MEDIUM;
                break;
            case 1:
                BrickType = BrickType.WEAK;
                break;
            default:
                Destroy(gameObject);
                return;
        }
    }

    private Material GetMaterial()
    {
        string assetPath = "";
        switch (BrickType)
        {
            case BrickType.WEAK:
                assetPath = "EnemyBrickWeak";
                break;
            case BrickType.MEDIUM:
                assetPath = "EnemyBrickMedium";
                break;
            case BrickType.STRONG:
                assetPath = "EnemyBrickStrong";
                break;
            default:
                return null;
        }
        return Resources.Load<Material>(assetPath);
    }
}
