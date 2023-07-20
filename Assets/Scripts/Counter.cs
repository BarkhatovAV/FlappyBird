using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _text;
    
    private int _count;

    public void Increment()
    {
        _count++;
        _text.text = _count.ToString();
    }
}
