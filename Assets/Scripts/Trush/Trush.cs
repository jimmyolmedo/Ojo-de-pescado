using UnityEngine;

public class Trush : MonoBehaviour
{
    //variables
    [SerializeField] float speed;
    Vector2 target;

    //methods
    private void Start()
    {
        target = Planet.instance.transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void ChangeTarget(Vector2 _target)
    {
        target = _target;
    }
}
