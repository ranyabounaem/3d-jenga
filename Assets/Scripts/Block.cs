using UnityEngine;

public class Block : MonoBehaviour
{
    private CourseDetails _course;
    [SerializeField]
    Material _glass;
    [SerializeField]
    Material _wood;
    [SerializeField]
    Material _stone;

    public void OnMouseOver()
    {
        CourseDetailsUI.instance.UpdateCourseDetails(_course);
    }

    public void Setup(CourseDetails course)
    {
        _course = course;
        var _renderer = GetComponent<Renderer>();
        switch (_course.mastery)
        {
            case 0:
                _renderer.material = _glass;
                break;
            case 1:
                _renderer.material = _wood;
                break;
            case 2:
                _renderer.material = _stone;
                break;
        }
    }
    
    public CourseDetails GetCourse()
    {
        return _course;
    }
}
