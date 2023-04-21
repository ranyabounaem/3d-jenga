[System.Serializable]
public class CourseDetails
{
    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
}

[System.Serializable]
public class Courses
{
    public CourseDetails[] coursedetails;
}
