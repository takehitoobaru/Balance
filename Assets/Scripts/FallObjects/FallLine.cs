using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class FallLine : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    [Tooltip("â°ïù")]
    [SerializeField]
    private float _width = 0.1f;

    [Tooltip("í∑Ç≥")]
    [SerializeField]
    private float _endPos = -3.0f;
    #endregion

    #region private
    private int _vertexCount = 2;
    private LineRenderer _renderer;
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Awake()
    {
        _renderer = GetComponent<LineRenderer>();
        _renderer.SetWidth(_width, _width);
        _renderer.SetVertexCount(_vertexCount);
        _renderer.SetPosition(0,transform.position);
        _renderer.SetPosition(1, new Vector2(transform.position.x, _endPos));
    }

    private void Start()
    {

    }

    private void Update()
    {
        _renderer.SetPosition(0, transform.position);
        _renderer.SetPosition(1, new Vector2(transform.position.x, _endPos));
    }
    #endregion

    #region public method
    #endregion

    #region private method
    #endregion
}
