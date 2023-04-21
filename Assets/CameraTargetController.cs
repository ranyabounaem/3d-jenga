using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{
    List<Stack> _stacks = new List<Stack>();
    private int _currentStackIndex = 0;

    public void Setup(List<Stack> stack)
    {
        _stacks = stack;
        var __stackPosition = _stacks[_currentStackIndex].transform.position;
        transform.position = new Vector3(__stackPosition.x, __stackPosition.y + 5, __stackPosition.z);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * 250, 0);
            Debug.Log("Rotating");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _currentStackIndex++;
            if (_currentStackIndex == _stacks.Count)
            {
                _currentStackIndex = 0;
            }
            var __stackPosition = _stacks[_currentStackIndex].transform.position;
            transform.position = new Vector3(__stackPosition.x, __stackPosition.y + 5, __stackPosition.z);
        }
    }
}
