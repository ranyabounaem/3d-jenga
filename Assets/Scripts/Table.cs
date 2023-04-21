using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Table : MonoBehaviour
{
    [SerializeField]
    private GameObject _stack;

    [SerializeField]
    private CameraTargetController _cameraController;

    public string URL;
    private CourseDetails[] _courses;

    private List<Stack> _stacks = new List<Stack>();
    

    public void Awake()
    {
        GetData();
    }

    public void GetData()
    {
        StartCoroutine(FetchData());
    }
    public IEnumerator FetchData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
            }
            else
            {
                _courses = Newtonsoft.Json.JsonConvert.DeserializeObject<CourseDetails[]>(request.downloadHandler.text);

                // To solve weird bug in last index's grade
                _courses[_courses.Length - 1].grade = _courses[_courses.Length - 2].grade;
                SetupStacks();
            }
        }
    }

    private void SetupStacks()
    {
        var __uniqueStacks = new Dictionary<string, List<CourseDetails>>();
        foreach (var __course in _courses)
        {
            if (!__uniqueStacks.ContainsKey(__course.grade))
            {
                __uniqueStacks.Add(__course.grade, new List<CourseDetails>());
            }
            __uniqueStacks[__course.grade].Add(__course);
        }

        var __index = 0;
        foreach (var __uniqueStack in __uniqueStacks)
        {

            var __stackObject = Instantiate(_stack,
                new Vector3(transform.position.x, transform.position.y, transform.position.z + (__index * 5)),
                Quaternion.identity);

            var __stack = __stackObject.GetComponent<Stack>();
            __stack.Setup(__index, __uniqueStack.Key, __uniqueStack.Value);
            _stacks.Add(__stack);
            __index++;
        }

        _cameraController.Setup(_stacks);
    }

    public void TestMyStack()
    {
        _stacks.ForEach(stack =>
        {
            stack.GetLevels().ForEach(level =>
            {
                level.GetBlocks().ForEach(block =>
                {
                    block.GetComponent<Rigidbody>().isKinematic = false;
                    if (block.GetCourse().mastery == 0)
                    {
                        block.gameObject.SetActive(false);
                    }

                    
                });
             
            });
        });
    }

    public List<Stack> GetStacks()
    {
        return _stacks;
    }
}
