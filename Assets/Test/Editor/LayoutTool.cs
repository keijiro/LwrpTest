using UnityEngine;
using UnityEditor;

static class LayoutTool
{
    [MenuItem("GameObject/Sphere Lattice")]
    static void SphereLattice()
    {
        const int width = 16;

        var root = new GameObject("Lattice");

        for (var i = 0; i < width; i++)
        {
            var layer = new GameObject("Layer " + i);
            layer.transform.parent = root.transform;
            layer.transform.localPosition = Vector3.forward * (i - width / 2 + 0.5f);

            for (var j = 0; j < width; j++)
            {
                var row = new GameObject("Cow " + j);
                row.transform.parent = layer.transform;
                row.transform.localPosition = Vector3.up * (j - width / 2 + 0.5f);

                for (var k = 0; k < width; k++)
                {
                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Object.DestroyImmediate(cube.GetComponent<BoxCollider>());
                    cube.name = "Cube " + k;
                    cube.transform.parent = row.transform;
                    cube.transform.localPosition = Vector3.right * (k - width / 2 + 0.5f);
                    cube.transform.localScale = Vector3.one * 0.2f;
                }
            }
        }
    }
}
