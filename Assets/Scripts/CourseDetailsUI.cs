using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CourseDetailsUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _courseText;

    public static CourseDetailsUI instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public CourseDetailsUI()
    {

    }

    public void UpdateCourseDetails (CourseDetails course)
    {
        _courseText.text = course.grade + ": " + course.domain + "<br>" + course.cluster + "<br>" + course.standarddescription;
    }
}
