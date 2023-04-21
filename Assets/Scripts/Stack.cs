using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private int _index;
    private string _stackName;
    [SerializeField]
    private GameObject _level;
    private List<CourseDetails> _courses;
    private List<Level> _levels = new List<Level>();

    [SerializeField]
    private TextMeshProUGUI _gradeText;

    public void Setup(int index, string name, List<CourseDetails> courses)
    {
        _gradeText.text = name;
        _index = index;
        _stackName = name;
        var __orderedCourses = courses.OrderBy(x => x.domain).ThenBy(x => x.cluster).ThenBy(x => x.standardid).ToList();
        _courses = __orderedCourses;

        var __levelObject = Instantiate(_level, transform.position, Quaternion.identity, transform);
        var __currentLevel = __levelObject.GetComponent<Level>();
        var __currentLevelIndex = 0;
        __currentLevel.Setup();
        _levels.Add(__currentLevel);
        for (var __i = 0; __i < _courses.Count; __i++)
        {
            if (!__currentLevel.CanAddCourse())
            {
                __currentLevelIndex++;
                if (__currentLevelIndex % 2 != 0)
                {
                    __levelObject = Instantiate(_level, transform);
                    __levelObject.transform.Translate(-2f, __currentLevelIndex, 2f);
                    __levelObject.transform.Rotate(new Vector3(0, 1, 0), 90);
                }
                else
                {
                    __levelObject = Instantiate(_level, transform);
                    __levelObject.transform.Translate(0, __currentLevelIndex, 0);
                }
                __currentLevel = __levelObject.GetComponent<Level>();
                __currentLevel.Setup();
                _levels.Add(__currentLevel);
            }
            __currentLevel.AddCourse(_courses[__i]);
        }
    }

    public List<Level> GetLevels()
    {
        return _levels;
    }
}
