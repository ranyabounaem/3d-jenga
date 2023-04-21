using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private GameObject _block;

    private List<CourseDetails> _courses;
    private List<Block> _blocks = new List<Block>();

    public void Setup()
    {
        _courses = new List<CourseDetails>();
    }

    public bool CanAddCourse()
    {
        return _courses.Count < 3;
    }

    public void AddCourse(CourseDetails course)
    {
        _courses.Add(course);
        var __blockObject = Instantiate(_block, transform);
        __blockObject.transform.Translate(new Vector3(0, 0, 1.5f * _courses.Count - 1));
        var __block = __blockObject.GetComponent<Block>();
        __block.Setup(course);
        _blocks.Add(__block);
    }

    public List<Block> GetBlocks()
    {
        return _blocks;
    }
}
