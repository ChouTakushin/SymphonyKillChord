using UnityEngine;

public class BoxCastNonAllocExample : MonoBehaviour
{
    // ボックスキャストのパラメータ
    public Vector3 boxCenter = Vector3.zero;
    public Vector3 boxHalfExtents = new Vector3(1f, 1f, 1f);
    public Vector3 castDirection = Vector3.forward;
    public float maxDistance = 10f;
    public Quaternion orientation = Quaternion.identity;
    public LayerMask layerMask;

    // 結果を格納するための配列を事前に用意しておく
    private RaycastHit[] results = new RaycastHit[10];

    void Update()
    {
        // BoxCastNonAlloc は、指定した配列にヒット情報を書き込み、書き込まれた数を返す
        int hitCount = Physics.BoxCastNonAlloc(
            boxCenter,
            boxHalfExtents,
            castDirection,
            results,
            orientation,
            maxDistance,
            layerMask
        );

        Debug.Log($"BoxCastNonAlloc hits count: {hitCount}");

        // 実際のヒット情報は配列resultsの先頭からhitCount分だけ有効
        for (int i = 0; i < hitCount; i++)
        {
            RaycastHit hit = results[i];
            Debug.Log($"Hit object: {hit.collider.name} at distance: {hit.distance}");
        }
    }
}