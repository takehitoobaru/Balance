using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 落下位置を示すライン
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class FallLine : MonoBehaviour
{
    #region serialize
    [Tooltip("横幅")]
    [SerializeField]
    private float _width = 0.1f;

    [Tooltip("長さ")]
    [SerializeField]
    private float _endPos = -3.0f;
    #endregion

    #region private
    /// <summary>頂点数</summary>
    private int _vertexCount = 2;
    /// <summary>ラインレンダラー</summary>
    private LineRenderer _renderer;
    #endregion

    #region unity methods
    private void Awake()
    {
        _renderer = GetComponent<LineRenderer>();
        _renderer.startWidth = _width;
        _renderer.endWidth = _width;
        _renderer.positionCount = 2;
        _renderer.SetPosition(0,transform.position);
        _renderer.SetPosition(1, new Vector2(transform.position.x, _endPos));
    }

    private void Update()
    {
        _renderer.SetPosition(0, transform.position);
        _renderer.SetPosition(1, new Vector2(transform.position.x, _endPos));
    }
    #endregion
}
