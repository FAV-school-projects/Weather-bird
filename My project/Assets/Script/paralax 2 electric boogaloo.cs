using UnityEngine;

public class Thegroundoftheback : MonoBehaviour
{
    private MeshRenderer mushRundurur;
    public float lexLuthor = 1f;

    private void Awake()
    {
        mushRundurur = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        mushRundurur.material.mainTextureOffset += new Vector2(lexLuthor * Time.deltaTime, 0);
    }
}
